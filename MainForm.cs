using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log4Merge.Domain.Models;
using Log4Merge.Domain.Services;
using Log4Merge.Domain.Settings;

namespace Log4Merge
{
    public partial class FormMainForm : Form
    {
        private static readonly ILogParserSettings s_settings = new AppLogParserSettings();
        private readonly ILogParser _logParser = new LogParser(s_settings);
        private readonly ISessionService _sessionService = new SessionService();
        private readonly IHighlightProfileService _highlightService = new HighlightProfileService();
        private readonly LogRepository _repository = new LogRepository();

        private string _filterText = string.Empty;
        private BindingList<HighlightEntry> _highlightEntries = new BindingList<HighlightEntry>();

        /// <summary>File paths passed on startup; loaded asynchronously in Shown.</summary>
        private string[] _pendingFileArgs;

        private readonly List<string> _loadedFiles = new List<string>();
        private readonly Dictionary<string, long> _tailFilePositions = new Dictionary<string, long>();

        public FormMainForm(string[] args)
        {
            LogEntry.Settings = s_settings;
            InitializeComponent();
            SetupGridColumns();

            this.AllowDrop = true;
            gridLogsViewer.AllowDrop = true;
            this.DragEnter += FormMainForm_DragEnter;
            this.DragDrop  += FormMainForm_DragDrop;
            gridLogsViewer.DragEnter += FormMainForm_DragEnter;
            gridLogsViewer.DragDrop  += FormMainForm_DragDrop;

            // Make level toggle buttons visually distinct: blue = level is active/included.
            // CheckBox.Appearance.Button checked vs unchecked is subtle on modern Windows themes,
            // so FlatStyle.Flat + CheckedBackColor gives a clear on/off indication.
            var levelCheckedColor = System.Drawing.Color.FromArgb(173, 214, 255);
            foreach (var cb in new[] { chkLevelError, chkLevelFatal, chkLevelWarn,
                                       chkLevelInfo,  chkLevelDebug, chkLevelTrace, chkLevelOther })
            {
                cb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                cb.FlatAppearance.CheckedBackColor = levelCheckedColor;
            }

            this.Text = $"{this.Text} {GetAssemblyVersion()}";

            if (args != null && args.Length > 0)
                _pendingFileArgs = args;
        }

        private void SetupGridColumns()
        {
            gridLogsViewer.AutoGenerateColumns = false;
            gridLogsViewer.Columns.Clear();

            columnTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnSourceFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnLogLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnTimeInvisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnMessageInvisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            columnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();

            columnTimeStamp.DataPropertyName = "TimeStampAsText";
            columnTimeStamp.FillWeight = 130F;
            columnTimeStamp.HeaderText = "Timestamp";
            columnTimeStamp.MinimumWidth = 6;
            columnTimeStamp.Name = "columnTimeStamp";
            columnTimeStamp.ReadOnly = true;
            columnTimeStamp.Width = 130;

            columnSourceFileName.DataPropertyName = "SourceFileName";
            columnSourceFileName.HeaderText = "Log File";
            columnSourceFileName.MinimumWidth = 6;
            columnSourceFileName.Name = "columnSourceFileName";
            columnSourceFileName.ReadOnly = true;
            columnSourceFileName.Width = 125;

            columnLineNumber.DataPropertyName = "LineNumber";
            columnLineNumber.FillWeight = 50F;
            columnLineNumber.HeaderText = "Line";
            columnLineNumber.MinimumWidth = 6;
            columnLineNumber.Name = "columnLineNumber";
            columnLineNumber.ReadOnly = true;
            columnLineNumber.Width = 50;

            columnLogLevel.DataPropertyName = "LogLevel";
            columnLogLevel.HeaderText = "Level";
            columnLogLevel.MinimumWidth = 6;
            columnLogLevel.Name = "columnLogLevel";
            columnLogLevel.ReadOnly = true;
            columnLogLevel.Width = 55;

            columnTimeInvisible.DataPropertyName = "TimeStamp";
            columnTimeInvisible.FillWeight = 2F;
            columnTimeInvisible.HeaderText = "columnTimeInvisible";
            columnTimeInvisible.MinimumWidth = 2;
            columnTimeInvisible.Name = "columnTimeInvisible";
            columnTimeInvisible.ReadOnly = true;
            columnTimeInvisible.Visible = false;
            columnTimeInvisible.Width = 2;

            columnMessageInvisible.DataPropertyName = "Message";
            columnMessageInvisible.HeaderText = "columnMessageInvisible";
            columnMessageInvisible.MinimumWidth = 2;
            columnMessageInvisible.Name = "columnMessageInvisible";
            columnMessageInvisible.ReadOnly = true;
            columnMessageInvisible.Visible = false;
            columnMessageInvisible.Width = 2;

            columnMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            columnMessage.DataPropertyName = "ShortMessage";
            columnMessage.HeaderText = "Log Message";
            columnMessage.MaxInputLength = 200000000;
            columnMessage.MinimumWidth = 6;
            columnMessage.Name = "columnMessage";
            columnMessage.ReadOnly = true;

            gridLogsViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                columnTimeStamp,
                columnSourceFileName,
                columnLineNumber,
                columnLogLevel,
                columnTimeInvisible,
                columnMessageInvisible,
                columnMessage
            });
        }

        private void LoadHighlightProfiles()
        {
            var loaded = _highlightService.Load();
            _highlightEntries.Clear();
            foreach (var entry in loaded)
                _highlightEntries.Add(entry);
        }

        private void SaveHighlightProfiles()
        {
            _highlightService.Save(_highlightEntries);
        }

        private void SaveSession()
        {
            _sessionService.Save(_loadedFiles);
        }

        private async Task TryRestoreSessionAsync()
        {
            var saved = _sessionService.Load();
            if (saved == null || saved.Length == 0) return;

            var existing = saved.Where(File.Exists).ToArray();
            if (existing.Length == 0) return;

            var names = string.Join("\n", existing.Take(5).Select(Path.GetFileName));
            var more = existing.Length > 5 ? $"\n… and {existing.Length - 5} more" : string.Empty;
            var answer = MessageBox.Show(
                $"Restore last session? ({existing.Length} file{(existing.Length == 1 ? "" : "s")})\n\n{names}{more}",
                "Session Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (answer != DialogResult.Yes) return;

            var progress = new Progress<LoadProgress>(p =>
            {
                if (IsDisposed || !IsHandleCreated || toolStripStatusLabelLines == null || toolStripProgressBar == null)
                    return;
                toolStripStatusLabelLines.Text = $"Loading {p.CurrentFileIndex} of {p.TotalFiles} files...";
                toolStripProgressBar.Value = p.CurrentFileIndex;
            });
            await LoadLogFilesAsync(existing, clearExisting: true, progress, CancellationToken.None);
        }

        private void FormMainForm_Shown(object sender, EventArgs e)
        {
            LoadHighlightProfiles();

            if (_pendingFileArgs == null || _pendingFileArgs.Length == 0)
            {
                _ = TryRestoreSessionAsync();
                return;
            }
            var files = _pendingFileArgs;
            _pendingFileArgs = null;
            var progress = new Progress<LoadProgress>(p =>
            {
                if (IsDisposed || !IsHandleCreated || toolStripStatusLabelLines == null || toolStripProgressBar == null)
                    return;
                toolStripStatusLabelLines.Text = $"Loading {p.CurrentFileIndex} of {p.TotalFiles} files...";
                toolStripProgressBar.Value = p.CurrentFileIndex;
            });
            _ = LoadLogFilesAsync(files, clearExisting: true, progress, CancellationToken.None);
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
                List<string> failedPaths;
                try
                {
                    (collected, failedPaths) = await Task.Run(() =>
                    {
                        var list   = new List<LogEntry>();
                        var failed = new List<string>();
                        for (var i = 0; i < fileNames.Length; i++)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            var file = fileNames[i];
                            try
                            {
                                list.AddRange(_logParser.ParseLogFile(file));
                            }
                            catch (Exception)
                            {
                                failed.Add(file);
                            }
                            progress?.Report(new LoadProgress
                            {
                                CurrentFileIndex = i + 1,
                                TotalFiles = totalFiles,
                                CurrentFileName = file
                            });
                        }
                        return (list, failed);
                    }, cancellationToken).ConfigureAwait(true);
                }
                catch (OperationCanceledException)
                {
                    return;
                }

                if (clearExisting)
                {
                    _repository.Clear();
                    _loadedFiles.Clear();
                }
                _loadedFiles.AddRange(fileNames.Except(failedPaths));
                _repository.AddRange(collected);
                _repository.DeduplicateAndSort();
                BindLogViewerDataGrip();

                if (chkTailMode.Checked)
                    InitializeTailPositions();

                SaveSession();

                if (failedPaths.Count > 0)
                    MessageBox.Show(
                        "The following files could not be parsed:\n\n" +
                        string.Join("\n", failedPaths.Select(Path.GetFileName)),
                        "Parse Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            gridLogsViewer.DataSource = _repository.Entries;
            saveAsToolStripMenuItem.Enabled = saveAsLogToolStripMenuItem.Enabled = saveFilteredRowsAsLog4NetToolStripMenuItem.Enabled = saveFilteredRowsAsLog4NetContextMenuItem.Enabled = _repository.Entries.Count > 0;
            if (_highlightEntries.Count > 0)
            {
                for (var i = 0; i < _repository.Entries.Count; i++)
                {
                    var logEntry = _repository.Entries[i];
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
            var tailPrefix = chkTailMode.Checked ? "⏩ Tail: ON  |  " : string.Empty;
            int visibleCount;
            if (isFiltered)
            {
                visibleCount = gridLogsViewer.Rows.Cast<DataGridViewRow>().Count(r => r.Visible);
                toolStripStatusLabelLines.Text = $"{tailPrefix}Lines: {visibleCount} / {total} (filtered)";
            }
            else
            {
                visibleCount = total;
                toolStripStatusLabelLines.Text = $"{tailPrefix}Lines: {total}";
            }
            saveFilteredRowsAsLog4NetToolStripMenuItem.Enabled = saveFilteredRowsAsLog4NetContextMenuItem.Enabled = visibleCount > 0;

            // Highlighted
            if (_highlightEntries.Count == 0)
                toolStripStatusLabelHighlighted.Text = "Highlighted: —";
            else
            {
                var highlightedCount = GetVisibleLogEntries().Count(entry => _highlightEntries.Any(he => he.IsMatch(entry.Message)));
                toolStripStatusLabelHighlighted.Text = $"Highlighted: {highlightedCount:N0} / {visibleCount:N0}";
            }

            // Time span
            if (_repository.Entries.Count == 0)
                toolStripStatusLabelSpan.Text = "Span: —";
            else
            {
                var minTs = _repository.Entries.Min(e => e.TimeStamp);
                var maxTs = _repository.Entries.Max(e => e.TimeStamp);
                const string fmt = "yyyy-MM-dd HH:mm";
                toolStripStatusLabelSpan.Text = $"Span: {minTs.ToString(fmt)} — {maxTs.ToString(fmt)}";
            }

            // Source files
            var fileCount = _repository.Entries.Select(e => e.SourceFileName).Distinct().Count();
            toolStripStatusLabelFiles.Text = $"Files: {fileCount:N0}";
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
            var prevVisibleLen = Properties.Settings.Default.GridVisibleLineLength;
            using (var settingsForm = new SettingsForm())
            {
                settingsForm.Owner = this;
                var result = settingsForm.ShowDialog();
                if (result == DialogResult.OK && Properties.Settings.Default.GridVisibleLineLength != prevVisibleLen)
                {
                    _repository.UpdateShortMessages(Properties.Settings.Default.GridVisibleLineLength);
                    gridLogsViewer.Refresh();
                }
            }
        }

        private void highlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hightPreferencesDialog = new HighlightPreferencesDialog(this._highlightEntries);
            if (hightPreferencesDialog.ShowDialog() == DialogResult.OK)
            {
                SaveHighlightProfiles();
                _repository.DeduplicateAndSort();
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
            var lastDir = Properties.Settings.Default.LastOpenDirectory;
            d.InitialDirectory = !string.IsNullOrEmpty(lastDir) && Directory.Exists(lastDir)
                ? lastDir
                : string.Empty;
            if (d.ShowDialog() != DialogResult.OK)
                return;

            Properties.Settings.Default.LastOpenDirectory = Path.GetDirectoryName(d.FileNames[0]);
            Properties.Settings.Default.Save();

            var progress = new Progress<LoadProgress>(p =>
            {
                if (IsDisposed || !IsHandleCreated || toolStripStatusLabelLines == null || toolStripProgressBar == null)
                    return;
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
            _repository.KeepHighlighted(_highlightEntries);
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
                var entriesToKeep = gridLogsViewer.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Select(r => r.DataBoundItem as LogEntry)
                    .Where(entry => entry != null)
                    .ToList();
                _repository.KeepEntries(entriesToKeep);
                BindLogViewerDataGrip();
            }
        }

        private void removeHighlightedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _repository.RemoveHighlighted(_highlightEntries);
            BindLogViewerDataGrip();
        }

        private void gridLogsViewer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex == 6)
            {
                //_repository.Entries[e.RowIndex].ShortMessage = _repository.Entries[e.RowIndex].Message;
            }
        }

        private void gridLogsViewer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0 && e.ColumnIndex == 6)
            {
                var entry = _repository.Entries[e.RowIndex];
                entry.ShortMessage = entry.Message.Substring(0, Math.Min(entry.ShortMessage.Length + 20, entry.Message.Length));
            }
        }

        private void toolStripMenuRemoveText_Click(object sender, EventArgs e)
        {
            var textToRemove = Microsoft.VisualBasic.Interaction.InputBox("Remove rows which contain the text:\nCan be split by '|'",
                "Remove rows",
                "",
                0,
                0);

            if (!string.IsNullOrWhiteSpace(textToRemove))
            {
                var patterns = textToRemove.Trim().Split('|')
                    .Select(p => p.Trim())
                    .Where(p => p.Length > 0);
                _repository.RemoveByText(patterns);
                BindLogViewerDataGrip();
            }
        }

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            foreach (DataGridViewCell selectedCell in gridLogsViewer.SelectedCells.OfType<DataGridViewCell>().OrderBy(r => r.RowIndex))
            {
                if (selectedCell.ColumnIndex == 6)
                    sb.Append(_repository.Entries[selectedCell.RowIndex].Message);
                else
                    sb.Append(selectedCell.Value);

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
                        foreach (var l in _repository.Entries)
                            writer.WriteLine($"{l.TimeStampAsText}|{l.SourceFileName}, Line:{l.LineNumber}|{l.Message}");
                    }
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
                        foreach (var l in _repository.Entries)
                            writer.WriteLine($"{l.TimeStampAsText} {l.Message}");
                    }
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
                _repository.RemoveBefore(selectedLogEntry.TimeStamp);
                BindLogViewerDataGrip();
            }
        }

        private void toolStripMenuItemRemoveAfter_Click(object sender, EventArgs e)
        {
            if (gridLogsViewer.SelectedRows.Count > 0)
            {
                var selectedLogEntry = gridLogsViewer.SelectedRows[0].DataBoundItem as LogEntry;
                _repository.RemoveAfter(selectedLogEntry.TimeStamp);
                BindLogViewerDataGrip();
            }
        }

        private void ApplyFilter()
        {
            // DataGridView throws if you hide the currently active row, so clear it first.
            gridLogsViewer.CurrentCell = null;

            var criteria = BuildFilterCriteria();
            bool hasAnyFilter = !string.IsNullOrEmpty(criteria.FilterText) ||
                                criteria.EnabledLevels != null ||
                                criteria.FromUtc.HasValue || criteria.ToUtc.HasValue;

            if (!hasAnyFilter)
            {
                foreach (DataGridViewRow row in gridLogsViewer.Rows)
                    row.Visible = true;
                UpdateFilterButtonText();
                return;
            }

            foreach (DataGridViewRow row in gridLogsViewer.Rows)
            {
                var entry = row.DataBoundItem as LogEntry;
                row.Visible = entry == null || LogFilter.IsMatch(entry, criteria);
            }
            UpdateFilterButtonText();
        }

        private FilterCriteria BuildFilterCriteria()
        {
            HashSet<string> enabledLevels = null;
            if (!AreAllLevelsChecked())
            {
                enabledLevels = new HashSet<string>();
                if (chkLevelError.Checked) enabledLevels.Add("ERROR");
                if (chkLevelFatal.Checked) enabledLevels.Add("FATAL");
                if (chkLevelWarn.Checked)  enabledLevels.Add("WARN");
                if (chkLevelInfo.Checked)  enabledLevels.Add("INFO");
                if (chkLevelDebug.Checked) enabledLevels.Add("DEBUG");
                if (chkLevelTrace.Checked) enabledLevels.Add("TRACE");
                if (chkLevelOther.Checked) enabledLevels.Add(""); // "" = unrecognised level ("other")
            }
            return new FilterCriteria
            {
                FilterText = _filterText,
                EnabledLevels = enabledLevels,
                FromUtc = dtpFrom.Checked ? (DateTime?)dtpFrom.Value.ToUniversalTime() : null,
                ToUtc   = dtpTo.Checked   ? (DateTime?)dtpTo.Value.ToUniversalTime()   : null
            };
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

        private void RepositionFilterPanel()
        {
            int x = this.ClientSize.Width - filterOverlayPanel.Width - 4;
            int y = menuStrip1.Bottom + 4;
            filterOverlayPanel.Location = new System.Drawing.Point(x, y);
            filterOverlayPanel.BringToFront();
        }

        private void filtersToggleMenuItem_Click(object sender, EventArgs e)
        {
            filterOverlayPanel.Visible = !filterOverlayPanel.Visible;
            if (filterOverlayPanel.Visible)
            {
                RepositionFilterPanel();
                filterTextBox.Focus();
                filterTextBox.SelectAll();
            }
        }

        private void btnCloseFilter_Click(object sender, EventArgs e)
        {
            filterOverlayPanel.Visible = false;
        }

        private void FormMainForm_Resize(object sender, EventArgs e)
        {
            if (filterOverlayPanel.Visible)
                RepositionFilterPanel();
        }

        private void UpdateFilterButtonText()
        {
            int active = 0;
            if (!string.IsNullOrEmpty(_filterText)) active++;
            if (!AreAllLevelsChecked()) active++;
            if (dtpFrom.Checked || dtpTo.Checked) active++;
            filtersToggleMenuItem.Text = active > 0 ? $"Filters ({active}) \u25be" : "Filters \u25be";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                if (!filterOverlayPanel.Visible)
                {
                    filterOverlayPanel.Visible = true;
                    RepositionFilterPanel();
                }
                filterTextBox.Focus();
                filterTextBox.SelectAll();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void chkTailMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTailMode.Checked)
            {
                if (_loadedFiles.Count == 0)
                {
                    chkTailMode.Checked = false;
                    MessageBox.Show("Open log files first before enabling Tail Mode.", "Tail Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                InitializeTailPositions();
                tailTimer.Start();
                BindToolStrip();
            }
            else
            {
                tailTimer.Stop();
                _tailFilePositions.Clear();
                BindToolStrip();
            }
        }

        private void InitializeTailPositions()
        {
            _tailFilePositions.Clear();
            foreach (var file in _loadedFiles)
            {
                try { _tailFilePositions[file] = new FileInfo(file).Length; }
                catch { _tailFilePositions[file] = 0; }
            }
        }

        private void tailTimer_Tick(object sender, EventArgs e)
        {
            var newEntries = new List<LogEntry>();
            string lastError = null;

            foreach (var file in _loadedFiles.ToList())
            {
                if (!File.Exists(file)) continue;
                long startPos = _tailFilePositions.TryGetValue(file, out long pos) ? pos : 0;
                try
                {
                    var parsed = _logParser.ParseLogFileFromPosition(file, startPos, out long newPos);
                    _tailFilePositions[file] = newPos;
                    newEntries.AddRange(parsed);
                }
                catch (Exception ex)
                {
                    lastError = $"Tail error: {ex.Message}";
                }
            }

            if (lastError != null)
            {
                toolStripStatusLabelFiles.Text = lastError;
                return;
            }

            if (newEntries.Count == 0) return;

            _repository.AppendAndSort(newEntries);
            BindLogViewerDataGrip();

            // Scroll to the last visible row
            var lastVisibleIndex = -1;
            for (int i = gridLogsViewer.Rows.Count - 1; i >= 0; i--)
            {
                if (gridLogsViewer.Rows[i].Visible) { lastVisibleIndex = i; break; }
            }
            if (lastVisibleIndex >= 0)
                gridLogsViewer.FirstDisplayedScrollingRowIndex = lastVisibleIndex;
        }

        private void FormMainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void FormMainForm_DragDrop(object sender, DragEventArgs e)
        {
            var paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            _ = HandleDroppedPathsAsync(paths);
        }

        private async Task HandleDroppedPathsAsync(string[] droppedPaths)
        {
            var logFiles = new List<string>();
            foreach (var path in droppedPaths)
            {
                if (Directory.Exists(path))
                    logFiles.AddRange(Directory.GetFiles(path, "*.log", SearchOption.TopDirectoryOnly));
                else if (File.Exists(path))
                    logFiles.Add(path);
            }
            if (logFiles.Count == 0) return;

            string[] filesToLoad;
            bool clearExisting;

            if (logFiles.Count == 1)
            {
                filesToLoad = logFiles.ToArray();
                clearExisting = true;
            }
            else
            {
                using (var dlg = new FileSelectionDialog(logFiles.ToArray()))
                {
                    if (dlg.ShowDialog(this) != DialogResult.OK) return;
                    filesToLoad = dlg.SelectedFiles;
                    clearExisting = dlg.ClearExisting;
                }
                if (filesToLoad.Length == 0) return;
            }

            var progress = new Progress<LoadProgress>(p =>
            {
                if (IsDisposed || !IsHandleCreated || toolStripStatusLabelLines == null || toolStripProgressBar == null)
                    return;
                toolStripStatusLabelLines.Text = $"Loading {p.CurrentFileIndex} of {p.TotalFiles} files...";
                toolStripProgressBar.Value = p.CurrentFileIndex;
            });
            await LoadLogFilesAsync(filesToLoad, clearExisting, progress, CancellationToken.None);
        }
    }
}
