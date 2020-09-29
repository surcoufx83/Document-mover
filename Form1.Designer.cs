namespace Document_mover
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SourceMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RescanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DestinationsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OverrideMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.FileListFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.DeleteExistingFileButton = new System.Windows.Forms.Button();
            this.DeleteMailButton = new System.Windows.Forms.Button();
            this.DeleteSourceFileButton = new System.Windows.Forms.Button();
            this.MoveFileButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CopyFileButton = new System.Windows.Forms.Button();
            this.FileExistsLabel = new System.Windows.Forms.Label();
            this.FilenameLabel = new System.Windows.Forms.Label();
            this.DatetimeCheckbox = new System.Windows.Forms.CheckBox();
            this.ExtensionTextbox = new System.Windows.Forms.TextBox();
            this.FilenameTextbox2 = new System.Windows.Forms.TextBox();
            this.FilenameTextbox1 = new System.Windows.Forms.TextBox();
            this.DatetimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.DestinationFolderLabel = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.DestinationKeyList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.MailFilesFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.TopMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopMenuStrip
            // 
            this.TopMenuStrip.BackColor = System.Drawing.Color.Silver;
            this.TopMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.SourceMenu,
            this.DestinationsMenu});
            this.TopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.TopMenuStrip.Name = "TopMenuStrip";
            this.TopMenuStrip.Size = new System.Drawing.Size(1942, 30);
            this.TopMenuStrip.TabIndex = 0;
            this.TopMenuStrip.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsMenuItem,
            this.toolStripSeparator1,
            this.ExitMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(46, 26);
            this.FileMenu.Text = "&File";
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(169, 26);
            this.SettingsMenuItem.Text = "&Settings";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.ExitMenuItem.Size = new System.Drawing.Size(169, 26);
            this.ExitMenuItem.Text = "&Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // SourceMenu
            // 
            this.SourceMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RescanMenuItem});
            this.SourceMenu.Name = "SourceMenu";
            this.SourceMenu.Size = new System.Drawing.Size(133, 26);
            this.SourceMenu.Text = "&Source Directory";
            // 
            // RescanMenuItem
            // 
            this.RescanMenuItem.Name = "RescanMenuItem";
            this.RescanMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.RescanMenuItem.Size = new System.Drawing.Size(243, 26);
            this.RescanMenuItem.Text = "&Rescan folders";
            this.RescanMenuItem.Click += new System.EventHandler(this.RescanMenuItem_Click);
            // 
            // DestinationsMenu
            // 
            this.DestinationsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OverrideMenuItem});
            this.DestinationsMenu.Name = "DestinationsMenu";
            this.DestinationsMenu.Size = new System.Drawing.Size(105, 26);
            this.DestinationsMenu.Text = "&Destinations";
            // 
            // OverrideMenuItem
            // 
            this.OverrideMenuItem.CheckOnClick = true;
            this.OverrideMenuItem.Name = "OverrideMenuItem";
            this.OverrideMenuItem.Size = new System.Drawing.Size(224, 26);
            this.OverrideMenuItem.Text = "&Allow override";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel1MinSize = 900;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1942, 912);
            this.splitContainer1.SplitterDistance = 954;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer3.Panel2Collapsed = true;
            this.splitContainer3.Size = new System.Drawing.Size(954, 912);
            this.splitContainer3.SplitterDistance = 448;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer4);
            this.splitContainer2.Panel1MinSize = 250;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Silver;
            this.splitContainer2.Panel2.Controls.Add(this.DeleteExistingFileButton);
            this.splitContainer2.Panel2.Controls.Add(this.DeleteMailButton);
            this.splitContainer2.Panel2.Controls.Add(this.DeleteSourceFileButton);
            this.splitContainer2.Panel2.Controls.Add(this.MoveFileButton);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.CopyFileButton);
            this.splitContainer2.Panel2.Controls.Add(this.FileExistsLabel);
            this.splitContainer2.Panel2.Controls.Add(this.FilenameLabel);
            this.splitContainer2.Panel2.Controls.Add(this.DatetimeCheckbox);
            this.splitContainer2.Panel2.Controls.Add(this.ExtensionTextbox);
            this.splitContainer2.Panel2.Controls.Add(this.FilenameTextbox2);
            this.splitContainer2.Panel2.Controls.Add(this.FilenameTextbox1);
            this.splitContainer2.Panel2.Controls.Add(this.DatetimePicker);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.DestinationFolderLabel);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.DestinationKeyList);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer2.Panel2MinSize = 250;
            this.splitContainer2.Size = new System.Drawing.Size(984, 912);
            this.splitContainer2.SplitterDistance = 600;
            this.splitContainer2.TabIndex = 1;
            // 
            // FileListFlow
            // 
            this.FileListFlow.AutoScroll = true;
            this.FileListFlow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.FileListFlow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FileListFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileListFlow.Location = new System.Drawing.Point(0, 0);
            this.FileListFlow.Name = "FileListFlow";
            this.FileListFlow.Size = new System.Drawing.Size(984, 600);
            this.FileListFlow.TabIndex = 0;
            // 
            // DeleteExistingFileButton
            // 
            this.DeleteExistingFileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteExistingFileButton.ForeColor = System.Drawing.Color.DarkRed;
            this.DeleteExistingFileButton.Location = new System.Drawing.Point(668, 124);
            this.DeleteExistingFileButton.Name = "DeleteExistingFileButton";
            this.DeleteExistingFileButton.Size = new System.Drawing.Size(217, 36);
            this.DeleteExistingFileButton.TabIndex = 18;
            this.DeleteExistingFileButton.Text = "Delete existing file";
            this.DeleteExistingFileButton.UseVisualStyleBackColor = true;
            this.DeleteExistingFileButton.Visible = false;
            this.DeleteExistingFileButton.Click += new System.EventHandler(this.DeleteExistingFileButton_Click);
            // 
            // DeleteMailButton
            // 
            this.DeleteMailButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteMailButton.Location = new System.Drawing.Point(455, 144);
            this.DeleteMailButton.Name = "DeleteMailButton";
            this.DeleteMailButton.Size = new System.Drawing.Size(87, 68);
            this.DeleteMailButton.TabIndex = 17;
            this.DeleteMailButton.Text = "Delete\r\nmail";
            this.DeleteMailButton.UseVisualStyleBackColor = true;
            this.DeleteMailButton.Visible = false;
            this.DeleteMailButton.Click += new System.EventHandler(this.DeleteMailButton_Click);
            // 
            // DeleteSourceFileButton
            // 
            this.DeleteSourceFileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSourceFileButton.Location = new System.Drawing.Point(342, 144);
            this.DeleteSourceFileButton.Name = "DeleteSourceFileButton";
            this.DeleteSourceFileButton.Size = new System.Drawing.Size(87, 68);
            this.DeleteSourceFileButton.TabIndex = 15;
            this.DeleteSourceFileButton.Text = "Delete\r\nsource\r\nfile";
            this.DeleteSourceFileButton.UseVisualStyleBackColor = true;
            this.DeleteSourceFileButton.Visible = false;
            this.DeleteSourceFileButton.Click += new System.EventHandler(this.DeleteSourceFileButton_Click);
            // 
            // MoveFileButton
            // 
            this.MoveFileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MoveFileButton.Location = new System.Drawing.Point(229, 144);
            this.MoveFileButton.Name = "MoveFileButton";
            this.MoveFileButton.Size = new System.Drawing.Size(87, 68);
            this.MoveFileButton.TabIndex = 14;
            this.MoveFileButton.Text = "Move\r\nfile";
            this.MoveFileButton.UseVisualStyleBackColor = true;
            this.MoveFileButton.Visible = false;
            this.MoveFileButton.Click += new System.EventHandler(this.MoveFileButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Actions:";
            // 
            // CopyFileButton
            // 
            this.CopyFileButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyFileButton.Location = new System.Drawing.Point(116, 144);
            this.CopyFileButton.Name = "CopyFileButton";
            this.CopyFileButton.Size = new System.Drawing.Size(87, 68);
            this.CopyFileButton.TabIndex = 12;
            this.CopyFileButton.Text = "Copy\r\nfile";
            this.CopyFileButton.UseVisualStyleBackColor = true;
            this.CopyFileButton.Visible = false;
            this.CopyFileButton.Click += new System.EventHandler(this.CopyFileButton_Click);
            // 
            // FileExistsLabel
            // 
            this.FileExistsLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileExistsLabel.ForeColor = System.Drawing.Color.Brown;
            this.FileExistsLabel.Location = new System.Drawing.Point(664, 98);
            this.FileExistsLabel.Name = "FileExistsLabel";
            this.FileExistsLabel.Size = new System.Drawing.Size(216, 23);
            this.FileExistsLabel.TabIndex = 11;
            this.FileExistsLabel.Text = "File already exists!";
            this.FileExistsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FileExistsLabel.Visible = false;
            // 
            // FilenameLabel
            // 
            this.FilenameLabel.AutoSize = true;
            this.FilenameLabel.Location = new System.Drawing.Point(113, 100);
            this.FilenameLabel.Name = "FilenameLabel";
            this.FilenameLabel.Size = new System.Drawing.Size(105, 20);
            this.FilenameLabel.TabIndex = 10;
            this.FilenameLabel.Text = "FilenameLabel";
            // 
            // DatetimeCheckbox
            // 
            this.DatetimeCheckbox.AutoSize = true;
            this.DatetimeCheckbox.Checked = true;
            this.DatetimeCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DatetimeCheckbox.Location = new System.Drawing.Point(97, 75);
            this.DatetimeCheckbox.Name = "DatetimeCheckbox";
            this.DatetimeCheckbox.Size = new System.Drawing.Size(18, 17);
            this.DatetimeCheckbox.TabIndex = 9;
            this.DatetimeCheckbox.UseVisualStyleBackColor = true;
            this.DatetimeCheckbox.CheckedChanged += new System.EventHandler(this.DatetimeCheckbox_CheckedChanged);
            // 
            // ExtensionTextbox
            // 
            this.ExtensionTextbox.Location = new System.Drawing.Point(794, 69);
            this.ExtensionTextbox.Name = "ExtensionTextbox";
            this.ExtensionTextbox.ReadOnly = true;
            this.ExtensionTextbox.Size = new System.Drawing.Size(64, 27);
            this.ExtensionTextbox.TabIndex = 8;
            // 
            // FilenameTextbox2
            // 
            this.FilenameTextbox2.Location = new System.Drawing.Point(394, 69);
            this.FilenameTextbox2.Name = "FilenameTextbox2";
            this.FilenameTextbox2.Size = new System.Drawing.Size(394, 27);
            this.FilenameTextbox2.TabIndex = 7;
            this.FilenameTextbox2.TextChanged += new System.EventHandler(this.FilenameTextbox2_TextChanged);
            this.FilenameTextbox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FilenameTextbox2_KeyUp);
            // 
            // FilenameTextbox1
            // 
            this.FilenameTextbox1.Location = new System.Drawing.Point(224, 69);
            this.FilenameTextbox1.Name = "FilenameTextbox1";
            this.FilenameTextbox1.Size = new System.Drawing.Size(164, 27);
            this.FilenameTextbox1.TabIndex = 6;
            this.FilenameTextbox1.TextChanged += new System.EventHandler(this.FilenameTextbox1_TextChanged);
            this.FilenameTextbox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FilenameTextbox1_KeyUp);
            // 
            // DatetimePicker
            // 
            this.DatetimePicker.CalendarMonthBackground = System.Drawing.SystemColors.ControlLight;
            this.DatetimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatetimePicker.Location = new System.Drawing.Point(116, 69);
            this.DatetimePicker.Name = "DatetimePicker";
            this.DatetimePicker.Size = new System.Drawing.Size(102, 27);
            this.DatetimePicker.TabIndex = 5;
            this.DatetimePicker.ValueChanged += new System.EventHandler(this.DatetimePicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Filename:";
            // 
            // DestinationFolderLabel
            // 
            this.DestinationFolderLabel.AutoSize = true;
            this.DestinationFolderLabel.Location = new System.Drawing.Point(113, 45);
            this.DestinationFolderLabel.Name = "DestinationFolderLabel";
            this.DestinationFolderLabel.Size = new System.Drawing.Size(163, 20);
            this.DestinationFolderLabel.TabIndex = 3;
            this.DestinationFolderLabel.TabStop = true;
            this.DestinationFolderLabel.Text = "DestinationFolderLabel";
            this.DestinationFolderLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DestinationFolderLabel_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folder:";
            // 
            // DestinationKeyList
            // 
            this.DestinationKeyList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DestinationKeyList.FormattingEnabled = true;
            this.DestinationKeyList.ItemHeight = 20;
            this.DestinationKeyList.Items.AddRange(new object[] {
            ""});
            this.DestinationKeyList.Location = new System.Drawing.Point(114, 15);
            this.DestinationKeyList.Name = "DestinationKeyList";
            this.DestinationKeyList.Size = new System.Drawing.Size(202, 24);
            this.DestinationKeyList.TabIndex = 1;
            this.DestinationKeyList.SelectedIndexChanged += new System.EventHandler(this.DestinationKeyList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Destination:";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.FileListFlow);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.MailFilesFlow);
            this.splitContainer4.Panel2Collapsed = true;
            this.splitContainer4.Panel2MinSize = 100;
            this.splitContainer4.Size = new System.Drawing.Size(984, 600);
            this.splitContainer4.SplitterDistance = 482;
            this.splitContainer4.TabIndex = 0;
            // 
            // MailFilesFlow
            // 
            this.MailFilesFlow.AutoScroll = true;
            this.MailFilesFlow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MailFilesFlow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MailFilesFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MailFilesFlow.Location = new System.Drawing.Point(0, 0);
            this.MailFilesFlow.Name = "MailFilesFlow";
            this.MailFilesFlow.Size = new System.Drawing.Size(984, 114);
            this.MailFilesFlow.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1942, 942);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.TopMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.TopMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "Document Mover";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.TopMenuStrip.ResumeLayout(false);
            this.TopMenuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TopMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SourceMenu;
        private System.Windows.Forms.ToolStripMenuItem RescanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DestinationsMenu;
        private System.Windows.Forms.ToolStripMenuItem OverrideMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel FileListFlow;
        private System.Windows.Forms.Button DeleteMailButton;
        private System.Windows.Forms.Button DeleteSourceFileButton;
        private System.Windows.Forms.Button MoveFileButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CopyFileButton;
        private System.Windows.Forms.Label FileExistsLabel;
        private System.Windows.Forms.Label FilenameLabel;
        private System.Windows.Forms.CheckBox DatetimeCheckbox;
        private System.Windows.Forms.TextBox ExtensionTextbox;
        private System.Windows.Forms.TextBox FilenameTextbox2;
        private System.Windows.Forms.TextBox FilenameTextbox1;
        private System.Windows.Forms.DateTimePicker DatetimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel DestinationFolderLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox DestinationKeyList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button DeleteExistingFileButton;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.FlowLayoutPanel MailFilesFlow;
    }
}

