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
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.saveFilteredRowsAsLog4NetContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelHighlighted = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpan = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelLines = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openLog4netLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appendLog4netLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilteredRowsAsLog4NetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contributeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToggleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterDebounceTimer = new System.Windows.Forms.Timer(this.components);
            this.gridLogsViewer = new System.Windows.Forms.DataGridView();
            this.lblLevel = new System.Windows.Forms.Label();
            this.chkLevelError = new System.Windows.Forms.CheckBox();
            this.chkLevelFatal = new System.Windows.Forms.CheckBox();
            this.chkLevelWarn = new System.Windows.Forms.CheckBox();
            this.chkLevelInfo = new System.Windows.Forms.CheckBox();
            this.chkLevelDebug = new System.Windows.Forms.CheckBox();
            this.chkLevelTrace = new System.Windows.Forms.CheckBox();
            this.chkLevelOther = new System.Windows.Forms.CheckBox();
            this.chkTailMode = new System.Windows.Forms.CheckBox();
            this.lblFilter = new System.Windows.Forms.Label();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.lblTimeRange = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnClearTimeRange = new System.Windows.Forms.Button();
            this.tailTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.filterOverlayPanel = new System.Windows.Forms.Panel();
            this.filterOverlayInnerTable = new System.Windows.Forms.TableLayoutPanel();
            this.filterHeaderTable = new System.Windows.Forms.TableLayoutPanel();
            this.lblFiltersHeader = new System.Windows.Forms.Label();
            this.btnCloseFilter = new System.Windows.Forms.Button();
            this.filterSearchRowFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.filterLevelFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.filterTimeFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.ctxGridMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLogsViewer)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.filterOverlayPanel.SuspendLayout();
            this.filterOverlayInnerTable.SuspendLayout();
            this.filterHeaderTable.SuspendLayout();
            this.filterSearchRowFlow.SuspendLayout();
            this.filterLevelFlow.SuspendLayout();
            this.filterTimeFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(53, 3);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(55, 24);
            this.btnClearFilter.TabIndex = 3;
            this.btnClearFilter.Text = "Clear";
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
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
            this.toolStripMenuItemCopy,
            this.toolStripSeparator6,
            this.saveFilteredRowsAsLog4NetContextMenuItem});
            this.ctxGridMenu.Name = "ctxGridMenu";
            this.ctxGridMenu.Size = new System.Drawing.Size(229, 226);
            // 
            // menuRemoveUnhighlighted
            // 
            this.menuRemoveUnhighlighted.Name = "menuRemoveUnhighlighted";
            this.menuRemoveUnhighlighted.Size = new System.Drawing.Size(228, 22);
            this.menuRemoveUnhighlighted.Text = "Remove Unhighlited";
            this.menuRemoveUnhighlighted.Click += new System.EventHandler(this.menuRemoveUnhighlighted_Click);
            // 
            // removeHighlightedToolStripMenuItem
            // 
            this.removeHighlightedToolStripMenuItem.Name = "removeHighlightedToolStripMenuItem";
            this.removeHighlightedToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.removeHighlightedToolStripMenuItem.Text = "Remove Highlighted";
            this.removeHighlightedToolStripMenuItem.Click += new System.EventHandler(this.removeHighlightedToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(225, 6);
            // 
            // toolStripMenuItemRemoveBefore
            // 
            this.toolStripMenuItemRemoveBefore.Name = "toolStripMenuItemRemoveBefore";
            this.toolStripMenuItemRemoveBefore.Size = new System.Drawing.Size(228, 22);
            this.toolStripMenuItemRemoveBefore.Text = "Remove Before Selected";
            this.toolStripMenuItemRemoveBefore.Click += new System.EventHandler(this.toolStripMenuItemRemoveBefore_Click);
            // 
            // toolStripMenuItemRemoveAfter
            // 
            this.toolStripMenuItemRemoveAfter.Name = "toolStripMenuItemRemoveAfter";
            this.toolStripMenuItemRemoveAfter.Size = new System.Drawing.Size(228, 22);
            this.toolStripMenuItemRemoveAfter.Text = "Remove After Selected";
            this.toolStripMenuItemRemoveAfter.Click += new System.EventHandler(this.toolStripMenuItemRemoveAfter_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(225, 6);
            // 
            // removeSelectedToolStripMenuItem
            // 
            this.removeSelectedToolStripMenuItem.Name = "removeSelectedToolStripMenuItem";
            this.removeSelectedToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.removeSelectedToolStripMenuItem.Text = "Remove Selected";
            this.removeSelectedToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedToolStripMenuItem_Click);
            // 
            // removeUnselectedToolStripMenuItem
            // 
            this.removeUnselectedToolStripMenuItem.Name = "removeUnselectedToolStripMenuItem";
            this.removeUnselectedToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.removeUnselectedToolStripMenuItem.Text = "Remove Unselected";
            this.removeUnselectedToolStripMenuItem.Click += new System.EventHandler(this.removeUnselectedToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(225, 6);
            // 
            // toolStripMenuRemoveText
            // 
            this.toolStripMenuRemoveText.Name = "toolStripMenuRemoveText";
            this.toolStripMenuRemoveText.Size = new System.Drawing.Size(228, 22);
            this.toolStripMenuRemoveText.Text = "Remove By Text Pattern...";
            this.toolStripMenuRemoveText.Click += new System.EventHandler(this.toolStripMenuRemoveText_Click);
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(228, 22);
            this.toolStripMenuItemCopy.Text = "Copy";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(225, 6);
            // 
            // saveFilteredRowsAsLog4NetContextMenuItem
            // 
            this.saveFilteredRowsAsLog4NetContextMenuItem.Enabled = false;
            this.saveFilteredRowsAsLog4NetContextMenuItem.Name = "saveFilteredRowsAsLog4NetContextMenuItem";
            this.saveFilteredRowsAsLog4NetContextMenuItem.Size = new System.Drawing.Size(228, 22);
            this.saveFilteredRowsAsLog4NetContextMenuItem.Text = "Save filtered rows as Log4Net";
            this.saveFilteredRowsAsLog4NetContextMenuItem.Click += new System.EventHandler(this.saveFilteredRowsAsLog4NetToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelHighlighted,
            this.toolStripStatusLabelSpan,
            this.toolStripStatusLabelFiles,
            this.toolStripStatusLabelLines,
            this.toolStripProgressBar,
            this.toolStripStatusLabelSpacer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1172);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1432, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelHighlighted
            // 
            this.toolStripStatusLabelHighlighted.Name = "toolStripStatusLabelHighlighted";
            this.toolStripStatusLabelHighlighted.Size = new System.Drawing.Size(19, 17);
            this.toolStripStatusLabelHighlighted.Text = "—";
            // 
            // toolStripStatusLabelSpan
            // 
            this.toolStripStatusLabelSpan.Name = "toolStripStatusLabelSpan";
            this.toolStripStatusLabelSpan.Size = new System.Drawing.Size(19, 17);
            this.toolStripStatusLabelSpan.Text = "—";
            // 
            // toolStripStatusLabelFiles
            // 
            this.toolStripStatusLabelFiles.Name = "toolStripStatusLabelFiles";
            this.toolStripStatusLabelFiles.Size = new System.Drawing.Size(19, 17);
            this.toolStripStatusLabelFiles.Text = "—";
            // 
            // toolStripStatusLabelLines
            // 
            this.toolStripStatusLabelSpacer.Name = "toolStripStatusLabelSpacer";
            this.toolStripStatusLabelSpacer.Size = new System.Drawing.Size(19, 17);
            this.toolStripStatusLabelSpacer.Spring = true;
            //
            // toolStripStatusLabelLines
            //
            this.toolStripStatusLabelLines.Name = "toolStripStatusLabelLines";
            this.toolStripStatusLabelLines.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabelLines.Text = "Lines: 0";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(150, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.aboutToolStripMenuItem,
            this.filtersToggleMenuItem});
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
            this.saveFilteredRowsAsLog4NetToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openLog4netLogsToolStripMenuItem
            // 
            this.openLog4netLogsToolStripMenuItem.Name = "openLog4netLogsToolStripMenuItem";
            this.openLog4netLogsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.openLog4netLogsToolStripMenuItem.Text = "Open Log4net logs...";
            this.openLog4netLogsToolStripMenuItem.Click += new System.EventHandler(this.openLog4netLogsToolStripMenuItem_Click);
            // 
            // appendLog4netLogsToolStripMenuItem
            // 
            this.appendLog4netLogsToolStripMenuItem.Name = "appendLog4netLogsToolStripMenuItem";
            this.appendLog4netLogsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.appendLog4netLogsToolStripMenuItem.Text = "Append Log4net logs...";
            this.appendLog4netLogsToolStripMenuItem.Click += new System.EventHandler(this.appendLog4netLogsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(225, 6);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveAsLogToolStripMenuItem
            // 
            this.saveAsLogToolStripMenuItem.Enabled = false;
            this.saveAsLogToolStripMenuItem.Name = "saveAsLogToolStripMenuItem";
            this.saveAsLogToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.saveAsLogToolStripMenuItem.Text = "Save As Log4Net";
            this.saveAsLogToolStripMenuItem.Click += new System.EventHandler(this.saveAsLogToolStripMenuItem_Click);
            // 
            // saveFilteredRowsAsLog4NetToolStripMenuItem
            // 
            this.saveFilteredRowsAsLog4NetToolStripMenuItem.Enabled = false;
            this.saveFilteredRowsAsLog4NetToolStripMenuItem.Name = "saveFilteredRowsAsLog4NetToolStripMenuItem";
            this.saveFilteredRowsAsLog4NetToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.saveFilteredRowsAsLog4NetToolStripMenuItem.Text = "Save filtered rows as Log4Net";
            this.saveFilteredRowsAsLog4NetToolStripMenuItem.Click += new System.EventHandler(this.saveFilteredRowsAsLog4NetToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(225, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
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
            // filtersToggleMenuItem
            // 
            this.filtersToggleMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.filtersToggleMenuItem.Name = "filtersToggleMenuItem";
            this.filtersToggleMenuItem.Size = new System.Drawing.Size(63, 20);
            this.filtersToggleMenuItem.Text = "Filters ▾";
            this.filtersToggleMenuItem.Click += new System.EventHandler(this.filtersToggleMenuItem_Click);
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
            this.gridLogsViewer.Location = new System.Drawing.Point(0, 24);
            this.gridLogsViewer.Margin = new System.Windows.Forms.Padding(0);
            this.gridLogsViewer.Name = "gridLogsViewer";
            this.gridLogsViewer.ReadOnly = true;
            this.gridLogsViewer.RowHeadersWidth = 51;
            this.gridLogsViewer.RowTemplate.Height = 24;
            this.gridLogsViewer.Size = new System.Drawing.Size(1432, 1170);
            this.gridLogsViewer.TabIndex = 1;
            this.gridLogsViewer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLogsViewer_CellClick);
            this.gridLogsViewer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLogsViewer_CellDoubleClick);
            this.gridLogsViewer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridLogsViewer_KeyDown);
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
            this.chkLevelTrace.Location = new System.Drawing.Point(5, 32);
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
            this.chkLevelOther.Location = new System.Drawing.Point(62, 32);
            this.chkLevelOther.Margin = new System.Windows.Forms.Padding(2);
            this.chkLevelOther.Name = "chkLevelOther";
            this.chkLevelOther.Size = new System.Drawing.Size(47, 23);
            this.chkLevelOther.TabIndex = 7;
            this.chkLevelOther.Text = "(other)";
            this.chkLevelOther.CheckedChanged += new System.EventHandler(this.levelButton_CheckedChanged);
            // 
            // chkTailMode
            // 
            this.chkTailMode.AutoSize = true;
            this.chkTailMode.Location = new System.Drawing.Point(20, 193);
            this.chkTailMode.Margin = new System.Windows.Forms.Padding(20, 7, 2, 2);
            this.chkTailMode.Name = "chkTailMode";
            this.chkTailMode.Size = new System.Drawing.Size(73, 17);
            this.chkTailMode.TabIndex = 8;
            this.chkTailMode.Text = "Tail Mode";
            this.chkTailMode.CheckedChanged += new System.EventHandler(this.chkTailMode_CheckedChanged);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Location = new System.Drawing.Point(3, 3);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(44, 13);
            this.lblFilter.TabIndex = 0;
            this.lblFilter.Text = "Search:";
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // filterTextBox
            // 
            this.filterTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTextBox.Location = new System.Drawing.Point(3, 74);
            this.filterTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(350, 20);
            this.filterTextBox.TabIndex = 1;
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            this.filterTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.filterTextBox_KeyDown);
            // 
            // lblTimeRange
            // 
            this.lblTimeRange.AutoSize = true;
            this.lblTimeRange.Location = new System.Drawing.Point(6, 9);
            this.lblTimeRange.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.lblTimeRange.Name = "lblTimeRange";
            this.lblTimeRange.Size = new System.Drawing.Size(63, 13);
            this.lblTimeRange.TabIndex = 0;
            this.lblTimeRange.Text = "Time range:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Checked = false;
            this.dtpFrom.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(74, 5);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(140, 20);
            this.dtpFrom.TabIndex = 1;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpTimeRange_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Checked = false;
            this.dtpTo.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(218, 5);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size(140, 20);
            this.dtpTo.TabIndex = 2;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTimeRange_ValueChanged);
            // 
            // btnClearTimeRange
            // 
            this.btnClearTimeRange.Location = new System.Drawing.Point(363, 6);
            this.btnClearTimeRange.Name = "btnClearTimeRange";
            this.btnClearTimeRange.Size = new System.Drawing.Size(110, 24);
            this.btnClearTimeRange.TabIndex = 3;
            this.btnClearTimeRange.Text = "Clear time range";
            this.btnClearTimeRange.Click += new System.EventHandler(this.btnClearTimeRange_Click);
            // 
            // tailTimer
            // 
            this.tailTimer.Interval = 2000;
            this.tailTimer.Tick += new System.EventHandler(this.tailTimer_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridLogsViewer, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 24, 0, 0);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1432, 1194);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // filterOverlayPanel
            // 
            this.filterOverlayPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.filterOverlayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filterOverlayPanel.Controls.Add(this.filterOverlayInnerTable);
            this.filterOverlayPanel.Location = new System.Drawing.Point(0, 0);
            this.filterOverlayPanel.Name = "filterOverlayPanel";
            this.filterOverlayPanel.Padding = new System.Windows.Forms.Padding(6);
            this.filterOverlayPanel.Size = new System.Drawing.Size(370, 265);
            this.filterOverlayPanel.TabIndex = 3;
            this.filterOverlayPanel.Visible = false;
            // 
            // filterOverlayInnerTable
            // 
            this.filterOverlayInnerTable.ColumnCount = 1;
            this.filterOverlayInnerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filterOverlayInnerTable.Controls.Add(this.filterHeaderTable, 0, 0);
            this.filterOverlayInnerTable.Controls.Add(this.filterSearchRowFlow, 0, 1);
            this.filterOverlayInnerTable.Controls.Add(this.filterTextBox, 0, 2);
            this.filterOverlayInnerTable.Controls.Add(this.filterLevelFlow, 0, 3);
            this.filterOverlayInnerTable.Controls.Add(this.filterTimeFlow, 0, 4);
            this.filterOverlayInnerTable.Controls.Add(this.chkTailMode, 0, 5);
            this.filterOverlayInnerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterOverlayInnerTable.Location = new System.Drawing.Point(6, 6);
            this.filterOverlayInnerTable.Name = "filterOverlayInnerTable";
            this.filterOverlayInnerTable.RowCount = 6;
            this.filterOverlayInnerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.filterOverlayInnerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.filterOverlayInnerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.filterOverlayInnerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.filterOverlayInnerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.filterOverlayInnerTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.filterOverlayInnerTable.Size = new System.Drawing.Size(356, 251);
            this.filterOverlayInnerTable.TabIndex = 0;
            // 
            // filterHeaderTable
            // 
            this.filterHeaderTable.AutoSize = true;
            this.filterHeaderTable.ColumnCount = 2;
            this.filterHeaderTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.filterHeaderTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.filterHeaderTable.Controls.Add(this.lblFiltersHeader, 0, 0);
            this.filterHeaderTable.Controls.Add(this.btnCloseFilter, 1, 0);
            this.filterHeaderTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterHeaderTable.Location = new System.Drawing.Point(3, 3);
            this.filterHeaderTable.Name = "filterHeaderTable";
            this.filterHeaderTable.RowCount = 1;
            this.filterHeaderTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.filterHeaderTable.Size = new System.Drawing.Size(350, 30);
            this.filterHeaderTable.TabIndex = 0;
            // 
            // lblFiltersHeader
            // 
            this.lblFiltersHeader.AutoSize = true;
            this.lblFiltersHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFiltersHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltersHeader.Location = new System.Drawing.Point(3, 0);
            this.lblFiltersHeader.Name = "lblFiltersHeader";
            this.lblFiltersHeader.Size = new System.Drawing.Size(316, 30);
            this.lblFiltersHeader.TabIndex = 0;
            this.lblFiltersHeader.Text = "Filters";
            this.lblFiltersHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCloseFilter
            // 
            this.btnCloseFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseFilter.Location = new System.Drawing.Point(325, 3);
            this.btnCloseFilter.Name = "btnCloseFilter";
            this.btnCloseFilter.Size = new System.Drawing.Size(22, 24);
            this.btnCloseFilter.TabIndex = 0;
            this.btnCloseFilter.Text = "×";
            this.btnCloseFilter.Click += new System.EventHandler(this.btnCloseFilter_Click);
            // 
            // filterSearchRowFlow
            // 
            this.filterSearchRowFlow.AutoSize = true;
            this.filterSearchRowFlow.Controls.Add(this.lblFilter);
            this.filterSearchRowFlow.Controls.Add(this.btnClearFilter);
            this.filterSearchRowFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterSearchRowFlow.Location = new System.Drawing.Point(3, 39);
            this.filterSearchRowFlow.Name = "filterSearchRowFlow";
            this.filterSearchRowFlow.Size = new System.Drawing.Size(350, 30);
            this.filterSearchRowFlow.TabIndex = 10;
            // 
            // filterLevelFlow
            // 
            this.filterLevelFlow.AutoSize = true;
            this.filterLevelFlow.Controls.Add(this.lblLevel);
            this.filterLevelFlow.Controls.Add(this.chkLevelError);
            this.filterLevelFlow.Controls.Add(this.chkLevelFatal);
            this.filterLevelFlow.Controls.Add(this.chkLevelWarn);
            this.filterLevelFlow.Controls.Add(this.chkLevelInfo);
            this.filterLevelFlow.Controls.Add(this.chkLevelDebug);
            this.filterLevelFlow.Controls.Add(this.chkLevelTrace);
            this.filterLevelFlow.Controls.Add(this.chkLevelOther);
            this.filterLevelFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterLevelFlow.Location = new System.Drawing.Point(0, 96);
            this.filterLevelFlow.Margin = new System.Windows.Forms.Padding(0);
            this.filterLevelFlow.Name = "filterLevelFlow";
            this.filterLevelFlow.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.filterLevelFlow.Size = new System.Drawing.Size(356, 57);
            this.filterLevelFlow.TabIndex = 11;
            // 
            // filterTimeFlow
            // 
            this.filterTimeFlow.AutoSize = true;
            this.filterTimeFlow.Controls.Add(this.lblTimeRange);
            this.filterTimeFlow.Controls.Add(this.dtpFrom);
            this.filterTimeFlow.Controls.Add(this.dtpTo);
            this.filterTimeFlow.Controls.Add(this.btnClearTimeRange);
            this.filterTimeFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterTimeFlow.Location = new System.Drawing.Point(0, 153);
            this.filterTimeFlow.Margin = new System.Windows.Forms.Padding(0);
            this.filterTimeFlow.Name = "filterTimeFlow";
            this.filterTimeFlow.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.filterTimeFlow.Size = new System.Drawing.Size(356, 33);
            this.filterTimeFlow.TabIndex = 12;
            this.filterTimeFlow.WrapContents = false;
            // 
            // FormMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 1194);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.filterOverlayPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMainForm";
            this.Text = "Log4Merge";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.FormMainForm_Shown);
            this.Resize += new System.EventHandler(this.FormMainForm_Resize);
            this.ctxGridMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLogsViewer)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.filterOverlayPanel.ResumeLayout(false);
            this.filterOverlayInnerTable.ResumeLayout(false);
            this.filterOverlayInnerTable.PerformLayout();
            this.filterHeaderTable.ResumeLayout(false);
            this.filterHeaderTable.PerformLayout();
            this.filterSearchRowFlow.ResumeLayout(false);
            this.filterSearchRowFlow.PerformLayout();
            this.filterLevelFlow.ResumeLayout(false);
            this.filterLevelFlow.PerformLayout();
            this.filterTimeFlow.ResumeLayout(false);
            this.filterTimeFlow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLines;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelHighlighted;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpan;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFiles;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
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
        private System.Windows.Forms.ToolStripMenuItem saveFilteredRowsAsLog4NetToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem saveFilteredRowsAsLog4NetContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveBefore;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveAfter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
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
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.CheckBox chkLevelError;
        private System.Windows.Forms.CheckBox chkLevelFatal;
        private System.Windows.Forms.CheckBox chkLevelWarn;
        private System.Windows.Forms.CheckBox chkLevelInfo;
        private System.Windows.Forms.CheckBox chkLevelDebug;
        private System.Windows.Forms.CheckBox chkLevelTrace;
        private System.Windows.Forms.CheckBox chkLevelOther;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label lblTimeRange;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnClearTimeRange;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox chkTailMode;
        private System.Windows.Forms.Timer tailTimer;
        private System.Windows.Forms.Panel filterOverlayPanel;
        private System.Windows.Forms.TableLayoutPanel filterOverlayInnerTable;
        private System.Windows.Forms.TableLayoutPanel filterHeaderTable;
        private System.Windows.Forms.Label lblFiltersHeader;
        private System.Windows.Forms.Button btnCloseFilter;
        private System.Windows.Forms.FlowLayoutPanel filterSearchRowFlow;
        private System.Windows.Forms.FlowLayoutPanel filterLevelFlow;
        private System.Windows.Forms.FlowLayoutPanel filterTimeFlow;
        private System.Windows.Forms.ToolStripMenuItem filtersToggleMenuItem;
    }
}

