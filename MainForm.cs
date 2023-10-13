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
using System.Threading.Tasks;
using System.Windows.Forms;
using Log4Merge.Domain;
using Newtonsoft.Json;

namespace Log4Merge
{
    public partial class formMainForm : Form
    {
        private BindingList<LogEntry> _logEntries = new BindingList<LogEntry>();


        private BindingList<HighlightEntry> _highlightEntries = new BindingList<HighlightEntry>();
        public formMainForm()
        {
            InitializeComponent();
            this.Text = $"{this.Text} {GetAssemblyVersion()}";
        }

        private void btnChooseLogFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Multiselect = true;
            d.InitialDirectory = @"C:\tmp\logs-test\sideGall";
            if (d.ShowDialog() == DialogResult.OK)
            {
                _logEntries.Clear();
                foreach (var logFileName in d.FileNames)
                {

                    var logLines = System.IO.File.ReadAllLines(logFileName, Encoding.UTF8);

                    for (var i = 0; i < logLines.Length; i++)
                    {
                        var logLine = logLines[i];
                        if (logLine.Length < 23)
                        {
                            _logEntries.Last()?.AppendMessage(logLine);
                        }
                        else
                        {
                            var timeString = logLine.Substring(0, 23);
                            var message = logLine.Substring(23);
                            if (DateTime.TryParseExact(timeString, @"yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture,
                                    DateTimeStyles.AssumeUniversal, out var timeStamp))
                            {
                                _logEntries.Add(new LogEntry(logFileName, i + 1, timeStamp, message));
                            }
                            else
                            {
                                _logEntries.Last()?.AppendMessage(logLine);
                            }
                        }
                    }

                }

                _logEntries = new BindingList<LogEntry>(_logEntries.ToList().OrderBy(l => l.TimeStamp).ToList());
                BindLogViewerDataGrip();


            }
        }

        private void BindLogViewerDataGrip()
        {
            gridLogsViewer.DataSource = _logEntries;
            saveAsToolStripMenuItem.Enabled = _logEntries.Count > 0;
            BindToolStrip();
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
        }

        private void BindToolStrip()
        {
            toolStripStatusLabelLines.Text = $"Lines: {gridLogsViewer.Rows.Count}";
        }

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

        private void highlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hightPreferencesDialog = new HighlightPreferencesDialog(this._highlightEntries);
            if (hightPreferencesDialog.ShowDialog() == DialogResult.OK)
            {
                _logEntries = new BindingList<LogEntry>(_logEntries.Distinct().ToList().OrderBy(l => l.TimeStamp).ToList());
                BindLogViewerDataGrip();
            }
        }

        private void openLog4netLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFilesDialog(true);
        }

        private void OpenFilesDialog(bool clearExisting)
        {
            var d = new OpenFileDialog();
            d.Multiselect = true;
            d.InitialDirectory = @"C:\tmp\logs-test\sideGall";
            if (d.ShowDialog() == DialogResult.OK)
            {
                if (clearExisting)
                {
                    _logEntries.Clear();
                }

                foreach (var logFileName in d.FileNames)
                {
                    var logLines = System.IO.File.ReadAllLines(logFileName, Encoding.UTF8);

                    for (var i = 0; i < logLines.Length; i++)
                    {
                        var logLine = logLines[i];
                        if (logLine.Length < 23)
                        {
                            _logEntries.Last()?.AppendMessage(logLine);
                        }
                        else
                        {
                            var timeString = logLine.Substring(0, 23);
                            var message = logLine.Substring(23);
                            
                            if (DateTime.TryParseExact(timeString, @"yyyy-MM-dd HH:mm:ss,fff", CultureInfo.InvariantCulture,
                                    DateTimeStyles.AssumeUniversal, out var timeStamp))
                            {
                                _logEntries.Add(new LogEntry(logFileName, i + 1, timeStamp, message));
                            }
                            else
                            {
                                _logEntries.Last()?.AppendMessage(logLine);
                            }
                        }
                    }
                }

                _logEntries = new BindingList<LogEntry>(_logEntries.Distinct().ToList().OrderBy(l => l.TimeStamp).ToList());
                BindLogViewerDataGrip();
            }
        }

        private void appendLog4netLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFilesDialog(false);
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
            if (e.RowIndex > 0 && e.ColumnIndex == 4)
            {
                //_logEntries[e.RowIndex].ShortMessage = _logEntries[e.RowIndex].Message;
            }
        }

        private void toolStripMenuRemoveText_Click(object sender, EventArgs e)
        {

            var textToRemove = Microsoft.VisualBasic.Interaction.InputBox("Remove rows which contain the text:",
                "Remove rows",
                "",
                0,
                0);

            if (string.IsNullOrWhiteSpace(textToRemove) == false)
            {
                var items = _logEntries.ToList()
                    .Where(l => l.Message.ToLower().Contains(textToRemove.Trim().ToLower()) == false).ToList();

                _logEntries = new BindingList<LogEntry>(items.Distinct().ToList());
                BindLogViewerDataGrip();

            }
        }

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            foreach (DataGridViewCell selectedCell in gridLogsViewer.SelectedCells.OfType<DataGridViewCell>().OrderBy(r => r.RowIndex))
            {
                if (selectedCell.ColumnIndex == 4)
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
                    File.WriteAllText(saveFileDialog.FileName, string.Join("\n", this._logEntries.Select(l => $"{l.TimeStampAsText}|{l.SourceFileName}, Line:{l.LineNumber}|{l.Message}")));
                }
            }
        }
    }
}
