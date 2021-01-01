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
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblRomSearch = new System.Windows.Forms.Label();
            this.txtRomSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewRomList = new System.Windows.Forms.DataGridView();
            this.RomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStripGridActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedCellValueToAllROMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedRowDataToAllROMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runROMUsingNativeVPinMameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopRunningROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vpinDatabaseSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.backgroundWorkerProgressBar = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRomList)).BeginInit();
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
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.lblRomSearch);
            this.panel1.Controls.Add(this.txtRomSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 90);
            this.panel1.TabIndex = 1;
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
            // dataGridViewRomList
            // 
            this.dataGridViewRomList.AllowUserToAddRows = false;
            this.dataGridViewRomList.AllowUserToDeleteRows = false;
            this.dataGridViewRomList.AutoGenerateColumns = false;
            this.dataGridViewRomList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewRomList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridViewRomList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RomName,
            this.titleDataGridViewTextBoxColumn});
            this.dataGridViewRomList.ContextMenuStrip = this.contextMenuStripGridActions;
            this.dataGridViewRomList.DataSource = this.vpinDatabaseSettingBindingSource;
            this.dataGridViewRomList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRomList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRomList.Name = "dataGridViewRomList";
            this.dataGridViewRomList.ReadOnly = true;
            this.dataGridViewRomList.Size = new System.Drawing.Size(1049, 324);
            this.dataGridViewRomList.TabIndex = 2;
            // 
            // RomName
            // 
            this.RomName.DataPropertyName = "RomName";
            this.RomName.HeaderText = "RomName";
            this.RomName.Name = "RomName";
            this.RomName.ReadOnly = true;
            this.RomName.Width = 82;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.titleDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.titleDataGridViewTextBoxColumn.ThreeState = true;
            this.titleDataGridViewTextBoxColumn.Width = 52;
            // 
            // contextMenuStripGridActions
            // 
            this.contextMenuStripGridActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.copySelectedCellValueToAllROMSToolStripMenuItem,
            this.copySelectedRowDataToAllROMSToolStripMenuItem,
            this.runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem,
            this.runROMUsingNativeVPinMameToolStripMenuItem,
            this.stopRunningROMToolStripMenuItem});
            this.contextMenuStripGridActions.Name = "contextMenuStripGridActions";
            this.contextMenuStripGridActions.Size = new System.Drawing.Size(325, 136);
            this.contextMenuStripGridActions.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripGridActions_ItemClicked);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copySelectedCellValueToAllROMSToolStripMenuItem
            // 
            this.copySelectedCellValueToAllROMSToolStripMenuItem.Name = "copySelectedCellValueToAllROMSToolStripMenuItem";
            this.copySelectedCellValueToAllROMSToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.copySelectedCellValueToAllROMSToolStripMenuItem.Text = "Copy Selected Cell Value to All ROMS";
            // 
            // copySelectedRowDataToAllROMSToolStripMenuItem
            // 
            this.copySelectedRowDataToAllROMSToolStripMenuItem.Name = "copySelectedRowDataToAllROMSToolStripMenuItem";
            this.copySelectedRowDataToAllROMSToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.copySelectedRowDataToAllROMSToolStripMenuItem.Text = "Copy Selected Row Data to All ROMS";
            // 
            // runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem
            // 
            this.runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem.Name = "runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem";
            this.runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem.Text = "Run ROM using External DMD Device / DMDExt";
            // 
            // runROMUsingNativeVPinMameToolStripMenuItem
            // 
            this.runROMUsingNativeVPinMameToolStripMenuItem.Name = "runROMUsingNativeVPinMameToolStripMenuItem";
            this.runROMUsingNativeVPinMameToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.runROMUsingNativeVPinMameToolStripMenuItem.Text = "Run ROM using Native VPinMame";
            // 
            // stopRunningROMToolStripMenuItem
            // 
            this.stopRunningROMToolStripMenuItem.Name = "stopRunningROMToolStripMenuItem";
            this.stopRunningROMToolStripMenuItem.Size = new System.Drawing.Size(324, 22);
            this.stopRunningROMToolStripMenuItem.Text = "Stop Running ROM";
            this.stopRunningROMToolStripMenuItem.Visible = false;
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewRomList);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRomList)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridViewRomList;
        private System.Windows.Forms.BindingSource vpinDatabaseSettingBindingSource;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblRomSearch;
        private System.Windows.Forms.TextBox txtRomSearch;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGridActions;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedCellValueToAllROMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedRowDataToAllROMSToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn RomName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runROMUsingNativeVPinMameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopRunningROMToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProgressBar;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}