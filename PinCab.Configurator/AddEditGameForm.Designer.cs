namespace PinCab.Configurator
{
    partial class AddEditGameForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.colorDialogDmdColor = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.chkFavorite = new System.Windows.Forms.CheckBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtManufacturer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTheme = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIpdb = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRom = new System.Windows.Forms.TextBox();
            this.txtPlayCount = new System.Windows.Forms.TextBox();
            this.txtSeconds = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtAdded = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkHideDmd = new System.Windows.Forms.CheckBox();
            this.chkHideBackglass = new System.Windows.Forms.CheckBox();
            this.chkHideTopper = new System.Windows.Forms.CheckBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnFillFromIpdb = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtModified = new System.Windows.Forms.TextBox();
            this.txtGameUrl = new System.Windows.Forms.TextBox();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPlayers = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbAlternateExe = new System.Windows.Forms.ComboBox();
            this.btnDatabaseBrowser = new System.Windows.Forms.Button();
            this.btnShowNew = new System.Windows.Forms.Button();
            this.btnIpdbUrl = new System.Windows.Forms.Button();
            this.btnGameUrl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Alternate Exe";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(308, 52);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(95, 17);
            this.chkEnabled.TabIndex = 11;
            this.chkEnabled.Text = "Table Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // chkFavorite
            // 
            this.chkFavorite.AutoSize = true;
            this.chkFavorite.Enabled = false;
            this.chkFavorite.Location = new System.Drawing.Point(400, 52);
            this.chkFavorite.Name = "chkFavorite";
            this.chkFavorite.Size = new System.Drawing.Size(64, 17);
            this.chkFavorite.TabIndex = 13;
            this.chkFavorite.Text = "Favorite";
            this.chkFavorite.UseVisualStyleBackColor = true;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(80, 17);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(215, 20);
            this.txtTableName.TabIndex = 15;
            this.txtTableName.Leave += new System.EventHandler(this.txtTableName_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Table Name";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(80, 49);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(215, 20);
            this.txtDisplayName.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Display Name";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(25, 376);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(51, 13);
            this.lblComment.TabIndex = 18;
            this.lblComment.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(80, 376);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(367, 40);
            this.txtComment.TabIndex = 19;
            // 
            // txtManufacturer
            // 
            this.txtManufacturer.Location = new System.Drawing.Point(80, 80);
            this.txtManufacturer.Name = "txtManufacturer";
            this.txtManufacturer.Size = new System.Drawing.Size(215, 20);
            this.txtManufacturer.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Manufacturer";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(81, 106);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(80, 20);
            this.txtYear.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Year";
            // 
            // txtTheme
            // 
            this.txtTheme.Location = new System.Drawing.Point(81, 132);
            this.txtTheme.Name = "txtTheme";
            this.txtTheme.Size = new System.Drawing.Size(80, 20);
            this.txtTheme.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Theme";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(80, 160);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(212, 20);
            this.txtAuthor.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Author";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(81, 186);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(80, 20);
            this.txtVersion.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Version";
            // 
            // txtIpdb
            // 
            this.txtIpdb.Location = new System.Drawing.Point(81, 212);
            this.txtIpdb.Name = "txtIpdb";
            this.txtIpdb.Size = new System.Drawing.Size(80, 20);
            this.txtIpdb.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(34, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "IPDB #";
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(81, 245);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(80, 20);
            this.txtType.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(48, 246);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 272);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "ROM";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 298);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Play Count";
            // 
            // txtRom
            // 
            this.txtRom.Location = new System.Drawing.Point(81, 269);
            this.txtRom.Name = "txtRom";
            this.txtRom.Size = new System.Drawing.Size(80, 20);
            this.txtRom.TabIndex = 37;
            // 
            // txtPlayCount
            // 
            this.txtPlayCount.Enabled = false;
            this.txtPlayCount.Location = new System.Drawing.Point(81, 295);
            this.txtPlayCount.Name = "txtPlayCount";
            this.txtPlayCount.Size = new System.Drawing.Size(80, 20);
            this.txtPlayCount.TabIndex = 38;
            // 
            // txtSeconds
            // 
            this.txtSeconds.Enabled = false;
            this.txtSeconds.Location = new System.Drawing.Point(231, 295);
            this.txtSeconds.Name = "txtSeconds";
            this.txtSeconds.Size = new System.Drawing.Size(80, 20);
            this.txtSeconds.TabIndex = 40;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(176, 298);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "Seconds";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 323);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 41;
            this.label15.Text = "Added";
            // 
            // txtAdded
            // 
            this.txtAdded.Location = new System.Drawing.Point(80, 320);
            this.txtAdded.Name = "txtAdded";
            this.txtAdded.Size = new System.Drawing.Size(130, 20);
            this.txtAdded.TabIndex = 42;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(212, 323);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "Modified";
            // 
            // chkHideDmd
            // 
            this.chkHideDmd.AutoSize = true;
            this.chkHideDmd.Location = new System.Drawing.Point(12, 456);
            this.chkHideDmd.Name = "chkHideDmd";
            this.chkHideDmd.Size = new System.Drawing.Size(137, 17);
            this.chkHideDmd.TabIndex = 45;
            this.chkHideDmd.Text = "Hide DMD during game";
            this.chkHideDmd.UseVisualStyleBackColor = true;
            // 
            // chkHideBackglass
            // 
            this.chkHideBackglass.AutoSize = true;
            this.chkHideBackglass.Location = new System.Drawing.Point(12, 479);
            this.chkHideBackglass.Name = "chkHideBackglass";
            this.chkHideBackglass.Size = new System.Drawing.Size(161, 17);
            this.chkHideBackglass.TabIndex = 46;
            this.chkHideBackglass.Text = "Hide Backglass during game";
            this.chkHideBackglass.UseVisualStyleBackColor = true;
            // 
            // chkHideTopper
            // 
            this.chkHideTopper.AutoSize = true;
            this.chkHideTopper.Location = new System.Drawing.Point(12, 502);
            this.chkHideTopper.Name = "chkHideTopper";
            this.chkHideTopper.Size = new System.Drawing.Size(150, 17);
            this.chkHideTopper.TabIndex = 47;
            this.chkHideTopper.Text = "Hide Topper During Game";
            this.chkHideTopper.UseVisualStyleBackColor = true;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(381, 14);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 48;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnFillFromIpdb
            // 
            this.btnFillFromIpdb.Location = new System.Drawing.Point(199, 210);
            this.btnFillFromIpdb.Name = "btnFillFromIpdb";
            this.btnFillFromIpdb.Size = new System.Drawing.Size(98, 23);
            this.btnFillFromIpdb.TabIndex = 49;
            this.btnFillFromIpdb.Text = "Fill From IPDB";
            this.btnFillFromIpdb.UseVisualStyleBackColor = true;
            this.btnFillFromIpdb.Click += new System.EventHandler(this.btnFillFromIpdb_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 428);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 60;
            this.label17.Text = "Game Url:";
            // 
            // txtModified
            // 
            this.txtModified.Location = new System.Drawing.Point(265, 321);
            this.txtModified.Name = "txtModified";
            this.txtModified.Size = new System.Drawing.Size(130, 20);
            this.txtModified.TabIndex = 43;
            // 
            // txtGameUrl
            // 
            this.txtGameUrl.Location = new System.Drawing.Point(81, 425);
            this.txtGameUrl.Name = "txtGameUrl";
            this.txtGameUrl.Size = new System.Drawing.Size(366, 20);
            this.txtGameUrl.TabIndex = 61;
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(215, 245);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(80, 20);
            this.txtRating.TabIndex = 65;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(178, 245);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 13);
            this.label18.TabIndex = 64;
            this.label18.Text = "Rating";
            // 
            // txtPlayers
            // 
            this.txtPlayers.Location = new System.Drawing.Point(217, 269);
            this.txtPlayers.Name = "txtPlayers";
            this.txtPlayers.Size = new System.Drawing.Size(80, 20);
            this.txtPlayers.TabIndex = 67;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(178, 269);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 66;
            this.label19.Text = "Players";
            // 
            // cmbAlternateExe
            // 
            this.cmbAlternateExe.FormattingEnabled = true;
            this.cmbAlternateExe.Location = new System.Drawing.Point(80, 347);
            this.cmbAlternateExe.Name = "cmbAlternateExe";
            this.cmbAlternateExe.Size = new System.Drawing.Size(367, 21);
            this.cmbAlternateExe.TabIndex = 68;
            // 
            // btnDatabaseBrowser
            // 
            this.btnDatabaseBrowser.Location = new System.Drawing.Point(462, 14);
            this.btnDatabaseBrowser.Name = "btnDatabaseBrowser";
            this.btnDatabaseBrowser.Size = new System.Drawing.Size(107, 23);
            this.btnDatabaseBrowser.TabIndex = 69;
            this.btnDatabaseBrowser.Text = "Database Browser";
            this.btnDatabaseBrowser.UseVisualStyleBackColor = true;
            this.btnDatabaseBrowser.Click += new System.EventHandler(this.btnDatabaseBrowser_Click);
            // 
            // btnShowNew
            // 
            this.btnShowNew.Location = new System.Drawing.Point(300, 14);
            this.btnShowNew.Name = "btnShowNew";
            this.btnShowNew.Size = new System.Drawing.Size(75, 23);
            this.btnShowNew.TabIndex = 70;
            this.btnShowNew.Text = "Add New";
            this.btnShowNew.UseVisualStyleBackColor = true;
            this.btnShowNew.Click += new System.EventHandler(this.btnShowNew_Click);
            // 
            // btnIpdbUrl
            // 
            this.btnIpdbUrl.BackgroundImage = global::PinCab.Configurator.Properties.Resources.BrowserLink_75x;
            this.btnIpdbUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIpdbUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIpdbUrl.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIpdbUrl.Location = new System.Drawing.Point(167, 210);
            this.btnIpdbUrl.Name = "btnIpdbUrl";
            this.btnIpdbUrl.Size = new System.Drawing.Size(26, 23);
            this.btnIpdbUrl.TabIndex = 63;
            this.btnIpdbUrl.UseVisualStyleBackColor = true;
            this.btnIpdbUrl.Click += new System.EventHandler(this.btnIpdbUrl_Click);
            // 
            // btnGameUrl
            // 
            this.btnGameUrl.BackgroundImage = global::PinCab.Configurator.Properties.Resources.BrowserLink_75x;
            this.btnGameUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGameUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGameUrl.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGameUrl.Location = new System.Drawing.Point(453, 425);
            this.btnGameUrl.Name = "btnGameUrl";
            this.btnGameUrl.Size = new System.Drawing.Size(27, 23);
            this.btnGameUrl.TabIndex = 62;
            this.btnGameUrl.UseVisualStyleBackColor = true;
            this.btnGameUrl.Click += new System.EventHandler(this.btnGameUrl_Click);
            // 
            // AddEditGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 583);
            this.Controls.Add(this.btnShowNew);
            this.Controls.Add(this.btnDatabaseBrowser);
            this.Controls.Add(this.cmbAlternateExe);
            this.Controls.Add(this.txtPlayers);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.btnIpdbUrl);
            this.Controls.Add(this.btnGameUrl);
            this.Controls.Add(this.txtGameUrl);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnFillFromIpdb);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.chkHideTopper);
            this.Controls.Add(this.chkHideBackglass);
            this.Controls.Add(this.chkHideDmd);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtModified);
            this.Controls.Add(this.txtAdded);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtSeconds);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPlayCount);
            this.Controls.Add(this.txtRom);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtIpdb);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTheme);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtManufacturer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkFavorite);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(550, 622);
            this.Name = "AddEditGameForm";
            this.Text = "Edit Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColorDialog colorDialogDmdColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.CheckBox chkFavorite;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtManufacturer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTheme;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIpdb;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRom;
        private System.Windows.Forms.TextBox txtPlayCount;
        private System.Windows.Forms.TextBox txtSeconds;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtAdded;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkHideDmd;
        private System.Windows.Forms.CheckBox chkHideBackglass;
        private System.Windows.Forms.CheckBox chkHideTopper;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnFillFromIpdb;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtModified;
        private System.Windows.Forms.TextBox txtGameUrl;
        private System.Windows.Forms.Button btnGameUrl;
        private System.Windows.Forms.Button btnIpdbUrl;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtPlayers;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbAlternateExe;
        private System.Windows.Forms.Button btnDatabaseBrowser;
        private System.Windows.Forms.Button btnShowNew;
    }
}