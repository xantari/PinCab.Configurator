
namespace PinCab.Configurator
{
    partial class AddDatabaseForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbContentDatabaseType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtContentDatabaseName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtContentDatabaseAccessToken = new System.Windows.Forms.TextBox();
            this.txtContentDatabaseUrl = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnFilePathDatabaseBrowser = new System.Windows.Forms.Button();
            this.btnContentDatabaseUrl = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(203, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(97, 121);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbContentDatabaseType
            // 
            this.cmbContentDatabaseType.FormattingEnabled = true;
            this.cmbContentDatabaseType.Location = new System.Drawing.Point(97, 6);
            this.cmbContentDatabaseType.Name = "cmbContentDatabaseType";
            this.cmbContentDatabaseType.Size = new System.Drawing.Size(181, 21);
            this.cmbContentDatabaseType.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(53, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(34, 13);
            this.label18.TabIndex = 74;
            this.label18.Text = "Type:";
            // 
            // txtContentDatabaseName
            // 
            this.txtContentDatabaseName.Location = new System.Drawing.Point(97, 32);
            this.txtContentDatabaseName.Name = "txtContentDatabaseName";
            this.txtContentDatabaseName.Size = new System.Drawing.Size(401, 20);
            this.txtContentDatabaseName.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(53, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 72;
            this.label17.Text = "Name:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 13);
            this.label15.TabIndex = 71;
            this.label15.Text = "Access Token:";
            // 
            // txtContentDatabaseAccessToken
            // 
            this.txtContentDatabaseAccessToken.Location = new System.Drawing.Point(97, 85);
            this.txtContentDatabaseAccessToken.Name = "txtContentDatabaseAccessToken";
            this.txtContentDatabaseAccessToken.Size = new System.Drawing.Size(401, 20);
            this.txtContentDatabaseAccessToken.TabIndex = 5;
            // 
            // txtContentDatabaseUrl
            // 
            this.txtContentDatabaseUrl.Location = new System.Drawing.Point(97, 58);
            this.txtContentDatabaseUrl.Name = "txtContentDatabaseUrl";
            this.txtContentDatabaseUrl.Size = new System.Drawing.Size(401, 20);
            this.txtContentDatabaseUrl.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 61);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 67;
            this.label14.Text = "Url / Path:";
            // 
            // btnFilePathDatabaseBrowser
            // 
            this.btnFilePathDatabaseBrowser.BackgroundImage = global::PinCab.Configurator.Properties.Resources.FolderOpened_75x;
            this.btnFilePathDatabaseBrowser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFilePathDatabaseBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilePathDatabaseBrowser.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFilePathDatabaseBrowser.Location = new System.Drawing.Point(536, 55);
            this.btnFilePathDatabaseBrowser.Name = "btnFilePathDatabaseBrowser";
            this.btnFilePathDatabaseBrowser.Size = new System.Drawing.Size(38, 23);
            this.btnFilePathDatabaseBrowser.TabIndex = 7;
            this.btnFilePathDatabaseBrowser.UseVisualStyleBackColor = true;
            this.btnFilePathDatabaseBrowser.Click += new System.EventHandler(this.btnFilePathDatabaseBrowser_Click);
            // 
            // btnContentDatabaseUrl
            // 
            this.btnContentDatabaseUrl.BackgroundImage = global::PinCab.Configurator.Properties.Resources.BrowserLink_75x;
            this.btnContentDatabaseUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnContentDatabaseUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContentDatabaseUrl.ForeColor = System.Drawing.SystemColors.Control;
            this.btnContentDatabaseUrl.Location = new System.Drawing.Point(504, 55);
            this.btnContentDatabaseUrl.Name = "btnContentDatabaseUrl";
            this.btnContentDatabaseUrl.Size = new System.Drawing.Size(38, 23);
            this.btnContentDatabaseUrl.TabIndex = 6;
            this.btnContentDatabaseUrl.UseVisualStyleBackColor = true;
            this.btnContentDatabaseUrl.Click += new System.EventHandler(this.btnContentDatabaseUrl_Click);
            // 
            // AddDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 152);
            this.Controls.Add(this.btnFilePathDatabaseBrowser);
            this.Controls.Add(this.cmbContentDatabaseType);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtContentDatabaseName);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtContentDatabaseAccessToken);
            this.Controls.Add(this.btnContentDatabaseUrl);
            this.Controls.Add(this.txtContentDatabaseUrl);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MinimumSize = new System.Drawing.Size(604, 191);
            this.Name = "AddDatabaseForm";
            this.Text = "Add Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFilePathDatabaseBrowser;
        private System.Windows.Forms.ComboBox cmbContentDatabaseType;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtContentDatabaseName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtContentDatabaseAccessToken;
        private System.Windows.Forms.Button btnContentDatabaseUrl;
        private System.Windows.Forms.TextBox txtContentDatabaseUrl;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}