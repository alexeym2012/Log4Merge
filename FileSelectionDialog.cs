using System.Windows.Forms;
using Log4Merge.ViewModels;

namespace Log4Merge
{
    internal sealed partial class FileSelectionDialog : Form
    {
        private readonly FileSelectionViewModel _viewModel;

        public FileSelectionDialog(FileSelectionViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            _viewModel.Confirmed += (s, e) => DialogResult = DialogResult.OK;
            Controls.Add(_viewModel.RootPanel);
            CancelButton = _viewModel.CancelButton;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _viewModel?.Dispose();
            base.Dispose(disposing);
        }
    }
}
