
namespace PinCab.Configurator
{
    partial class AddRelatedDatabaseEntryForm
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewRelated = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagsString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.majorCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeLogDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featuresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.themeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipdbNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSizeBytesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloadCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedDateUtcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseEntryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(60, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(230, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dataGridViewRelated
            // 
            this.dataGridViewRelated.AllowUserToAddRows = false;
            this.dataGridViewRelated.AllowUserToDeleteRows = false;
            this.dataGridViewRelated.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRelated.AutoGenerateColumns = false;
            this.dataGridViewRelated.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridViewRelated.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridViewRelated.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.TagsString,
            this.majorCategoryDataGridViewTextBoxColumn,
            this.urlDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.fileNameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.changeLogDataGridViewTextBoxColumn,
            this.authorsDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.featuresDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn,
            this.playersDataGridViewTextBoxColumn,
            this.themeDataGridViewTextBoxColumn,
            this.ipdbNumberDataGridViewTextBoxColumn,
            this.fileSizeBytesDataGridViewTextBoxColumn,
            this.downloadCountDataGridViewTextBoxColumn,
            this.ratingDataGridViewTextBoxColumn,
            this.lastModifiedDateUtcDataGridViewTextBoxColumn});
            this.dataGridViewRelated.DataSource = this.databaseEntryBindingSource;
            this.dataGridViewRelated.Location = new System.Drawing.Point(16, 40);
            this.dataGridViewRelated.Name = "dataGridViewRelated";
            this.dataGridViewRelated.ReadOnly = true;
            this.dataGridViewRelated.Size = new System.Drawing.Size(772, 145);
            this.dataGridViewRelated.TabIndex = 2;
            this.dataGridViewRelated.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewRelated_DataBindingComplete);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 41;
            // 
            // TagsString
            // 
            this.TagsString.DataPropertyName = "TagsString";
            this.TagsString.HeaderText = "TagsString";
            this.TagsString.Name = "TagsString";
            this.TagsString.ReadOnly = true;
            this.TagsString.Visible = false;
            // 
            // majorCategoryDataGridViewTextBoxColumn
            // 
            this.majorCategoryDataGridViewTextBoxColumn.DataPropertyName = "MajorCategory";
            this.majorCategoryDataGridViewTextBoxColumn.HeaderText = "MajorCategory";
            this.majorCategoryDataGridViewTextBoxColumn.Name = "majorCategoryDataGridViewTextBoxColumn";
            this.majorCategoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.majorCategoryDataGridViewTextBoxColumn.Visible = false;
            // 
            // urlDataGridViewTextBoxColumn
            // 
            this.urlDataGridViewTextBoxColumn.DataPropertyName = "Url";
            this.urlDataGridViewTextBoxColumn.HeaderText = "Url";
            this.urlDataGridViewTextBoxColumn.Name = "urlDataGridViewTextBoxColumn";
            this.urlDataGridViewTextBoxColumn.ReadOnly = true;
            this.urlDataGridViewTextBoxColumn.Width = 45;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 52;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "FileName";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Visible = false;
            // 
            // changeLogDataGridViewTextBoxColumn
            // 
            this.changeLogDataGridViewTextBoxColumn.DataPropertyName = "ChangeLog";
            this.changeLogDataGridViewTextBoxColumn.HeaderText = "ChangeLog";
            this.changeLogDataGridViewTextBoxColumn.Name = "changeLogDataGridViewTextBoxColumn";
            this.changeLogDataGridViewTextBoxColumn.ReadOnly = true;
            this.changeLogDataGridViewTextBoxColumn.Visible = false;
            // 
            // authorsDataGridViewTextBoxColumn
            // 
            this.authorsDataGridViewTextBoxColumn.DataPropertyName = "Authors";
            this.authorsDataGridViewTextBoxColumn.HeaderText = "Authors";
            this.authorsDataGridViewTextBoxColumn.Name = "authorsDataGridViewTextBoxColumn";
            this.authorsDataGridViewTextBoxColumn.ReadOnly = true;
            this.authorsDataGridViewTextBoxColumn.Visible = false;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            this.versionDataGridViewTextBoxColumn.Visible = false;
            // 
            // featuresDataGridViewTextBoxColumn
            // 
            this.featuresDataGridViewTextBoxColumn.DataPropertyName = "Features";
            this.featuresDataGridViewTextBoxColumn.HeaderText = "Features";
            this.featuresDataGridViewTextBoxColumn.Name = "featuresDataGridViewTextBoxColumn";
            this.featuresDataGridViewTextBoxColumn.ReadOnly = true;
            this.featuresDataGridViewTextBoxColumn.Visible = false;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Visible = false;
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            this.yearDataGridViewTextBoxColumn.ReadOnly = true;
            this.yearDataGridViewTextBoxColumn.Visible = false;
            // 
            // playersDataGridViewTextBoxColumn
            // 
            this.playersDataGridViewTextBoxColumn.DataPropertyName = "Players";
            this.playersDataGridViewTextBoxColumn.HeaderText = "Players";
            this.playersDataGridViewTextBoxColumn.Name = "playersDataGridViewTextBoxColumn";
            this.playersDataGridViewTextBoxColumn.ReadOnly = true;
            this.playersDataGridViewTextBoxColumn.Visible = false;
            // 
            // themeDataGridViewTextBoxColumn
            // 
            this.themeDataGridViewTextBoxColumn.DataPropertyName = "Theme";
            this.themeDataGridViewTextBoxColumn.HeaderText = "Theme";
            this.themeDataGridViewTextBoxColumn.Name = "themeDataGridViewTextBoxColumn";
            this.themeDataGridViewTextBoxColumn.ReadOnly = true;
            this.themeDataGridViewTextBoxColumn.Visible = false;
            // 
            // ipdbNumberDataGridViewTextBoxColumn
            // 
            this.ipdbNumberDataGridViewTextBoxColumn.DataPropertyName = "IpdbNumber";
            this.ipdbNumberDataGridViewTextBoxColumn.HeaderText = "Ipdb #";
            this.ipdbNumberDataGridViewTextBoxColumn.Name = "ipdbNumberDataGridViewTextBoxColumn";
            this.ipdbNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.ipdbNumberDataGridViewTextBoxColumn.Width = 63;
            // 
            // fileSizeBytesDataGridViewTextBoxColumn
            // 
            this.fileSizeBytesDataGridViewTextBoxColumn.DataPropertyName = "FileSizeBytes";
            this.fileSizeBytesDataGridViewTextBoxColumn.HeaderText = "FileSizeBytes";
            this.fileSizeBytesDataGridViewTextBoxColumn.Name = "fileSizeBytesDataGridViewTextBoxColumn";
            this.fileSizeBytesDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileSizeBytesDataGridViewTextBoxColumn.Visible = false;
            // 
            // downloadCountDataGridViewTextBoxColumn
            // 
            this.downloadCountDataGridViewTextBoxColumn.DataPropertyName = "DownloadCount";
            this.downloadCountDataGridViewTextBoxColumn.HeaderText = "DownloadCount";
            this.downloadCountDataGridViewTextBoxColumn.Name = "downloadCountDataGridViewTextBoxColumn";
            this.downloadCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.downloadCountDataGridViewTextBoxColumn.Visible = false;
            // 
            // ratingDataGridViewTextBoxColumn
            // 
            this.ratingDataGridViewTextBoxColumn.DataPropertyName = "Rating";
            this.ratingDataGridViewTextBoxColumn.HeaderText = "Rating";
            this.ratingDataGridViewTextBoxColumn.Name = "ratingDataGridViewTextBoxColumn";
            this.ratingDataGridViewTextBoxColumn.ReadOnly = true;
            this.ratingDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastModifiedDateUtcDataGridViewTextBoxColumn
            // 
            this.lastModifiedDateUtcDataGridViewTextBoxColumn.DataPropertyName = "LastModifiedDateUtc";
            this.lastModifiedDateUtcDataGridViewTextBoxColumn.HeaderText = "LastModifiedDateUtc";
            this.lastModifiedDateUtcDataGridViewTextBoxColumn.Name = "lastModifiedDateUtcDataGridViewTextBoxColumn";
            this.lastModifiedDateUtcDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastModifiedDateUtcDataGridViewTextBoxColumn.Visible = false;
            // 
            // databaseEntryBindingSource
            // 
            this.databaseEntryBindingSource.DataSource = typeof(VirtualPinball.Database.Models.DatabaseEntry);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(122, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(16, 191);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddRelatedDatabaseEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 226);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridViewRelated);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(809, 265);
            this.Name = "AddRelatedDatabaseEntryForm";
            this.Text = "Add Related Database Entry";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddRelatedDatabaseEntryForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseEntryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridViewRelated;
        private System.Windows.Forms.BindingSource databaseEntryBindingSource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagsString;
        private System.Windows.Forms.DataGridViewTextBoxColumn majorCategoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn changeLogDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn featuresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn themeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipdbNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSizeBytesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn downloadCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedDateUtcDataGridViewTextBoxColumn;
    }
}