using Log4Merge.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log4Merge
{
    public partial class HighlightPreferencesDialog : Form
    {
        private readonly BindingList<HighlightEntry> _highlightEntries;

        public HighlightPreferencesDialog(BindingList<HighlightEntry> highlightEntries)
        {
            _highlightEntries = highlightEntries;
            InitializeComponent();
        }

        private void btnAddPattern_Click(object sender, EventArgs e)
        {
            this.txtPattern.Text = string.Empty;
        }
    }
}
