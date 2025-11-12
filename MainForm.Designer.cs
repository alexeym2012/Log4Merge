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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridLogsViewer = new System.Windows.Forms.DataGridView();
            this.columnTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSourceFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTimeInvisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMessageInvisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuRemoveUnhighlighted = new System.Windows.Forms.ToolStripMenuItem();
            this.removeHighlightedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.removeSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeUnselectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuRemoveText = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLines = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openLog4netLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendLog4netLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contributeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRemoveBefore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRemoveAfter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLogsViewer)).BeginInit();
            this.ctxGridMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 813F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(877, 813);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridLogsViewer
            // 
            this.gridLogsViewer.AllowUserToAddRows = false;
            this.gridLogsViewer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLogsViewer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLogsViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLogsViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnTimeStamp,
            this.columnSourceFileName,
            this.columnLineNumber,
            this.columnTimeInvisible,
            this.columnMessageInvisible,
            this.columnMessage});
            this.tableLayoutPanel1.SetColumnSpan(this.gridLogsViewer, 3);
            this.gridLogsViewer.ContextMenuStrip = this.ctxGridMenu;
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
            this.gridLogsViewer.Location = new System.Drawing.Point(2, 20);
            this.gridLogsViewer.Margin = new System.Windows.Forms.Padding(2, 20, 2, 2);
            this.gridLogsViewer.Name = "gridLogsViewer";
            this.gridLogsViewer.ReadOnly = true;
            this.gridLogsViewer.RowHeadersWidth = 51;
            this.gridLogsViewer.RowTemplate.Height = 24;
            this.gridLogsViewer.Size = new System.Drawing.Size(873, 791);
            this.gridLogsViewer.TabIndex = 1;
            this.gridLogsViewer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLogsViewer_CellClick);
            this.gridLogsViewer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLogsViewer_CellDoubleClick);
            this.gridLogsViewer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridLogsViewer_KeyDown);
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
            // columnSourceFileName
            // 
            this.columnSourceFileName.DataPropertyName = "SourceFileName";
            this.columnSourceFileName.HeaderText = "Source File";
            this.columnSourceFileName.MinimumWidth = 6;
            this.columnSourceFileName.Name = "columnSourceFileName";
            this.columnSourceFileName.ReadOnly = true;
            this.columnSourceFileName.Width = 125;
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
            // columnMessageInvisible
            // 
            this.columnMessageInvisible.DataPropertyName = "Message";
            this.columnMessageInvisible.HeaderText = "columnMessageInvisible";
            this.columnMessageInvisible.MinimumWidth = 2;
            this.columnMessageInvisible.Name = "columnMessageInvisible";
            this.columnMessageInvisible.ReadOnly = true;
            this.columnMessageInvisible.Visible = false;
            this.columnMessageInvisible.Width = 2;
            // 
            // columnMessage
            // 
            this.columnMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnMessage.DataPropertyName = "ShortMessage";
            this.columnMessage.HeaderText = "Log Message";
            this.columnMessage.MaxInputLength = 200000000;
            this.columnMessage.MinimumWidth = 6;
            this.columnMessage.Name = "columnMessage";
            this.columnMessage.ReadOnly = true;
            // 
            // ctxGridMenu
            // 
            this.ctxGridMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRemoveUnhighlighted,
            this.removeHighlightedToolStripMenuItem,
            this.toolStripSeparator2,
            this.toolStripMenuItemRemoveBefore,
            this.toolStripMenuItemRemoveAfter,
            this.toolStripSeparator4,
            this.removeSelectedToolStripMenuItem,
            this.removeUnselectedToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuRemoveText,
            this.toolStripMenuItemCopy});
            this.ctxGridMenu.Name = "ctxGridMenu";
            this.ctxGridMenu.Size = new System.Drawing.Size(208, 220);
            // 
            // menuRemoveUnhighlighted
            // 
            this.menuRemoveUnhighlighted.Name = "menuRemoveUnhighlighted";
            this.menuRemoveUnhighlighted.Size = new System.Drawing.Size(207, 22);
            this.menuRemoveUnhighlighted.Text = "Remove Unhighlited";
            this.menuRemoveUnhighlighted.Click += new System.EventHandler(this.menuRemoveUnhighlighted_Click);
            // 
            // removeHighlightedToolStripMenuItem
            // 
            this.removeHighlightedToolStripMenuItem.Name = "removeHighlightedToolStripMenuItem";
            this.removeHighlightedToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.removeHighlightedToolStripMenuItem.Text = "Remove Highlighted";
            this.removeHighlightedToolStripMenuItem.Click += new System.EventHandler(this.removeHighlightedToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(204, 6);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
            // 
            // removeUnselectedToolStripMenuItem
            // 
            this.removeUnselectedToolStripMenuItem.Name = "removeUnselectedToolStripMenuItem";
            this.removeUnselectedToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.removeUnselectedToolStripMenuItem.Text = "Remove Unselected";
            this.removeUnselectedToolStripMenuItem.Click += new System.EventHandler(this.removeUnselectedToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(204, 6);
            // 
            // toolStripMenuRemoveText
            // 
            this.toolStripMenuRemoveText.Name = "toolStripMenuRemoveText";
            this.toolStripMenuRemoveText.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuRemoveText.Text = "Remove By Text Pattern...";
            this.toolStripMenuRemoveText.Click += new System.EventHandler(this.toolStripMenuRemoveText_Click);
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItemCopy.Text = "Copy";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelLines});
            this.statusStrip1.Location = new System.Drawing.Point(0, 791);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(877, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelLines
            // 
            this.toolStripStatusLabelLines.Name = "toolStripStatusLabelLines";
            this.toolStripStatusLabelLines.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabelLines.Text = "Lines: 0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(877, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLog4netLogsToolStripMenuItem,
            this.appendLog4netLogsToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveAsToolStripMenuItem,
            this.saveAsLogToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openLog4netLogsToolStripMenuItem
            // 
            this.openLog4netLogsToolStripMenuItem.Name = "openLog4netLogsToolStripMenuItem";
            this.openLog4netLogsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.openLog4netLogsToolStripMenuItem.Text = "Open Log4net logs...";
            this.openLog4netLogsToolStripMenuItem.Click += new System.EventHandler(this.openLog4netLogsToolStripMenuItem_Click);
            // 
            // appendLog4netLogsToolStripMenuItem
            // 
            this.appendLog4netLogsToolStripMenuItem.Name = "appendLog4netLogsToolStripMenuItem";
            this.appendLog4netLogsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.appendLog4netLogsToolStripMenuItem.Text = "Append Log4net logs...";
            this.appendLog4netLogsToolStripMenuItem.Click += new System.EventHandler(this.appendLog4netLogsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveAsLogToolStripMenuItem
            // 
            this.saveAsLogToolStripMenuItem.Enabled = false;
            this.saveAsLogToolStripMenuItem.Name = "saveAsLogToolStripMenuItem";
            this.saveAsLogToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.saveAsLogToolStripMenuItem.Text = "Save As Log4Net";
            this.saveAsLogToolStripMenuItem.Click += new System.EventHandler(this.saveAsLogToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(193, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highlightingToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 20);
            this.toolStripMenuItem2.Text = "Preferences";
            // 
            // highlightingToolStripMenuItem
            // 
            this.highlightingToolStripMenuItem.Name = "highlightingToolStripMenuItem";
            this.highlightingToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.highlightingToolStripMenuItem.Text = "Highlighting...";
            this.highlightingToolStripMenuItem.Click += new System.EventHandler(this.highlightingToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contributeMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // contributeMenuItem
            // 
            this.contributeMenuItem.Name = "contributeMenuItem";
            this.contributeMenuItem.Size = new System.Drawing.Size(131, 22);
            this.contributeMenuItem.Text = "Contribute";
            this.contributeMenuItem.Click += new System.EventHandler(this.contributeMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // toolStripMenuItemRemoveBefore
            // 
            this.toolStripMenuItemRemoveBefore.Name = "toolStripMenuItemRemoveBefore";
            this.toolStripMenuItemRemoveBefore.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItemRemoveBefore.Text = "Remove Before Selected";
            this.toolStripMenuItemRemoveBefore.Click += new System.EventHandler(this.toolStripMenuItemRemoveBefore_Click);
            // 
            // toolStripMenuItemRemoveAfter
            // 
            this.toolStripMenuItemRemoveAfter.Name = "toolStripMenuItemRemoveAfter";
            this.toolStripMenuItemRemoveAfter.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItemRemoveAfter.Text = "Remove After Selected";
            this.toolStripMenuItemRemoveAfter.Click += new System.EventHandler(this.toolStripMenuItemRemoveAfter_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(204, 6);
            // 
            // formMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 813);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formMainForm";
            this.Text = "Log4Merge";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLogsViewer)).EndInit();
            this.ctxGridMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem appendLog4netLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contributeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ctxGridMenu;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveUnhighlighted;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeUnselectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeHighlightedToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSourceFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTimeInvisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMessageInvisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMessage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuRemoveText;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem saveAsLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveBefore;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveAfter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

