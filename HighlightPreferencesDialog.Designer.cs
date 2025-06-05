namespace Log4Merge
{
    partial class HighlightPreferencesDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighlightPreferencesDialog));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnChooseBackColor = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPattern = new System.Windows.Forms.TextBox();
            this.btnAddPattern = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChooseTextColor = new System.Windows.Forms.Button();
            this.btnImportList = new System.Windows.Forms.Button();
            this.btnExportList = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lstHighlights = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnChooseBackColor, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPattern, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAddPattern, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnChooseTextColor, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnImportList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnExportList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnRemove, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lstHighlights, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.40711F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.64822F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.64822F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.64822F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.64822F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(430, 569);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnChooseBackColor
            // 
            this.btnChooseBackColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnChooseBackColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChooseBackColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChooseBackColor.Location = new System.Drawing.Point(323, 372);
            this.btnChooseBackColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChooseBackColor.Name = "btnChooseBackColor";
            this.btnChooseBackColor.Size = new System.Drawing.Size(34, 30);
            this.btnChooseBackColor.TabIndex = 8;
            this.btnChooseBackColor.UseVisualStyleBackColor = true;
            this.btnChooseBackColor.Click += new System.EventHandler(this.btnChooseBackColor_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOk.Location = new System.Drawing.Point(323, 496);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(105, 71);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "APPLY";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(216, 496);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 71);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtPattern
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtPattern, 3);
            this.txtPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPattern.Location = new System.Drawing.Point(2, 425);
            this.txtPattern.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPattern.Name = "txtPattern";
            this.txtPattern.Size = new System.Drawing.Size(317, 20);
            this.txtPattern.TabIndex = 2;
            // 
            // btnAddPattern
            // 
            this.btnAddPattern.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAddPattern.Location = new System.Drawing.Point(323, 425);
            this.btnAddPattern.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddPattern.Name = "btnAddPattern";
            this.btnAddPattern.Size = new System.Drawing.Size(105, 28);
            this.btnAddPattern.TabIndex = 3;
            this.btnAddPattern.Text = "Add";
            this.btnAddPattern.UseVisualStyleBackColor = true;
            this.btnAddPattern.Click += new System.EventHandler(this.btnAddPattern_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 371);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 52);
            this.label1.TabIndex = 4;
            this.label1.Text = "                     Foreground:\r\n\r\nRegex:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 381);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Background";
            // 
            // btnChooseTextColor
            // 
            this.btnChooseTextColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnChooseTextColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChooseTextColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChooseTextColor.Location = new System.Drawing.Point(109, 372);
            this.btnChooseTextColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChooseTextColor.Name = "btnChooseTextColor";
            this.btnChooseTextColor.Size = new System.Drawing.Size(34, 30);
            this.btnChooseTextColor.TabIndex = 7;
            this.btnChooseTextColor.UseVisualStyleBackColor = true;
            this.btnChooseTextColor.Click += new System.EventHandler(this.btnChooseTextColor_Click);
            // 
            // btnImportList
            // 
            this.btnImportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImportList.Location = new System.Drawing.Point(2, 283);
            this.btnImportList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnImportList.Name = "btnImportList";
            this.btnImportList.Size = new System.Drawing.Size(103, 67);
            this.btnImportList.TabIndex = 10;
            this.btnImportList.Text = "Import";
            this.btnImportList.UseVisualStyleBackColor = true;
            this.btnImportList.Click += new System.EventHandler(this.btnImportList_Click);
            // 
            // btnExportList
            // 
            this.btnExportList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExportList.Location = new System.Drawing.Point(109, 283);
            this.btnExportList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportList.Name = "btnExportList";
            this.btnExportList.Size = new System.Drawing.Size(103, 67);
            this.btnExportList.TabIndex = 11;
            this.btnExportList.Text = "Export";
            this.btnExportList.UseVisualStyleBackColor = true;
            this.btnExportList.Click += new System.EventHandler(this.btnExportList_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemove.Location = new System.Drawing.Point(323, 283);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(105, 67);
            this.btnRemove.TabIndex = 12;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lstHighlights
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lstHighlights, 4);
            this.lstHighlights.DisplayMember = "Pattern";
            this.lstHighlights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHighlights.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstHighlights.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lstHighlights.FormattingEnabled = true;
            this.lstHighlights.ItemHeight = 25;
            this.lstHighlights.Location = new System.Drawing.Point(2, 2);
            this.lstHighlights.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstHighlights.Name = "lstHighlights";
            this.lstHighlights.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstHighlights.Size = new System.Drawing.Size(426, 277);
            this.lstHighlights.TabIndex = 13;
            this.lstHighlights.ValueMember = "Pattern";
            this.lstHighlights.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstHighlights_DrawItem);
            this.lstHighlights.SelectedIndexChanged += new System.EventHandler(this.lstHighlights_SelectedIndexChanged);
            // 
            // HighlightPreferencesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 569);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "HighlightPreferencesDialog";
            this.Text = "Highlighting...";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPattern;
        private System.Windows.Forms.Button btnAddPattern;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChooseTextColor;
        private System.Windows.Forms.Button btnChooseBackColor;
        private System.Windows.Forms.Button btnImportList;
        private System.Windows.Forms.Button btnExportList;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lstHighlights;
    }
}