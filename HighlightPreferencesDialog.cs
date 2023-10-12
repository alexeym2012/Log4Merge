using Log4Merge.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            this.lstHighlights.DataSource = _highlightEntries;
        }

        private void btnAddPattern_Click(object sender, EventArgs e)
        {
            _highlightEntries.Add(new HighlightEntry(txtPattern.Text, Color.Transparent, Color.Black));
       
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var itemsToRemove = new List<HighlightEntry>();
            foreach (var selectedItem in lstHighlights.SelectedItems)
            {
                itemsToRemove.Add(selectedItem as HighlightEntry);
            }

            foreach (var highlightEntryToRemove in itemsToRemove)
            {
                _highlightEntries.Remove(highlightEntryToRemove);
            }
        }

        private void btnChooseTextColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Button).BackColor = colorDialog.Color;
                foreach (var selectedItem in lstHighlights.SelectedItems)
                {
                    (selectedItem as HighlightEntry).ForeColor = colorDialog.Color;
                }
            }
        
        }

        private void btnChooseBackColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                (sender as Button).BackColor = colorDialog.Color;
                foreach (var selectedItem in lstHighlights.SelectedItems)
                {
                    (selectedItem as HighlightEntry).BackColor = colorDialog.Color;
                }
            }

        
        }

        private void lstHighlights_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindControls(lstHighlights.SelectedItem as HighlightEntry);
        }

        private void BindControls(HighlightEntry item)
        {

            if (item == null)
            {
                return;
            }
            //txtPattern.Text = lstHighlightsSelectedItem.Pattern;
            this.txtPattern.DataBindings.Clear();
            this.txtPattern.DataBindings.Add("Text", item, "Pattern", false,
                DataSourceUpdateMode.OnValidation);

            btnChooseBackColor.DataBindings.Clear();
            btnChooseBackColor.DataBindings.Add("BackColor", item, "BackColor", false,
                DataSourceUpdateMode.OnValidation);

            btnChooseTextColor.DataBindings.Clear();
            btnChooseTextColor.DataBindings.Add("BackColor", item, "ForeColor", false,
                DataSourceUpdateMode.OnValidation);

            lstHighlights.DrawMode = DrawMode.Normal;
            lstHighlights.DrawMode = DrawMode.OwnerDrawFixed;

        }

        private void lstHighlights_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                var currentHighlightItem = (lstHighlights.Items[e.Index] as HighlightEntry);

                var foreColor = Color.White;
                var backColor = Color.RoyalBlue;

                if (lstHighlights.SelectedIndices.Contains(e.Index) == false)
                {
                    foreColor = currentHighlightItem.ForeColor;
                    backColor = currentHighlightItem.BackColor;
                }

                using (Brush backgroundBrush = new SolidBrush(backColor))
                {

                    e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
                }

                using (Brush brush = new SolidBrush(foreColor))
                {
                    e.Graphics.DrawString(currentHighlightItem.Pattern, e.Font, brush, e.Bounds.Location);
                }
            }
        }

        private void btnImportList_Click(object sender, EventArgs e)
        {
            var highlights = this.ReturnObjectFromFileDialog<HighlightEntry>();
            if (highlights != null && highlights.Count > 0)
            {
                this._highlightEntries.Clear();
                highlights.ForEach(this._highlightEntries.Add);
            }
        }

        private void btnExportList_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json files|*.json|All files|*.*";
            saveFileDialog.Title = "Save Highlights To File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(this._highlightEntries, Formatting.Indented));
                }
            }
        }


        private List<T> ReturnObjectFromFileDialog<T>()
        {
            var result = new List<T>();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.FileNames != null && openFileDialog.FileNames.Length > 0)
                    {

                        foreach (var fileName in openFileDialog.FileNames)
                        {
                            try
                            {
                                var json = File.ReadAllText(fileName);
                                result.AddRange(JsonConvert.DeserializeObject<List<T>>(json));
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(this, e.Message, $"Failed to import {fileName}", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }

                        }
                    }

                }
            }


            return result;
        }
    }
}
