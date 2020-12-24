
namespace PinCab.Configurator
{
    partial class GameManagerForm
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
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enabledDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alternateExeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hideDmdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hideTopperDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hideBackglassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.themeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPDBNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateAddedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateModifiedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasUpdatesAvailableDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.romDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vPinGameDatabaseIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.contextMenuStripGridActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewIPDBPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frontEndGameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtLog = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerProgressBar = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.cmbFrontEnd = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaAuditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGameList)).BeginInit();
            this.contextMenuStripGridActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frontEndGameBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 86);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewGameList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtLog);
            this.splitContainer1.Size = new System.Drawing.Size(955, 444);
            this.splitContainer1.SplitterDistance = 344;
            this.splitContainer1.TabIndex = 9;
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
            this.manufacturerDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.enabledDataGridViewTextBoxColumn,
            this.alternateExeDataGridViewTextBoxColumn,
            this.hideDmdDataGridViewTextBoxColumn,
            this.hideTopperDataGridViewTextBoxColumn,
            this.hideBackglassDataGridViewTextBoxColumn,
            this.ratingDataGridViewTextBoxColumn,
            this.playersDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn,
            this.themeDataGridViewTextBoxColumn,
            this.authorDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.iPDBNumberDataGridViewTextBoxColumn,
            this.dateAddedDataGridViewTextBoxColumn,
            this.dateModifiedDataGridViewTextBoxColumn,
            this.hasUpdatesAvailableDataGridViewCheckBoxColumn,
            this.romDataGridViewTextBoxColumn,
            this.vPinGameDatabaseIdDataGridViewTextBoxColumn,
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
            this.dataGridViewGameList.ContextMenuStrip = this.contextMenuStripGridActions;
            this.dataGridViewGameList.DataSource = this.frontEndGameBindingSource;
            this.dataGridViewGameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGameList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewGameList.Name = "dataGridViewGameList";
            this.dataGridViewGameList.ReadOnly = true;
            this.dataGridViewGameList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewGameList.Size = new System.Drawing.Size(955, 344);
            this.dataGridViewGameList.TabIndex = 2;
            this.dataGridViewGameList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewGameList_DataBindingComplete);
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "FileName";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.Width = 76;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 85;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.Width = 95;
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            this.yearDataGridViewTextBoxColumn.Width = 54;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Width = 56;
            // 
            // enabledDataGridViewTextBoxColumn
            // 
            this.enabledDataGridViewTextBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewTextBoxColumn.HeaderText = "Enabled";
            this.enabledDataGridViewTextBoxColumn.Name = "enabledDataGridViewTextBoxColumn";
            this.enabledDataGridViewTextBoxColumn.Width = 71;
            // 
            // alternateExeDataGridViewTextBoxColumn
            // 
            this.alternateExeDataGridViewTextBoxColumn.DataPropertyName = "AlternateExe";
            this.alternateExeDataGridViewTextBoxColumn.HeaderText = "AlternateExe";
            this.alternateExeDataGridViewTextBoxColumn.Name = "alternateExeDataGridViewTextBoxColumn";
            this.alternateExeDataGridViewTextBoxColumn.Width = 92;
            // 
            // hideDmdDataGridViewTextBoxColumn
            // 
            this.hideDmdDataGridViewTextBoxColumn.DataPropertyName = "HideDmd";
            this.hideDmdDataGridViewTextBoxColumn.HeaderText = "HideDmd";
            this.hideDmdDataGridViewTextBoxColumn.Name = "hideDmdDataGridViewTextBoxColumn";
            this.hideDmdDataGridViewTextBoxColumn.Width = 76;
            // 
            // hideTopperDataGridViewTextBoxColumn
            // 
            this.hideTopperDataGridViewTextBoxColumn.DataPropertyName = "HideTopper";
            this.hideTopperDataGridViewTextBoxColumn.HeaderText = "HideTopper";
            this.hideTopperDataGridViewTextBoxColumn.Name = "hideTopperDataGridViewTextBoxColumn";
            this.hideTopperDataGridViewTextBoxColumn.Width = 88;
            // 
            // hideBackglassDataGridViewTextBoxColumn
            // 
            this.hideBackglassDataGridViewTextBoxColumn.DataPropertyName = "HideBackglass";
            this.hideBackglassDataGridViewTextBoxColumn.HeaderText = "HideBackglass";
            this.hideBackglassDataGridViewTextBoxColumn.Name = "hideBackglassDataGridViewTextBoxColumn";
            this.hideBackglassDataGridViewTextBoxColumn.Width = 103;
            // 
            // ratingDataGridViewTextBoxColumn
            // 
            this.ratingDataGridViewTextBoxColumn.DataPropertyName = "Rating";
            this.ratingDataGridViewTextBoxColumn.HeaderText = "Rating";
            this.ratingDataGridViewTextBoxColumn.Name = "ratingDataGridViewTextBoxColumn";
            this.ratingDataGridViewTextBoxColumn.Width = 63;
            // 
            // playersDataGridViewTextBoxColumn
            // 
            this.playersDataGridViewTextBoxColumn.DataPropertyName = "Players";
            this.playersDataGridViewTextBoxColumn.HeaderText = "Players";
            this.playersDataGridViewTextBoxColumn.Name = "playersDataGridViewTextBoxColumn";
            this.playersDataGridViewTextBoxColumn.Width = 66;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Comment";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.Width = 76;
            // 
            // themeDataGridViewTextBoxColumn
            // 
            this.themeDataGridViewTextBoxColumn.DataPropertyName = "Theme";
            this.themeDataGridViewTextBoxColumn.HeaderText = "Theme";
            this.themeDataGridViewTextBoxColumn.Name = "themeDataGridViewTextBoxColumn";
            this.themeDataGridViewTextBoxColumn.Width = 65;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            this.authorDataGridViewTextBoxColumn.DataPropertyName = "Author";
            this.authorDataGridViewTextBoxColumn.HeaderText = "Author";
            this.authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            this.authorDataGridViewTextBoxColumn.Width = 63;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.Width = 67;
            // 
            // iPDBNumberDataGridViewTextBoxColumn
            // 
            this.iPDBNumberDataGridViewTextBoxColumn.DataPropertyName = "IPDBNumber";
            this.iPDBNumberDataGridViewTextBoxColumn.HeaderText = "IPDB #";
            this.iPDBNumberDataGridViewTextBoxColumn.Name = "iPDBNumberDataGridViewTextBoxColumn";
            this.iPDBNumberDataGridViewTextBoxColumn.Width = 67;
            // 
            // dateAddedDataGridViewTextBoxColumn
            // 
            this.dateAddedDataGridViewTextBoxColumn.DataPropertyName = "DateAdded";
            this.dateAddedDataGridViewTextBoxColumn.HeaderText = "Date Added";
            this.dateAddedDataGridViewTextBoxColumn.Name = "dateAddedDataGridViewTextBoxColumn";
            this.dateAddedDataGridViewTextBoxColumn.Width = 89;
            // 
            // dateModifiedDataGridViewTextBoxColumn
            // 
            this.dateModifiedDataGridViewTextBoxColumn.DataPropertyName = "DateModified";
            this.dateModifiedDataGridViewTextBoxColumn.HeaderText = "Date Modified";
            this.dateModifiedDataGridViewTextBoxColumn.Name = "dateModifiedDataGridViewTextBoxColumn";
            this.dateModifiedDataGridViewTextBoxColumn.Width = 98;
            // 
            // hasUpdatesAvailableDataGridViewCheckBoxColumn
            // 
            this.hasUpdatesAvailableDataGridViewCheckBoxColumn.DataPropertyName = "HasUpdatesAvailable";
            this.hasUpdatesAvailableDataGridViewCheckBoxColumn.HeaderText = "HasUpdatesAvailable";
            this.hasUpdatesAvailableDataGridViewCheckBoxColumn.Name = "hasUpdatesAvailableDataGridViewCheckBoxColumn";
            this.hasUpdatesAvailableDataGridViewCheckBoxColumn.Width = 115;
            // 
            // romDataGridViewTextBoxColumn
            // 
            this.romDataGridViewTextBoxColumn.DataPropertyName = "Rom";
            this.romDataGridViewTextBoxColumn.HeaderText = "Rom";
            this.romDataGridViewTextBoxColumn.Name = "romDataGridViewTextBoxColumn";
            this.romDataGridViewTextBoxColumn.Width = 54;
            // 
            // vPinGameDatabaseIdDataGridViewTextBoxColumn
            // 
            this.vPinGameDatabaseIdDataGridViewTextBoxColumn.DataPropertyName = "VPinGameDatabaseId";
            this.vPinGameDatabaseIdDataGridViewTextBoxColumn.HeaderText = "VPinGameDatabaseId";
            this.vPinGameDatabaseIdDataGridViewTextBoxColumn.Name = "vPinGameDatabaseIdDataGridViewTextBoxColumn";
            this.vPinGameDatabaseIdDataGridViewTextBoxColumn.Visible = false;
            this.vPinGameDatabaseIdDataGridViewTextBoxColumn.Width = 137;
            // 
            // backglassStatusDataGridViewTextBoxColumn
            // 
            this.backglassStatusDataGridViewTextBoxColumn.DataPropertyName = "BackglassStatus";
            this.backglassStatusDataGridViewTextBoxColumn.HeaderText = "Backglass Media";
            this.backglassStatusDataGridViewTextBoxColumn.Name = "backglassStatusDataGridViewTextBoxColumn";
            this.backglassStatusDataGridViewTextBoxColumn.Width = 113;
            // 
            // dMDStatusDataGridViewTextBoxColumn
            // 
            this.dMDStatusDataGridViewTextBoxColumn.DataPropertyName = "DMDStatus";
            this.dMDStatusDataGridViewTextBoxColumn.HeaderText = "DMD Media";
            this.dMDStatusDataGridViewTextBoxColumn.Name = "dMDStatusDataGridViewTextBoxColumn";
            this.dMDStatusDataGridViewTextBoxColumn.Width = 89;
            // 
            // realDMDColorStatusDataGridViewTextBoxColumn
            // 
            this.realDMDColorStatusDataGridViewTextBoxColumn.DataPropertyName = "RealDMDColorStatus";
            this.realDMDColorStatusDataGridViewTextBoxColumn.HeaderText = "Read DMD Color Media";
            this.realDMDColorStatusDataGridViewTextBoxColumn.Name = "realDMDColorStatusDataGridViewTextBoxColumn";
            this.realDMDColorStatusDataGridViewTextBoxColumn.Width = 145;
            // 
            // readDMDStatusDataGridViewTextBoxColumn
            // 
            this.readDMDStatusDataGridViewTextBoxColumn.DataPropertyName = "ReadDMDStatus";
            this.readDMDStatusDataGridViewTextBoxColumn.HeaderText = "Read DMD Media";
            this.readDMDStatusDataGridViewTextBoxColumn.Name = "readDMDStatusDataGridViewTextBoxColumn";
            this.readDMDStatusDataGridViewTextBoxColumn.Width = 118;
            // 
            // tableStatusDataGridViewTextBoxColumn
            // 
            this.tableStatusDataGridViewTextBoxColumn.DataPropertyName = "TableStatus";
            this.tableStatusDataGridViewTextBoxColumn.HeaderText = "Table Media";
            this.tableStatusDataGridViewTextBoxColumn.Name = "tableStatusDataGridViewTextBoxColumn";
            this.tableStatusDataGridViewTextBoxColumn.Width = 91;
            // 
            // tableDesktopStatusDataGridViewTextBoxColumn
            // 
            this.tableDesktopStatusDataGridViewTextBoxColumn.DataPropertyName = "TableDesktopStatus";
            this.tableDesktopStatusDataGridViewTextBoxColumn.HeaderText = "Table Desktop Media";
            this.tableDesktopStatusDataGridViewTextBoxColumn.Name = "tableDesktopStatusDataGridViewTextBoxColumn";
            this.tableDesktopStatusDataGridViewTextBoxColumn.Width = 134;
            // 
            // topperStatusDataGridViewTextBoxColumn
            // 
            this.topperStatusDataGridViewTextBoxColumn.DataPropertyName = "TopperStatus";
            this.topperStatusDataGridViewTextBoxColumn.HeaderText = "Topper Media";
            this.topperStatusDataGridViewTextBoxColumn.Name = "topperStatusDataGridViewTextBoxColumn";
            this.topperStatusDataGridViewTextBoxColumn.Width = 98;
            // 
            // ManufacturerMediaStatus
            // 
            this.ManufacturerMediaStatus.DataPropertyName = "ManufacturerMediaStatus";
            this.ManufacturerMediaStatus.HeaderText = "Manufacturer Media";
            this.ManufacturerMediaStatus.Name = "ManufacturerMediaStatus";
            this.ManufacturerMediaStatus.Width = 127;
            // 
            // hasWheelImageDataGridViewCheckBoxColumn
            // 
            this.hasWheelImageDataGridViewCheckBoxColumn.DataPropertyName = "HasWheelImage";
            this.hasWheelImageDataGridViewCheckBoxColumn.HeaderText = "Wheel Image";
            this.hasWheelImageDataGridViewCheckBoxColumn.Name = "hasWheelImageDataGridViewCheckBoxColumn";
            this.hasWheelImageDataGridViewCheckBoxColumn.Width = 76;
            // 
            // HasInstructionCard
            // 
            this.HasInstructionCard.DataPropertyName = "HasInstructionCard";
            this.HasInstructionCard.HeaderText = "Instruction Card";
            this.HasInstructionCard.Name = "HasInstructionCard";
            this.HasInstructionCard.Width = 87;
            // 
            // HasFlyer
            // 
            this.HasFlyer.DataPropertyName = "HasFlyer";
            this.HasFlyer.HeaderText = "Flyer";
            this.HasFlyer.Name = "HasFlyer";
            this.HasFlyer.Width = 35;
            // 
            // HasLaunchAudio
            // 
            this.HasLaunchAudio.DataPropertyName = "HasLaunchAudio";
            this.HasLaunchAudio.HeaderText = "Launch Audio";
            this.HasLaunchAudio.Name = "HasLaunchAudio";
            this.HasLaunchAudio.Width = 79;
            // 
            // HasTableAudio
            // 
            this.HasTableAudio.DataPropertyName = "HasTableAudio";
            this.HasTableAudio.HeaderText = "Table Audio Media";
            this.HasTableAudio.Name = "HasTableAudio";
            this.HasTableAudio.Width = 102;
            // 
            // contextMenuStripGridActions
            // 
            this.contextMenuStripGridActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.findMediaToolStripMenuItem,
            this.recordMediaToolStripMenuItem,
            this.previewMediaToolStripMenuItem,
            this.addGameToolStripMenuItem,
            this.deleteGameToolStripMenuItem,
            this.launchGameToolStripMenuItem,
            this.viewIPDBPageToolStripMenuItem});
            this.contextMenuStripGridActions.Name = "contextMenuStripGridActions";
            this.contextMenuStripGridActions.Size = new System.Drawing.Size(157, 180);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // findMediaToolStripMenuItem
            // 
            this.findMediaToolStripMenuItem.Name = "findMediaToolStripMenuItem";
            this.findMediaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.findMediaToolStripMenuItem.Text = "Find Media";
            // 
            // recordMediaToolStripMenuItem
            // 
            this.recordMediaToolStripMenuItem.Name = "recordMediaToolStripMenuItem";
            this.recordMediaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.recordMediaToolStripMenuItem.Text = "Record Media";
            // 
            // previewMediaToolStripMenuItem
            // 
            this.previewMediaToolStripMenuItem.Name = "previewMediaToolStripMenuItem";
            this.previewMediaToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.previewMediaToolStripMenuItem.Text = "Preview Media";
            // 
            // addGameToolStripMenuItem
            // 
            this.addGameToolStripMenuItem.Name = "addGameToolStripMenuItem";
            this.addGameToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addGameToolStripMenuItem.Text = "Add Game";
            // 
            // deleteGameToolStripMenuItem
            // 
            this.deleteGameToolStripMenuItem.Name = "deleteGameToolStripMenuItem";
            this.deleteGameToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.deleteGameToolStripMenuItem.Text = "Delete Game";
            // 
            // launchGameToolStripMenuItem
            // 
            this.launchGameToolStripMenuItem.Name = "launchGameToolStripMenuItem";
            this.launchGameToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.launchGameToolStripMenuItem.Text = "Launch Game";
            // 
            // viewIPDBPageToolStripMenuItem
            // 
            this.viewIPDBPageToolStripMenuItem.Name = "viewIPDBPageToolStripMenuItem";
            this.viewIPDBPageToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.viewIPDBPageToolStripMenuItem.Text = "View IPDB Page";
            this.viewIPDBPageToolStripMenuItem.Click += new System.EventHandler(this.viewIPDBPageToolStripMenuItem_Click);
            // 
            // frontEndGameBindingSource
            // 
            this.frontEndGameBindingSource.DataSource = typeof(PinCab.Utils.ViewModels.FrontEndGameViewModel);
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(955, 96);
            this.txtLog.TabIndex = 4;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 530);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(955, 23);
            this.progressBar.TabIndex = 8;
            // 
            // backgroundWorkerProgressBar
            // 
            this.backgroundWorkerProgressBar.WorkerReportsProgress = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbDatabase);
            this.panel1.Controls.Add(this.lblDatabase);
            this.panel1.Controls.Add(this.cmbFrontEnd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 62);
            this.panel1.TabIndex = 7;
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(236, 4);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(264, 21);
            this.cmbDatabase.TabIndex = 6;
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(176, 6);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(53, 13);
            this.lblDatabase.TabIndex = 5;
            this.lblDatabase.Text = "Database";
            // 
            // cmbFrontEnd
            // 
            this.cmbFrontEnd.DisplayMember = "Name";
            this.cmbFrontEnd.FormattingEnabled = true;
            this.cmbFrontEnd.Location = new System.Drawing.Point(63, 4);
            this.cmbFrontEnd.Name = "cmbFrontEnd";
            this.cmbFrontEnd.Size = new System.Drawing.Size(107, 21);
            this.cmbFrontEnd.TabIndex = 4;
            this.cmbFrontEnd.ValueMember = "System";
            this.cmbFrontEnd.SelectedIndexChanged += new System.EventHandler(this.cmbFrontEnd_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Front End";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(783, 6);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(160, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "Right Click Cell or Row for Menu";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 33);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(63, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(107, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.utilitiesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(955, 24);
            this.menuStrip1.TabIndex = 6;
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
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mediaAuditToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // mediaAuditToolStripMenuItem
            // 
            this.mediaAuditToolStripMenuItem.Name = "mediaAuditToolStripMenuItem";
            this.mediaAuditToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.mediaAuditToolStripMenuItem.Text = "Media Audit";
            this.mediaAuditToolStripMenuItem.Click += new System.EventHandler(this.mediaAuditToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // GameManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 553);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "GameManagerForm";
            this.Text = "Game Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameManagerForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGameList)).EndInit();
            this.contextMenuStripGridActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.frontEndGameBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewGameList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGridActions;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findMediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGameToolStripMenuItem;
        private System.Windows.Forms.BindingSource frontEndGameBindingSource;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProgressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediaAuditToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbFrontEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.ToolStripMenuItem recordMediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewMediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewIPDBPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enabledDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn alternateExeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hideDmdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hideTopperDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hideBackglassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn themeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPDBNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateAddedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateModifiedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasUpdatesAvailableDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn romDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vPinGameDatabaseIdDataGridViewTextBoxColumn;
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
    }
}