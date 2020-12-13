
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
            this.dataGridViewRomList = new System.Windows.Forms.DataGridView();
            this.contextMenuStripGridActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedCellValueToAllROMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySelectedRowDataToAllROMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runROMUsingNativeVPinMameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopRunningROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vpinMameRomSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtLog = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerProgressBar = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtRomSearch = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findStrandedMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.RomName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRomList)).BeginInit();
            this.contextMenuStripGridActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vpinMameRomSettingBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 56);
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
            this.splitContainer1.Size = new System.Drawing.Size(955, 474);
            this.splitContainer1.SplitterDistance = 368;
            this.splitContainer1.TabIndex = 9;
            // 
            // dataGridViewRomList
            // 
            this.dataGridViewRomList.AllowUserToAddRows = false;
            this.dataGridViewRomList.AllowUserToDeleteRows = false;
            this.dataGridViewRomList.AutoGenerateColumns = false;
            this.dataGridViewRomList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewRomList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridViewRomList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RomName});
            this.dataGridViewRomList.ContextMenuStrip = this.contextMenuStripGridActions;
            this.dataGridViewRomList.DataSource = this.vpinMameRomSettingBindingSource;
            this.dataGridViewRomList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRomList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRomList.Name = "dataGridViewRomList";
            this.dataGridViewRomList.ReadOnly = true;
            this.dataGridViewRomList.Size = new System.Drawing.Size(955, 368);
            this.dataGridViewRomList.TabIndex = 2;
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
            // vpinMameRomSettingBindingSource
            // 
            this.vpinMameRomSettingBindingSource.DataSource = typeof(PinCab.ScreenUtil.Models.VpinMameRomSetting);
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(955, 102);
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
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.txtRomSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 32);
            this.panel1.TabIndex = 7;
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
            this.lblSearch.Location = new System.Drawing.Point(188, 7);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search";
            // 
            // txtRomSearch
            // 
            this.txtRomSearch.Location = new System.Drawing.Point(235, 4);
            this.txtRomSearch.Name = "txtRomSearch";
            this.txtRomSearch.Size = new System.Drawing.Size(100, 20);
            this.txtRomSearch.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.utilitiesToolStripMenuItem});
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
            this.findStrandedMediaToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // findStrandedMediaToolStripMenuItem
            // 
            this.findStrandedMediaToolStripMenuItem.Name = "findStrandedMediaToolStripMenuItem";
            this.findStrandedMediaToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.findStrandedMediaToolStripMenuItem.Text = "Find Stranded Media";
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Pinball X",
            "Pinball Y",
            "Pinup Popper"});
            this.comboBox1.Location = new System.Drawing.Point(63, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // RomName
            // 
            this.RomName.DataPropertyName = "GameName";
            this.RomName.HeaderText = "GameName";
            this.RomName.Name = "RomName";
            this.RomName.ReadOnly = true;
            this.RomName.Width = 88;
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRomList)).EndInit();
            this.contextMenuStripGridActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.vpinMameRomSettingBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewRomList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGridActions;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedCellValueToAllROMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedRowDataToAllROMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runROMUsingNativeVPinMameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopRunningROMToolStripMenuItem;
        private System.Windows.Forms.BindingSource vpinMameRomSettingBindingSource;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProgressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtRomSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findStrandedMediaToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RomName;
    }
}