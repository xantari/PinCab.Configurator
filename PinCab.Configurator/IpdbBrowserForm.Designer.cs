
namespace PinCab.Configurator
{
    partial class IpdbBrowserForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ipdbDatabaseSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelFilterCriteria = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.splitContainerTopAndBottomGrids = new System.Windows.Forms.SplitContainer();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseTagsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpdbId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseTypeString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewIpdb = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.chkOverrideDisplayName = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ipdbDatabaseSettingBindingSource)).BeginInit();
            this.panelFilterCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTopAndBottomGrids)).BeginInit();
            this.splitContainerTopAndBottomGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIpdb)).BeginInit();
            this.SuspendLayout();
            // 
            // ipdbDatabaseSettingBindingSource
            // 
            this.ipdbDatabaseSettingBindingSource.DataSource = typeof(Ipdb.Models.IpdbResult);
            // 
            // panelFilterCriteria
            // 
            this.panelFilterCriteria.Controls.Add(this.chkOverrideDisplayName);
            this.panelFilterCriteria.Controls.Add(this.lblSearch);
            this.panelFilterCriteria.Controls.Add(this.txtSearch);
            this.panelFilterCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilterCriteria.Location = new System.Drawing.Point(0, 0);
            this.panelFilterCriteria.Name = "panelFilterCriteria";
            this.panelFilterCriteria.Size = new System.Drawing.Size(610, 32);
            this.panelFilterCriteria.TabIndex = 8;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(4, 6);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(41, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(51, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // splitContainerTopAndBottomGrids
            // 
            this.splitContainerTopAndBottomGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTopAndBottomGrids.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTopAndBottomGrids.Name = "splitContainerTopAndBottomGrids";
            this.splitContainerTopAndBottomGrids.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainerTopAndBottomGrids.Size = new System.Drawing.Size(800, 328);
            this.splitContainerTopAndBottomGrids.SplitterDistance = 183;
            this.splitContainerTopAndBottomGrids.TabIndex = 3;
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
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DatabaseTagsString.DefaultCellStyle = dataGridViewCellStyle3;
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewIpdb);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnSelect);
            this.splitContainer1.Size = new System.Drawing.Size(610, 418);
            this.splitContainer1.SplitterDistance = 373;
            this.splitContainer1.TabIndex = 9;
            // 
            // dataGridViewIpdb
            // 
            this.dataGridViewIpdb.AllowUserToAddRows = false;
            this.dataGridViewIpdb.AllowUserToDeleteRows = false;
            this.dataGridViewIpdb.AutoGenerateColumns = false;
            this.dataGridViewIpdb.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewIpdb.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridViewIpdb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn1});
            this.dataGridViewIpdb.DataSource = this.ipdbDatabaseSettingBindingSource;
            this.dataGridViewIpdb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewIpdb.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewIpdb.Name = "dataGridViewIpdb";
            this.dataGridViewIpdb.ReadOnly = true;
            this.dataGridViewIpdb.Size = new System.Drawing.Size(610, 373);
            this.dataGridViewIpdb.TabIndex = 3;
            this.dataGridViewIpdb.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIpdb_CellDoubleClick);
            this.dataGridViewIpdb.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewIpdb_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "IpdbId";
            this.dataGridViewTextBoxColumn4.HeaderText = "Ipdb";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 53;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Title";
            this.dataGridViewTextBoxColumn1.HeaderText = "Title";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.Width = 52;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(138, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSelect.Location = new System.Drawing.Point(13, 6);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // chkOverrideDisplayName
            // 
            this.chkOverrideDisplayName.AutoSize = true;
            this.chkOverrideDisplayName.Location = new System.Drawing.Point(262, 5);
            this.chkOverrideDisplayName.Name = "chkOverrideDisplayName";
            this.chkOverrideDisplayName.Size = new System.Drawing.Size(134, 17);
            this.chkOverrideDisplayName.TabIndex = 2;
            this.chkOverrideDisplayName.Text = "Override Display Name";
            this.chkOverrideDisplayName.UseVisualStyleBackColor = true;
            // 
            // IpdbBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelFilterCriteria);
            this.Name = "IpdbBrowserForm";
            this.Text = "Ipdb Browser";
            ((System.ComponentModel.ISupportInitialize)(this.ipdbDatabaseSettingBindingSource)).EndInit();
            this.panelFilterCriteria.ResumeLayout(false);
            this.panelFilterCriteria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTopAndBottomGrids)).EndInit();
            this.splitContainerTopAndBottomGrids.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIpdb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource ipdbDatabaseSettingBindingSource;
        private System.Windows.Forms.Panel panelFilterCriteria;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.SplitContainer splitContainerTopAndBottomGrids;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseTagsString;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpdbId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeString;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseTypeString;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewIpdb;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSelect;
        public System.Windows.Forms.CheckBox chkOverrideDisplayName;
    }
}