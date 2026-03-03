using Log4Merge.ViewModels;
using System.Windows.Forms;

namespace Log4Merge
{
    internal sealed partial class HighlightPreferencesDialog : Form
    {
        public HighlightPreferencesDialog(HighlightPreferencesViewModel viewModel)
        {
            InitializeComponent();
            Controls.Add(viewModel.RootPanel);
            AcceptButton = viewModel.OkButton;
            CancelButton = viewModel.CancelButton;
        }
    }
}
