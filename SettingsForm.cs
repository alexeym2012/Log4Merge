using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Log4Merge.Domain;
using Log4Merge.Properties;

namespace Log4Merge
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var pattern = Settings.Default.LevelRegexPattern;
            txtLevelRegex.Text = string.IsNullOrEmpty(pattern) ? LogEntry.DefaultLevelRegexPattern : pattern;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtLevelRegex.Text = LogEntry.DefaultLevelRegexPattern;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                return;

            if (!ValidateAndSavePattern())
                e.Cancel = true;
        }

        private bool ValidateAndSavePattern()
        {
            var pattern = txtLevelRegex.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(pattern))
            {
                MessageBox.Show(this, "Please enter a regex pattern.", "Invalid pattern", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                new Regex(pattern);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(this, "The regex pattern is invalid: " + ex.Message, "Invalid pattern", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Settings.Default.LevelRegexPattern = pattern;
            Settings.Default.Save();
            return true;
        }
    }
}
