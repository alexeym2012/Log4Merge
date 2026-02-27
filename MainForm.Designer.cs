namespace Log4Merge
{
    partial class FormMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainForm));
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.ctxGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuRemoveUnhighlighted = new System.Windows.Forms.ToolStripMenuItem();
            this.removeHighlightedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemRemoveBefore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRemoveAfter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
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
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contributeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filterDebounceTimer = new System.Windows.Forms.Timer(this.components);
            this.gridLogsViewer = new System.Windows.Forms.DataGridView();
            this.columnTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLogLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSourceFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnLineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTimeInvisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMessageInvisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelFilterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblLevel = new System.Windows.Forms.Label();
            this.chkLevelError = new System.Windows.Forms.CheckBox();
            this.chkLevelFatal = new System.Windows.Forms.CheckBox();
            this.chkLevelWarn = new System.Windows.Forms.CheckBox();
            this.chkLevelInfo = new System.Windows.Forms.CheckBox();
            this.chkLevelDebug = new System.Windows.Forms.CheckBox();
            this.chkLevelTrace = new System.Windows.Forms.CheckBox();
            this.chkLevelOther = new System.Windows.Forms.CheckBox();
            this.filterPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ctxGridMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLogsViewer)).BeginInit();
            this.levelFilterPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilter.Location = new System.Drawing.Point(430, 6);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(55, 24);
            this.btnClearFilter.TabIndex = 3;
            this.btnClearFilter.Text = "Clear";
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Location = new System.Drawing.Point(491, 6);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(55, 24);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filter";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
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
            this.ctxGridMenu.Size = new System.Drawing.Size(208, 198);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 1172);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1432, 22);
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
            this.menuStrip1.Size = new System.Drawing.Size(1432, 24);
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
            this.settingsToolStripMenuItem,
            this.highlightingToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(80, 20);
            this.toolStripMenuItem2.Text = "Preferences";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
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
            // filterDebounceTimer
            // 
            this.filterDebounceTimer.Interval = 400;
            this.filterDebounceTimer.Tick += new System.EventHandler(this.filterDebounceTimer_Tick);
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
            this.columnLogLevel,
            this.columnSourceFileName,
            this.columnLineNumber,
            this.columnTimeInvisible,
            this.columnMessageInvisible,
            this.columnMessage});
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
            this.gridLogsViewer.Location = new System.Drawing.Point(0, 139);
            this.gridLogsViewer.Margin = new System.Windows.Forms.Padding(0);
            this.gridLogsViewer.Name = "gridLogsViewer";
            this.gridLogsViewer.ReadOnly = true;
            this.gridLogsViewer.RowHeadersWidth = 51;
            this.gridLogsViewer.RowTemplate.Height = 24;
            this.gridLogsViewer.Size = new System.Drawing.Size(1432, 1055);
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
            // columnLogLevel
            // 
            this.columnLogLevel.DataPropertyName = "LogLevel";
            this.columnLogLevel.HeaderText = "Level";
            this.columnLogLevel.MinimumWidth = 6;
            this.columnLogLevel.Name = "columnLogLevel";
            this.columnLogLevel.ReadOnly = true;
            this.columnLogLevel.Width = 55;
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
            // levelFilterPanel
            // 
            this.levelFilterPanel.Controls.Add(this.lblLevel);
            this.levelFilterPanel.Controls.Add(this.chkLevelError);
            this.levelFilterPanel.Controls.Add(this.chkLevelFatal);
            this.levelFilterPanel.Controls.Add(this.chkLevelWarn);
            this.levelFilterPanel.Controls.Add(this.chkLevelInfo);
            this.levelFilterPanel.Controls.Add(this.chkLevelDebug);
            this.levelFilterPanel.Controls.Add(this.chkLevelTrace);
            this.levelFilterPanel.Controls.Add(this.chkLevelOther);
            this.levelFilterPanel.Controls.Add(this.btnClearFilter);
            this.levelFilterPanel.Controls.Add(this.btnFilter);
            this.levelFilterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelFilterPanel.Location = new System.Drawing.Point(0, 81);
            this.levelFilterPanel.Margin = new System.Windows.Forms.Padding(0);
            this.levelFilterPanel.Name = "levelFilterPanel";
            this.levelFilterPanel.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.levelFilterPanel.Size = new System.Drawing.Size(1432, 58);
            this.levelFilterPanel.TabIndex = 11;
            this.levelFilterPanel.WrapContents = false;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(6, 9);
            this.lblLevel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(36, 13);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Level:";
            // 
            // chkLevelError
            // 
            this.chkLevelError.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLevelError.AutoSize = true;
            this.chkLevelError.Checked = true;
            this.chkLevelError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLevelError.Location = new System.Drawing.Point(47, 5);
            this.chkLevelError.Margin = new System.Windows.Forms.Padding(2);
            this.chkLevelError.Name = "chkLevelError";
            this.chkLevelError.Size = new System.Drawing.Size(56, 23);
            this.chkLevelError.TabIndex = 1;
            this.chkLevelError.Text = "ERROR";
            this.chkLevelError.CheckedChanged += new System.EventHandler(this.levelButton_CheckedChanged);
            // 
            // chkLevelFatal
            // 
            this.chkLevelFatal.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLevelFatal.AutoSize = true;
            this.chkLevelFatal.Checked = true;
            this.chkLevelFatal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLevelFatal.Location = new System.Drawing.Point(107, 5);
            this.chkLevelFatal.Margin = new System.Windows.Forms.Padding(2);
            this.chkLevelFatal.Name = "chkLevelFatal";
            this.chkLevelFatal.Size = new System.Drawing.Size(50, 23);
            this.chkLevelFatal.TabIndex = 2;
            this.chkLevelFatal.Text = "FATAL";
            this.chkLevelFatal.CheckedChanged += new System.EventHandler(this.levelButton_CheckedChanged);
            // 
            // chkLevelWarn
            // 
            this.chkLevelWarn.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLevelWarn.AutoSize = true;
            this.chkLevelWarn.Checked = true;
            this.chkLevelWarn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLevelWarn.Location = new System.Drawing.Point(161, 5);
            this.chkLevelWarn.Margin = new System.Windows.Forms.Padding(2);
            this.chkLevelWarn.Name = "chkLevelWarn";
            this.chkLevelWarn.Size = new System.Drawing.Size(51, 23);
            this.chkLevelWarn.TabIndex = 3;
            this.chkLevelWarn.Text = "WARN";
            this.chkLevelWarn.CheckedChanged += new System.EventHandler(this.levelButton_CheckedChanged);
            // 
            // chkLevelInfo
            // 
            this.chkLevelInfo.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLevelInfo.AutoSize = true;
            this.chkLevelInfo.Checked = true;
            this.chkLevelInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLevelInfo.Location = new System.Drawing.Point(216, 5);
            this.chkLevelInfo.Margin = new System.Windows.Forms.Padding(2);
            this.chkLevelInfo.Name = "chkLevelInfo";
            this.chkLevelInfo.Size = new System.Drawing.Size(42, 23);
            this.chkLevelInfo.TabIndex = 4;
            this.chkLevelInfo.Text = "INFO";
            this.chkLevelInfo.CheckedChanged += new System.EventHandler(this.levelButton_CheckedChanged);
            // 
            // chkLevelDebug
            // 
            this.chkLevelDebug.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLevelDebug.AutoSize = true;
            this.chkLevelDebug.Checked = true;
            this.chkLevelDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLevelDebug.Location = new System.Drawing.Point(262, 5);
            this.chkLevelDebug.Margin = new System.Windows.Forms.Padding(2);
            this.chkLevelDebug.Name = "chkLevelDebug";
            this.chkLevelDebug.Size = new System.Drawing.Size(55, 23);
            this.chkLevelDebug.TabIndex = 5;
            this.chkLevelDebug.Text = "DEBUG";
            this.chkLevelDebug.CheckedChanged += new System.EventHandler(this.levelButton_CheckedChanged);
            // 
            // chkLevelTrace
            // 
            this.chkLevelTrace.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLevelTrace.AutoSize = true;
            this.chkLevelTrace.Checked = true;
            this.chkLevelTrace.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLevelTrace.Location = new System.Drawing.Point(321, 5);
            this.chkLevelTrace.Margin = new System.Windows.Forms.Padding(2);
            this.chkLevelTrace.Name = "chkLevelTrace";
            this.chkLevelTrace.Size = new System.Drawing.Size(53, 23);
            this.chkLevelTrace.TabIndex = 6;
            this.chkLevelTrace.Text = "TRACE";
            this.chkLevelTrace.CheckedChanged += new System.EventHandler(this.levelButton_CheckedChanged);
            // 
            // chkLevelOther
            // 
            this.chkLevelOther.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLevelOther.AutoSize = true;
            this.chkLevelOther.Checked = true;
            this.chkLevelOther.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLevelOther.Location = new System.Drawing.Point(378, 5);
            this.chkLevelOther.Margin = new System.Windows.Forms.Padding(2);
            this.chkLevelOther.Name = "chkLevelOther";
            this.chkLevelOther.Size = new System.Drawing.Size(47, 23);
            this.chkLevelOther.TabIndex = 7;
            this.chkLevelOther.Text = "(other)";
            this.chkLevelOther.CheckedChanged += new System.EventHandler(this.levelButton_CheckedChanged);
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.lblFilter);
            this.filterPanel.Controls.Add(this.filterTextBox);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterPanel.Location = new System.Drawing.Point(3, 26);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1426, 52);
            this.filterPanel.TabIndex = 10;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblFilter.Location = new System.Drawing.Point(3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(44, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Search:";
            // 
            // filterTextBox
            // 
            this.filterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTextBox.Location = new System.Drawing.Point(3, 16);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(1423, 20);
            this.filterTextBox.TabIndex = 1;
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            this.filterTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filterTextBox_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridLogsViewer, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.levelFilterPanel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.filterPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.960784F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.901961F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.901961F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.23529F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1432, 1194);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // FormMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 1194);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMainForm";
            this.Text = "Log4Merge";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ctxGridMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLogsViewer)).EndInit();
            this.levelFilterPanel.ResumeLayout(false);
            this.levelFilterPanel.PerformLayout();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLines;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLog4netLogsToolStripMenuItem;
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
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Timer filterDebounceTimer;
        private System.Windows.Forms.DataGridView gridLogsViewer;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLogLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSourceFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnLineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTimeInvisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMessageInvisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnMessage;
        private System.Windows.Forms.FlowLayoutPanel levelFilterPanel;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.CheckBox chkLevelError;
        private System.Windows.Forms.CheckBox chkLevelFatal;
        private System.Windows.Forms.CheckBox chkLevelWarn;
        private System.Windows.Forms.CheckBox chkLevelInfo;
        private System.Windows.Forms.CheckBox chkLevelDebug;
        private System.Windows.Forms.CheckBox chkLevelTrace;
        private System.Windows.Forms.CheckBox chkLevelOther;
        private System.Windows.Forms.FlowLayoutPanel filterPanel;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

