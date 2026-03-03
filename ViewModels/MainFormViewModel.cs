using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log4Merge;
using Log4Merge.Domain.Models;
using Log4Merge.Domain.Services;
using Log4Merge.Properties;
using Microsoft.VisualBasic;

namespace Log4Merge.ViewModels
{
    /// <summary>
    /// Holds state and business logic for the main form. Updates the UI via the owning <see cref="FormMainForm"/>.
    /// </summary>
    public sealed class MainFormViewModel
    {
        private readonly FormMainForm _form;
        private readonly ILogParser _logParser;
        private readonly ISessionService _sessionService;
        private readonly IHighlightProfileService _highlightService;
        private readonly LogRepository _repository = new LogRepository();

        private string _filterText = string.Empty;
        private readonly BindingList<HighlightEntry> _highlightEntries = new BindingList<HighlightEntry>();
        private readonly List<string> _loadedFiles = new List<string>();
        private readonly Dictionary<string, long> _tailFilePositions = new Dictionary<string, long>();
        private string[] _pendingFileArgs;

        public MainFormViewModel(FormMainForm form)
        {
            _form = form ?? throw new ArgumentNullException(nameof(form));
            var settings = new AppLogParserSettings();
            LogEntry.Settings = settings;
            _logParser = new LogParser(settings);
            _sessionService = new SessionService();
            _highlightService = new HighlightProfileService();
        }

        /// <summary>File paths passed on startup; loaded asynchronously in OnShownAsync.</summary>
        public void SetPendingFileArgs(string[] args)
        {
            _pendingFileArgs = args;
        }

        /// <summary>Called from Form ctor after SetPendingFileArgs: setup grid, level style, form title.</summary>
        public void Initialize()
        {
            SetupGridColumnsOnForm();
            ConfigureLevelCheckboxes();
            _form.Text = _form.Text + " " + GetAssemblyVersion();
        }

        private static string GetAssemblyVersion()
        {
            var asm = Assembly.GetExecutingAssembly();
            var fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(asm.Location);
            return fvi.FileVersion;
        }

        private void SetupGridColumnsOnForm()
        {
            var grid = _form.gridLogsViewer;
            grid.AutoGenerateColumns = false;
            grid.Columns.Clear();

            _form.columnTimeStamp = new DataGridViewTextBoxColumn();
            _form.columnSourceFileName = new DataGridViewTextBoxColumn();
            _form.columnLineNumber = new DataGridViewTextBoxColumn();
            _form.columnLogLevel = new DataGridViewTextBoxColumn();
            _form.columnTimeInvisible = new DataGridViewTextBoxColumn();
            _form.columnMessageInvisible = new DataGridViewTextBoxColumn();
            _form.columnMessage = new DataGridViewTextBoxColumn();

            _form.columnTimeStamp.DataPropertyName = "TimeStampAsText";
            _form.columnTimeStamp.FillWeight = 130F;
            _form.columnTimeStamp.HeaderText = "Timestamp";
            _form.columnTimeStamp.MinimumWidth = 6;
            _form.columnTimeStamp.Name = "columnTimeStamp";
            _form.columnTimeStamp.ReadOnly = true;
            _form.columnTimeStamp.Width = 130;

            _form.columnSourceFileName.DataPropertyName = "SourceFileName";
            _form.columnSourceFileName.HeaderText = "Log File";
            _form.columnSourceFileName.MinimumWidth = 6;
            _form.columnSourceFileName.Name = "columnSourceFileName";
            _form.columnSourceFileName.ReadOnly = true;
            _form.columnSourceFileName.Width = 125;

            _form.columnLineNumber.DataPropertyName = "LineNumber";
            _form.columnLineNumber.FillWeight = 50F;
            _form.columnLineNumber.HeaderText = "Line";
            _form.columnLineNumber.MinimumWidth = 6;
            _form.columnLineNumber.Name = "columnLineNumber";
            _form.columnLineNumber.ReadOnly = true;
            _form.columnLineNumber.Width = 50;

            _form.columnLogLevel.DataPropertyName = "LogLevel";
            _form.columnLogLevel.HeaderText = "Level";
            _form.columnLogLevel.MinimumWidth = 6;
            _form.columnLogLevel.Name = "columnLogLevel";
            _form.columnLogLevel.ReadOnly = true;
            _form.columnLogLevel.Width = 55;

            _form.columnTimeInvisible.DataPropertyName = "TimeStamp";
            _form.columnTimeInvisible.FillWeight = 2F;
            _form.columnTimeInvisible.HeaderText = "columnTimeInvisible";
            _form.columnTimeInvisible.MinimumWidth = 2;
            _form.columnTimeInvisible.Name = "columnTimeInvisible";
            _form.columnTimeInvisible.ReadOnly = true;
            _form.columnTimeInvisible.Visible = false;
            _form.columnTimeInvisible.Width = 2;

            _form.columnMessageInvisible.DataPropertyName = "Message";
            _form.columnMessageInvisible.HeaderText = "columnMessageInvisible";
            _form.columnMessageInvisible.MinimumWidth = 2;
            _form.columnMessageInvisible.Name = "columnMessageInvisible";
            _form.columnMessageInvisible.ReadOnly = true;
            _form.columnMessageInvisible.Visible = false;
            _form.columnMessageInvisible.Width = 2;

            _form.columnMessage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            _form.columnMessage.DataPropertyName = "ShortMessage";
            _form.columnMessage.HeaderText = "Log Message";
            _form.columnMessage.MaxInputLength = 200000000;
            _form.columnMessage.MinimumWidth = 6;
            _form.columnMessage.Name = "columnMessage";
            _form.columnMessage.ReadOnly = true;

            grid.Columns.AddRange(new DataGridViewColumn[]
            {
                _form.columnTimeStamp,
                _form.columnSourceFileName,
                _form.columnLineNumber,
                _form.columnLogLevel,
                _form.columnTimeInvisible,
                _form.columnMessageInvisible,
                _form.columnMessage
            });
        }

        private void ConfigureLevelCheckboxes()
        {
            var checkedBackColor = Color.FromArgb(173, 214, 255);
            foreach (var cb in new[]
                     {
                         _form.chkLevelError, _form.chkLevelFatal, _form.chkLevelWarn,
                         _form.chkLevelInfo, _form.chkLevelDebug, _form.chkLevelTrace, _form.chkLevelOther
                     })
            {
                cb.FlatStyle = FlatStyle.Flat;
                cb.FlatAppearance.CheckedBackColor = checkedBackColor;
            }
        }

        /// <summary>Exposed for the Highlight preferences dialog (same list reference).</summary>
        public BindingList<HighlightEntry> HighlightEntries => _highlightEntries;

        public void LoadHighlightProfiles()
        {
            var loaded = _highlightService.Load();
            _highlightEntries.Clear();
            foreach (var entry in loaded)
                _highlightEntries.Add(entry);
        }

        public void SaveHighlightProfiles()
        {
            _highlightService.Save(_highlightEntries);
        }

        private void SaveSession()
        {
            _sessionService.Save(_loadedFiles);
        }

        /// <summary>Returns existing files from last session to offer restore, or null if none.</summary>
        public string[] GetPendingSessionRestore()
        {
            var saved = _sessionService.Load();
            if (saved == null || saved.Length == 0) return null;
            var existing = saved.Where(File.Exists).ToArray();
            return existing.Length == 0 ? null : existing;
        }

        /// <summary>Shows restore prompt; if user chooses Yes, loads the session files.</summary>
        public async Task TryRestoreSessionAsync()
        {
            var existing = GetPendingSessionRestore();
            if (existing == null || existing.Length == 0) return;
            var names = string.Join("\n", existing.Take(5).Select(Path.GetFileName));
            var more = existing.Length > 5 ? $"\n… and {existing.Length - 5} more" : string.Empty;
            var message = $"Restore last session? ({existing.Length} file{(existing.Length == 1 ? "" : "s")})\n\n{names}{more}";
            if (MessageBox.Show(_form, message, "Session Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            await LoadLogFilesAsync(existing, clearExisting: true, CancellationToken.None);
        }

        /// <summary>Called when the form is shown: load highlights, then either load pending startup files or offer session restore.</summary>
        public async Task OnShownAsync()
        {
            LoadHighlightProfiles();
            if (_pendingFileArgs != null && _pendingFileArgs.Length > 0)
            {
                var files = _pendingFileArgs;
                _pendingFileArgs = null;
                await LoadLogFilesAsync(files, clearExisting: true, CancellationToken.None);
                return;
            }
            await TryRestoreSessionAsync();
        }

        private IProgress<LoadProgress> CreateProgress()
        {
            return new Progress<LoadProgress>(p =>
            {
                if (_form.IsDisposed || !_form.IsHandleCreated) return;
                _form.toolStripStatusLabelLines.Text = $"Loading {p.CurrentFileIndex} of {p.TotalFiles} files...";
                _form.toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                _form.toolStripProgressBar.Maximum = p.TotalFiles;
                _form.toolStripProgressBar.Value = p.CurrentFileIndex;
            });
        }

        public async Task LoadLogFilesAsync(string[] fileNames, bool clearExisting, CancellationToken cancellationToken)
        {
            var totalFiles = fileNames?.Length ?? 0;
            if (totalFiles == 0) return;

            var progress = CreateProgress();
            _form.toolStripStatusLabelLines.Text = "Loading 1 of " + totalFiles + " files...";
            _form.toolStripProgressBar.Visible = true;
            _form.toolStripProgressBar.Style = ProgressBarStyle.Continuous;
            _form.toolStripProgressBar.Maximum = totalFiles;
            _form.toolStripProgressBar.Value = 0;
            _form.openLog4netLogsToolStripMenuItem.Enabled = false;
            _form.appendLog4netLogsToolStripMenuItem.Enabled = false;

            try
            {
                List<LogEntry> collected;
                List<string> failedPaths;
                try
                {
                    (collected, failedPaths) = await Task.Run(() =>
                    {
                        var list = new List<LogEntry>();
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
                            progress.Report(new LoadProgress
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

                if (_form.chkTailMode.Checked)
                    InitializeTailPositions();

                SaveSession();

                if (failedPaths.Count > 0)
                    MessageBox.Show(_form,
                        "The following files could not be parsed:\n\n" +
                        string.Join("\n", failedPaths.Select(Path.GetFileName)),
                        "Parse Errors", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                _form.toolStripProgressBar.Visible = false;
                _form.openLog4netLogsToolStripMenuItem.Enabled = true;
                _form.appendLog4netLogsToolStripMenuItem.Enabled = true;
                BindToolStrip();
            }
        }

        public void BindLogViewerDataGrip()
        {
            _form.gridLogsViewer.DataSource = _repository.Entries;
            var hasEntries = _repository.Entries.Count > 0;
            _form.saveAsToolStripMenuItem.Enabled = _form.saveAsLogToolStripMenuItem.Enabled = hasEntries;
            _form.saveFilteredRowsAsLog4NetToolStripMenuItem.Enabled = _form.saveFilteredRowsAsLog4NetContextMenuItem.Enabled = hasEntries;

            if (_highlightEntries.Count > 0)
            {
                var grid = _form.gridLogsViewer;
                for (var i = 0; i < _repository.Entries.Count; i++)
                {
                    var logEntry = _repository.Entries[i];
                    foreach (var highlightEntry in _highlightEntries)
                    {
                        if (highlightEntry.IsMatch(logEntry.Message))
                        {
                            grid.Rows[i].DefaultCellStyle.BackColor = highlightEntry.BackColor;
                            grid.Rows[i].DefaultCellStyle.ForeColor = highlightEntry.ForeColor;
                            break; // first match wins (same as original loop order)
                        }
                    }
                }
            }

            ApplyFilter();
            BindToolStrip();
        }

        private void BindToolStrip()
        {
            var grid = _form.gridLogsViewer;
            var total = grid.Rows.Count;
            var filterText = _form.filterTextBox.Text.Trim();
            var allLevelsChecked = _form.chkLevelError.Checked && _form.chkLevelFatal.Checked && _form.chkLevelWarn.Checked &&
                _form.chkLevelInfo.Checked && _form.chkLevelDebug.Checked && _form.chkLevelTrace.Checked && _form.chkLevelOther.Checked;
            var isFiltered = !string.IsNullOrWhiteSpace(filterText) || !allLevelsChecked ||
                             _form.dtpFrom.Checked || _form.dtpTo.Checked;
            var tailPrefix = _form.chkTailMode.Checked ? "⏩ Tail: ON  |  " : string.Empty;
            int visibleCount = isFiltered ? grid.Rows.Cast<DataGridViewRow>().Count(r => r.Visible) : total;

            _form.toolStripStatusLabelLines.Text = isFiltered
                ? $"{tailPrefix}Lines: {visibleCount} / {total} (filtered)"
                : $"{tailPrefix}Lines: {total}";

            _form.saveFilteredRowsAsLog4NetToolStripMenuItem.Enabled = _form.saveFilteredRowsAsLog4NetContextMenuItem.Enabled = visibleCount > 0;

            if (_highlightEntries.Count == 0)
                _form.toolStripStatusLabelHighlighted.Text = "Highlighted: —";
            else
            {
                var visibleEntries = GetVisibleLogEntries().ToList();
                var highlightedCount = visibleEntries.Count(entry => _highlightEntries.Any(he => he.IsMatch(entry.Message)));
                _form.toolStripStatusLabelHighlighted.Text = $"Highlighted: {highlightedCount:N0} / {visibleCount:N0}";
            }

            if (_repository.Entries.Count == 0)
                _form.toolStripStatusLabelSpan.Text = "Span: —";
            else
            {
                var minTs = _repository.Entries.Min(e => e.TimeStamp);
                var maxTs = _repository.Entries.Max(e => e.TimeStamp);
                _form.toolStripStatusLabelSpan.Text = $"Span: {minTs:yyyy-MM-dd HH:mm} — {maxTs:yyyy-MM-dd HH:mm}";
            }

            var fileCount = _repository.Entries.Select(e => e.SourceFileName).Distinct().Count();
            _form.toolStripStatusLabelFiles.Text = $"Files: {fileCount:N0}";
        }

        private IEnumerable<LogEntry> GetVisibleLogEntries()
        {
            foreach (DataGridViewRow row in _form.gridLogsViewer.Rows)
            {
                if (!row.Visible) continue;
                if (row.DataBoundItem is LogEntry entry) yield return entry;
            }
        }

        private HashSet<string> GetEnabledLevels()
        {
            if (_form.chkLevelError.Checked && _form.chkLevelFatal.Checked && _form.chkLevelWarn.Checked &&
                _form.chkLevelInfo.Checked && _form.chkLevelDebug.Checked && _form.chkLevelTrace.Checked && _form.chkLevelOther.Checked)
                return null;
            var set = new HashSet<string>();
            if (_form.chkLevelError.Checked) set.Add("ERROR");
            if (_form.chkLevelFatal.Checked) set.Add("FATAL");
            if (_form.chkLevelWarn.Checked) set.Add("WARN");
            if (_form.chkLevelInfo.Checked) set.Add("INFO");
            if (_form.chkLevelDebug.Checked) set.Add("DEBUG");
            if (_form.chkLevelTrace.Checked) set.Add("TRACE");
            if (_form.chkLevelOther.Checked) set.Add("");
            return set;
        }

        private FilterCriteria BuildFilterCriteria()
        {
            var enabledLevels = GetEnabledLevels();
            return new FilterCriteria
            {
                FilterText = _filterText,
                EnabledLevels = enabledLevels,
                FromUtc = _form.dtpFrom.Checked ? (DateTime?)_form.dtpFrom.Value.ToUniversalTime() : null,
                ToUtc = _form.dtpTo.Checked ? (DateTime?)_form.dtpTo.Value.ToUniversalTime() : null
            };
        }

        public void ApplyFilter()
        {
            _form.gridLogsViewer.CurrentCell = null;

            var criteria = BuildFilterCriteria();
            bool hasAnyFilter = !string.IsNullOrEmpty(criteria.FilterText) ||
                                criteria.EnabledLevels != null ||
                                criteria.FromUtc.HasValue || criteria.ToUtc.HasValue;

            var grid = _form.gridLogsViewer;
            if (!hasAnyFilter)
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                    grid.Rows[i].Visible = true;
                UpdateFilterButtonText();
                return;
            }

            var entries = _repository.Entries;
            for (int i = 0; i < entries.Count; i++)
            {
                var entry = entries[i];
                grid.Rows[i].Visible = LogFilter.IsMatch(entry, criteria);
            }
            UpdateFilterButtonText();
        }

        private void UpdateFilterButtonText()
        {
            int active = 0;
            if (!string.IsNullOrEmpty(_filterText)) active++;
            if (!(_form.chkLevelError.Checked && _form.chkLevelFatal.Checked && _form.chkLevelWarn.Checked &&
                _form.chkLevelInfo.Checked && _form.chkLevelDebug.Checked && _form.chkLevelTrace.Checked && _form.chkLevelOther.Checked)) active++;
            if (_form.dtpFrom.Checked || _form.dtpTo.Checked) active++;
            _form.filtersToggleMenuItem.Text = active > 0 ? $"Filters ({active}) \u25be" : "Filters \u25be";
        }

        public void ApplyFilterFromView()
        {
            _filterText = _form.filterTextBox.Text.Trim();
            ApplyFilter();
            BindToolStrip();
        }

        public void ClearFilter()
        {
            _form.filterDebounceTimer.Stop();
            _form.filterTextBox.Clear();
            _filterText = string.Empty;
            ApplyFilter();
            BindToolStrip();
        }

        public void OnFilterDebounceTick()
        {
            _filterText = _form.filterTextBox.Text.Trim();
            ApplyFilter();
            BindToolStrip();
        }

        public void OnLevelOrTimeFilterChanged()
        {
            ApplyFilter();
            BindToolStrip();
        }

        public void ClearTimeRange()
        {
            _form.dtpFrom.Checked = false;
            _form.dtpTo.Checked = false;
            ApplyFilter();
            BindToolStrip();
        }

        // --- Open / Append ---

        public async Task OpenFilesAsync(bool clearExisting)
        {
            var result = ShowOpenFileDialog(clearExisting);
            if (result == null || result.Value.files == null || result.Value.files.Length == 0) return;
            var (files, finalClearExisting) = result.Value;
            await LoadLogFilesAsync(files, finalClearExisting, CancellationToken.None);
        }

        private (string[] files, bool clearExisting)? ShowOpenFileDialog(bool defaultClearExisting)
        {
            using (var d = new OpenFileDialog { Multiselect = true })
            {
                var lastDir = Settings.Default.LastOpenDirectory;
                d.InitialDirectory = !string.IsNullOrEmpty(lastDir) && Directory.Exists(lastDir) ? lastDir : string.Empty;
                if (d.ShowDialog(_form) != DialogResult.OK) return null;
                if (d.FileNames.Length == 0) return null;
                Settings.Default.LastOpenDirectory = Path.GetDirectoryName(d.FileNames[0]);
                Settings.Default.Save();
                if (d.FileNames.Length == 1)
                    return (d.FileNames, defaultClearExisting);
                var selVm = new FileSelectionViewModel(d.FileNames);
                using (var selDlg = new FileSelectionDialog(selVm))
                {
                    if (selDlg.ShowDialog(_form) != DialogResult.OK) return null;
                    if (selVm.SelectedFiles == null || selVm.SelectedFiles.Length == 0) return null;
                    return (selVm.SelectedFiles, selVm.ClearExisting);
                }
            }
        }

        // --- Remove commands ---

        private IEnumerable<LogEntry> GetSelectedLogEntries()
        {
            foreach (DataGridViewRow row in _form.gridLogsViewer.SelectedRows.Cast<DataGridViewRow>())
            {
                if (row.DataBoundItem is LogEntry entry) yield return entry;
            }
        }

        private LogEntry GetFirstSelectedLogEntry()
        {
            if (_form.gridLogsViewer.SelectedRows.Count == 0) return null;
            return _form.gridLogsViewer.SelectedRows[0].DataBoundItem as LogEntry;
        }

        public void RemoveSelectedRows()
        {
            var selected = GetSelectedLogEntries().ToList();
            if (selected.Count == 0) return;
            _repository.RemoveEntries(selected);
            BindLogViewerDataGrip();
        }

        public void RemoveUnselectedRows()
        {
            var toKeep = GetSelectedLogEntries().ToList();
            if (toKeep.Count == 0) return;
            _repository.KeepEntries(toKeep);
            BindLogViewerDataGrip();
        }

        public void RemoveBeforeSelected()
        {
            var entry = GetFirstSelectedLogEntry();
            if (entry == null) return;
            _repository.RemoveBefore(entry.TimeStamp);
            BindLogViewerDataGrip();
        }

        public void RemoveAfterSelected()
        {
            var entry = GetFirstSelectedLogEntry();
            if (entry == null) return;
            _repository.RemoveAfter(entry.TimeStamp);
            BindLogViewerDataGrip();
        }

        public void KeepHighlightedOnly()
        {
            _repository.KeepHighlighted(_highlightEntries);
            BindLogViewerDataGrip();
        }

        public void RemoveHighlighted()
        {
            _repository.RemoveHighlighted(_highlightEntries);
            BindLogViewerDataGrip();
        }

        public void RemoveByText(string textToRemove)
        {
            if (string.IsNullOrWhiteSpace(textToRemove)) return;
            var patterns = textToRemove.Trim().Split('|').Select(p => p.Trim()).Where(p => p.Length > 0).ToList();
            if (patterns.Count == 0) return;
            _repository.RemoveByText(patterns);
            BindLogViewerDataGrip();
        }

        /// <summary>Shows input prompt and removes rows containing the entered text (pipe-separated).</summary>
        public void RemoveByTextPrompt()
        {
            var text = Interaction.InputBox("Remove rows which contain the text:\nCan be split by '|'", "Remove rows", "", 0, 0);
            RemoveByText(text ?? "");
        }

        /// <summary>Expand short message at row (double-click on message column).</summary>
        public void ExpandMessageAtRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= _repository.Entries.Count) return;
            var entry = _repository.Entries[rowIndex];
            var newLen = Math.Min(entry.ShortMessage.Length + 20, entry.Message.Length);
            entry.ShortMessage = entry.Message.Substring(0, newLen);
        }

        /// <summary>Grid key down (e.g. Delete = remove selected rows).</summary>
        public void OnGridKeyDown(Keys keyCode)
        {
            if (keyCode == Keys.Delete)
                RemoveSelectedRows();
        }

        /// <summary>Cell double-click (e.g. column 6 = expand message).</summary>
        public void OnCellDoubleClick(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && columnIndex == 6)
                ExpandMessageAtRow(rowIndex);
        }

        // --- Copy ---

        private IReadOnlyList<(int RowIndex, int ColumnIndex)> GetSelectedCellsOrderedByRow()
        {
            return _form.gridLogsViewer.SelectedCells.Cast<DataGridViewCell>()
                .OrderBy(c => c.RowIndex).ThenBy(c => c.ColumnIndex)
                .Select(c => (c.RowIndex, c.ColumnIndex)).ToList();
        }

        public void CopySelection()
        {
            var cells = GetSelectedCellsOrderedByRow();
            if (cells == null || cells.Count == 0) return;

            var sb = new StringBuilder();
            var entries = _repository.Entries;
            foreach (var (rowIndex, columnIndex) in cells)
            {
                if (rowIndex < 0 || rowIndex >= entries.Count) continue;
                var entry = entries[rowIndex];
                if (columnIndex == 6)
                    sb.Append(entry.Message);
                else
                {
                    switch (columnIndex)
                    {
                        case 0: sb.Append(entry.TimeStampAsText); break;
                        case 1: sb.Append(entry.SourceFileName); break;
                        case 2: sb.Append(entry.LineNumber); break;
                        case 3: sb.Append(entry.LogLevel); break;
                        default: sb.Append(entry.ShortMessage); break;
                    }
                }
                sb.Append("\n");
            }
            Clipboard.SetText(sb.ToString());
        }

        // --- Save ---

        private string ShowSaveFileDialog(string filter, string title)
        {
            using (var d = new SaveFileDialog { Filter = filter, Title = title })
                return d.ShowDialog(_form) == DialogResult.OK ? d.FileName : null;
        }

        public void SaveAs()
        {
            var path = ShowSaveFileDialog("All files|*.*", "Save Logs To File");
            if (string.IsNullOrEmpty(path)) return;
            using (var writer = new StreamWriter(path))
            {
                foreach (var l in _repository.Entries)
                    writer.WriteLine($"{l.TimeStampAsText}|{l.SourceFileName}, Line:{l.LineNumber}|{l.Message}");
            }
        }

        public void SaveAsLog()
        {
            var path = ShowSaveFileDialog("Log4New|*.log", "Save Logs To File");
            if (string.IsNullOrEmpty(path)) return;
            using (var writer = new StreamWriter(path))
            {
                foreach (var l in _repository.Entries)
                    writer.WriteLine($"{l.TimeStampAsText} {l.Message}");
            }
        }

        public void SaveFilteredAsLog()
        {
            var visibleEntries = GetVisibleLogEntries().ToList();
            if (visibleEntries.Count == 0) return;
            var path = ShowSaveFileDialog("Log4New|*.log", "Save Logs To File");
            if (string.IsNullOrEmpty(path)) return;
            using (var writer = new StreamWriter(path))
            {
                foreach (var l in visibleEntries)
                    writer.WriteLine($"{l.TimeStampAsText} {l.Message}");
            }
        }

        // --- Tail ---

        /// <summary>Returns true if tail was enabled; false if no files loaded (caller should uncheck and show message).</summary>
        public bool TryEnableTailMode()
        {
            if (_loadedFiles.Count == 0)
            {
                MessageBox.Show(_form, "Open log files first before enabling Tail Mode.", "Tail Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            InitializeTailPositions();
            return true;
        }

        public void DisableTailMode()
        {
            _tailFilePositions.Clear();
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

        public void OnTailTick()
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
                _form.toolStripStatusLabelFiles.Text = lastError;
                return;
            }

            if (newEntries.Count == 0) return;

            _repository.AppendAndSort(newEntries);
            BindLogViewerDataGrip();
            var gridScroll = _form.gridLogsViewer;
            for (int i = gridScroll.Rows.Count - 1; i >= 0; i--)
            {
                if (gridScroll.Rows[i].Visible)
                {
                    gridScroll.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        // --- Settings / repository refresh ---

        public void UpdateShortMessagesAndRefresh(int visibleLineLength)
        {
            _repository.UpdateShortMessages(visibleLineLength);
            _form.gridLogsViewer.Refresh();
        }

        public LogRepository Repository => _repository;

        // --- Dialogs and UI commands (Form proxies to these) ---

        public void OpenSettings()
        {
            var prevLen = Settings.Default.GridVisibleLineLength;
            using (var f = new SettingsForm()) { f.Owner = _form; if (f.ShowDialog() != DialogResult.OK) return; }
            var newLen = Settings.Default.GridVisibleLineLength;
            if (newLen != prevLen)
                UpdateShortMessagesAndRefresh(newLen);
        }

        public void OpenHighlightPreferences()
        {
            var vm = new HighlightPreferencesViewModel(_highlightEntries);
            using (var dlg = new HighlightPreferencesDialog(vm))
            {
                if (dlg.ShowDialog(_form) != DialogResult.OK) return;
            }
            SaveHighlightProfiles();
            _repository.DeduplicateAndSort();
            BindLogViewerDataGrip();
        }

        public void OpenContributeLink() => System.Diagnostics.Process.Start("https://github.com/alexeym2012/Log4Merge");

        public void ShowAbout() => new AboutWindow().ShowDialog();

        public void Exit() => _form.Close();

        private void RepositionFilterPanel()
        {
            int x = _form.ClientSize.Width - _form.filterOverlayPanel.Width - 4;
            int y = _form.menuStrip1.Bottom + 4;
            _form.filterOverlayPanel.Location = new Point(x, y);
            _form.filterOverlayPanel.BringToFront();
        }

        public void ToggleFilterPanel()
        {
            _form.filterOverlayPanel.Visible = !_form.filterOverlayPanel.Visible;
            if (_form.filterOverlayPanel.Visible)
            {
                RepositionFilterPanel();
                _form.filterTextBox.Focus();
                _form.filterTextBox.SelectAll();
            }
        }

        public void CloseFilterPanel() => _form.filterOverlayPanel.Visible = false;

        public void OnFormResize()
        {
            if (_form.filterOverlayPanel.Visible)
                RepositionFilterPanel();
        }

        /// <summary>Returns true if the key was handled (e.g. Ctrl+F).</summary>
        public bool HandleCmdKey(Keys keyData)
        {
            if (keyData != (Keys.Control | Keys.F)) return false;
            if (!_form.filterOverlayPanel.Visible)
            {
                _form.filterOverlayPanel.Visible = true;
                RepositionFilterPanel();
            }
            _form.filterTextBox.Focus();
            _form.filterTextBox.SelectAll();
            return true;
        }

        public void OnTailModeCheckedChanged(bool isChecked)
        {
            if (isChecked)
            {
                if (!TryEnableTailMode())
                    _form.chkTailMode.Checked = false;
                else
                    _form.tailTimer.Start();
            }
            else
            {
                _form.tailTimer.Stop();
                DisableTailMode();
            }
        }

        public DragDropEffects GetDragDropEffect(bool hasFileDrop) =>
            hasFileDrop ? DragDropEffects.Copy : DragDropEffects.None;

        /// <summary>Handle dropped paths: collect log files, optionally show file-selection dialog, then load.</summary>
        public async Task HandleDroppedPathsAsync(string[] droppedPaths)
        {
            var logFiles = new List<string>();
            foreach (var path in droppedPaths ?? Array.Empty<string>())
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
                var vm = new FileSelectionViewModel(logFiles.ToArray());
                using (var dlg = new FileSelectionDialog(vm))
                {
                    if (dlg.ShowDialog(_form) != DialogResult.OK) return;
                    if (vm.SelectedFiles == null || vm.SelectedFiles.Length == 0) return;
                    filesToLoad = vm.SelectedFiles;
                    clearExisting = vm.ClearExisting;
                }
            }
            await LoadLogFilesAsync(filesToLoad, clearExisting, CancellationToken.None);
        }

        public void OnFilterTextChanged()
        {
            _form.filterDebounceTimer.Stop();
            _form.filterDebounceTimer.Start();
        }

        /// <summary>Returns true if the key was handled (Enter = apply, Escape = clear).</summary>
        public bool OnFilterKeyDown(Keys keyCode)
        {
            if (keyCode == Keys.Enter) { ApplyFilterFromView(); return true; }
            if (keyCode == Keys.Escape) { ClearFilter(); return true; }
            return false;
        }
    }
}
