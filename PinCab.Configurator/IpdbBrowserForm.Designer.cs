
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.vpinDatabaseSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelFilterCriteria = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.splitContainerGridAndLog = new System.Windows.Forms.SplitContainer();
            this.splitContainerTopAndBottomGrids = new System.Windows.Forms.SplitContainer();
            this.DatabaseTypeString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastUpdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpdbId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatabaseTagsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewEntryList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.vpinDatabaseSettingBindingSource)).BeginInit();
            this.panelFilterCriteria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGridAndLog)).BeginInit();
            this.splitContainerGridAndLog.Panel1.SuspendLayout();
            this.splitContainerGridAndLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTopAndBottomGrids)).BeginInit();
            this.splitContainerTopAndBottomGrids.Panel1.SuspendLayout();
            this.splitContainerTopAndBottomGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntryList)).BeginInit();
            this.SuspendLayout();
            // 
            // vpinDatabaseSettingBindingSource
            // 
            this.vpinDatabaseSettingBindingSource.DataSource = typeof(PinCab.Utils.Models.DatabaseBrowserEntry);
            // 
            // panelFilterCriteria
            // 
            this.panelFilterCriteria.Controls.Add(this.lblSearch);
            this.panelFilterCriteria.Controls.Add(this.txtSearch);
            this.panelFilterCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilterCriteria.Location = new System.Drawing.Point(0, 0);
            this.panelFilterCriteria.Name = "panelFilterCriteria";
            this.panelFilterCriteria.Size = new System.Drawing.Size(800, 32);
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
            // 
            // splitContainerGridAndLog
            // 
            this.splitContainerGridAndLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerGridAndLog.Location = new System.Drawing.Point(0, 32);
            this.splitContainerGridAndLog.Name = "splitContainerGridAndLog";
            this.splitContainerGridAndLog.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerGridAndLog.Panel1
            // 
            this.splitContainerGridAndLog.Panel1.Controls.Add(this.splitContainerTopAndBottomGrids);
            this.splitContainerGridAndLog.Size = new System.Drawing.Size(800, 418);
            this.splitContainerGridAndLog.SplitterDistance = 328;
            this.splitContainerGridAndLog.TabIndex = 9;
            // 
            // splitContainerTopAndBottomGrids
            // 
            this.splitContainerTopAndBottomGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTopAndBottomGrids.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTopAndBottomGrids.Name = "splitContainerTopAndBottomGrids";
            this.splitContainerTopAndBottomGrids.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTopAndBottomGrids.Panel1
            // 
            this.splitContainerTopAndBottomGrids.Panel1.Controls.Add(this.dataGridViewEntryList);
            this.splitContainerTopAndBottomGrids.Size = new System.Drawing.Size(800, 328);
            this.splitContainerTopAndBottomGrids.SplitterDistance = 183;
            this.splitContainerTopAndBottomGrids.TabIndex = 3;
            // 
            // DatabaseTypeString
            // 
            this.DatabaseTypeString.DataPropertyName = "DatabaseTypeString";
            this.DatabaseTypeString.HeaderText = "DB";
            this.DatabaseTypeString.Name = "DatabaseTypeString";
            this.DatabaseTypeString.ReadOnly = true;
            this.DatabaseTypeString.Width = 47;
            // 
            // TypeString
            // 
            this.TypeString.DataPropertyName = "TypeString";
            this.TypeString.HeaderText = "Type";
            this.TypeString.Name = "TypeString";
            this.TypeString.ReadOnly = true;
            this.TypeString.Width = 56;
            // 
            // LastUpdated
            // 
            this.LastUpdated.DataPropertyName = "LastUpdated";
            this.LastUpdated.HeaderText = "Updated";
            this.LastUpdated.Name = "LastUpdated";
            this.LastUpdated.ReadOnly = true;
            this.LastUpdated.Width = 73;
            // 
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            this.Version.Width = 67;
            // 
            // IpdbId
            // 
            this.IpdbId.DataPropertyName = "IpdbId";
            this.IpdbId.HeaderText = "Ipdb";
            this.IpdbId.Name = "IpdbId";
            this.IpdbId.ReadOnly = true;
            this.IpdbId.Width = 53;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.HeaderText = "Url";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Width = 45;
            // 
            // DatabaseTagsString
            // 
            this.DatabaseTagsString.DataPropertyName = "DatabaseTagsString";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DatabaseTagsString.DefaultCellStyle = dataGridViewCellStyle1;
            this.DatabaseTagsString.HeaderText = "Tags";
            this.DatabaseTagsString.Name = "DatabaseTagsString";
            this.DatabaseTagsString.ReadOnly = true;
            this.DatabaseTagsString.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DatabaseTagsString.Width = 37;
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
            this.dataGridViewEntryList.DataSource = this.vpinDatabaseSettingBindingSource;
            this.dataGridViewEntryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEntryList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewEntryList.Name = "dataGridViewEntryList";
            this.dataGridViewEntryList.ReadOnly = true;
            this.dataGridViewEntryList.Size = new System.Drawing.Size(800, 183);
            this.dataGridViewEntryList.TabIndex = 2;
            // 
            // IpdbBrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainerGridAndLog);
            this.Controls.Add(this.panelFilterCriteria);
            this.Name = "IpdbBrowserForm";
            this.Text = "Ipdb Browser";
            ((System.ComponentModel.ISupportInitialize)(this.vpinDatabaseSettingBindingSource)).EndInit();
            this.panelFilterCriteria.ResumeLayout(false);
            this.panelFilterCriteria.PerformLayout();
            this.splitContainerGridAndLog.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerGridAndLog)).EndInit();
            this.splitContainerGridAndLog.ResumeLayout(false);
            this.splitContainerTopAndBottomGrids.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTopAndBottomGrids)).EndInit();
            this.splitContainerTopAndBottomGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntryList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource vpinDatabaseSettingBindingSource;
        private System.Windows.Forms.Panel panelFilterCriteria;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.SplitContainer splitContainerGridAndLog;
        private System.Windows.Forms.SplitContainer splitContainerTopAndBottomGrids;
        private System.Windows.Forms.DataGridView dataGridViewEntryList;
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