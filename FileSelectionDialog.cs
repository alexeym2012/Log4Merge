using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Log4Merge
{
    /// <summary>
    /// Programmatic dialog that lets the user select which dropped files to open
    /// and whether to replace or append to the current view.
    /// </summary>
    internal sealed class FileSelectionDialog : Form
    {
        public string[] SelectedFiles { get; private set; }
        public bool ClearExisting { get; private set; }

        private readonly string[] _fullPaths;
        private readonly CheckedListBox _listBox;
        private readonly ToolTip _toolTip;

        public FileSelectionDialog(string[] filePaths)
        {
            _fullPaths = filePaths;

            Text = "Select Files to Open";
            Width = 480;
            Height = 380;
            MinimumSize = new System.Drawing.Size(380, 280);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.Sizable;

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
            var btnCancel = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel, AutoSize = true };

            btnOpen.Click += (s, e) =>
            {
                if (!TryCollectSelection()) return;
                ClearExisting = true;
                DialogResult = DialogResult.OK;
            };
            btnAppend.Click += (s, e) =>
            {
                if (!TryCollectSelection()) return;
                ClearExisting = false;
                DialogResult = DialogResult.OK;
            };

            var bottomFlow = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                FlowDirection = FlowDirection.RightToLeft,
                AutoSize = true,
                Padding = new Padding(4, 4, 4, 4)
            };
            bottomFlow.Controls.Add(btnCancel);
            bottomFlow.Controls.Add(btnAppend);
            bottomFlow.Controls.Add(btnOpen);

            CancelButton = btnCancel;

            Controls.Add(_listBox);
            Controls.Add(topFlow);
            Controls.Add(label);
            Controls.Add(bottomFlow);
        }

        private bool TryCollectSelection()
        {
            var selected = _listBox.CheckedIndices.Cast<int>()
                .Select(i => _fullPaths[i])
                .ToArray();

            if (selected.Length == 0)
            {
                MessageBox.Show("Please select at least one file.", "No Files Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            SelectedFiles = selected;
            return true;
        }

        private int _lastTooltipIndex = -1;

        private void ListBox_MouseMove(object sender, MouseEventArgs e)
        {
            int idx = _listBox.IndexFromPoint(e.Location);
            if (idx < 0 || idx >= _fullPaths.Length)
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
                _toolTip.SetToolTip(_listBox, _fullPaths[idx]);
                _lastTooltipIndex = idx;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _toolTip?.Dispose();
            base.Dispose(disposing);
        }
    }
}
