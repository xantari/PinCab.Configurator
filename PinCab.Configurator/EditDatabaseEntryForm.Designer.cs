namespace PinCab.Configurator
{
    partial class EditDatabaseEntryForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialogDmdColor = new System.Windows.Forms.ColorDialog();
            this.txtIpdbNumber = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTheme = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericYear = new System.Windows.Forms.NumericUpDown();
            this.numericPlayers = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblId = new System.Windows.Forms.Label();
            this.btnGameUrl = new System.Windows.Forms.Button();
            this.txtGameUrl = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAdded = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtAuthors = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtIpdb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 550);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(118, 550);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtIpdbNumber
            // 
            this.txtIpdbNumber.Enabled = false;
            this.txtIpdbNumber.Location = new System.Drawing.Point(72, 439);
            this.txtIpdbNumber.Name = "txtIpdbNumber";
            this.txtIpdbNumber.Size = new System.Drawing.Size(80, 20);
            this.txtIpdbNumber.TabIndex = 116;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(21, 442);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 115;
            this.label14.Text = "IPDB #";
            // 
            // txtTheme
            // 
            this.txtTheme.Location = new System.Drawing.Point(72, 415);
            this.txtTheme.Name = "txtTheme";
            this.txtTheme.Size = new System.Drawing.Size(366, 20);
            this.txtTheme.TabIndex = 114;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 418);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 113;
            this.label11.Text = "Theme";
            // 
            // numericYear
            // 
            this.numericYear.Location = new System.Drawing.Point(214, 389);
            this.numericYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericYear.Name = "numericYear";
            this.numericYear.Size = new System.Drawing.Size(90, 20);
            this.numericYear.TabIndex = 112;
            // 
            // numericPlayers
            // 
            this.numericPlayers.Location = new System.Drawing.Point(71, 389);
            this.numericPlayers.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericPlayers.Name = "numericPlayers";
            this.numericPlayers.Size = new System.Drawing.Size(90, 20);
            this.numericPlayers.TabIndex = 111;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(167, 391);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 110;
            this.label9.Text = "Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 109;
            this.label2.Text = "Players";
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(72, 364);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(366, 20);
            this.txtManufacturer.TabIndex = 108;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::PinCab.Configurator.Properties.Resources.BrowserLink_75x;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(497, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 107;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(71, 40);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(230, 21);
            this.cmbCategory.TabIndex = 106;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(68, 9);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(88, 13);
            this.lblId.TabIndex = 105;
            this.lblId.Text = "(Auto Generated)";
            // 
            // btnGameUrl
            // 
            this.btnGameUrl.BackgroundImage = global::PinCab.Configurator.Properties.Resources.BrowserLink_75x;
            this.btnGameUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGameUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGameUrl.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGameUrl.Location = new System.Drawing.Point(440, 507);
            this.btnGameUrl.Name = "btnGameUrl";
            this.btnGameUrl.Size = new System.Drawing.Size(27, 23);
            this.btnGameUrl.TabIndex = 104;
            this.btnGameUrl.UseVisualStyleBackColor = true;
            // 
            // txtGameUrl
            // 
            this.txtGameUrl.Location = new System.Drawing.Point(68, 507);
            this.txtGameUrl.Name = "txtGameUrl";
            this.txtGameUrl.Size = new System.Drawing.Size(366, 20);
            this.txtGameUrl.TabIndex = 103;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(-1, 510);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 102;
            this.label17.Text = "Game Url:";
            // 
            // txtAdded
            // 
            this.txtAdded.Enabled = false;
            this.txtAdded.Location = new System.Drawing.Point(71, 260);
            this.txtAdded.Multiline = true;
            this.txtAdded.Name = "txtAdded";
            this.txtAdded.Size = new System.Drawing.Size(421, 49);
            this.txtAdded.TabIndex = 101;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 263);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 100;
            this.label15.Text = "Features";
            // 
            // txtVersion
            // 
            this.txtVersion.Enabled = false;
            this.txtVersion.Location = new System.Drawing.Point(71, 341);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(80, 20);
            this.txtVersion.TabIndex = 99;
            // 
            // txtAuthors
            // 
            this.txtAuthors.Location = new System.Drawing.Point(71, 315);
            this.txtAuthors.Name = "txtAuthors";
            this.txtAuthors.Size = new System.Drawing.Size(420, 20);
            this.txtAuthors.TabIndex = 98;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 344);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 97;
            this.label13.Text = "Version";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 318);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 96;
            this.label12.Text = "Authors";
            // 
            // txtIpdb
            // 
            this.txtIpdb.Location = new System.Drawing.Point(71, 203);
            this.txtIpdb.Multiline = true;
            this.txtIpdb.Name = "txtIpdb";
            this.txtIpdb.Size = new System.Drawing.Size(420, 51);
            this.txtIpdb.TabIndex = 95;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 206);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 94;
            this.label10.Text = "Change Log";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(70, 151);
            this.txtAuthor.Multiline = true;
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(421, 46);
            this.txtAuthor.TabIndex = 93;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 92;
            this.label8.Text = "Description";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(71, 123);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(420, 20);
            this.txtFileName.TabIndex = 91;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 90;
            this.label7.Text = "File Name";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(71, 97);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(420, 20);
            this.txtTitle.TabIndex = 89;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 88;
            this.label6.Text = "Title";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(70, 71);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(421, 20);
            this.txtUrl.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 86;
            this.label5.Text = "Url";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(-3, 367);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(70, 13);
            this.lblManufacturer.TabIndex = 85;
            this.lblManufacturer.Text = "Manufacturer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 84;
            this.label4.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 83;
            this.label3.Text = "Id:";
            // 
            // EditDatabaseEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 583);
            this.Controls.Add(this.txtIpdbNumber);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTheme);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericYear);
            this.Controls.Add(this.numericPlayers);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnGameUrl);
            this.Controls.Add(this.txtGameUrl);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtAdded);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.txtAuthors);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtIpdb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblManufacturer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.MinimumSize = new System.Drawing.Size(550, 622);
            this.Name = "EditDatabaseEntryForm";
            this.Text = "Edit Game";
            ((System.ComponentModel.ISupportInitialize)(this.numericYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColorDialog colorDialogDmdColor;
        private System.Windows.Forms.TextBox txtIpdbNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTheme;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericYear;
        private System.Windows.Forms.NumericUpDown numericPlayers;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnGameUrl;
        private System.Windows.Forms.TextBox txtGameUrl;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtAdded;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.TextBox txtAuthors;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtIpdb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}