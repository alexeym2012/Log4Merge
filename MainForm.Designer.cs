namespace Log4Merge
{
    partial class formMainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLines = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLog4netLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTimeInvisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSourceFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCheckbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gridLogsViewer = new System.Windows.Forms.DataGridView();
            this.appendLog4netLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLogsViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.gridLogsViewer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1169, 1001);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLines});
            this.statusStrip1.Location = new System.Drawing.Point(0, 975);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1169, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelLines
            // 
            this.toolStripStatusLabelLines.Name = "toolStripStatusLabelLines";
            this.toolStripStatusLabelLines.Size = new System.Drawing.Size(57, 20);
            this.toolStripStatusLabelLines.Text = "Lines: 0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1169, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLog4netLogsToolStripMenuItem,
            this.appendLog4netLogsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 24);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highlightingToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(99, 24);
            this.toolStripMenuItem2.Text = "Preferences";
            // 
            // highlightingToolStripMenuItem
            // 
            this.highlightingToolStripMenuItem.Name = "highlightingToolStripMenuItem";
            this.highlightingToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.highlightingToolStripMenuItem.Text = "Highlighting...";
            this.highlightingToolStripMenuItem.Click += new System.EventHandler(this.highlightingToolStripMenuItem_Click);
            // 
            // openLog4netLogsToolStripMenuItem
            // 
            this.openLog4netLogsToolStripMenuItem.Name = "openLog4netLogsToolStripMenuItem";
            this.openLog4netLogsToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.openLog4netLogsToolStripMenuItem.Text = "Open Log4net logs...";
            this.openLog4netLogsToolStripMenuItem.Click += new System.EventHandler(this.openLog4netLogsToolStripMenuItem_Click);
            // 
            // columnMessage
            // 
            this.columnMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnMessage.DataPropertyName = "Message";
            this.columnMessage.HeaderText = "Log Message";
            this.columnMessage.MaxInputLength = 200000000;
            this.columnMessage.MinimumWidth = 6;
            this.columnMessage.Name = "columnMessage";
            this.columnMessage.ReadOnly = true;
            // 
            // columnTimeInvisible
            // 
            this.columnTimeInvisible.DataPropertyName = "TimeStamp";
            this.columnTimeInvisible.FillWeight = 2F;
            this.columnTimeInvisible.HeaderText = "columnTimeInvisible";
            this.columnTimeInvisible.MinimumWidth = 2;
            this.columnTimeInvisible.Name = "columnTimeInvisible";
            this.columnTimeInvisible.ReadOnly = true;
            this.columnTimeInvisible.Visible = false;
            this.columnTimeInvisible.Width = 2;
            // 
            // columnLineNumber
            // 
            this.columnLineNumber.DataPropertyName = "LineNumber";
            this.columnLineNumber.FillWeight = 50F;
            this.columnLineNumber.HeaderText = "Line";
            this.columnLineNumber.MinimumWidth = 6;
            this.columnLineNumber.Name = "columnLineNumber";
            this.columnLineNumber.ReadOnly = true;
            this.columnLineNumber.Width = 50;
            // 
            // columnSourceFileName
            // 
            this.columnSourceFileName.DataPropertyName = "SourceFileName";
            this.columnSourceFileName.HeaderText = "Source File";
            this.columnSourceFileName.MinimumWidth = 6;
            this.columnSourceFileName.Name = "columnSourceFileName";
            this.columnSourceFileName.ReadOnly = true;
            this.columnSourceFileName.Width = 125;
            // 
            // columnTimeStamp
            // 
            this.columnTimeStamp.DataPropertyName = "TimeStampAsText";
            this.columnTimeStamp.FillWeight = 130F;
            this.columnTimeStamp.HeaderText = "TimeStamp";
            this.columnTimeStamp.MinimumWidth = 6;
            this.columnTimeStamp.Name = "columnTimeStamp";
            this.columnTimeStamp.ReadOnly = true;
            this.columnTimeStamp.Width = 130;
            // 
            // columnCheckbox
            // 
            this.columnCheckbox.FillWeight = 30F;
            this.columnCheckbox.Frozen = true;
            this.columnCheckbox.HeaderText = "";
            this.columnCheckbox.MinimumWidth = 6;
            this.columnCheckbox.Name = "columnCheckbox";
            this.columnCheckbox.ReadOnly = true;
            this.columnCheckbox.Visible = false;
            this.columnCheckbox.Width = 30;
            // 
            // gridLogsViewer
            // 
            this.gridLogsViewer.AllowUserToAddRows = false;
            this.gridLogsViewer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLogsViewer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLogsViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLogsViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnCheckbox,
            this.columnTimeStamp,
            this.columnSourceFileName,
            this.columnLineNumber,
            this.columnTimeInvisible,
            this.columnMessage});
            this.tableLayoutPanel1.SetColumnSpan(this.gridLogsViewer, 3);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLogsViewer.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridLogsViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridLogsViewer.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridLogsViewer.Location = new System.Drawing.Point(3, 3);
            this.gridLogsViewer.Name = "gridLogsViewer";
            this.gridLogsViewer.ReadOnly = true;
            this.gridLogsViewer.RowHeadersWidth = 51;
            this.gridLogsViewer.RowTemplate.Height = 24;
            this.gridLogsViewer.Size = new System.Drawing.Size(1163, 995);
            this.gridLogsViewer.TabIndex = 1;
            this.gridLogsViewer.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridLogsViewer_CellMouseDoubleClick);
            this.gridLogsViewer.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.gridLogsViewer_RowPrePaint);
            this.gridLogsViewer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridLogsViewer_KeyDown);
            // 
            // appendLog4netLogsToolStripMenuItem
            // 
            this.appendLog4netLogsToolStripMenuItem.Name = "appendLog4netLogsToolStripMenuItem";
            this.appendLog4netLogsToolStripMenuItem.Size = new System.Drawing.Size(244, 26);
            this.appendLog4netLogsToolStripMenuItem.Text = "Append Log4net logs...";
            this.appendLog4netLogsToolStripMenuItem.Click += new System.EventHandler(this.appendLog4netLogsToolStripMenuItem_Click);
            // 
            // formMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 1001);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formMainForm";
            this.Text = "Log4Merge";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLogsViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLines;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem highlightingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLog4netLogsToolStripMenuItem;
        private System.Windows.Forms.DataGridView gridLogsViewer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnCheckbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSourceFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTimeInvisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMessage;
        private System.Windows.Forms.ToolStripMenuItem appendLog4netLogsToolStripMenuItem;
    }
}

