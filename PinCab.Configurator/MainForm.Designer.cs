namespace PinCab.Configurator
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxDisplays = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveDisplayLabel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateFFMpegCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshDisplayDepictionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeAllSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writePinballXiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeB2sSettingsScreenrestxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeFutureDMDiniToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.writeUltraDMDRegistryKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeDmdDeviceiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writevPinMameDefaultRegistryKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writevPinMameUpdateAllROMsRegistryKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writepinballYSettingstxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writepinupPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writepinupPopperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writepRocSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateallSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validatePinballXiniToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.validateb2SScreenrestxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validatefutureDMDiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateultraDMDRegistryKeyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.validateDmdDeviceiniToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.validatetoolStripMenuItemValidateVPinMameDefaultRegistryKey = new System.Windows.Forms.ToolStripMenuItem();
            this.validateToolStripMenuItemValidateVPinMameAllRomsRegistryKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.validatepinballYSettingstxtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.validatepinupPlayerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.validatepinupPopperPupDatabasedbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validatepROCSettingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpDisplayInfoToFileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpHighLevelDisplayInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.b2SScreenresEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pinMameROMBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbRegionLabel = new System.Windows.Forms.ComboBox();
            this.btnAddRegionToDisplay = new System.Windows.Forms.Button();
            this.listBoxDisplayRegions = new System.Windows.Forms.ListBox();
            this.lblRegions = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbRegionColor = new System.Windows.Forms.ComboBox();
            this.numericUpDownRegionXOffset = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRegionYOffset = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRegionWidth = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRegionHeight = new System.Windows.Forms.NumericUpDown();
            this.backgroundWorkerRefreshDispaly = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainerDepictionAndLog = new System.Windows.Forms.SplitContainer();
            this.panelMonitorDrawing = new System.Windows.Forms.Panel();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtDisplayLabel = new System.Windows.Forms.TextBox();
            this.backgroundWorkerProgressBar = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDepictionAndLog = new System.Windows.Forms.Panel();
            this.panelRegionAndDisplayDetails = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRegionXOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRegionYOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRegionWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRegionHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDepictionAndLog)).BeginInit();
            this.splitContainerDepictionAndLog.Panel1.SuspendLayout();
            this.splitContainerDepictionAndLog.Panel2.SuspendLayout();
            this.splitContainerDepictionAndLog.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDepictionAndLog.SuspendLayout();
            this.panelRegionAndDisplayDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Displays:";
            // 
            // listBoxDisplays
            // 
            this.listBoxDisplays.FormattingEnabled = true;
            this.listBoxDisplays.Location = new System.Drawing.Point(88, 5);
            this.listBoxDisplays.Name = "listBoxDisplays";
            this.listBoxDisplays.Size = new System.Drawing.Size(652, 56);
            this.listBoxDisplays.TabIndex = 1;
            this.listBoxDisplays.SelectedIndexChanged += new System.EventHandler(this.listBoxDisplays_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Display Label:";
            // 
            // btnSaveDisplayLabel
            // 
            this.btnSaveDisplayLabel.Location = new System.Drawing.Point(96, 159);
            this.btnSaveDisplayLabel.Name = "btnSaveDisplayLabel";
            this.btnSaveDisplayLabel.Size = new System.Drawing.Size(116, 23);
            this.btnSaveDisplayLabel.TabIndex = 4;
            this.btnSaveDisplayLabel.Text = "Save Display Config";
            this.btnSaveDisplayLabel.UseVisualStyleBackColor = true;
            this.btnSaveDisplayLabel.Click += new System.EventHandler(this.btnSaveDisplayConfig_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.commandsToolStripMenuItem,
            this.utilitiesToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(756, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.saveConfigurationToolStripMenuItem,
            this.loadConfigurationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // saveConfigurationToolStripMenuItem
            // 
            this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
            this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveConfigurationToolStripMenuItem.Text = "Save Configuration";
            this.saveConfigurationToolStripMenuItem.Click += new System.EventHandler(this.saveConfigurationToolStripMenuItem_Click);
            // 
            // loadConfigurationToolStripMenuItem
            // 
            this.loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
            this.loadConfigurationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.loadConfigurationToolStripMenuItem.Text = "Load Configuration";
            this.loadConfigurationToolStripMenuItem.Click += new System.EventHandler(this.loadConfigurationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateFFMpegCommandsToolStripMenuItem,
            this.refreshDisplayDepictionToolStripMenuItem,
            this.writeConfigurationToolStripMenuItem,
            this.validateToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.commandsToolStripMenuItem.Text = "Commands";
            // 
            // generateFFMpegCommandsToolStripMenuItem
            // 
            this.generateFFMpegCommandsToolStripMenuItem.Name = "generateFFMpegCommandsToolStripMenuItem";
            this.generateFFMpegCommandsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.generateFFMpegCommandsToolStripMenuItem.Text = "Generate FFMpeg Commands";
            this.generateFFMpegCommandsToolStripMenuItem.Click += new System.EventHandler(this.generateFFMpegCommandsToolStripMenuItem_Click);
            // 
            // refreshDisplayDepictionToolStripMenuItem
            // 
            this.refreshDisplayDepictionToolStripMenuItem.Name = "refreshDisplayDepictionToolStripMenuItem";
            this.refreshDisplayDepictionToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.refreshDisplayDepictionToolStripMenuItem.Text = "Refresh Display Depiction";
            this.refreshDisplayDepictionToolStripMenuItem.Click += new System.EventHandler(this.refreshDisplayDepictionToolStripMenuItem_Click);
            // 
            // writeConfigurationToolStripMenuItem
            // 
            this.writeConfigurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.writeAllSettingsToolStripMenuItem,
            this.writePinballXiniToolStripMenuItem,
            this.writeB2sSettingsScreenrestxtToolStripMenuItem,
            this.writeFutureDMDiniToolStripMenuItem1,
            this.writeUltraDMDRegistryKeyToolStripMenuItem,
            this.writeDmdDeviceiniToolStripMenuItem,
            this.writevPinMameDefaultRegistryKeyToolStripMenuItem,
            this.writevPinMameUpdateAllROMsRegistryKeyToolStripMenuItem,
            this.writepinballYSettingstxtToolStripMenuItem,
            this.writepinupPlayerToolStripMenuItem,
            this.writepinupPopperToolStripMenuItem,
            this.writepRocSettingsToolStripMenuItem});
            this.writeConfigurationToolStripMenuItem.Name = "writeConfigurationToolStripMenuItem";
            this.writeConfigurationToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.writeConfigurationToolStripMenuItem.Text = "Write";
            // 
            // writeAllSettingsToolStripMenuItem
            // 
            this.writeAllSettingsToolStripMenuItem.Name = "writeAllSettingsToolStripMenuItem";
            this.writeAllSettingsToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.writeAllSettingsToolStripMenuItem.Text = "All Settings";
            // 
            // writePinballXiniToolStripMenuItem
            // 
            this.writePinballXiniToolStripMenuItem.Name = "writePinballXiniToolStripMenuItem";
            this.writePinballXiniToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.writePinballXiniToolStripMenuItem.Text = "PinballX.ini";
            this.writePinballXiniToolStripMenuItem.Click += new System.EventHandler(this.writePinballXiniToolStripMenuItem_Click);
            // 
            // writeB2sSettingsScreenrestxtToolStripMenuItem
            // 
            this.writeB2sSettingsScreenrestxtToolStripMenuItem.Name = "writeB2sSettingsScreenrestxtToolStripMenuItem";
            this.writeB2sSettingsScreenrestxtToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.writeB2sSettingsScreenrestxtToolStripMenuItem.Text = "B2s Settings (Screenres.txt)";
            this.writeB2sSettingsScreenrestxtToolStripMenuItem.Click += new System.EventHandler(this.writeB2sSettingsScreenrestxtToolStripMenuItem_Click);
            // 
            // writeFutureDMDiniToolStripMenuItem1
            // 
            this.writeFutureDMDiniToolStripMenuItem1.Name = "writeFutureDMDiniToolStripMenuItem1";
            this.writeFutureDMDiniToolStripMenuItem1.Size = new System.Drawing.Size(297, 22);
            this.writeFutureDMDiniToolStripMenuItem1.Text = "FutureDMD.ini";
            this.writeFutureDMDiniToolStripMenuItem1.Click += new System.EventHandler(this.writeFutureDMDiniToolStripMenuItem1_Click);
            // 
            // writeUltraDMDRegistryKeyToolStripMenuItem
            // 
            this.writeUltraDMDRegistryKeyToolStripMenuItem.Name = "writeUltraDMDRegistryKeyToolStripMenuItem";
            this.writeUltraDMDRegistryKeyToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.writeUltraDMDRegistryKeyToolStripMenuItem.Text = "UltraDMD Registry Key";
            this.writeUltraDMDRegistryKeyToolStripMenuItem.Click += new System.EventHandler(this.writeUltraDMDRegistryKeyToolStripMenuItem_Click);
            // 
            // writeDmdDeviceiniToolStripMenuItem
            // 
            this.writeDmdDeviceiniToolStripMenuItem.Name = "writeDmdDeviceiniToolStripMenuItem";
            this.writeDmdDeviceiniToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.writeDmdDeviceiniToolStripMenuItem.Text = "DMDDevice.ini";
            this.writeDmdDeviceiniToolStripMenuItem.Click += new System.EventHandler(this.writeDmdDeviceiniToolStripMenuItem_Click);
            // 
            // writevPinMameDefaultRegistryKeyToolStripMenuItem
            // 
            this.writevPinMameDefaultRegistryKeyToolStripMenuItem.Name = "writevPinMameDefaultRegistryKeyToolStripMenuItem";
            this.writevPinMameDefaultRegistryKeyToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.writevPinMameDefaultRegistryKeyToolStripMenuItem.Text = "VPinMame Default Registry Key";
            this.writevPinMameDefaultRegistryKeyToolStripMenuItem.Click += new System.EventHandler(this.writevPinMameDefaultRegistryKeyToolStripMenuItem_Click);
            // 
            // writevPinMameUpdateAllROMsRegistryKeyToolStripMenuItem
            // 
            this.writevPinMameUpdateAllROMsRegistryKeyToolStripMenuItem.Name = "writevPinMameUpdateAllROMsRegistryKeyToolStripMenuItem";
            this.writevPinMameUpdateAllROMsRegistryKeyToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.writevPinMameUpdateAllROMsRegistryKeyToolStripMenuItem.Text = "VPinMame Update All ROMs Registry Keys";
            this.writevPinMameUpdateAllROMsRegistryKeyToolStripMenuItem.Click += new System.EventHandler(this.writevPinMameUpdateAllROMsRegistryKeyToolStripMenuItem_Click);
            // 
            // writepinballYSettingstxtToolStripMenuItem
            // 
            this.writepinballYSettingstxtToolStripMenuItem.Name = "writepinballYSettingstxtToolStripMenuItem";
            this.writepinballYSettingstxtToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.writepinballYSettingstxtToolStripMenuItem.Text = "PinballY Settings.txt";
            // 
            // writepinupPlayerToolStripMenuItem
            // 
            this.writepinupPlayerToolStripMenuItem.Name = "writepinupPlayerToolStripMenuItem";
            this.writepinupPlayerToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.writepinupPlayerToolStripMenuItem.Text = "Pinup Player";
            // 
            // writepinupPopperToolStripMenuItem
            // 
            this.writepinupPopperToolStripMenuItem.Name = "writepinupPopperToolStripMenuItem";
            this.writepinupPopperToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.writepinupPopperToolStripMenuItem.Text = "Pinup Popper (PupDatabase.db)";
            // 
            // writepRocSettingsToolStripMenuItem
            // 
            this.writepRocSettingsToolStripMenuItem.Name = "writepRocSettingsToolStripMenuItem";
            this.writepRocSettingsToolStripMenuItem.Size = new System.Drawing.Size(297, 22);
            this.writepRocSettingsToolStripMenuItem.Text = "P-ROC Settings";
            // 
            // validateToolStripMenuItem
            // 
            this.validateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.validateallSettingsToolStripMenuItem,
            this.monitorConfigurationToolStripMenuItem,
            this.validatePinballXiniToolStripMenuItem1,
            this.validateb2SScreenrestxtToolStripMenuItem,
            this.validatefutureDMDiniToolStripMenuItem,
            this.validateultraDMDRegistryKeyToolStripMenuItem1,
            this.validateDmdDeviceiniToolStripMenuItem1,
            this.validatetoolStripMenuItemValidateVPinMameDefaultRegistryKey,
            this.validateToolStripMenuItemValidateVPinMameAllRomsRegistryKeys,
            this.validatepinballYSettingstxtToolStripMenuItem1,
            this.validatepinupPlayerToolStripMenuItem1,
            this.validatepinupPopperPupDatabasedbToolStripMenuItem,
            this.validatepROCSettingsToolStripMenuItem1});
            this.validateToolStripMenuItem.Name = "validateToolStripMenuItem";
            this.validateToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.validateToolStripMenuItem.Text = "Validate";
            // 
            // validateallSettingsToolStripMenuItem
            // 
            this.validateallSettingsToolStripMenuItem.Name = "validateallSettingsToolStripMenuItem";
            this.validateallSettingsToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.validateallSettingsToolStripMenuItem.Text = "All Settings";
            this.validateallSettingsToolStripMenuItem.Click += new System.EventHandler(this.validateallSettingsToolStripMenuItem_Click);
            // 
            // monitorConfigurationToolStripMenuItem
            // 
            this.monitorConfigurationToolStripMenuItem.Name = "monitorConfigurationToolStripMenuItem";
            this.monitorConfigurationToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.monitorConfigurationToolStripMenuItem.Text = "Monitor Configuration";
            this.monitorConfigurationToolStripMenuItem.Click += new System.EventHandler(this.monitorConfigurationToolStripMenuItem_Click);
            // 
            // validatePinballXiniToolStripMenuItem1
            // 
            this.validatePinballXiniToolStripMenuItem1.Name = "validatePinballXiniToolStripMenuItem1";
            this.validatePinballXiniToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            this.validatePinballXiniToolStripMenuItem1.Text = "PinballX.ini";
            this.validatePinballXiniToolStripMenuItem1.Click += new System.EventHandler(this.validatePinballXiniToolStripMenuItem1_Click);
            // 
            // validateb2SScreenrestxtToolStripMenuItem
            // 
            this.validateb2SScreenrestxtToolStripMenuItem.Name = "validateb2SScreenrestxtToolStripMenuItem";
            this.validateb2SScreenrestxtToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.validateb2SScreenrestxtToolStripMenuItem.Text = "B2S Settings (Screenres.txt)";
            this.validateb2SScreenrestxtToolStripMenuItem.Click += new System.EventHandler(this.validateb2SScreenrestxtToolStripMenuItem_Click);
            // 
            // validatefutureDMDiniToolStripMenuItem
            // 
            this.validatefutureDMDiniToolStripMenuItem.Name = "validatefutureDMDiniToolStripMenuItem";
            this.validatefutureDMDiniToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.validatefutureDMDiniToolStripMenuItem.Text = "FutureDMD.ini";
            this.validatefutureDMDiniToolStripMenuItem.Click += new System.EventHandler(this.validatefutureDMDiniToolStripMenuItem_Click);
            // 
            // validateultraDMDRegistryKeyToolStripMenuItem1
            // 
            this.validateultraDMDRegistryKeyToolStripMenuItem1.Name = "validateultraDMDRegistryKeyToolStripMenuItem1";
            this.validateultraDMDRegistryKeyToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            this.validateultraDMDRegistryKeyToolStripMenuItem1.Text = "UltraDMD Registry Key";
            this.validateultraDMDRegistryKeyToolStripMenuItem1.Click += new System.EventHandler(this.validateultraDMDRegistryKeyToolStripMenuItem1_Click);
            // 
            // validateDmdDeviceiniToolStripMenuItem1
            // 
            this.validateDmdDeviceiniToolStripMenuItem1.Name = "validateDmdDeviceiniToolStripMenuItem1";
            this.validateDmdDeviceiniToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            this.validateDmdDeviceiniToolStripMenuItem1.Text = "DMDDevice.ini";
            this.validateDmdDeviceiniToolStripMenuItem1.Click += new System.EventHandler(this.validateDmdDeviceiniToolStripMenuItem1_Click);
            // 
            // validatetoolStripMenuItemValidateVPinMameDefaultRegistryKey
            // 
            this.validatetoolStripMenuItemValidateVPinMameDefaultRegistryKey.Name = "validatetoolStripMenuItemValidateVPinMameDefaultRegistryKey";
            this.validatetoolStripMenuItemValidateVPinMameDefaultRegistryKey.Size = new System.Drawing.Size(256, 22);
            this.validatetoolStripMenuItemValidateVPinMameDefaultRegistryKey.Text = "VPinMame Default Registry Key";
            this.validatetoolStripMenuItemValidateVPinMameDefaultRegistryKey.Click += new System.EventHandler(this.validatetoolStripMenuItemValidateVPinMameDefaultRegistryKey_Click);
            // 
            // validateToolStripMenuItemValidateVPinMameAllRomsRegistryKeys
            // 
            this.validateToolStripMenuItemValidateVPinMameAllRomsRegistryKeys.Name = "validateToolStripMenuItemValidateVPinMameAllRomsRegistryKeys";
            this.validateToolStripMenuItemValidateVPinMameAllRomsRegistryKeys.Size = new System.Drawing.Size(256, 22);
            this.validateToolStripMenuItemValidateVPinMameAllRomsRegistryKeys.Text = "VPinMame All ROMs Registry Keys";
            this.validateToolStripMenuItemValidateVPinMameAllRomsRegistryKeys.Click += new System.EventHandler(this.validateToolStripMenuItemValidateVPinMameAllRomsRegistryKeys_Click);
            // 
            // validatepinballYSettingstxtToolStripMenuItem1
            // 
            this.validatepinballYSettingstxtToolStripMenuItem1.Name = "validatepinballYSettingstxtToolStripMenuItem1";
            this.validatepinballYSettingstxtToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            this.validatepinballYSettingstxtToolStripMenuItem1.Text = "PinballY Settings.txt";
            // 
            // validatepinupPlayerToolStripMenuItem1
            // 
            this.validatepinupPlayerToolStripMenuItem1.Name = "validatepinupPlayerToolStripMenuItem1";
            this.validatepinupPlayerToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            this.validatepinupPlayerToolStripMenuItem1.Text = "Pinup Player";
            // 
            // validatepinupPopperPupDatabasedbToolStripMenuItem
            // 
            this.validatepinupPopperPupDatabasedbToolStripMenuItem.Name = "validatepinupPopperPupDatabasedbToolStripMenuItem";
            this.validatepinupPopperPupDatabasedbToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.validatepinupPopperPupDatabasedbToolStripMenuItem.Text = "Pinup Popper (PupDatabase.db)";
            // 
            // validatepROCSettingsToolStripMenuItem1
            // 
            this.validatepROCSettingsToolStripMenuItem1.Name = "validatepROCSettingsToolStripMenuItem1";
            this.validatepROCSettingsToolStripMenuItem1.Size = new System.Drawing.Size(256, 22);
            this.validatepROCSettingsToolStripMenuItem1.Text = "P-ROC Settings";
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dumpDisplayInfoToFileToolStripMenuItem1,
            this.dumpHighLevelDisplayInformationToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // dumpDisplayInfoToFileToolStripMenuItem1
            // 
            this.dumpDisplayInfoToFileToolStripMenuItem1.Name = "dumpDisplayInfoToFileToolStripMenuItem1";
            this.dumpDisplayInfoToFileToolStripMenuItem1.Size = new System.Drawing.Size(273, 22);
            this.dumpDisplayInfoToFileToolStripMenuItem1.Text = "Dump Display Info To File";
            this.dumpDisplayInfoToFileToolStripMenuItem1.Click += new System.EventHandler(this.dumpDisplayInfoToFileToolStripMenuItem1_Click);
            // 
            // dumpHighLevelDisplayInformationToolStripMenuItem
            // 
            this.dumpHighLevelDisplayInformationToolStripMenuItem.Name = "dumpHighLevelDisplayInformationToolStripMenuItem";
            this.dumpHighLevelDisplayInformationToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.dumpHighLevelDisplayInformationToolStripMenuItem.Text = "Dump High Level Display Information";
            this.dumpHighLevelDisplayInformationToolStripMenuItem.Click += new System.EventHandler(this.dumpHighLevelDisplayInformationToolStripMenuItem_Click);
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.b2SScreenresEditorToolStripMenuItem,
            this.pinMameROMBrowserToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // b2SScreenresEditorToolStripMenuItem
            // 
            this.b2SScreenresEditorToolStripMenuItem.Name = "b2SScreenresEditorToolStripMenuItem";
            this.b2SScreenresEditorToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.b2SScreenresEditorToolStripMenuItem.Text = "B2S Screenres Editor";
            this.b2SScreenresEditorToolStripMenuItem.Click += new System.EventHandler(this.b2SScreenresEditorToolStripMenuItem_Click);
            // 
            // pinMameROMBrowserToolStripMenuItem
            // 
            this.pinMameROMBrowserToolStripMenuItem.Name = "pinMameROMBrowserToolStripMenuItem";
            this.pinMameROMBrowserToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.pinMameROMBrowserToolStripMenuItem.Text = "PinMAME ROM Browser";
            this.pinMameROMBrowserToolStripMenuItem.Click += new System.EventHandler(this.pinMameROMBrowserToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Region X Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Region Y Offset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(247, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Region Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Region Height";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Region Label:";
            // 
            // cmbRegionLabel
            // 
            this.cmbRegionLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegionLabel.FormattingEnabled = true;
            this.cmbRegionLabel.Items.AddRange(new object[] {
            "Playfield",
            "DMD",
            "Backglass",
            "Topper",
            "Apron"});
            this.cmbRegionLabel.Location = new System.Drawing.Point(96, 134);
            this.cmbRegionLabel.MaxDropDownItems = 10;
            this.cmbRegionLabel.Name = "cmbRegionLabel";
            this.cmbRegionLabel.Size = new System.Drawing.Size(100, 21);
            this.cmbRegionLabel.TabIndex = 18;
            this.cmbRegionLabel.SelectedIndexChanged += new System.EventHandler(this.cmbRegionLabel_SelectedIndexChanged);
            // 
            // btnAddRegionToDisplay
            // 
            this.btnAddRegionToDisplay.Location = new System.Drawing.Point(279, 159);
            this.btnAddRegionToDisplay.Name = "btnAddRegionToDisplay";
            this.btnAddRegionToDisplay.Size = new System.Drawing.Size(146, 23);
            this.btnAddRegionToDisplay.TabIndex = 19;
            this.btnAddRegionToDisplay.Text = "Add / Update Region";
            this.btnAddRegionToDisplay.UseVisualStyleBackColor = true;
            this.btnAddRegionToDisplay.Click += new System.EventHandler(this.btnAddRegionToDisplay_Click);
            // 
            // listBoxDisplayRegions
            // 
            this.listBoxDisplayRegions.FormattingEnabled = true;
            this.listBoxDisplayRegions.Location = new System.Drawing.Point(443, 90);
            this.listBoxDisplayRegions.Name = "listBoxDisplayRegions";
            this.listBoxDisplayRegions.Size = new System.Drawing.Size(225, 69);
            this.listBoxDisplayRegions.TabIndex = 20;
            this.listBoxDisplayRegions.SelectedIndexChanged += new System.EventHandler(this.listBoxDisplayRegions_SelectedIndexChanged);
            this.listBoxDisplayRegions.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxDisplayRegions_KeyUp);
            // 
            // lblRegions
            // 
            this.lblRegions.AutoSize = true;
            this.lblRegions.Location = new System.Drawing.Point(440, 69);
            this.lblRegions.Name = "lblRegions";
            this.lblRegions.Size = new System.Drawing.Size(179, 13);
            this.lblRegions.TabIndex = 21;
            this.lblRegions.Text = "Display Regions (DEL key removes):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(244, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Region Color";
            // 
            // cmbRegionColor
            // 
            this.cmbRegionColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRegionColor.FormattingEnabled = true;
            this.cmbRegionColor.Items.AddRange(new object[] {
            "Green",
            "Blue",
            "Yellow",
            "Pink",
            "Maroon",
            "BlueViolet",
            "Purple",
            "GreenYellow",
            "Silver",
            "Ivory",
            "Orange"});
            this.cmbRegionColor.Location = new System.Drawing.Point(325, 137);
            this.cmbRegionColor.MaxDropDownItems = 10;
            this.cmbRegionColor.Name = "cmbRegionColor";
            this.cmbRegionColor.Size = new System.Drawing.Size(100, 21);
            this.cmbRegionColor.TabIndex = 23;
            this.cmbRegionColor.SelectedIndexChanged += new System.EventHandler(this.cmbRegionColor_SelectedIndexChanged);
            // 
            // numericUpDownRegionXOffset
            // 
            this.numericUpDownRegionXOffset.Location = new System.Drawing.Point(96, 90);
            this.numericUpDownRegionXOffset.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownRegionXOffset.Name = "numericUpDownRegionXOffset";
            this.numericUpDownRegionXOffset.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownRegionXOffset.TabIndex = 24;
            this.numericUpDownRegionXOffset.ValueChanged += new System.EventHandler(this.numericUpDownRegionXOffset_ValueChanged);
            // 
            // numericUpDownRegionYOffset
            // 
            this.numericUpDownRegionYOffset.Location = new System.Drawing.Point(96, 112);
            this.numericUpDownRegionYOffset.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownRegionYOffset.Name = "numericUpDownRegionYOffset";
            this.numericUpDownRegionYOffset.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownRegionYOffset.TabIndex = 25;
            this.numericUpDownRegionYOffset.ValueChanged += new System.EventHandler(this.numericUpDownRegionYOffset_ValueChanged);
            // 
            // numericUpDownRegionWidth
            // 
            this.numericUpDownRegionWidth.Location = new System.Drawing.Point(325, 90);
            this.numericUpDownRegionWidth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownRegionWidth.Name = "numericUpDownRegionWidth";
            this.numericUpDownRegionWidth.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownRegionWidth.TabIndex = 26;
            this.numericUpDownRegionWidth.ValueChanged += new System.EventHandler(this.numericUpDownRegionWidth_ValueChanged);
            // 
            // numericUpDownRegionHeight
            // 
            this.numericUpDownRegionHeight.Location = new System.Drawing.Point(325, 113);
            this.numericUpDownRegionHeight.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownRegionHeight.Name = "numericUpDownRegionHeight";
            this.numericUpDownRegionHeight.Size = new System.Drawing.Size(100, 20);
            this.numericUpDownRegionHeight.TabIndex = 27;
            this.numericUpDownRegionHeight.ValueChanged += new System.EventHandler(this.numericUpDownRegionHeight_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            // 
            // splitContainerDepictionAndLog
            // 
            this.splitContainerDepictionAndLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDepictionAndLog.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDepictionAndLog.Name = "splitContainerDepictionAndLog";
            this.splitContainerDepictionAndLog.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDepictionAndLog.Panel1
            // 
            this.splitContainerDepictionAndLog.Panel1.Controls.Add(this.panelMonitorDrawing);
            // 
            // splitContainerDepictionAndLog.Panel2
            // 
            this.splitContainerDepictionAndLog.Panel2.Controls.Add(this.txtData);
            this.splitContainerDepictionAndLog.Size = new System.Drawing.Size(750, 335);
            this.splitContainerDepictionAndLog.SplitterDistance = 154;
            this.splitContainerDepictionAndLog.TabIndex = 28;
            // 
            // panelMonitorDrawing
            // 
            this.panelMonitorDrawing.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMonitorDrawing.BackColor = System.Drawing.Color.Black;
            this.panelMonitorDrawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMonitorDrawing.Location = new System.Drawing.Point(0, 0);
            this.panelMonitorDrawing.Name = "panelMonitorDrawing";
            this.panelMonitorDrawing.Size = new System.Drawing.Size(750, 154);
            this.panelMonitorDrawing.TabIndex = 8;
            this.panelMonitorDrawing.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMonitorDrawing_Paint);
            // 
            // txtData
            // 
            this.txtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtData.Location = new System.Drawing.Point(0, 0);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(750, 177);
            this.txtData.TabIndex = 1;
            // 
            // txtDisplayLabel
            // 
            this.txtDisplayLabel.Location = new System.Drawing.Point(87, 66);
            this.txtDisplayLabel.Name = "txtDisplayLabel";
            this.txtDisplayLabel.Size = new System.Drawing.Size(338, 20);
            this.txtDisplayLabel.TabIndex = 29;
            // 
            // backgroundWorkerProgressBar
            // 
            this.backgroundWorkerProgressBar.WorkerReportsProgress = true;
            this.backgroundWorkerProgressBar.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerProgressBar_ProgressChanged);
            this.backgroundWorkerProgressBar.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerProgressBar_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 561);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(756, 23);
            this.progressBar.TabIndex = 30;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panelDepictionAndLog, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelRegionAndDisplayDetails, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 537);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // panelDepictionAndLog
            // 
            this.panelDepictionAndLog.Controls.Add(this.splitContainerDepictionAndLog);
            this.panelDepictionAndLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDepictionAndLog.Location = new System.Drawing.Point(3, 199);
            this.panelDepictionAndLog.Name = "panelDepictionAndLog";
            this.panelDepictionAndLog.Size = new System.Drawing.Size(750, 335);
            this.panelDepictionAndLog.TabIndex = 32;
            // 
            // panelRegionAndDisplayDetails
            // 
            this.panelRegionAndDisplayDetails.Controls.Add(this.label1);
            this.panelRegionAndDisplayDetails.Controls.Add(this.listBoxDisplays);
            this.panelRegionAndDisplayDetails.Controls.Add(this.label2);
            this.panelRegionAndDisplayDetails.Controls.Add(this.txtDisplayLabel);
            this.panelRegionAndDisplayDetails.Controls.Add(this.btnSaveDisplayLabel);
            this.panelRegionAndDisplayDetails.Controls.Add(this.numericUpDownRegionHeight);
            this.panelRegionAndDisplayDetails.Controls.Add(this.label3);
            this.panelRegionAndDisplayDetails.Controls.Add(this.numericUpDownRegionWidth);
            this.panelRegionAndDisplayDetails.Controls.Add(this.label4);
            this.panelRegionAndDisplayDetails.Controls.Add(this.numericUpDownRegionYOffset);
            this.panelRegionAndDisplayDetails.Controls.Add(this.label5);
            this.panelRegionAndDisplayDetails.Controls.Add(this.numericUpDownRegionXOffset);
            this.panelRegionAndDisplayDetails.Controls.Add(this.label6);
            this.panelRegionAndDisplayDetails.Controls.Add(this.cmbRegionColor);
            this.panelRegionAndDisplayDetails.Controls.Add(this.label7);
            this.panelRegionAndDisplayDetails.Controls.Add(this.label8);
            this.panelRegionAndDisplayDetails.Controls.Add(this.cmbRegionLabel);
            this.panelRegionAndDisplayDetails.Controls.Add(this.lblRegions);
            this.panelRegionAndDisplayDetails.Controls.Add(this.btnAddRegionToDisplay);
            this.panelRegionAndDisplayDetails.Controls.Add(this.listBoxDisplayRegions);
            this.panelRegionAndDisplayDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegionAndDisplayDetails.Location = new System.Drawing.Point(3, 3);
            this.panelRegionAndDisplayDetails.Name = "panelRegionAndDisplayDetails";
            this.panelRegionAndDisplayDetails.Size = new System.Drawing.Size(750, 190);
            this.panelRegionAndDisplayDetails.TabIndex = 32;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 584);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(772, 623);
            this.Name = "MainForm";
            this.Text = "Pincab Configurator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRegionXOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRegionYOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRegionWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRegionHeight)).EndInit();
            this.splitContainerDepictionAndLog.Panel1.ResumeLayout(false);
            this.splitContainerDepictionAndLog.Panel2.ResumeLayout(false);
            this.splitContainerDepictionAndLog.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDepictionAndLog)).EndInit();
            this.splitContainerDepictionAndLog.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDepictionAndLog.ResumeLayout(false);
            this.panelRegionAndDisplayDetails.ResumeLayout(false);
            this.panelRegionAndDisplayDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxDisplays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveDisplayLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateFFMpegCommandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshDisplayDepictionToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigurationToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbRegionLabel;
        private System.Windows.Forms.Button btnAddRegionToDisplay;
        private System.Windows.Forms.ListBox listBoxDisplayRegions;
        private System.Windows.Forms.Label lblRegions;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbRegionColor;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateallSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateb2SScreenrestxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validatefutureDMDiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeAllSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeB2sSettingsScreenrestxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeFutureDMDiniToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem writeUltraDMDRegistryKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeDmdDeviceiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writevPinMameDefaultRegistryKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writevPinMameUpdateAllROMsRegistryKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validatetoolStripMenuItemValidateVPinMameDefaultRegistryKey;
        private System.Windows.Forms.ToolStripMenuItem validateToolStripMenuItemValidateVPinMameAllRomsRegistryKeys;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpDisplayInfoToFileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem writepinballYSettingstxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writepinupPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writepinupPopperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writePinballXiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpHighLevelDisplayInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writepRocSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validatePinballXiniToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem validateultraDMDRegistryKeyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem validateDmdDeviceiniToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem validatepinballYSettingstxtToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem validatepinupPlayerToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem validatepinupPopperPupDatabasedbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validatepROCSettingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDownRegionXOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownRegionYOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownRegionWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownRegionHeight;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRefreshDispaly;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainerDepictionAndLog;
        private System.Windows.Forms.Panel panelMonitorDrawing;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.TextBox txtDisplayLabel;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem b2SScreenresEditorToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProgressBar;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelRegionAndDisplayDetails;
        private System.Windows.Forms.Panel panelDepictionAndLog;
        private System.Windows.Forms.ToolStripMenuItem pinMameROMBrowserToolStripMenuItem;
    }
}

