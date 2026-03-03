using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Log4Merge.ViewModels
{
    internal sealed class FileSelectionViewModel : IDisposable
    {
        public IReadOnlyList<string> FilePaths { get; }
        public string[] SelectedFiles { get; private set; }
        public bool ClearExisting { get; private set; }

        public event EventHandler Confirmed;

        public Panel RootPanel { get; }
        public Button CancelButton { get; }

        private readonly CheckedListBox _listBox;
        private readonly ToolTip _toolTip;
        private int _lastTooltipIndex = -1;

        public FileSelectionViewModel(string[] filePaths)
        {
            FilePaths = Array.AsReadOnly(filePaths);

            // --- label ---
            var label = new Label
            {
                Text = $"{filePaths.Length} log file(s) found. Select which to open:",
                Dock = DockStyle.Top,
                Height = 28,
                TextAlign = System.Drawing.ContentAlignment.MiddleLeft,
                Padding = new Padding(4, 0, 0, 0)
            };

            // --- Select All / Clear All ---
            var btnSelectAll = new Button { Text = "Select All", AutoSize = true };
            var btnClearAll  = new Button { Text = "Clear All",  AutoSize = true };
            btnSelectAll.Click += (s, e) =>
            {
                for (int i = 0; i < _listBox.Items.Count; i++)
                    _listBox.SetItemChecked(i, true);
            };
            btnClearAll.Click += (s, e) =>
            {
                for (int i = 0; i < _listBox.Items.Count; i++)
                    _listBox.SetItemChecked(i, false);
            };
            var topFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Padding = new Padding(2, 2, 2, 2)
            };
            topFlow.Controls.Add(btnSelectAll);
            topFlow.Controls.Add(btnClearAll);

            // --- file list ---
            _listBox = new CheckedListBox
            {
                Dock = DockStyle.Fill,
                CheckOnClick = true,
                IntegralHeight = false
            };
            _toolTip = new ToolTip();
            foreach (var path in filePaths)
            {
                int idx = _listBox.Items.Add(Path.GetFileName(path));
                _listBox.SetItemChecked(idx, true);
            }
            _listBox.MouseMove += ListBox_MouseMove;

            // --- bottom buttons ---
            var btnOpen   = new Button { Text = "Open",   DialogResult = DialogResult.None, AutoSize = true };
            var btnAppend = new Button { Text = "Append", DialogResult = DialogResult.None, AutoSize = true };
            CancelButton  = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, AutoSize = true };

            btnOpen.Click   += (s, e) => TryCommit(clearExisting: true);
            btnAppend.Click += (s, e) => TryCommit(clearExisting: false);

            var bottomFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                Padding = new Padding(4, 4, 4, 4)
            };
            bottomFlow.Controls.Add(CancelButton);
            bottomFlow.Controls.Add(btnAppend);
            bottomFlow.Controls.Add(btnOpen);

            // --- root panel ---
            RootPanel = new Panel { Dock = DockStyle.Fill };
            RootPanel.Controls.Add(_listBox);
            RootPanel.Controls.Add(topFlow);
            RootPanel.Controls.Add(label);
            RootPanel.Controls.Add(bottomFlow);
        }

        private bool TryCommit(bool clearExisting)
        {
            var selected = _listBox.CheckedIndices.Cast<int>()
                .Select(i => FilePaths[i]).ToArray();

            if (selected.Length == 0)
            {
                MessageBox.Show("Please select at least one file.", "No Files Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            SelectedFiles = selected;
            ClearExisting = clearExisting;
            Confirmed?.Invoke(this, EventArgs.Empty);
            return true;
        }

        private void ListBox_MouseMove(object sender, MouseEventArgs e)
        {
            int idx = _listBox.IndexFromPoint(e.Location);
            if (idx < 0 || idx >= FilePaths.Count)
            {
                if (_lastTooltipIndex != -1)
                {
                    _toolTip.SetToolTip(_listBox, string.Empty);
                    _lastTooltipIndex = -1;
                }
                return;
            }
            if (idx != _lastTooltipIndex)
            {
                _toolTip.SetToolTip(_listBox, FilePaths[idx]);
                _lastTooltipIndex = idx;
            }
        }

        public void Dispose() => _toolTip?.Dispose();
    }
}
