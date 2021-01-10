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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilieisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFilterCriteria = new System.Windows.Forms.Panel();
            this.flowLayoutPanelTags = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.cmbTags = new System.Windows.Forms.ComboBox();
            this.lblTags = new System.Windows.Forms.Label();
            this.lblFilteredTags = new System.Windows.Forms.Label();
            this.dateTimePickerBegin = new System.Windows.Forms.DateTimePicker();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblRomSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewEntryList = new System.Windows.Forms.DataGridView();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseTagsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpdbId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseTypeString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStripGridActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.IpdbInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vpinDatabaseSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtLog = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.backgroundWorkerProgressBar = new System.ComponentModel.BackgroundWorker();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.panelFilterCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntryList)).BeginInit();
            this.contextMenuStripGridActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vpinDatabaseSettingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStripBottom.SuspendLayout();
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
            // panelFilterCriteria
            // 
            this.panelFilterCriteria.Controls.Add(this.flowLayoutPanelTags);
            this.panelFilterCriteria.Controls.Add(this.lblDatabase);
            this.panelFilterCriteria.Controls.Add(this.cmbDatabase);
            this.panelFilterCriteria.Controls.Add(this.cmbType);
            this.panelFilterCriteria.Controls.Add(this.lblType);
            this.panelFilterCriteria.Controls.Add(this.lblEndDate);
            this.panelFilterCriteria.Controls.Add(this.dateTimePickerEnd);
            this.panelFilterCriteria.Controls.Add(this.lblBeginDate);
            this.panelFilterCriteria.Controls.Add(this.cmbTags);
            this.panelFilterCriteria.Controls.Add(this.lblTags);
            this.panelFilterCriteria.Controls.Add(this.lblFilteredTags);
            this.panelFilterCriteria.Controls.Add(this.dateTimePickerBegin);
            this.panelFilterCriteria.Controls.Add(this.lblInfo);
            this.panelFilterCriteria.Controls.Add(this.lblRomSearch);
            this.panelFilterCriteria.Controls.Add(this.txtSearch);
            this.panelFilterCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilterCriteria.Location = new System.Drawing.Point(0, 24);
            this.panelFilterCriteria.Name = "panelFilterCriteria";
            this.panelFilterCriteria.Size = new System.Drawing.Size(1049, 84);
            this.panelFilterCriteria.TabIndex = 1;
            // 
            // flowLayoutPanelTags
            // 
            this.flowLayoutPanelTags.Location = new System.Drawing.Point(331, 32);
            this.flowLayoutPanelTags.Name = "flowLayoutPanelTags";
            this.flowLayoutPanelTags.Size = new System.Drawing.Size(706, 46);
            this.flowLayoutPanelTags.TabIndex = 14;
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(3, 58);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(56, 13);
            this.lblDatabase.TabIndex = 13;
            this.lblDatabase.Text = "Database:";
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Items.AddRange(new object[] {
            "All",
            "VPForums",
            "VPinball",
            "VPS Spreadsheet",
            "VPUniverse"});
            this.cmbDatabase.Location = new System.Drawing.Point(65, 55);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(144, 21);
            this.cmbDatabase.TabIndex = 12;
            this.cmbDatabase.Text = "All";
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(644, 6);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(227, 21);
            this.cmbType.TabIndex = 11;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(604, 12);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 10;
            this.lblType.Text = "Type:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(438, 10);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(52, 13);
            this.lblEndDate.TabIndex = 9;
            this.lblEndDate.Text = "End Date";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(496, 6);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(101, 20);
            this.dateTimePickerEnd.TabIndex = 8;
            this.dateTimePickerEnd.ValueChanged += new System.EventHandler(this.dateTimePickerEnd_ValueChanged);
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.AutoSize = true;
            this.lblBeginDate.Location = new System.Drawing.Point(265, 10);
            this.lblBeginDate.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(60, 13);
            this.lblBeginDate.TabIndex = 7;
            this.lblBeginDate.Text = "Begin Date";
            // 
            // cmbTags
            // 
            this.cmbTags.FormattingEnabled = true;
            this.cmbTags.Location = new System.Drawing.Point(52, 30);
            this.cmbTags.Name = "cmbTags";
            this.cmbTags.Size = new System.Drawing.Size(204, 21);
            this.cmbTags.TabIndex = 6;
            this.cmbTags.SelectedIndexChanged += new System.EventHandler(this.cmbTags_SelectedIndexChanged);
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.Location = new System.Drawing.Point(12, 33);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(34, 13);
            this.lblTags.TabIndex = 5;
            this.lblTags.Text = "Tags:";
            // 
            // lblFilteredTags
            // 
            this.lblFilteredTags.AutoSize = true;
            this.lblFilteredTags.Location = new System.Drawing.Point(262, 36);
            this.lblFilteredTags.Name = "lblFilteredTags";
            this.lblFilteredTags.Size = new System.Drawing.Size(71, 13);
            this.lblFilteredTags.TabIndex = 4;
            this.lblFilteredTags.Text = "Filtered Tags:";
            // 
            // dateTimePickerBegin
            // 
            this.dateTimePickerBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerBegin.Location = new System.Drawing.Point(331, 6);
            this.dateTimePickerBegin.Name = "dateTimePickerBegin";
            this.dateTimePickerBegin.Size = new System.Drawing.Size(101, 20);
            this.dateTimePickerBegin.TabIndex = 3;
            this.dateTimePickerBegin.ValueChanged += new System.EventHandler(this.dateTimePickerBegin_ValueChanged);
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
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(51, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
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
            this.DatabaseTagsString,
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
            this.dataGridViewEntryList.Size = new System.Drawing.Size(1049, 288);
            this.dataGridViewEntryList.TabIndex = 2;
            this.dataGridViewEntryList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEntryList_CellDoubleClick);
            this.dataGridViewEntryList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewEntryList_DataBindingComplete);
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
            // DatabaseTagsString
            // 
            this.DatabaseTagsString.DataPropertyName = "DatabaseTagsString";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DatabaseTagsString.DefaultCellStyle = dataGridViewCellStyle2;
            this.DatabaseTagsString.HeaderText = "Tags";
            this.DatabaseTagsString.Name = "DatabaseTagsString";
            this.DatabaseTagsString.ReadOnly = true;
            this.DatabaseTagsString.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DatabaseTagsString.Width = 37;
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
            this.IpdbInfoToolStripMenuItem.Click += new System.EventHandler(this.IpdbInfoToolStripMenuItem_Click);
            // 
            // goToUrlToolStripMenuItem
            // 
            this.goToUrlToolStripMenuItem.Name = "goToUrlToolStripMenuItem";
            this.goToUrlToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.goToUrlToolStripMenuItem.Text = "Go to URL";
            this.goToUrlToolStripMenuItem.Click += new System.EventHandler(this.goToUrlToolStripMenuItem_Click);
            // 
            // vpinDatabaseSettingBindingSource
            // 
            this.vpinDatabaseSettingBindingSource.DataSource = typeof(PinCab.Utils.Models.DatabaseBrowserEntry);
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1049, 133);
            this.txtLog.TabIndex = 4;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 108);
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
            this.splitContainer1.Size = new System.Drawing.Size(1049, 425);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 5;
            // 
            // backgroundWorkerProgressBar
            // 
            this.backgroundWorkerProgressBar.WorkerReportsProgress = true;
            this.backgroundWorkerProgressBar.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerProgressBar_DoWork);
            this.backgroundWorkerProgressBar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerProgressBar_ProgressChanged);
            this.backgroundWorkerProgressBar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerProgressBar_RunWorkerCompleted);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(67, 17);
            this.toolStripStatusLabel.Text = "Status Here";
            // 
            // toolStripStatusLabelSpacer
            // 
            this.toolStripStatusLabelSpacer.Name = "toolStripStatusLabelSpacer";
            this.toolStripStatusLabelSpacer.Size = new System.Drawing.Size(865, 17);
            this.toolStripStatusLabelSpacer.Spring = true;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // statusStripBottom
            // 
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabelSpacer,
            this.toolStripProgressBar});
            this.statusStripBottom.Location = new System.Drawing.Point(0, 533);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(1049, 22);
            this.statusStripBottom.TabIndex = 6;
            this.statusStripBottom.Text = "statusStrip1";
            // 
            // DatabaseBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 555);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelFilterCriteria);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStripBottom);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DatabaseBrowserForm";
            this.Text = "Database Browser";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelFilterCriteria.ResumeLayout(false);
            this.panelFilterCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntryList)).EndInit();
            this.contextMenuStripGridActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vpinDatabaseSettingBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panelFilterCriteria;
        private System.Windows.Forms.DataGridView dataGridViewEntryList;
        private System.Windows.Forms.BindingSource vpinDatabaseSettingBindingSource;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblRomSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGridActions;
        private System.Windows.Forms.ToolStripMenuItem IpdbInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToUrlToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProgressBar;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label lblBeginDate;
        private System.Windows.Forms.ComboBox cmbTags;
        private System.Windows.Forms.Label lblTags;
        private System.Windows.Forms.Label lblFilteredTags;
        private System.Windows.Forms.DateTimePicker dateTimePickerBegin;
        private System.Windows.Forms.ToolStripMenuItem utilieisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshDatabaseToolStripMenuItem;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.StatusStrip statusStripBottom;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseTagsString;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpdbId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeString;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseTypeString;
    }
}