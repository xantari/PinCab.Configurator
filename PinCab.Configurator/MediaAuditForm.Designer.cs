
namespace PinCab.Configurator
{
    partial class MediaAuditForm
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
            this.dataGridViewAuditList = new System.Windows.Forms.DataGridView();
            this.contextMenuStripGridActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerProgressBar = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbFrontEnd = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediaIssuesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.frontEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullPathToFileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MediaType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuditList)).BeginInit();
            this.contextMenuStripGridActions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaIssuesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 63);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewAuditList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtLog);
            this.splitContainer1.Size = new System.Drawing.Size(955, 467);
            this.splitContainer1.SplitterDistance = 361;
            this.splitContainer1.TabIndex = 9;
            // 
            // dataGridViewAuditList
            // 
            this.dataGridViewAuditList.AllowUserToAddRows = false;
            this.dataGridViewAuditList.AllowUserToDeleteRows = false;
            this.dataGridViewAuditList.AutoGenerateColumns = false;
            this.dataGridViewAuditList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridViewAuditList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.frontEndDataGridViewTextBoxColumn,
            this.fullPathToFileDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.MediaType});
            this.dataGridViewAuditList.ContextMenuStrip = this.contextMenuStripGridActions;
            this.dataGridViewAuditList.DataSource = this.mediaIssuesBindingSource;
            this.dataGridViewAuditList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAuditList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewAuditList.Name = "dataGridViewAuditList";
            this.dataGridViewAuditList.ReadOnly = true;
            this.dataGridViewAuditList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAuditList.Size = new System.Drawing.Size(955, 361);
            this.dataGridViewAuditList.TabIndex = 2;
            this.dataGridViewAuditList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewAuditList_DataBindingComplete);
            // 
            // contextMenuStripGridActions
            // 
            this.contextMenuStripGridActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.contextMenuStripGridActions.Name = "contextMenuStripGridActions";
            this.contextMenuStripGridActions.Size = new System.Drawing.Size(144, 26);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.editToolStripMenuItem.Text = "Delete Media";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
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
            this.panel1.Controls.Add(this.cmbFrontEnd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 39);
            this.panel1.TabIndex = 7;
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
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
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // mediaIssuesBindingSource
            // 
            this.mediaIssuesBindingSource.DataSource = typeof(PinCab.Utils.Models.MediaAuditResult);
            // 
            // frontEndDataGridViewTextBoxColumn
            // 
            this.frontEndDataGridViewTextBoxColumn.DataPropertyName = "FrontEnd";
            this.frontEndDataGridViewTextBoxColumn.HeaderText = "FrontEnd";
            this.frontEndDataGridViewTextBoxColumn.Name = "frontEndDataGridViewTextBoxColumn";
            this.frontEndDataGridViewTextBoxColumn.ReadOnly = true;
            this.frontEndDataGridViewTextBoxColumn.Visible = false;
            this.frontEndDataGridViewTextBoxColumn.Width = 75;
            // 
            // fullPathToFileDataGridViewTextBoxColumn
            // 
            this.fullPathToFileDataGridViewTextBoxColumn.DataPropertyName = "FullPathToFile";
            this.fullPathToFileDataGridViewTextBoxColumn.HeaderText = "File Path";
            this.fullPathToFileDataGridViewTextBoxColumn.Name = "fullPathToFileDataGridViewTextBoxColumn";
            this.fullPathToFileDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullPathToFileDataGridViewTextBoxColumn.Width = 73;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 62;
            // 
            // MediaType
            // 
            this.MediaType.DataPropertyName = "MediaType";
            this.MediaType.HeaderText = "Media Type";
            this.MediaType.Name = "MediaType";
            this.MediaType.ReadOnly = true;
            // 
            // MediaAuditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 553);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MediaAuditForm";
            this.Text = "Media Audit";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuditList)).EndInit();
            this.contextMenuStripGridActions.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaIssuesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewAuditList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGridActions;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.BindingSource mediaIssuesBindingSource;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProgressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbFrontEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn frontEndDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullPathToFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MediaType;
    }
}