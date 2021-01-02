namespace PinCab.Configurator
{
    partial class DatabaseBrowserForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilieisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTags = new System.Windows.Forms.Label();
            this.dateTimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblRomSearch = new System.Windows.Forms.Label();
            this.txtRomSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewEntryList = new System.Windows.Forms.DataGridView();
            this.contextMenuStripGridActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.IpdbInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vpinDatabaseSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.backgroundWorkerProgressBar = new System.ComponentModel.BackgroundWorker();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpdbId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseTypeString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntryList)).BeginInit();
            this.contextMenuStripGridActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vpinDatabaseSettingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.utilieisToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1049, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // utilieisToolStripMenuItem
            // 
            this.utilieisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshDatabaseToolStripMenuItem});
            this.utilieisToolStripMenuItem.Name = "utilieisToolStripMenuItem";
            this.utilieisToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.utilieisToolStripMenuItem.Text = "Utilities";
            // 
            // refreshDatabaseToolStripMenuItem
            // 
            this.refreshDatabaseToolStripMenuItem.Name = "refreshDatabaseToolStripMenuItem";
            this.refreshDatabaseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.refreshDatabaseToolStripMenuItem.Text = "Refresh Database";
            this.refreshDatabaseToolStripMenuItem.Click += new System.EventHandler(this.refreshDatabaseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbDatabase);
            this.panel1.Controls.Add(this.cmbType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTags);
            this.panel1.Controls.Add(this.dateTimePickerBegin);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.lblRomSearch);
            this.panel1.Controls.Add(this.txtRomSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 90);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(438, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "End Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(496, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(101, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Begin Date";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(52, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(204, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tags:";
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(262, 36);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(71, 13);
            this.lblTags.TabIndex = 4;
            this.lblTags.Text = "Filtered Tags:";
            // 
            // dateTimePickerBegin
            // 
            this.dateTimePickerBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBegin.Location = new System.Drawing.Point(331, 6);
            this.dateTimePickerBegin.Name = "dateTimePickerBegin";
            this.dateTimePickerBegin.Size = new System.Drawing.Size(101, 20);
            this.dateTimePickerBegin.TabIndex = 3;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(877, 6);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(160, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Right Click Cell or Row for Menu";
            // 
            // lblRomSearch
            // 
            this.lblRomSearch.AutoSize = true;
            this.lblRomSearch.Location = new System.Drawing.Point(4, 6);
            this.lblRomSearch.Name = "lblRomSearch";
            this.lblRomSearch.Size = new System.Drawing.Size(41, 13);
            this.lblRomSearch.TabIndex = 1;
            this.lblRomSearch.Text = "Search";
            // 
            // txtRomSearch
            // 
            this.txtRomSearch.Location = new System.Drawing.Point(51, 3);
            this.txtRomSearch.Name = "txtRomSearch";
            this.txtRomSearch.Size = new System.Drawing.Size(205, 20);
            this.txtRomSearch.TabIndex = 0;
            this.txtRomSearch.TextChanged += new System.EventHandler(this.txtRomSearch_TextChanged);
            // 
            // dataGridViewEntryList
            // 
            this.dataGridViewEntryList.AllowUserToAddRows = false;
            this.dataGridViewEntryList.AllowUserToDeleteRows = false;
            this.dataGridViewEntryList.AutoGenerateColumns = false;
            this.dataGridViewEntryList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewEntryList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridViewEntryList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.titleDataGridViewTextBoxColumn,
            this.Url,
            this.IpdbId,
            this.Version,
            this.LastUpdated,
            this.TypeString,
            this.DatabaseTypeString});
            this.dataGridViewEntryList.ContextMenuStrip = this.contextMenuStripGridActions;
            this.dataGridViewEntryList.DataSource = this.vpinDatabaseSettingBindingSource;
            this.dataGridViewEntryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEntryList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEntryList.Name = "dataGridViewEntryList";
            this.dataGridViewEntryList.ReadOnly = true;
            this.dataGridViewEntryList.Size = new System.Drawing.Size(1049, 324);
            this.dataGridViewEntryList.TabIndex = 2;
            this.dataGridViewEntryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewEntryList_DataBindingComplete);
            // 
            // contextMenuStripGridActions
            // 
            this.contextMenuStripGridActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IpdbInfoToolStripMenuItem,
            this.goToUrlToolStripMenuItem});
            this.contextMenuStripGridActions.Name = "contextMenuStripGridActions";
            this.contextMenuStripGridActions.Size = new System.Drawing.Size(128, 48);
            this.contextMenuStripGridActions.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripGridActions_ItemClicked);
            // 
            // IpdbInfoToolStripMenuItem
            // 
            this.IpdbInfoToolStripMenuItem.Name = "IpdbInfoToolStripMenuItem";
            this.IpdbInfoToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.IpdbInfoToolStripMenuItem.Text = "IPDB Info";
            // 
            // goToUrlToolStripMenuItem
            // 
            this.goToUrlToolStripMenuItem.Name = "goToUrlToolStripMenuItem";
            this.goToUrlToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.goToUrlToolStripMenuItem.Text = "Go to URL";
            // 
            // vpinDatabaseSettingBindingSource
            // 
            this.vpinDatabaseSettingBindingSource.DataSource = typeof(PinCab.Utils.Models.DatabaseBrowserEntry);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 532);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1049, 23);
            this.progressBar.TabIndex = 3;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1049, 90);
            this.txtLog.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 114);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewEntryList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtLog);
            this.splitContainer1.Size = new System.Drawing.Size(1049, 418);
            this.splitContainer1.SplitterDistance = 324;
            this.splitContainer1.TabIndex = 5;
            // 
            // backgroundWorkerProgressBar
            // 
            this.backgroundWorkerProgressBar.WorkerReportsProgress = true;
            this.backgroundWorkerProgressBar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerProgressBar_DoWork);
            this.backgroundWorkerProgressBar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerProgressBar_ProgressChanged);
            this.backgroundWorkerProgressBar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerProgressBar_RunWorkerCompleted);
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.titleDataGridViewTextBoxColumn.Width = 52;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.HeaderText = "Url";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Width = 45;
            // 
            // IpdbId
            // 
            this.IpdbId.DataPropertyName = "IpdbId";
            this.IpdbId.HeaderText = "Ipdb";
            this.IpdbId.Name = "IpdbId";
            this.IpdbId.ReadOnly = true;
            this.IpdbId.Width = 53;
            // 
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            this.Version.Width = 67;
            // 
            // LastUpdated
            // 
            this.LastUpdated.DataPropertyName = "LastUpdated";
            this.LastUpdated.HeaderText = "Updated";
            this.LastUpdated.Name = "LastUpdated";
            this.LastUpdated.ReadOnly = true;
            this.LastUpdated.Width = 73;
            // 
            // TypeString
            // 
            this.TypeString.DataPropertyName = "TypeString";
            this.TypeString.HeaderText = "Type";
            this.TypeString.Name = "TypeString";
            this.TypeString.ReadOnly = true;
            this.TypeString.Width = 56;
            // 
            // DatabaseTypeString
            // 
            this.DatabaseTypeString.DataPropertyName = "DatabaseTypeString";
            this.DatabaseTypeString.HeaderText = "DB";
            this.DatabaseTypeString.Name = "DatabaseTypeString";
            this.DatabaseTypeString.ReadOnly = true;
            this.DatabaseTypeString.Width = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(604, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Type:";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(644, 6);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(227, 21);
            this.cmbType.TabIndex = 11;
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(644, 33);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(144, 21);
            this.cmbDatabase.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(582, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Database:";
            // 
            // DatabaseBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 555);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DatabaseBrowserForm";
            this.Text = "Database Browser";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntryList)).EndInit();
            this.contextMenuStripGridActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vpinDatabaseSettingBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewEntryList;
        private System.Windows.Forms.BindingSource vpinDatabaseSettingBindingSource;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblRomSearch;
        private System.Windows.Forms.TextBox txtRomSearch;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGridActions;
        private System.Windows.Forms.ToolStripMenuItem IpdbInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToUrlToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProgressBar;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.DateTimePicker dateTimePickerBegin;
        private System.Windows.Forms.ToolStripMenuItem utilieisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshDatabaseToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpdbId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeString;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseTypeString;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label4;
    }
}