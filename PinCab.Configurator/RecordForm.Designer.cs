
namespace PinCab.Configurator
{
    partial class RecordForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewGameList = new System.Windows.Forms.DataGridView();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enabledDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backglassStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dMDStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realDMDColorStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.readDMDStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableDesktopStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topperStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManufacturerMediaStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasWheelImageDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HasInstructionCard = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HasFlyer = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HasLaunchAudio = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.HasTableAudio = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.frontEndGameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStripBottom = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFrontEnd = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartupDelaySeconds = new System.Windows.Forms.TextBox();
            this.txtFramerate = new System.Windows.Forms.TextBox();
            this.txtRecordTimeSeconds = new System.Windows.Forms.TextBox();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnSelectAllGamesWithMissingMedia = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSelectedTables = new System.Windows.Forms.Label();
            this.btnBuildObsProfiles = new System.Windows.Forms.Button();
            this.cmbPlayfield = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBackglass = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDMD = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTopper = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbFullDMD = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbApron = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGameList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontEndGameBindingSource)).BeginInit();
            this.statusStripBottom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 211);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewGameList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStripBottom);
            this.splitContainer1.Panel2.Controls.Add(this.txtLog);
            this.splitContainer1.Size = new System.Drawing.Size(1122, 479);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 27;
            // 
            // dataGridViewGameList
            // 
            this.dataGridViewGameList.AllowUserToAddRows = false;
            this.dataGridViewGameList.AllowUserToDeleteRows = false;
            this.dataGridViewGameList.AutoGenerateColumns = false;
            this.dataGridViewGameList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridViewGameList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fileNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.enabledDataGridViewTextBoxColumn,
            this.backglassStatusDataGridViewTextBoxColumn,
            this.dMDStatusDataGridViewTextBoxColumn,
            this.realDMDColorStatusDataGridViewTextBoxColumn,
            this.readDMDStatusDataGridViewTextBoxColumn,
            this.tableStatusDataGridViewTextBoxColumn,
            this.tableDesktopStatusDataGridViewTextBoxColumn,
            this.topperStatusDataGridViewTextBoxColumn,
            this.ManufacturerMediaStatus,
            this.hasWheelImageDataGridViewCheckBoxColumn,
            this.HasInstructionCard,
            this.HasFlyer,
            this.HasLaunchAudio,
            this.HasTableAudio});
            this.dataGridViewGameList.DataSource = this.frontEndGameBindingSource;
            this.dataGridViewGameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGameList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGameList.Name = "dataGridViewGameList";
            this.dataGridViewGameList.ReadOnly = true;
            this.dataGridViewGameList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGameList.Size = new System.Drawing.Size(1122, 300);
            this.dataGridViewGameList.TabIndex = 3;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "FileName";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileNameDataGridViewTextBoxColumn.Width = 76;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 85;
            // 
            // enabledDataGridViewTextBoxColumn
            // 
            this.enabledDataGridViewTextBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewTextBoxColumn.HeaderText = "Enabled";
            this.enabledDataGridViewTextBoxColumn.Name = "enabledDataGridViewTextBoxColumn";
            this.enabledDataGridViewTextBoxColumn.ReadOnly = true;
            this.enabledDataGridViewTextBoxColumn.Width = 71;
            // 
            // backglassStatusDataGridViewTextBoxColumn
            // 
            this.backglassStatusDataGridViewTextBoxColumn.DataPropertyName = "BackglassStatus";
            this.backglassStatusDataGridViewTextBoxColumn.HeaderText = "Backglass Media";
            this.backglassStatusDataGridViewTextBoxColumn.Name = "backglassStatusDataGridViewTextBoxColumn";
            this.backglassStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.backglassStatusDataGridViewTextBoxColumn.Width = 113;
            // 
            // dMDStatusDataGridViewTextBoxColumn
            // 
            this.dMDStatusDataGridViewTextBoxColumn.DataPropertyName = "DMDStatus";
            this.dMDStatusDataGridViewTextBoxColumn.HeaderText = "DMD Media";
            this.dMDStatusDataGridViewTextBoxColumn.Name = "dMDStatusDataGridViewTextBoxColumn";
            this.dMDStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.dMDStatusDataGridViewTextBoxColumn.Width = 89;
            // 
            // realDMDColorStatusDataGridViewTextBoxColumn
            // 
            this.realDMDColorStatusDataGridViewTextBoxColumn.DataPropertyName = "RealDMDColorStatus";
            this.realDMDColorStatusDataGridViewTextBoxColumn.HeaderText = "Read DMD Color Media";
            this.realDMDColorStatusDataGridViewTextBoxColumn.Name = "realDMDColorStatusDataGridViewTextBoxColumn";
            this.realDMDColorStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.realDMDColorStatusDataGridViewTextBoxColumn.Width = 145;
            // 
            // readDMDStatusDataGridViewTextBoxColumn
            // 
            this.readDMDStatusDataGridViewTextBoxColumn.DataPropertyName = "ReadDMDStatus";
            this.readDMDStatusDataGridViewTextBoxColumn.HeaderText = "Read DMD Media";
            this.readDMDStatusDataGridViewTextBoxColumn.Name = "readDMDStatusDataGridViewTextBoxColumn";
            this.readDMDStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.readDMDStatusDataGridViewTextBoxColumn.Width = 118;
            // 
            // tableStatusDataGridViewTextBoxColumn
            // 
            this.tableStatusDataGridViewTextBoxColumn.DataPropertyName = "TableStatus";
            this.tableStatusDataGridViewTextBoxColumn.HeaderText = "Table Media";
            this.tableStatusDataGridViewTextBoxColumn.Name = "tableStatusDataGridViewTextBoxColumn";
            this.tableStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.tableStatusDataGridViewTextBoxColumn.Width = 91;
            // 
            // tableDesktopStatusDataGridViewTextBoxColumn
            // 
            this.tableDesktopStatusDataGridViewTextBoxColumn.DataPropertyName = "TableDesktopStatus";
            this.tableDesktopStatusDataGridViewTextBoxColumn.HeaderText = "Table Desktop Media";
            this.tableDesktopStatusDataGridViewTextBoxColumn.Name = "tableDesktopStatusDataGridViewTextBoxColumn";
            this.tableDesktopStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.tableDesktopStatusDataGridViewTextBoxColumn.Width = 134;
            // 
            // topperStatusDataGridViewTextBoxColumn
            // 
            this.topperStatusDataGridViewTextBoxColumn.DataPropertyName = "TopperStatus";
            this.topperStatusDataGridViewTextBoxColumn.HeaderText = "Topper Media";
            this.topperStatusDataGridViewTextBoxColumn.Name = "topperStatusDataGridViewTextBoxColumn";
            this.topperStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.topperStatusDataGridViewTextBoxColumn.Width = 98;
            // 
            // ManufacturerMediaStatus
            // 
            this.ManufacturerMediaStatus.DataPropertyName = "ManufacturerMediaStatus";
            this.ManufacturerMediaStatus.HeaderText = "Manufacturer Media";
            this.ManufacturerMediaStatus.Name = "ManufacturerMediaStatus";
            this.ManufacturerMediaStatus.ReadOnly = true;
            this.ManufacturerMediaStatus.Width = 127;
            // 
            // hasWheelImageDataGridViewCheckBoxColumn
            // 
            this.hasWheelImageDataGridViewCheckBoxColumn.DataPropertyName = "HasWheelImage";
            this.hasWheelImageDataGridViewCheckBoxColumn.HeaderText = "Wheel Image";
            this.hasWheelImageDataGridViewCheckBoxColumn.Name = "hasWheelImageDataGridViewCheckBoxColumn";
            this.hasWheelImageDataGridViewCheckBoxColumn.ReadOnly = true;
            this.hasWheelImageDataGridViewCheckBoxColumn.Width = 76;
            // 
            // HasInstructionCard
            // 
            this.HasInstructionCard.DataPropertyName = "HasInstructionCard";
            this.HasInstructionCard.HeaderText = "Instruction Card";
            this.HasInstructionCard.Name = "HasInstructionCard";
            this.HasInstructionCard.ReadOnly = true;
            this.HasInstructionCard.Width = 87;
            // 
            // HasFlyer
            // 
            this.HasFlyer.DataPropertyName = "HasFlyer";
            this.HasFlyer.HeaderText = "Flyer";
            this.HasFlyer.Name = "HasFlyer";
            this.HasFlyer.ReadOnly = true;
            this.HasFlyer.Width = 35;
            // 
            // HasLaunchAudio
            // 
            this.HasLaunchAudio.DataPropertyName = "HasLaunchAudio";
            this.HasLaunchAudio.HeaderText = "Launch Audio";
            this.HasLaunchAudio.Name = "HasLaunchAudio";
            this.HasLaunchAudio.ReadOnly = true;
            this.HasLaunchAudio.Width = 79;
            // 
            // HasTableAudio
            // 
            this.HasTableAudio.DataPropertyName = "HasTableAudio";
            this.HasTableAudio.HeaderText = "Table Audio Media";
            this.HasTableAudio.Name = "HasTableAudio";
            this.HasTableAudio.ReadOnly = true;
            this.HasTableAudio.Width = 102;
            // 
            // frontEndGameBindingSource
            // 
            this.frontEndGameBindingSource.DataSource = typeof(PinCab.Utils.ViewModels.FrontEndGameViewModel);
            // 
            // statusStripBottom
            // 
            this.statusStripBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabelSpacer,
            this.toolStripProgressBar});
            this.statusStripBottom.Location = new System.Drawing.Point(0, 153);
            this.statusStripBottom.Name = "statusStripBottom";
            this.statusStripBottom.Size = new System.Drawing.Size(1122, 22);
            this.statusStripBottom.TabIndex = 11;
            this.statusStripBottom.Text = "statusStrip1";
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
            this.toolStripStatusLabelSpacer.Size = new System.Drawing.Size(938, 17);
            this.toolStripStatusLabelSpacer.Spring = true;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1122, 175);
            this.txtLog.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Front End";
            // 
            // cmbFrontEnd
            // 
            this.cmbFrontEnd.DisplayMember = "Name";
            this.cmbFrontEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrontEnd.FormattingEnabled = true;
            this.cmbFrontEnd.Location = new System.Drawing.Point(72, 7);
            this.cmbFrontEnd.Name = "cmbFrontEnd";
            this.cmbFrontEnd.Size = new System.Drawing.Size(107, 21);
            this.cmbFrontEnd.TabIndex = 35;
            this.cmbFrontEnd.ValueMember = "System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Method";
            // 
            // cmbMethod
            // 
            this.cmbMethod.DisplayMember = "Name";
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Items.AddRange(new object[] {
            "OBS Studio",
            "FFMpeg"});
            this.cmbMethod.Location = new System.Drawing.Point(71, 34);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(168, 21);
            this.cmbMethod.TabIndex = 37;
            this.cmbMethod.ValueMember = "System";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Startup Delay Seconds:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Framerate:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Record Time Seconds:";
            // 
            // txtStartupDelaySeconds
            // 
            this.txtStartupDelaySeconds.Location = new System.Drawing.Point(137, 66);
            this.txtStartupDelaySeconds.Name = "txtStartupDelaySeconds";
            this.txtStartupDelaySeconds.Size = new System.Drawing.Size(73, 20);
            this.txtStartupDelaySeconds.TabIndex = 45;
            // 
            // txtFramerate
            // 
            this.txtFramerate.Location = new System.Drawing.Point(137, 89);
            this.txtFramerate.Name = "txtFramerate";
            this.txtFramerate.Size = new System.Drawing.Size(73, 20);
            this.txtFramerate.TabIndex = 46;
            // 
            // txtRecordTimeSeconds
            // 
            this.txtRecordTimeSeconds.Location = new System.Drawing.Point(137, 111);
            this.txtRecordTimeSeconds.Name = "txtRecordTimeSeconds";
            this.txtRecordTimeSeconds.Size = new System.Drawing.Size(73, 20);
            this.txtRecordTimeSeconds.TabIndex = 47;
            // 
            // btnBegin
            // 
            this.btnBegin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBegin.Location = new System.Drawing.Point(15, 175);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(75, 23);
            this.btnBegin.TabIndex = 8;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnSelectAllGamesWithMissingMedia
            // 
            this.btnSelectAllGamesWithMissingMedia.Location = new System.Drawing.Point(15, 146);
            this.btnSelectAllGamesWithMissingMedia.Name = "btnSelectAllGamesWithMissingMedia";
            this.btnSelectAllGamesWithMissingMedia.Size = new System.Drawing.Size(192, 23);
            this.btnSelectAllGamesWithMissingMedia.TabIndex = 48;
            this.btnSelectAllGamesWithMissingMedia.Text = "Select All Games with Missing Media";
            this.btnSelectAllGamesWithMissingMedia.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(135, 175);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Location = new System.Drawing.Point(223, 146);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(75, 23);
            this.btnUnselectAll.TabIndex = 49;
            this.btnUnselectAll.Text = "Unselect All";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Selected:";
            // 
            // lblSelectedTables
            // 
            this.lblSelectedTables.AutoSize = true;
            this.lblSelectedTables.Location = new System.Drawing.Point(328, 185);
            this.lblSelectedTables.Name = "lblSelectedTables";
            this.lblSelectedTables.Size = new System.Drawing.Size(129, 13);
            this.lblSelectedTables.TabIndex = 51;
            this.lblSelectedTables.Text = "(Select one or more items)";
            // 
            // btnBuildObsProfiles
            // 
            this.btnBuildObsProfiles.Location = new System.Drawing.Point(245, 34);
            this.btnBuildObsProfiles.Name = "btnBuildObsProfiles";
            this.btnBuildObsProfiles.Size = new System.Drawing.Size(107, 23);
            this.btnBuildObsProfiles.TabIndex = 52;
            this.btnBuildObsProfiles.Text = "Build OBS Profiles";
            this.btnBuildObsProfiles.UseVisualStyleBackColor = true;
            // 
            // cmbPlayfield
            // 
            this.cmbPlayfield.DisplayMember = "Name";
            this.cmbPlayfield.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayfield.FormattingEnabled = true;
            this.cmbPlayfield.Items.AddRange(new object[] {
            "Do Not Record",
            "Record Only if Missing",
            "Record Always"});
            this.cmbPlayfield.Location = new System.Drawing.Point(434, 8);
            this.cmbPlayfield.Name = "cmbPlayfield";
            this.cmbPlayfield.Size = new System.Drawing.Size(159, 21);
            this.cmbPlayfield.TabIndex = 53;
            this.cmbPlayfield.ValueMember = "Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(379, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "Playfield:";
            // 
            // cmbBackglass
            // 
            this.cmbBackglass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackglass.FormattingEnabled = true;
            this.cmbBackglass.Items.AddRange(new object[] {
            "Do Not Record",
            "Record Only if Missing",
            "Record Always"});
            this.cmbBackglass.Location = new System.Drawing.Point(434, 32);
            this.cmbBackglass.Name = "cmbBackglass";
            this.cmbBackglass.Size = new System.Drawing.Size(159, 21);
            this.cmbBackglass.TabIndex = 55;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(369, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "Backglass:";
            // 
            // cmbDMD
            // 
            this.cmbDMD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDMD.FormattingEnabled = true;
            this.cmbDMD.Items.AddRange(new object[] {
            "Do Not Record",
            "Record Only if Missing",
            "Record Always"});
            this.cmbDMD.Location = new System.Drawing.Point(434, 57);
            this.cmbDMD.Name = "cmbDMD";
            this.cmbDMD.Size = new System.Drawing.Size(159, 21);
            this.cmbDMD.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(393, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 58;
            this.label9.Text = "DMD:";
            // 
            // cmbTopper
            // 
            this.cmbTopper.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTopper.FormattingEnabled = true;
            this.cmbTopper.Items.AddRange(new object[] {
            "Do Not Record",
            "Record Only if Missing",
            "Record Always"});
            this.cmbTopper.Location = new System.Drawing.Point(434, 80);
            this.cmbTopper.Name = "cmbTopper";
            this.cmbTopper.Size = new System.Drawing.Size(159, 21);
            this.cmbTopper.TabIndex = 59;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(384, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 60;
            this.label10.Text = "Topper:";
            // 
            // cmbFullDMD
            // 
            this.cmbFullDMD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFullDMD.FormattingEnabled = true;
            this.cmbFullDMD.Items.AddRange(new object[] {
            "Do Not Record",
            "Record Only if Missing",
            "Record Always"});
            this.cmbFullDMD.Location = new System.Drawing.Point(434, 107);
            this.cmbFullDMD.Name = "cmbFullDMD";
            this.cmbFullDMD.Size = new System.Drawing.Size(159, 21);
            this.cmbFullDMD.TabIndex = 61;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(374, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 62;
            this.label11.Text = "Full DMD:";
            // 
            // cmbApron
            // 
            this.cmbApron.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApron.FormattingEnabled = true;
            this.cmbApron.Items.AddRange(new object[] {
            "Do Not Record",
            "Record Only if Missing",
            "Record Always"});
            this.cmbApron.Location = new System.Drawing.Point(434, 134);
            this.cmbApron.Name = "cmbApron";
            this.cmbApron.Size = new System.Drawing.Size(159, 21);
            this.cmbApron.TabIndex = 63;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(390, 137);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 64;
            this.label12.Text = "Apron:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.cmbApron);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbFullDMD);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmbTopper);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cmbDMD);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmbBackglass);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cmbPlayfield);
            this.panel1.Controls.Add(this.btnBuildObsProfiles);
            this.panel1.Controls.Add(this.lblSelectedTables);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnUnselectAll);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSelectAllGamesWithMissingMedia);
            this.panel1.Controls.Add(this.btnBegin);
            this.panel1.Controls.Add(this.txtRecordTimeSeconds);
            this.panel1.Controls.Add(this.txtFramerate);
            this.panel1.Controls.Add(this.txtStartupDelaySeconds);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmbMethod);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbFrontEnd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1122, 211);
            this.panel1.TabIndex = 26;
            // 
            // RecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 690);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "RecordForm";
            this.Text = "Record Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecordForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGameList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frontEndGameBindingSource)).EndInit();
            this.statusStripBottom.ResumeLayout(false);
            this.statusStripBottom.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource frontEndGameBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewGameList;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.StatusStrip statusStripBottom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enabledDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn backglassStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dMDStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn realDMDColorStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn readDMDStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableDesktopStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn topperStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManufacturerMediaStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasWheelImageDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasInstructionCard;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasFlyer;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasLaunchAudio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HasTableAudio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFrontEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStartupDelaySeconds;
        private System.Windows.Forms.TextBox txtFramerate;
        private System.Windows.Forms.TextBox txtRecordTimeSeconds;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnSelectAllGamesWithMissingMedia;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSelectedTables;
        private System.Windows.Forms.Button btnBuildObsProfiles;
        private System.Windows.Forms.ComboBox cmbPlayfield;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBackglass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDMD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTopper;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbFullDMD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbApron;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
    }
}