using Log4Merge.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Log4Merge.ViewModels
{
    internal sealed class HighlightPreferencesViewModel
    {
        private readonly BindingList<HighlightEntry> _highlightEntries;

        public TableLayoutPanel RootPanel { get; }
        public Button OkButton { get; }
        public Button CancelButton { get; }

        private readonly ListBox _lstHighlights;
        private readonly TextBox _txtPattern;
        private readonly Button _btnChooseBackColor;
        private readonly Button _btnChooseTextColor;

        public HighlightPreferencesViewModel(BindingList<HighlightEntry> highlightEntries)
        {
            _highlightEntries = highlightEntries;

            // --- ListBox ---
            _lstHighlights = new ListBox
            {
                Dock = DockStyle.Fill,
                DisplayMember = "Pattern",
                ValueMember = "Pattern",
                DrawMode = DrawMode.OwnerDrawFixed,
                ItemHeight = 25,
                SelectionMode = SelectionMode.MultiExtended,
                FormattingEnabled = true,
                Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 254),
                Margin = new Padding(2, 2, 2, 2),
                Name = "lstHighlights"
            };
            _lstHighlights.DrawItem += LstHighlights_DrawItem;
            _lstHighlights.SelectedIndexChanged += LstHighlights_SelectedIndexChanged;

            // --- Row 1: Import / Export / Remove ---
            var btnImportList = new Button
            {
                Dock = DockStyle.Fill,
                Text = "Import",
                Margin = new Padding(2, 2, 2, 2),
                Name = "btnImportList"
            };
            btnImportList.Click += BtnImportList_Click;

            var btnExportList = new Button
            {
                Dock = DockStyle.Fill,
                Text = "Export",
                Margin = new Padding(2, 2, 2, 2),
                Name = "btnExportList"
            };
            btnExportList.Click += BtnExportList_Click;

            var btnRemove = new Button
            {
                Dock = DockStyle.Fill,
                Text = "Remove",
                Margin = new Padding(2, 2, 2, 2),
                Name = "btnRemove"
            };
            btnRemove.Click += BtnRemove_Click;

            // --- Row 2: Labels + color buttons ---
            var label1 = new Label
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                AutoSize = true,
                Text = "                     Foreground:\r\n\r\nRegex:",
                Margin = new Padding(2, 0, 2, 0),
                Name = "label1"
            };

            _btnChooseTextColor = new Button
            {
                Anchor = AnchorStyles.Left,
                Cursor = Cursors.Hand,
                Size = new Size(34, 30),
                Margin = new Padding(2, 2, 2, 2),
                Name = "btnChooseTextColor"
            };
            _btnChooseTextColor.Click += BtnChooseTextColor_Click;

            var label2 = new Label
            {
                Anchor = AnchorStyles.Right,
                AutoSize = true,
                Text = "Background",
                Margin = new Padding(2, 0, 2, 0),
                Name = "label2"
            };

            _btnChooseBackColor = new Button
            {
                Anchor = AnchorStyles.Left,
                Cursor = Cursors.Hand,
                Size = new Size(34, 30),
                Margin = new Padding(2, 2, 2, 2),
                Name = "btnChooseBackColor"
            };
            _btnChooseBackColor.Click += BtnChooseBackColor_Click;

            // --- Row 3: Pattern textbox + Add button ---
            _txtPattern = new TextBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(2, 2, 2, 2),
                Name = "txtPattern"
            };

            var btnAddPattern = new Button
            {
                Dock = DockStyle.Top,
                Text = "Add",
                Margin = new Padding(2, 2, 2, 2),
                Name = "btnAddPattern"
            };
            btnAddPattern.Click += BtnAddPattern_Click;

            // --- Row 4: Cancel + OK ---
            CancelButton = new Button
            {
                Dock = DockStyle.Fill,
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Margin = new Padding(2, 2, 2, 2),
                Name = "btnCancel"
            };

            OkButton = new Button
            {
                Dock = DockStyle.Fill,
                Text = "APPLY",
                DialogResult = DialogResult.OK,
                BackColor = Color.FromArgb(192, 255, 192),
                UseVisualStyleBackColor = false,
                Margin = new Padding(2, 2, 2, 2),
                Name = "btnOk"
            };

            // --- TableLayoutPanel ---
            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 5,
                Margin = new Padding(2, 2, 2, 2),
                Name = "tableLayoutPanel1"
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 49.40711F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 12.64822F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 12.64822F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 12.64822F));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 12.64822F));

            // Row 0: listbox spans all 4 columns
            table.Controls.Add(_lstHighlights, 0, 0);
            table.SetColumnSpan(_lstHighlights, 4);

            // Row 1: Import / Export / [empty] / Remove
            table.Controls.Add(btnImportList, 0, 1);
            table.Controls.Add(btnExportList, 1, 1);
            table.Controls.Add(btnRemove, 3, 1);

            // Row 2: label1 / textColor / label2 / backColor
            table.Controls.Add(label1, 0, 2);
            table.Controls.Add(_btnChooseTextColor, 1, 2);
            table.Controls.Add(label2, 2, 2);
            table.Controls.Add(_btnChooseBackColor, 3, 2);

            // Row 3: pattern (span 3) / Add
            table.Controls.Add(_txtPattern, 0, 3);
            table.SetColumnSpan(_txtPattern, 3);
            table.Controls.Add(btnAddPattern, 3, 3);

            // Row 4: [empty] / [empty] / Cancel / OK
            table.Controls.Add(CancelButton, 2, 4);
            table.Controls.Add(OkButton, 3, 4);

            RootPanel = table;

            // Bind data source
            _lstHighlights.DataSource = _highlightEntries;
        }

        private void BtnAddPattern_Click(object sender, EventArgs e)
        {
            var newHighlightEntry = new HighlightEntry(_txtPattern.Text, _btnChooseBackColor.BackColor, _btnChooseTextColor.BackColor);
            _highlightEntries.Add(newHighlightEntry);

            _lstHighlights.ClearSelected();
            _lstHighlights.SelectedItem = newHighlightEntry;
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var itemsToRemove = new List<HighlightEntry>();
            foreach (var selectedItem in _lstHighlights.SelectedItems)
                itemsToRemove.Add(selectedItem as HighlightEntry);

            foreach (var item in itemsToRemove)
                _highlightEntries.Remove(item);
        }

        private void BtnChooseTextColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ((Button)sender).BackColor = colorDialog.Color;
                foreach (var selectedItem in _lstHighlights.SelectedItems)
                    ((HighlightEntry)selectedItem).ForeColor = colorDialog.Color;
            }
        }

        private void BtnChooseBackColor_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ((Button)sender).BackColor = colorDialog.Color;
                foreach (var selectedItem in _lstHighlights.SelectedItems)
                    ((HighlightEntry)selectedItem).BackColor = colorDialog.Color;
            }
        }

        private void LstHighlights_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindControls(_lstHighlights.SelectedItem as HighlightEntry);
        }

        private void BindControls(HighlightEntry item)
        {
            if (item == null)
                return;

            _txtPattern.DataBindings.Clear();
            _txtPattern.DataBindings.Add("Text", item, "Pattern", false, DataSourceUpdateMode.OnValidation);

            _btnChooseBackColor.DataBindings.Clear();
            _btnChooseBackColor.DataBindings.Add("BackColor", item, "BackColor", false, DataSourceUpdateMode.OnValidation);

            _btnChooseTextColor.DataBindings.Clear();
            _btnChooseTextColor.DataBindings.Add("BackColor", item, "ForeColor", false, DataSourceUpdateMode.OnValidation);

            _lstHighlights.DrawMode = DrawMode.Normal;
            _lstHighlights.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void LstHighlights_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index <= -1)
                return;

            var entry = _lstHighlights.Items[e.Index] as HighlightEntry;
            Color foreColor, backColor;

            if (_lstHighlights.SelectedIndices.Contains(e.Index))
            {
                foreColor = Color.White;
                backColor = Color.RoyalBlue;
            }
            else
            {
                foreColor = entry.ForeColor;
                backColor = entry.BackColor;
            }

            using (var backgroundBrush = new SolidBrush(backColor))
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);

            using (var brush = new SolidBrush(foreColor))
                e.Graphics.DrawString(entry.Pattern, e.Font, brush, e.Bounds.Location);
        }

        private void BtnImportList_Click(object sender, EventArgs e)
        {
            var highlights = ReturnObjectFromFileDialog<HighlightEntry>();
            if (highlights != null && highlights.Count > 0)
            {
                _highlightEntries.Clear();
                highlights.ForEach(_highlightEntries.Add);
            }
        }

        private void BtnExportList_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Json files|*.json|All files|*.*";
                saveFileDialog.Title = "Save Highlights To File";
                if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName != "")
                    File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(_highlightEntries, Formatting.Indented));
            }
        }

        private List<T> ReturnObjectFromFileDialog<T>()
        {
            var result = new List<T>();
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK &&
                    openFileDialog.FileNames != null && openFileDialog.FileNames.Length > 0)
                {
                    foreach (var fileName in openFileDialog.FileNames)
                    {
                        try
                        {
                            var json = File.ReadAllText(fileName);
                            result.AddRange(JsonConvert.DeserializeObject<List<T>>(json));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, $"Failed to import {fileName}",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            return result;
        }
    }
}
