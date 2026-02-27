namespace Log4Merge
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimeStampFormat = new System.Windows.Forms.Label();
            this.txtTimeStampFormat = new System.Windows.Forms.TextBox();
            this.lblLevelRegex = new System.Windows.Forms.Label();
            this.txtLevelRegex = new System.Windows.Forms.TextBox();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tableLayoutPanel1
            //
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblTimeStampFormat, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTimeStampFormat, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLevelRegex, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtLevelRegex, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanelButtons, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(12);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(484, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            //
            // lblTimeStampFormat
            //
            this.lblTimeStampFormat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimeStampFormat.AutoSize = true;
            this.lblTimeStampFormat.Location = new System.Drawing.Point(15, 5);
            this.lblTimeStampFormat.Name = "lblTimeStampFormat";
            this.lblTimeStampFormat.Size = new System.Drawing.Size(88, 13);
            this.lblTimeStampFormat.TabIndex = 0;
            this.lblTimeStampFormat.Text = "Timestamp format:";
            //
            // txtTimeStampFormat
            //
            this.txtTimeStampFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeStampFormat.Location = new System.Drawing.Point(15, 30);
            this.txtTimeStampFormat.Name = "txtTimeStampFormat";
            this.txtTimeStampFormat.Size = new System.Drawing.Size(454, 20);
            this.txtTimeStampFormat.TabIndex = 1;
            //
            // lblLevelRegex
            //
            this.lblLevelRegex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLevelRegex.AutoSize = true;
            this.lblLevelRegex.Location = new System.Drawing.Point(15, 63);
            this.lblLevelRegex.Name = "lblLevelRegex";
            this.lblLevelRegex.Size = new System.Drawing.Size(110, 13);
            this.lblLevelRegex.TabIndex = 2;
            this.lblLevelRegex.Text = "Level parsing regex:";
            //
            // txtLevelRegex
            //
            this.txtLevelRegex.AcceptsReturn = false;
            this.txtLevelRegex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLevelRegex.Location = new System.Drawing.Point(15, 84);
            this.txtLevelRegex.Multiline = true;
            this.txtLevelRegex.Name = "txtLevelRegex";
            this.txtLevelRegex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLevelRegex.Size = new System.Drawing.Size(454, 127);
            this.txtLevelRegex.TabIndex = 3;
            //
            // flowLayoutPanelButtons
            //
            this.flowLayoutPanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelButtons.Controls.Add(this.btnReset);
            this.flowLayoutPanelButtons.Controls.Add(this.btnCancel);
            this.flowLayoutPanelButtons.Controls.Add(this.btnOk);
            this.flowLayoutPanelButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(15, 222);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(454, 34);
            this.flowLayoutPanelButtons.TabIndex = 2;
            //
            // btnReset
            //
            this.btnReset.Location = new System.Drawing.Point(0, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(120, 25);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "Reset to defaults";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(126, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            //
            // btnOk
            //
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(207, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            //
            // SettingsForm
            //
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTimeStampFormat;
        private System.Windows.Forms.TextBox txtTimeStampFormat;
        private System.Windows.Forms.Label lblLevelRegex;
        private System.Windows.Forms.TextBox txtLevelRegex;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}
