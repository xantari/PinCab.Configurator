namespace PinCab.Configurator
{
    partial class SettingsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabPageDatabases = new System.Windows.Forms.TabPage();
            this.btnFilePathDatabaseBrowser = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.gvContentDatabases = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accessTokenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentDatabaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbContentDatabaseType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtContentDatabaseName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtContentDatabaseAccessToken = new System.Windows.Forms.TextBox();
            this.numericRecheckMinutes = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.btnContentDatabaseUrl = new System.Windows.Forms.Button();
            this.txtContentDatabaseUrl = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPageRecording = new System.Windows.Forms.TabPage();
            this.txtOBSConfigPath = new System.Windows.Forms.TextBox();
            this.txtOBSPath = new System.Windows.Forms.TextBox();
            this.txtTempRecordingPath = new System.Windows.Forms.TextBox();
            this.txtFFMpegFilePath = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnOBSConfigPath = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.btnOBSPath = new System.Windows.Forms.Button();
            this.numericStartRecordDelaySeconds = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.numericFramerate = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericRecordTimeSeconds = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTempRecordFilePath = new System.Windows.Forms.Button();
            this.btnFFMpegFilePath = new System.Windows.Forms.Button();
            this.tabPageFrontEnd = new System.Windows.Forms.TabPage();
            this.btnPinupPopperFilePath = new System.Windows.Forms.Button();
            this.txtPinupPopperDbLocation = new System.Windows.Forms.TextBox();
            this.txtPinballYLocation = new System.Windows.Forms.TextBox();
            this.txtPinballXIniFilePath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPinballYFilePath = new System.Windows.Forms.Button();
            this.btnPinballXIniFilePath = new System.Windows.Forms.Button();
            this.tabPagePinballProgramSettings = new System.Windows.Forms.TabPage();
            this.lblUltraDMDFound = new System.Windows.Forms.Label();
            this.lblVPinMameFound = new System.Windows.Forms.Label();
            this.btnPRocUserSettingsFilePath = new System.Windows.Forms.Button();
            this.txtPRocUserSettings = new System.Windows.Forms.TextBox();
            this.txtDMDDeviceIniFilePath = new System.Windows.Forms.TextBox();
            this.txtFutureDMDFilePath = new System.Windows.Forms.TextBox();
            this.txtPinupPlayerFilePath = new System.Windows.Forms.TextBox();
            this.txtB2SScreenresFilePath = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnDMDDeviceIniFilePath = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnFutureDMDFilePath = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPinupPlayerFilePath = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnB2SScreenresFilePath = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbSettings = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            this.tabPageDatabases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvContentDatabases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentDatabaseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRecheckMinutes)).BeginInit();
            this.tabPageRecording.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartRecordDelaySeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFramerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRecordTimeSeconds)).BeginInit();
            this.tabPageFrontEnd.SuspendLayout();
            this.tabPagePinballProgramSettings.SuspendLayout();
            this.tbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHelp);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 30);
            this.panel1.TabIndex = 8;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(304, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(139, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(12, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabPageDatabases
            // 
            this.tabPageDatabases.Controls.Add(this.btnFilePathDatabaseBrowser);
            this.tabPageDatabases.Controls.Add(this.label19);
            this.tabPageDatabases.Controls.Add(this.gvContentDatabases);
            this.tabPageDatabases.Controls.Add(this.cmbContentDatabaseType);
            this.tabPageDatabases.Controls.Add(this.label18);
            this.tabPageDatabases.Controls.Add(this.txtContentDatabaseName);
            this.tabPageDatabases.Controls.Add(this.label17);
            this.tabPageDatabases.Controls.Add(this.btnAdd);
            this.tabPageDatabases.Controls.Add(this.label15);
            this.tabPageDatabases.Controls.Add(this.txtContentDatabaseAccessToken);
            this.tabPageDatabases.Controls.Add(this.numericRecheckMinutes);
            this.tabPageDatabases.Controls.Add(this.label20);
            this.tabPageDatabases.Controls.Add(this.btnContentDatabaseUrl);
            this.tabPageDatabases.Controls.Add(this.txtContentDatabaseUrl);
            this.tabPageDatabases.Controls.Add(this.label14);
            this.tabPageDatabases.Location = new System.Drawing.Point(4, 22);
            this.tabPageDatabases.Name = "tabPageDatabases";
            this.tabPageDatabases.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDatabases.Size = new System.Drawing.Size(674, 337);
            this.tabPageDatabases.TabIndex = 3;
            this.tabPageDatabases.Text = "Databases";
            this.tabPageDatabases.UseVisualStyleBackColor = true;
            // 
            // btnFilePathDatabaseBrowser
            // 
            this.btnFilePathDatabaseBrowser.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnFilePathDatabaseBrowser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFilePathDatabaseBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilePathDatabaseBrowser.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFilePathDatabaseBrowser.Location = new System.Drawing.Point(532, 215);
            this.btnFilePathDatabaseBrowser.Name = "btnFilePathDatabaseBrowser";
            this.btnFilePathDatabaseBrowser.Size = new System.Drawing.Size(38, 23);
            this.btnFilePathDatabaseBrowser.TabIndex = 66;
            this.btnFilePathDatabaseBrowser.UseVisualStyleBackColor = true;
            this.btnFilePathDatabaseBrowser.Click += new System.EventHandler(this.btnFilePathDatabaseBrowser_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(529, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(137, 13);
            this.label19.TabIndex = 65;
            this.label19.Text = "(Delete Key removes a row)";
            // 
            // gvContentDatabases
            // 
            this.gvContentDatabases.AllowUserToAddRows = false;
            this.gvContentDatabases.AutoGenerateColumns = false;
            this.gvContentDatabases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvContentDatabases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvContentDatabases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.urlDataGridViewTextBoxColumn,
            this.accessTokenDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn});
            this.gvContentDatabases.DataSource = this.contentDatabaseBindingSource;
            this.gvContentDatabases.Location = new System.Drawing.Point(11, 39);
            this.gvContentDatabases.MultiSelect = false;
            this.gvContentDatabases.Name = "gvContentDatabases";
            this.gvContentDatabases.ReadOnly = true;
            this.gvContentDatabases.Size = new System.Drawing.Size(655, 121);
            this.gvContentDatabases.TabIndex = 64;
            this.gvContentDatabases.SelectionChanged += new System.EventHandler(this.gvContentDatabases_SelectionChanged);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // urlDataGridViewTextBoxColumn
            // 
            this.urlDataGridViewTextBoxColumn.DataPropertyName = "Url";
            this.urlDataGridViewTextBoxColumn.HeaderText = "Url";
            this.urlDataGridViewTextBoxColumn.Name = "urlDataGridViewTextBoxColumn";
            this.urlDataGridViewTextBoxColumn.ReadOnly = true;
            this.urlDataGridViewTextBoxColumn.Width = 45;
            // 
            // accessTokenDataGridViewTextBoxColumn
            // 
            this.accessTokenDataGridViewTextBoxColumn.DataPropertyName = "AccessToken";
            this.accessTokenDataGridViewTextBoxColumn.HeaderText = "AccessToken";
            this.accessTokenDataGridViewTextBoxColumn.Name = "accessTokenDataGridViewTextBoxColumn";
            this.accessTokenDataGridViewTextBoxColumn.ReadOnly = true;
            this.accessTokenDataGridViewTextBoxColumn.Visible = false;
            this.accessTokenDataGridViewTextBoxColumn.Width = 98;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Visible = false;
            this.typeDataGridViewTextBoxColumn.Width = 56;
            // 
            // contentDatabaseBindingSource
            // 
            this.contentDatabaseBindingSource.DataSource = typeof(PinCab.Utils.Models.ContentDatabase);
            // 
            // cmbContentDatabaseType
            // 
            this.cmbContentDatabaseType.FormattingEnabled = true;
            this.cmbContentDatabaseType.Location = new System.Drawing.Point(93, 166);
            this.cmbContentDatabaseType.Name = "cmbContentDatabaseType";
            this.cmbContentDatabaseType.Size = new System.Drawing.Size(181, 21);
            this.cmbContentDatabaseType.TabIndex = 63;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(49, 169);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 13);
            this.label18.TabIndex = 62;
            this.label18.Text = "Type:";
            // 
            // txtContentDatabaseName
            // 
            this.txtContentDatabaseName.Location = new System.Drawing.Point(93, 192);
            this.txtContentDatabaseName.Name = "txtContentDatabaseName";
            this.txtContentDatabaseName.Size = new System.Drawing.Size(401, 20);
            this.txtContentDatabaseName.TabIndex = 61;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(49, 195);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 60;
            this.label17.Text = "Name:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(93, 271);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 23);
            this.btnAdd.TabIndex = 59;
            this.btnAdd.Text = "Add / Update";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 248);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 13);
            this.label15.TabIndex = 58;
            this.label15.Text = "Access Token:";
            // 
            // txtContentDatabaseAccessToken
            // 
            this.txtContentDatabaseAccessToken.Location = new System.Drawing.Point(93, 245);
            this.txtContentDatabaseAccessToken.Name = "txtContentDatabaseAccessToken";
            this.txtContentDatabaseAccessToken.Size = new System.Drawing.Size(401, 20);
            this.txtContentDatabaseAccessToken.TabIndex = 57;
            // 
            // numericRecheckMinutes
            // 
            this.numericRecheckMinutes.Location = new System.Drawing.Point(192, 11);
            this.numericRecheckMinutes.Maximum = new decimal(new int[] {
            10080,
            0,
            0,
            0});
            this.numericRecheckMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericRecheckMinutes.Name = "numericRecheckMinutes";
            this.numericRecheckMinutes.Size = new System.Drawing.Size(120, 20);
            this.numericRecheckMinutes.TabIndex = 56;
            this.numericRecheckMinutes.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 13);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(178, 13);
            this.label20.TabIndex = 55;
            this.label20.Text = "Database Update Recheck Minutes";
            // 
            // btnContentDatabaseUrl
            // 
            this.btnContentDatabaseUrl.BackgroundImage = global::PinCab.Configurator.Properties.Resources.BrowserLink_75x;
            this.btnContentDatabaseUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnContentDatabaseUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContentDatabaseUrl.ForeColor = System.Drawing.SystemColors.Control;
            this.btnContentDatabaseUrl.Location = new System.Drawing.Point(500, 215);
            this.btnContentDatabaseUrl.Name = "btnContentDatabaseUrl";
            this.btnContentDatabaseUrl.Size = new System.Drawing.Size(38, 23);
            this.btnContentDatabaseUrl.TabIndex = 54;
            this.btnContentDatabaseUrl.UseVisualStyleBackColor = true;
            this.btnContentDatabaseUrl.Click += new System.EventHandler(this.btnContentDatabaseUrl_Click);
            // 
            // txtContentDatabaseUrl
            // 
            this.txtContentDatabaseUrl.Location = new System.Drawing.Point(93, 218);
            this.txtContentDatabaseUrl.Name = "txtContentDatabaseUrl";
            this.txtContentDatabaseUrl.Size = new System.Drawing.Size(401, 20);
            this.txtContentDatabaseUrl.TabIndex = 53;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 221);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 52;
            this.label14.Text = "Url / Path:";
            // 
            // tabPageRecording
            // 
            this.tabPageRecording.Controls.Add(this.txtOBSConfigPath);
            this.tabPageRecording.Controls.Add(this.txtOBSPath);
            this.tabPageRecording.Controls.Add(this.txtTempRecordingPath);
            this.tabPageRecording.Controls.Add(this.txtFFMpegFilePath);
            this.tabPageRecording.Controls.Add(this.label23);
            this.tabPageRecording.Controls.Add(this.btnOBSConfigPath);
            this.tabPageRecording.Controls.Add(this.label22);
            this.tabPageRecording.Controls.Add(this.btnOBSPath);
            this.tabPageRecording.Controls.Add(this.numericStartRecordDelaySeconds);
            this.tabPageRecording.Controls.Add(this.label21);
            this.tabPageRecording.Controls.Add(this.numericFramerate);
            this.tabPageRecording.Controls.Add(this.label4);
            this.tabPageRecording.Controls.Add(this.label3);
            this.tabPageRecording.Controls.Add(this.numericRecordTimeSeconds);
            this.tabPageRecording.Controls.Add(this.label2);
            this.tabPageRecording.Controls.Add(this.label1);
            this.tabPageRecording.Controls.Add(this.btnTempRecordFilePath);
            this.tabPageRecording.Controls.Add(this.btnFFMpegFilePath);
            this.tabPageRecording.Location = new System.Drawing.Point(4, 22);
            this.tabPageRecording.Name = "tabPageRecording";
            this.tabPageRecording.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRecording.Size = new System.Drawing.Size(674, 337);
            this.tabPageRecording.TabIndex = 1;
            this.tabPageRecording.Text = "Recording";
            this.tabPageRecording.UseVisualStyleBackColor = true;
            // 
            // txtOBSConfigPath
            // 
            this.txtOBSConfigPath.Location = new System.Drawing.Point(100, 61);
            this.txtOBSConfigPath.Name = "txtOBSConfigPath";
            this.txtOBSConfigPath.Size = new System.Drawing.Size(459, 20);
            this.txtOBSConfigPath.TabIndex = 26;
            // 
            // txtOBSPath
            // 
            this.txtOBSPath.Location = new System.Drawing.Point(100, 35);
            this.txtOBSPath.Name = "txtOBSPath";
            this.txtOBSPath.Size = new System.Drawing.Size(459, 20);
            this.txtOBSPath.TabIndex = 23;
            // 
            // txtTempRecordingPath
            // 
            this.txtTempRecordingPath.Location = new System.Drawing.Point(126, 170);
            this.txtTempRecordingPath.Name = "txtTempRecordingPath";
            this.txtTempRecordingPath.Size = new System.Drawing.Size(433, 20);
            this.txtTempRecordingPath.TabIndex = 16;
            // 
            // txtFFMpegFilePath
            // 
            this.txtFFMpegFilePath.Location = new System.Drawing.Point(100, 9);
            this.txtFFMpegFilePath.Name = "txtFFMpegFilePath";
            this.txtFFMpegFilePath.Size = new System.Drawing.Size(459, 20);
            this.txtFFMpegFilePath.TabIndex = 8;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 65);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 13);
            this.label23.TabIndex = 25;
            this.label23.Text = "OBS Config Path:";
            // 
            // btnOBSConfigPath
            // 
            this.btnOBSConfigPath.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnOBSConfigPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOBSConfigPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOBSConfigPath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOBSConfigPath.Location = new System.Drawing.Point(565, 60);
            this.btnOBSConfigPath.Name = "btnOBSConfigPath";
            this.btnOBSConfigPath.Size = new System.Drawing.Size(38, 23);
            this.btnOBSConfigPath.TabIndex = 27;
            this.btnOBSConfigPath.UseVisualStyleBackColor = true;
            this.btnOBSConfigPath.Click += new System.EventHandler(this.btnOBSConfigPath_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(46, 38);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 13);
            this.label22.TabIndex = 22;
            this.label22.Text = "OBS Path:";
            // 
            // btnOBSPath
            // 
            this.btnOBSPath.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnOBSPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOBSPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOBSPath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOBSPath.Location = new System.Drawing.Point(565, 34);
            this.btnOBSPath.Name = "btnOBSPath";
            this.btnOBSPath.Size = new System.Drawing.Size(38, 23);
            this.btnOBSPath.TabIndex = 24;
            this.btnOBSPath.UseVisualStyleBackColor = true;
            this.btnOBSPath.Click += new System.EventHandler(this.btnOBSPath_Click);
            // 
            // numericStartRecordDelaySeconds
            // 
            this.numericStartRecordDelaySeconds.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericStartRecordDelaySeconds.Location = new System.Drawing.Point(172, 92);
            this.numericStartRecordDelaySeconds.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericStartRecordDelaySeconds.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericStartRecordDelaySeconds.Name = "numericStartRecordDelaySeconds";
            this.numericStartRecordDelaySeconds.Size = new System.Drawing.Size(61, 20);
            this.numericStartRecordDelaySeconds.TabIndex = 21;
            this.numericStartRecordDelaySeconds.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(10, 94);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(156, 13);
            this.label21.TabIndex = 20;
            this.label21.Text = "Start Recording Delay Seconds";
            // 
            // numericFramerate
            // 
            this.numericFramerate.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericFramerate.Location = new System.Drawing.Point(172, 144);
            this.numericFramerate.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericFramerate.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericFramerate.Name = "numericFramerate";
            this.numericFramerate.Size = new System.Drawing.Size(61, 20);
            this.numericFramerate.TabIndex = 19;
            this.numericFramerate.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Frame Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Temp Record File Path:";
            // 
            // numericRecordTimeSeconds
            // 
            this.numericRecordTimeSeconds.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericRecordTimeSeconds.Location = new System.Drawing.Point(172, 118);
            this.numericRecordTimeSeconds.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericRecordTimeSeconds.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericRecordTimeSeconds.Name = "numericRecordTimeSeconds";
            this.numericRecordTimeSeconds.Size = new System.Drawing.Size(61, 20);
            this.numericRecordTimeSeconds.TabIndex = 13;
            this.numericRecordTimeSeconds.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Record Time Seconds";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "FFMpeg File Path:";
            // 
            // btnTempRecordFilePath
            // 
            this.btnTempRecordFilePath.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnTempRecordFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTempRecordFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTempRecordFilePath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTempRecordFilePath.Location = new System.Drawing.Point(565, 170);
            this.btnTempRecordFilePath.Name = "btnTempRecordFilePath";
            this.btnTempRecordFilePath.Size = new System.Drawing.Size(38, 23);
            this.btnTempRecordFilePath.TabIndex = 17;
            this.btnTempRecordFilePath.UseVisualStyleBackColor = true;
            this.btnTempRecordFilePath.Click += new System.EventHandler(this.btnTempRecordFilePath_Click);
            // 
            // btnFFMpegFilePath
            // 
            this.btnFFMpegFilePath.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnFFMpegFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFFMpegFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFFMpegFilePath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFFMpegFilePath.Location = new System.Drawing.Point(565, 8);
            this.btnFFMpegFilePath.Name = "btnFFMpegFilePath";
            this.btnFFMpegFilePath.Size = new System.Drawing.Size(38, 23);
            this.btnFFMpegFilePath.TabIndex = 10;
            this.btnFFMpegFilePath.UseVisualStyleBackColor = true;
            this.btnFFMpegFilePath.Click += new System.EventHandler(this.btnFFMpegFilePath_Click);
            // 
            // tabPageFrontEnd
            // 
            this.tabPageFrontEnd.Controls.Add(this.btnPinupPopperFilePath);
            this.tabPageFrontEnd.Controls.Add(this.txtPinupPopperDbLocation);
            this.tabPageFrontEnd.Controls.Add(this.txtPinballYLocation);
            this.tabPageFrontEnd.Controls.Add(this.txtPinballXIniFilePath);
            this.tabPageFrontEnd.Controls.Add(this.label7);
            this.tabPageFrontEnd.Controls.Add(this.label6);
            this.tabPageFrontEnd.Controls.Add(this.label5);
            this.tabPageFrontEnd.Controls.Add(this.btnPinballYFilePath);
            this.tabPageFrontEnd.Controls.Add(this.btnPinballXIniFilePath);
            this.tabPageFrontEnd.Location = new System.Drawing.Point(4, 22);
            this.tabPageFrontEnd.Name = "tabPageFrontEnd";
            this.tabPageFrontEnd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFrontEnd.Size = new System.Drawing.Size(674, 337);
            this.tabPageFrontEnd.TabIndex = 0;
            this.tabPageFrontEnd.Text = "Front End";
            this.tabPageFrontEnd.UseVisualStyleBackColor = true;
            // 
            // btnPinupPopperFilePath
            // 
            this.btnPinupPopperFilePath.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnPinupPopperFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPinupPopperFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPinupPopperFilePath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPinupPopperFilePath.Location = new System.Drawing.Point(566, 60);
            this.btnPinupPopperFilePath.Name = "btnPinupPopperFilePath";
            this.btnPinupPopperFilePath.Size = new System.Drawing.Size(38, 23);
            this.btnPinupPopperFilePath.TabIndex = 26;
            this.btnPinupPopperFilePath.UseVisualStyleBackColor = true;
            this.btnPinupPopperFilePath.Click += new System.EventHandler(this.btnPinupPopperFilePath_Click);
            // 
            // txtPinupPopperDbLocation
            // 
            this.txtPinupPopperDbLocation.Location = new System.Drawing.Point(212, 61);
            this.txtPinupPopperDbLocation.Name = "txtPinupPopperDbLocation";
            this.txtPinupPopperDbLocation.Size = new System.Drawing.Size(348, 20);
            this.txtPinupPopperDbLocation.TabIndex = 25;
            // 
            // txtPinballYLocation
            // 
            this.txtPinballYLocation.Location = new System.Drawing.Point(158, 33);
            this.txtPinballYLocation.Name = "txtPinballYLocation";
            this.txtPinballYLocation.Size = new System.Drawing.Size(402, 20);
            this.txtPinballYLocation.TabIndex = 22;
            // 
            // txtPinballXIniFilePath
            // 
            this.txtPinballXIniFilePath.Location = new System.Drawing.Point(127, 9);
            this.txtPinballXIniFilePath.Name = "txtPinballXIniFilePath";
            this.txtPinballXIniFilePath.Size = new System.Drawing.Size(433, 20);
            this.txtPinballXIniFilePath.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Pinup Popper PupDatabase.db Location:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Pinball Y Settings.txt Location:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Pinball X Ini Location:";
            // 
            // btnPinballYFilePath
            // 
            this.btnPinballYFilePath.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnPinballYFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPinballYFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPinballYFilePath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPinballYFilePath.Location = new System.Drawing.Point(566, 32);
            this.btnPinballYFilePath.Name = "btnPinballYFilePath";
            this.btnPinballYFilePath.Size = new System.Drawing.Size(38, 23);
            this.btnPinballYFilePath.TabIndex = 23;
            this.btnPinballYFilePath.UseVisualStyleBackColor = true;
            this.btnPinballYFilePath.Click += new System.EventHandler(this.btnPinballYFilePath_Click);
            // 
            // btnPinballXIniFilePath
            // 
            this.btnPinballXIniFilePath.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnPinballXIniFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPinballXIniFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPinballXIniFilePath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPinballXIniFilePath.Location = new System.Drawing.Point(566, 8);
            this.btnPinballXIniFilePath.Name = "btnPinballXIniFilePath";
            this.btnPinballXIniFilePath.Size = new System.Drawing.Size(38, 23);
            this.btnPinballXIniFilePath.TabIndex = 20;
            this.btnPinballXIniFilePath.UseVisualStyleBackColor = true;
            this.btnPinballXIniFilePath.Click += new System.EventHandler(this.btnPinballXIniFilePath_Click);
            // 
            // tabPagePinballProgramSettings
            // 
            this.tabPagePinballProgramSettings.Controls.Add(this.lblUltraDMDFound);
            this.tabPagePinballProgramSettings.Controls.Add(this.lblVPinMameFound);
            this.tabPagePinballProgramSettings.Controls.Add(this.btnPRocUserSettingsFilePath);
            this.tabPagePinballProgramSettings.Controls.Add(this.txtPRocUserSettings);
            this.tabPagePinballProgramSettings.Controls.Add(this.txtDMDDeviceIniFilePath);
            this.tabPagePinballProgramSettings.Controls.Add(this.txtFutureDMDFilePath);
            this.tabPagePinballProgramSettings.Controls.Add(this.txtPinupPlayerFilePath);
            this.tabPagePinballProgramSettings.Controls.Add(this.txtB2SScreenresFilePath);
            this.tabPagePinballProgramSettings.Controls.Add(this.label16);
            this.tabPagePinballProgramSettings.Controls.Add(this.btnDMDDeviceIniFilePath);
            this.tabPagePinballProgramSettings.Controls.Add(this.label13);
            this.tabPagePinballProgramSettings.Controls.Add(this.label12);
            this.tabPagePinballProgramSettings.Controls.Add(this.label11);
            this.tabPagePinballProgramSettings.Controls.Add(this.btnFutureDMDFilePath);
            this.tabPagePinballProgramSettings.Controls.Add(this.label10);
            this.tabPagePinballProgramSettings.Controls.Add(this.btnPinupPlayerFilePath);
            this.tabPagePinballProgramSettings.Controls.Add(this.label9);
            this.tabPagePinballProgramSettings.Controls.Add(this.btnB2SScreenresFilePath);
            this.tabPagePinballProgramSettings.Controls.Add(this.label8);
            this.tabPagePinballProgramSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPagePinballProgramSettings.Name = "tabPagePinballProgramSettings";
            this.tabPagePinballProgramSettings.Size = new System.Drawing.Size(674, 337);
            this.tabPagePinballProgramSettings.TabIndex = 2;
            this.tabPagePinballProgramSettings.Text = "Pinball Program Settings";
            this.tabPagePinballProgramSettings.UseVisualStyleBackColor = true;
            // 
            // lblUltraDMDFound
            // 
            this.lblUltraDMDFound.AutoSize = true;
            this.lblUltraDMDFound.Location = new System.Drawing.Point(154, 152);
            this.lblUltraDMDFound.Name = "lblUltraDMDFound";
            this.lblUltraDMDFound.Size = new System.Drawing.Size(44, 13);
            this.lblUltraDMDFound.TabIndex = 43;
            this.lblUltraDMDFound.Text = "Yes/No";
            // 
            // lblVPinMameFound
            // 
            this.lblVPinMameFound.AutoSize = true;
            this.lblVPinMameFound.Location = new System.Drawing.Point(153, 176);
            this.lblVPinMameFound.Name = "lblVPinMameFound";
            this.lblVPinMameFound.Size = new System.Drawing.Size(44, 13);
            this.lblVPinMameFound.TabIndex = 40;
            this.lblVPinMameFound.Text = "Yes/No";
            // 
            // btnPRocUserSettingsFilePath
            // 
            this.btnPRocUserSettingsFilePath.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnPRocUserSettingsFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPRocUserSettingsFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPRocUserSettingsFilePath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPRocUserSettingsFilePath.Location = new System.Drawing.Point(563, 118);
            this.btnPRocUserSettingsFilePath.Name = "btnPRocUserSettingsFilePath";
            this.btnPRocUserSettingsFilePath.Size = new System.Drawing.Size(38, 23);
            this.btnPRocUserSettingsFilePath.TabIndex = 39;
            this.btnPRocUserSettingsFilePath.UseVisualStyleBackColor = true;
            this.btnPRocUserSettingsFilePath.Click += new System.EventHandler(this.btnPRocUserSettingsFilePath_Click);
            // 
            // txtPRocUserSettings
            // 
            this.txtPRocUserSettings.Location = new System.Drawing.Point(156, 119);
            this.txtPRocUserSettings.Name = "txtPRocUserSettings";
            this.txtPRocUserSettings.Size = new System.Drawing.Size(401, 20);
            this.txtPRocUserSettings.TabIndex = 38;
            // 
            // txtDMDDeviceIniFilePath
            // 
            this.txtDMDDeviceIniFilePath.Location = new System.Drawing.Point(156, 93);
            this.txtDMDDeviceIniFilePath.Name = "txtDMDDeviceIniFilePath";
            this.txtDMDDeviceIniFilePath.Size = new System.Drawing.Size(401, 20);
            this.txtDMDDeviceIniFilePath.TabIndex = 33;
            // 
            // txtFutureDMDFilePath
            // 
            this.txtFutureDMDFilePath.Location = new System.Drawing.Point(156, 67);
            this.txtFutureDMDFilePath.Name = "txtFutureDMDFilePath";
            this.txtFutureDMDFilePath.Size = new System.Drawing.Size(401, 20);
            this.txtFutureDMDFilePath.TabIndex = 28;
            // 
            // txtPinupPlayerFilePath
            // 
            this.txtPinupPlayerFilePath.Location = new System.Drawing.Point(156, 38);
            this.txtPinupPlayerFilePath.Name = "txtPinupPlayerFilePath";
            this.txtPinupPlayerFilePath.Size = new System.Drawing.Size(401, 20);
            this.txtPinupPlayerFilePath.TabIndex = 25;
            // 
            // txtB2SScreenresFilePath
            // 
            this.txtB2SScreenresFilePath.Location = new System.Drawing.Point(156, 10);
            this.txtB2SScreenresFilePath.Name = "txtB2SScreenresFilePath";
            this.txtB2SScreenresFilePath.Size = new System.Drawing.Size(401, 20);
            this.txtB2SScreenresFilePath.TabIndex = 22;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 123);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "P-ROC Usersettings.yaml:";
            // 
            // btnDMDDeviceIniFilePath
            // 
            this.btnDMDDeviceIniFilePath.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnDMDDeviceIniFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDMDDeviceIniFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDMDDeviceIniFilePath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDMDDeviceIniFilePath.Location = new System.Drawing.Point(563, 92);
            this.btnDMDDeviceIniFilePath.Name = "btnDMDDeviceIniFilePath";
            this.btnDMDDeviceIniFilePath.Size = new System.Drawing.Size(38, 23);
            this.btnDMDDeviceIniFilePath.TabIndex = 34;
            this.btnDMDDeviceIniFilePath.UseVisualStyleBackColor = true;
            this.btnDMDDeviceIniFilePath.Click += new System.EventHandler(this.btnDMDDeviceIniFilePath_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "DMDDevice.ini Location:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "VPinMame Found In Registry:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(145, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Ultra DMD Found in Registry:";
            // 
            // btnFutureDMDFilePath
            // 
            this.btnFutureDMDFilePath.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnFutureDMDFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFutureDMDFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFutureDMDFilePath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFutureDMDFilePath.Location = new System.Drawing.Point(563, 66);
            this.btnFutureDMDFilePath.Name = "btnFutureDMDFilePath";
            this.btnFutureDMDFilePath.Size = new System.Drawing.Size(38, 23);
            this.btnFutureDMDFilePath.TabIndex = 29;
            this.btnFutureDMDFilePath.UseVisualStyleBackColor = true;
            this.btnFutureDMDFilePath.Click += new System.EventHandler(this.btnFutureDMDFilePath_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Future DMD Ini Location:";
            // 
            // btnPinupPlayerFilePath
            // 
            this.btnPinupPlayerFilePath.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnPinupPlayerFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPinupPlayerFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPinupPlayerFilePath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPinupPlayerFilePath.Location = new System.Drawing.Point(563, 37);
            this.btnPinupPlayerFilePath.Name = "btnPinupPlayerFilePath";
            this.btnPinupPlayerFilePath.Size = new System.Drawing.Size(38, 23);
            this.btnPinupPlayerFilePath.TabIndex = 26;
            this.btnPinupPlayerFilePath.UseVisualStyleBackColor = true;
            this.btnPinupPlayerFilePath.Click += new System.EventHandler(this.btnPinupPlayerFilePath_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Pinup Player Location:";
            // 
            // btnB2SScreenresFilePath
            // 
            this.btnB2SScreenresFilePath.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnB2SScreenresFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnB2SScreenresFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnB2SScreenresFilePath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnB2SScreenresFilePath.Location = new System.Drawing.Point(563, 9);
            this.btnB2SScreenresFilePath.Name = "btnB2SScreenresFilePath";
            this.btnB2SScreenresFilePath.Size = new System.Drawing.Size(38, 23);
            this.btnB2SScreenresFilePath.TabIndex = 23;
            this.btnB2SScreenresFilePath.UseVisualStyleBackColor = true;
            this.btnB2SScreenresFilePath.Click += new System.EventHandler(this.btnB2SScreenresFilePath_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(139, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "B2S Screenres.txt Location:";
            // 
            // tbSettings
            // 
            this.tbSettings.Controls.Add(this.tabPagePinballProgramSettings);
            this.tbSettings.Controls.Add(this.tabPageFrontEnd);
            this.tbSettings.Controls.Add(this.tabPageRecording);
            this.tbSettings.Controls.Add(this.tabPageDatabases);
            this.tbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSettings.Location = new System.Drawing.Point(0, 0);
            this.tbSettings.Name = "tbSettings";
            this.tbSettings.SelectedIndex = 0;
            this.tbSettings.Size = new System.Drawing.Size(682, 363);
            this.tbSettings.TabIndex = 7;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 363);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbSettings);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(698, 402);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.SettingsForm_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabPageDatabases.ResumeLayout(false);
            this.tabPageDatabases.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvContentDatabases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contentDatabaseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRecheckMinutes)).EndInit();
            this.tabPageRecording.ResumeLayout(false);
            this.tabPageRecording.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartRecordDelaySeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFramerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRecordTimeSeconds)).EndInit();
            this.tabPageFrontEnd.ResumeLayout(false);
            this.tabPageFrontEnd.PerformLayout();
            this.tabPagePinballProgramSettings.ResumeLayout(false);
            this.tabPagePinballProgramSettings.PerformLayout();
            this.tbSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TabPage tabPageDatabases;
        private System.Windows.Forms.NumericUpDown numericRecheckMinutes;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnContentDatabaseUrl;
        private System.Windows.Forms.TextBox txtContentDatabaseUrl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPageRecording;
        private System.Windows.Forms.TextBox txtOBSConfigPath;
        private System.Windows.Forms.TextBox txtOBSPath;
        private System.Windows.Forms.TextBox txtTempRecordingPath;
        private System.Windows.Forms.TextBox txtFFMpegFilePath;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnOBSConfigPath;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnOBSPath;
        private System.Windows.Forms.NumericUpDown numericStartRecordDelaySeconds;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown numericFramerate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericRecordTimeSeconds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTempRecordFilePath;
        private System.Windows.Forms.Button btnFFMpegFilePath;
        private System.Windows.Forms.TabPage tabPageFrontEnd;
        private System.Windows.Forms.Button btnPinupPopperFilePath;
        private System.Windows.Forms.TextBox txtPinupPopperDbLocation;
        private System.Windows.Forms.TextBox txtPinballYLocation;
        private System.Windows.Forms.TextBox txtPinballXIniFilePath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPinballYFilePath;
        private System.Windows.Forms.Button btnPinballXIniFilePath;
        private System.Windows.Forms.TabPage tabPagePinballProgramSettings;
        private System.Windows.Forms.Label lblUltraDMDFound;
        private System.Windows.Forms.Label lblVPinMameFound;
        private System.Windows.Forms.Button btnPRocUserSettingsFilePath;
        private System.Windows.Forms.TextBox txtPRocUserSettings;
        private System.Windows.Forms.TextBox txtDMDDeviceIniFilePath;
        private System.Windows.Forms.TextBox txtFutureDMDFilePath;
        private System.Windows.Forms.TextBox txtPinupPlayerFilePath;
        private System.Windows.Forms.TextBox txtB2SScreenresFilePath;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnDMDDeviceIniFilePath;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnFutureDMDFilePath;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPinupPlayerFilePath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnB2SScreenresFilePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabControl tbSettings;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtContentDatabaseAccessToken;
        private System.Windows.Forms.ComboBox cmbContentDatabaseType;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtContentDatabaseName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView gvContentDatabases;
        private System.Windows.Forms.BindingSource contentDatabaseBindingSource;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accessTokenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnFilePathDatabaseBrowser;
    }
}