using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log4Merge.ViewModels;

namespace Log4Merge
{
    public partial class FormMainForm : Form
    {
        private readonly MainFormViewModel _viewModel;

        public FormMainForm(string[] args)
        {
            InitializeComponent();
            _viewModel = new MainFormViewModel(this);
            if (args != null && args.Length > 0)
                _viewModel.SetPendingFileArgs(args);
            _viewModel.Initialize();

            this.AllowDrop = true;
            gridLogsViewer.AllowDrop = true;
            this.DragEnter += FormMainForm_DragEnter;
            this.DragDrop  += FormMainForm_DragDrop;
            gridLogsViewer.DragEnter += FormMainForm_DragEnter;
            gridLogsViewer.DragDrop  += FormMainForm_DragDrop;
        }

        private void FormMainForm_Shown(object sender, EventArgs e)
        {
            _ = _viewModel.OnShownAsync();
        }

        private void gridLogsViewer_KeyDown(object sender, KeyEventArgs e) => _viewModel.OnGridKeyDown(e.KeyCode);

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) => _viewModel.OpenSettings();

        private void highlightingToolStripMenuItem_Click(object sender, EventArgs e) => _viewModel.OpenHighlightPreferences();

        private async void openLog4netLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _viewModel.OpenFilesAsync(clearExisting: true);
        }

        private async void appendLog4netLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await _viewModel.OpenFilesAsync(clearExisting: false);
        }

        private void contributeMenuItem_Click(object sender, EventArgs e) => _viewModel.OpenContributeLink();

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e) => _viewModel.ShowAbout();

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => _viewModel.Exit();

        private void menuRemoveUnhighlighted_Click(object sender, EventArgs e) => _viewModel.KeepHighlightedOnly();

        private void removeSelectedToolStripMenuItem_Click(object sender, EventArgs e) => _viewModel.RemoveSelectedRows();

        private void removeUnselectedToolStripMenuItem_Click(object sender, EventArgs e) => _viewModel.RemoveUnselectedRows();

        private void removeHighlightedToolStripMenuItem_Click(object sender, EventArgs e) => _viewModel.RemoveHighlighted();

        private void gridLogsViewer_CellClick(object sender, DataGridViewCellEventArgs e) { }

        private void gridLogsViewer_CellDoubleClick(object sender, DataGridViewCellEventArgs e) =>
            _viewModel.OnCellDoubleClick(e.RowIndex, e.ColumnIndex);

        private void toolStripMenuRemoveText_Click(object sender, EventArgs e) => _viewModel.RemoveByTextPrompt();

        private void toolStripMenuItemCopy_Click(object sender, EventArgs e) => _viewModel.CopySelection();

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) => _viewModel.SaveAs();

        private void saveAsLogToolStripMenuItem_Click(object sender, EventArgs e) => _viewModel.SaveAsLog();

        private void saveFilteredRowsAsLog4NetToolStripMenuItem_Click(object sender, EventArgs e) => _viewModel.SaveFilteredAsLog();

        private void toolStripMenuItemRemoveBefore_Click(object sender, EventArgs e) => _viewModel.RemoveBeforeSelected();

        private void toolStripMenuItemRemoveAfter_Click(object sender, EventArgs e) => _viewModel.RemoveAfterSelected();

        private void btnFilter_Click(object sender, EventArgs e) => _viewModel.ApplyFilterFromView();

        private void btnClearFilter_Click(object sender, EventArgs e) => _viewModel.ClearFilter();

        private void filterTextBox_TextChanged(object sender, EventArgs e) => _viewModel.OnFilterTextChanged();

        private void filterDebounceTimer_Tick(object sender, EventArgs e) => _viewModel.OnFilterDebounceTick();

        private void filterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_viewModel.OnFilterKeyDown(e.KeyCode)) return;
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void levelButton_CheckedChanged(object sender, EventArgs e) => _viewModel.OnLevelOrTimeFilterChanged();

        private void btnClearTimeRange_Click(object sender, EventArgs e) => _viewModel.ClearTimeRange();

        private void dtpTimeRange_ValueChanged(object sender, EventArgs e) => _viewModel.OnLevelOrTimeFilterChanged();

        private void filtersToggleMenuItem_Click(object sender, EventArgs e) => _viewModel.ToggleFilterPanel();

        private void btnCloseFilter_Click(object sender, EventArgs e) => _viewModel.CloseFilterPanel();

        private void FormMainForm_Resize(object sender, EventArgs e) => _viewModel.OnFormResize();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) =>
            _viewModel.HandleCmdKey(keyData) || base.ProcessCmdKey(ref msg, keyData);

        private void chkTailMode_CheckedChanged(object sender, EventArgs e) => _viewModel.OnTailModeCheckedChanged(chkTailMode.Checked);

        private void tailTimer_Tick(object sender, EventArgs e) => _viewModel.OnTailTick();

        private void FormMainForm_DragEnter(object sender, DragEventArgs e) =>
            e.Effect = _viewModel.GetDragDropEffect(e.Data.GetDataPresent(DataFormats.FileDrop));

        private void FormMainForm_DragDrop(object sender, DragEventArgs e)
        {
            var paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            _ = _viewModel.HandleDroppedPathsAsync(paths);
        }
    }
}
