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
                                _logEntries.Add(new LogEntry(logFileName,i +1, timeStamp, message));
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
            BindToolStrip();
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

        private void gridLogsViewer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            gridLogsViewer.Rows[e.RowIndex].Selected = true;

        }

        private void gridLogsViewer_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            foreach (var highlightEntry in this._highlightEntries)
            {
                var message = _logEntries[e.RowIndex].Message;
                if (string.IsNullOrWhiteSpace(message) == false)
                {
                    var rgx = new Regex(highlightEntry.Pattern, RegexOptions.IgnoreCase);
                    if (rgx.IsMatch(message))
                    {
                        gridLogsViewer.Rows[e.RowIndex].DefaultCellStyle.BackColor = highlightEntry.BackColor;
                        gridLogsViewer.Rows[e.RowIndex].DefaultCellStyle.ForeColor = highlightEntry.ForeColor;

                    }
                }
            }
        }

        private void highlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hightPreferencesDialog = new HighlightPreferencesDialog(this._highlightEntries);
            if (hightPreferencesDialog.ShowDialog() == DialogResult.OK)
            {
                _logEntries = new BindingList<LogEntry>(_logEntries.ToList().OrderBy(l => l.TimeStamp).ToList());
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

                _logEntries = new BindingList<LogEntry>(_logEntries.ToList().OrderBy(l => l.TimeStamp).ToList());
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
    }
}
