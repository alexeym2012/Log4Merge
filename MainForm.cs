using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log4Merge.Domain;
using Newtonsoft.Json;

namespace Log4Merge
{
    public partial class FormMainForm : Form
    {
        private BindingList<LogEntry> _logEntries = new BindingList<LogEntry>();
        private string _filterText = string.Empty;

        private BindingList<HighlightEntry> _highlightEntries = new BindingList<HighlightEntry>();

        /// <summary>File paths passed on startup; loaded asynchronously in Shown.</summary>
        private string[] _pendingFileArgs;

        public FormMainForm(string[] args)
        {
            InitializeComponent();

            this.Text = $"{this.Text} {GetAssemblyVersion()}";

            if (args != null && args.Length > 0)
                _pendingFileArgs = args;
        }

        private void FormMainForm_Shown(object sender, EventArgs e)
        {
            if (_pendingFileArgs == null || _pendingFileArgs.Length == 0)
                return;
            var files = _pendingFileArgs;
            _pendingFileArgs = null;
            var progress = new Progress<LoadProgress>(p =>
            {
                toolStripStatusLabelLines.Text = $"Loading {p.CurrentFileIndex} of {p.TotalFiles} files...";
                toolStripProgressBar.Value = p.CurrentFileIndex;
            });
            _ = LoadLogFilesAsync(files, clearExisting: true, progress, CancellationToken.None);
        }

        private struct LoadProgress
        {
            public int CurrentFileIndex { get; set; }
            public int TotalFiles { get; set; }
            public string CurrentFileName { get; set; }
        }

        /// <summary>Parses a single log file and returns entries (thread-safe, no shared state).</summary>
        private static List<LogEntry> ParseLogFile(string logFileName)
        {
            var logLines = File.ReadAllLines(logFileName, Encoding.UTF8);
            var entries = new List<LogEntry>();
            LogEntry lastEntry = null;

            for (var i = 0; i < logLines.Length; i++)
            {
                var logLine = logLines[i];
                if (logLine.Length < 23)
                {
                    lastEntry?.AppendMessage(logLine);
                }
                else
                {
                    var timeString = logLine.Substring(0, 23);
                    var message = logLine.Substring(23);

                    if (DateTime.TryParseExact(timeString, @"yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture,
                            DateTimeStyles.AssumeUniversal, out var timeStamp))
                    {
                        var entry = new LogEntry(logFileName, i + 1, timeStamp.ToUniversalTime(), message);
                        entries.Add(entry);
                        lastEntry = entry;
                    }
                    else
                    {
                        lastEntry?.AppendMessage(logLine);
                    }
                }
            }

            return entries;
        }

        private void AppendLogsFromTheFile(string logFileName)
        {
            var entries = ParseLogFile(logFileName);
            foreach (var entry in entries)
                _logEntries.Add(entry);
        }

        private async Task LoadLogFilesAsync(string[] fileNames, bool clearExisting, IProgress<LoadProgress> progress, CancellationToken cancellationToken)
        {
            var totalFiles = fileNames?.Length ?? 0;
            if (totalFiles == 0)
                return;

            toolStripStatusLabelLines.Text = "Loading 1 of " + totalFiles + " files...";
            toolStripProgressBar.Visible = true;
            toolStripProgressBar.Style = ProgressBarStyle.Continuous;
            toolStripProgressBar.Maximum = totalFiles;
            toolStripProgressBar.Value = 0;
            openLog4netLogsToolStripMenuItem.Enabled = false;
            appendLog4netLogsToolStripMenuItem.Enabled = false;

            try
            {
                List<LogEntry> collected;
                try
                {
                    collected = await Task.Run(() =>
                    {
                        var list = new List<LogEntry>();
                        for (var i = 0; i < fileNames.Length; i++)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            var file = fileNames[i];
                            var entries = ParseLogFile(file);
                            list.AddRange(entries);
                            progress?.Report(new LoadProgress
                            {
                                CurrentFileIndex = i + 1,
                                TotalFiles = totalFiles,
                                CurrentFileName = file
                            });
                        }
                        return list;
                    }, cancellationToken).ConfigureAwait(true);
                }
                catch (OperationCanceledException)
                {
                    return;
                }

                if (clearExisting)
                    _logEntries.Clear();
                foreach (var entry in collected)
                    _logEntries.Add(entry);
                _logEntries = new BindingList<LogEntry>(_logEntries.Distinct().ToList().OrderBy(l => l.TimeStamp).ToList());
                BindLogViewerDataGrip();
            }
            finally
            {
                toolStripProgressBar.Visible = false;
                openLog4netLogsToolStripMenuItem.Enabled = true;
                appendLog4netLogsToolStripMenuItem.Enabled = true;
                BindToolStrip();
            }
        }

        private void BindLogViewerDataGrip()
        {
            gridLogsViewer.DataSource = _logEntries;
            saveAsToolStripMenuItem.Enabled = saveAsLogToolStripMenuItem.Enabled = saveFilteredRowsAsLog4NetToolStripMenuItem.Enabled = saveFilteredRowsAsLog4NetContextMenuItem.Enabled = _logEntries.Count > 0;
            if (_highlightEntries.Count > 0)
            {
                for (var i = 0; i < _logEntries.Count; i++)
                {
                    var logEntry = _logEntries[i];
                    foreach (var highlightEntry in this._highlightEntries)
                    {
                        var message = logEntry.Message;
                        if (highlightEntry.IsMatch(message))
                        {
                            gridLogsViewer.Rows[i].DefaultCellStyle.BackColor = highlightEntry.BackColor;
                            gridLogsViewer.Rows[i].DefaultCellStyle.ForeColor = highlightEntry.ForeColor;
                        }
                    }
                }
            }
            ApplyFilter();
            BindToolStrip();
        }

        private IEnumerable<LogEntry> GetVisibleLogEntries()
        {
            foreach (DataGridViewRow row in gridLogsViewer.Rows)
            {
                if (!row.Visible) continue;
                if (row.DataBoundItem is LogEntry entry)
                    yield return entry;
            }
        }

        private void BindToolStrip()
        {
            var total = gridLogsViewer.Rows.Count;
            bool isFiltered = !string.IsNullOrWhiteSpace(_filterText) || !AreAllLevelsChecked() ||
                              (dtpFrom.Checked || dtpTo.Checked);
            int visibleCount;
            if (isFiltered)
            {
                visibleCount = gridLogsViewer.Rows.Cast<DataGridViewRow>().Count(r => r.Visible);
                toolStripStatusLabelLines.Text = $"Lines: {visibleCount} / {total} (filtered)";
            }
            else
            {
                visibleCount = total;
                toolStripStatusLabelLines.Text = $"Lines: {total}";
            }
            saveFilteredRowsAsLog4NetToolStripMenuItem.Enabled = saveFilteredRowsAsLog4NetContextMenuItem.Enabled = visibleCount > 0;
        }

        private bool IsLevelVisible(string logLevel)
        {
            switch (logLevel)
            {
                case "ERROR": return chkLevelError.Checked;
                case "FATAL": return chkLevelFatal.Checked;
                case "WARN":  return chkLevelWarn.Checked;
                case "INFO":  return chkLevelInfo.Checked;
                case "DEBUG": return chkLevelDebug.Checked;
                case "TRACE": return chkLevelTrace.Checked;
                default:      return chkLevelOther.Checked;
            }
        }

        private bool AreAllLevelsChecked() =>
            chkLevelError.Checked && chkLevelFatal.Checked && chkLevelWarn.Checked &&
            chkLevelInfo.Checked  && chkLevelDebug.Checked && chkLevelTrace.Checked &&
            chkLevelOther.Checked;

        private void gridLogsViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gridLogsViewer.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in gridLogsViewer.SelectedRows)
                {
                    gridLogsViewer.Rows.RemoveAt(gridLogsViewer.Rows.IndexOf(selectedRow));
                }

                BindToolStrip();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                settingsForm.Owner = this;
                settingsForm.ShowDialog();
            }
        }

        private void highlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hightPreferencesDialog = new HighlightPreferencesDialog(this._highlightEntries);
            if (hightPreferencesDialog.ShowDialog() == DialogResult.OK)
            {
                _logEntries = new BindingList<LogEntry>(_logEntries.Distinct().ToList().OrderBy(l => l.TimeStamp).ToList());
                BindLogViewerDataGrip();
            }
        }

        private async void openLog4netLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await OpenFilesDialogAsync(clearExisting: true);
        }

        private async void appendLog4netLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await OpenFilesDialogAsync(clearExisting: false);
        }

        private async Task OpenFilesDialogAsync(bool clearExisting)
        {
            var d = new OpenFileDialog();
            d.Multiselect = true;
            d.InitialDirectory = @"C:\tmp\logs-test\sideGall";
            if (d.ShowDialog() != DialogResult.OK)
                return;

            var progress = new Progress<LoadProgress>(p =>
            {
                toolStripStatusLabelLines.Text = $"Loading {p.CurrentFileIndex} of {p.TotalFiles} files...";
                toolStripProgressBar.Value = p.CurrentFileIndex;
            });
            await LoadLogFilesAsync(d.FileNames, clearExisting, progress, CancellationToken.None);
        }

        private void contributeMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/alexeym2012/Log4Merge");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }

        private string GetAssemblyVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void menuRemoveUnhighlighted_Click(object sender, EventArgs e)
        {
            var items = new List<LogEntry>();

            if (_highlightEntries.Count > 0)
            {
                foreach (var logEntry in this._logEntries)
                {
                    foreach (var highlightEntry in this._highlightEntries)
                    {
                        var message = logEntry.Message;
                        if (highlightEntry.IsMatch(message))
                        {
                            items.Add(logEntry);
                        }
                    }
                }
            }

            _logEntries = new BindingList<LogEntry>(items.Distinct().ToList());
            BindLogViewerDataGrip();
        }

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selectedRow in gridLogsViewer.SelectedRows)
            {
                gridLogsViewer.Rows.RemoveAt(gridLogsViewer.Rows.IndexOf(selectedRow));
            }

            BindToolStrip();
        }

        private void removeUnselectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridLogsViewer.SelectedRows.Count > 0)
            {
                var items = new List<LogEntry>();

                foreach (DataGridViewRow selectedRow in gridLogsViewer.SelectedRows)
                {
                    items.Add(selectedRow.DataBoundItem as LogEntry);
                }

                _logEntries = new BindingList<LogEntry>(items.Distinct().ToList());
                BindLogViewerDataGrip();

            }

        }

        private void removeHighlightedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = _logEntries.ToList();

            if (_highlightEntries.Count > 0)
            {
                foreach (var logEntry in this._logEntries)
                {
                    foreach (var highlightEntry in this._highlightEntries)
                    {
                        var message = logEntry.Message;
                        if (highlightEntry.IsMatch(message))
                        {
                            items.Remove(logEntry);
                        }
                    }
                }
            }

            _logEntries = new BindingList<LogEntry>(items.Distinct().ToList());
            BindLogViewerDataGrip();
        }

        private void gridLogsViewer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex == 6)
            {
                //_logEntries[e.RowIndex].ShortMessage = _logEntries[e.RowIndex].Message;
            }
        }

        private void gridLogsViewer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex == 6)
            {

                _logEntries[e.RowIndex].ShortMessage = _logEntries[e.RowIndex].Message.Substring(0, Math.Min(_logEntries[e.RowIndex].ShortMessage.Length + 20, _logEntries[e.RowIndex].Message.Length));
            }
        }

        private void toolStripMenuRemoveText_Click(object sender, EventArgs e)
        {

            var textToRemove = Microsoft.VisualBasic.Interaction.InputBox("Remove rows which contain the text:\nCan be split by '|'",
                "Remove rows",
                "",
                0,
                0);

            if (string.IsNullOrWhiteSpace(textToRemove) == false)
            {
                var logEntries = _logEntries.ToList();
                var filteredEntries = new List<LogEntry>();
                var removePatterns = new HashSet<string>(textToRemove.Trim().ToLower().Split('|'));

                foreach (var logEntry in logEntries)
                {
                    bool shouldRemove = false;
                    foreach (var removePattern in removePatterns)
                    {
                        if (logEntry.Message.ToLower().Contains(removePattern.Trim()))
                        {
                            shouldRemove = true;
                            break;
                        }
                    }

                    if (shouldRemove == false)
                    {
                        filteredEntries.Add(logEntry);
                    }
                }

                _logEntries = new BindingList<LogEntry>(filteredEntries.Distinct().ToList());
                BindLogViewerDataGrip();
            }
        }

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            foreach (DataGridViewCell selectedCell in gridLogsViewer.SelectedCells.OfType<DataGridViewCell>().OrderBy(r => r.RowIndex))
            {
                if (selectedCell.ColumnIndex == 6)
                {
                    sb.Append(_logEntries[selectedCell.RowIndex].Message);
                }
                else
                {
                    sb.Append(selectedCell.Value);
                }

                sb.Append("\n");
            }

            Clipboard.SetText(sb.ToString());
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "All files|*.*";
            saveFileDialog.Title = "Save Logs To File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    
                    using (var writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var l in _logEntries)
                            writer.WriteLine($"{l.TimeStampAsText}|{l.SourceFileName}, Line:{l.LineNumber}|{l.Message}");
                    }
                    
                    //File.WriteAllText(saveFileDialog.FileName, string.Join("\n", this._logEntries.Select(l => $"{l.TimeStampAsText}|{l.SourceFileName}, Line:{l.LineNumber}|{l.Message}")));
                }
            }
        }

        private void saveAsLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Log4New|*.log";
            saveFileDialog.Title = "Save Logs To File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    using (var writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var l in _logEntries)
                            writer.WriteLine($"{l.TimeStampAsText} {l.Message}");
                    }

                    //File.WriteAllText(saveFileDialog.FileName, string.Join("\n", this._logEntries.Select(l => $"{l.TimeStampAsText} {l.Message}")));
                }
            }
        }

        private void saveFilteredRowsAsLog4NetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var visibleEntries = GetVisibleLogEntries().ToList();
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Log4New|*.log";
            saveFileDialog.Title = "Save Logs To File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    using (var writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var l in visibleEntries)
                            writer.WriteLine($"{l.TimeStampAsText} {l.Message}");
                    }
                }
            }
        }

        private void toolStripMenuItemRemoveBefore_Click(object sender, EventArgs e)
        {
            if (gridLogsViewer.SelectedRows.Count > 0)
            {
                var selectedLogEntry = gridLogsViewer.SelectedRows[0].DataBoundItem as LogEntry;

                _logEntries = new BindingList<LogEntry>(_logEntries.Where(l => l.TimeStamp >= selectedLogEntry.TimeStamp).Distinct().OrderBy(l => l.TimeStamp).ToList());
                BindLogViewerDataGrip();
            }
        }

        private void toolStripMenuItemRemoveAfter_Click(object sender, EventArgs e)
        {
            if (gridLogsViewer.SelectedRows.Count > 0)
            {
                var selectedLogEntry = gridLogsViewer.SelectedRows[0].DataBoundItem as LogEntry;

                _logEntries = new BindingList<LogEntry>(_logEntries.Where(l => l.TimeStamp <= selectedLogEntry.TimeStamp).Distinct().OrderBy(l => l.TimeStamp).ToList());
                BindLogViewerDataGrip();
            }

        }

        private void ApplyFilter()
        {
            // DataGridView throws if you hide the currently active row, so clear it first.
            gridLogsViewer.CurrentCell = null;

            var patterns = string.IsNullOrWhiteSpace(_filterText)
                ? new string[0]
                : _filterText.ToLower().Split('|')
                    .Select(p => p.Trim()).Where(p => p.Length > 0).ToArray();

            bool hasTextFilter  = patterns.Length > 0;
            bool hasLevelFilter = !AreAllLevelsChecked();
            bool hasTimeRangeFilter = dtpFrom.Checked || dtpTo.Checked;

            DateTime? fromUtc = dtpFrom.Checked ? (DateTime?)dtpFrom.Value.ToUniversalTime() : null;
            DateTime? toUtc   = dtpTo.Checked   ? (DateTime?)dtpTo.Value.ToUniversalTime()   : null;

            if (!hasTextFilter && !hasLevelFilter && !hasTimeRangeFilter)
            {
                foreach (DataGridViewRow row in gridLogsViewer.Rows)
                    row.Visible = true;
                return;
            }

            foreach (DataGridViewRow row in gridLogsViewer.Rows)
            {
                var entry = row.DataBoundItem as LogEntry;
                if (entry == null) { row.Visible = true; continue; }

                bool textMatch  = !hasTextFilter  || patterns.Any(p => entry.Message.ToLower().Contains(p));
                bool levelMatch = !hasLevelFilter || IsLevelVisible(entry.LogLevel);
                bool timeInRange = (!fromUtc.HasValue || entry.TimeStamp >= fromUtc.Value) &&
                                  (!toUtc.HasValue   || entry.TimeStamp <= toUtc.Value);
                row.Visible = textMatch && levelMatch && timeInRange;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            _filterText = filterTextBox.Text.Trim();
            ApplyFilter();
            BindToolStrip();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            filterDebounceTimer.Stop();
            filterTextBox.Clear();
            _filterText = string.Empty;
            ApplyFilter();
            BindToolStrip();
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            filterDebounceTimer.Stop();
            filterDebounceTimer.Start();
        }

        private void filterDebounceTimer_Tick(object sender, EventArgs e)
        {
            filterDebounceTimer.Stop();
            _filterText = filterTextBox.Text.Trim();
            ApplyFilter();
            BindToolStrip();
        }

        private void filterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFilter_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnClearFilter_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void levelButton_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
            BindToolStrip();
        }

        private void btnClearTimeRange_Click(object sender, EventArgs e)
        {
            dtpFrom.Checked = false;
            dtpTo.Checked = false;
            ApplyFilter();
            BindToolStrip();
        }

        private void dtpTimeRange_ValueChanged(object sender, EventArgs e)
        {
            ApplyFilter();
            BindToolStrip();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                filterTextBox.Focus();
                filterTextBox.SelectAll();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
