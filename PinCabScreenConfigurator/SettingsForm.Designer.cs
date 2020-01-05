namespace PinCabScreenConfigurator
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFFMpegFilePath = new System.Windows.Forms.TextBox();
            this.btnFFMPegHelp = new System.Windows.Forms.Button();
            this.btnFFMpegFilePath = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(139, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "FFMpeg File Path:";
            // 
            // txtFFMpegFilePath
            // 
            this.txtFFMpegFilePath.Location = new System.Drawing.Point(116, 5);
            this.txtFFMpegFilePath.Name = "txtFFMpegFilePath";
            this.txtFFMpegFilePath.Size = new System.Drawing.Size(459, 20);
            this.txtFFMpegFilePath.TabIndex = 3;
            // 
            // btnFFMPegHelp
            // 
            this.btnFFMPegHelp.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnFFMPegHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFFMPegHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnFFMPegHelp.Image")));
            this.btnFFMPegHelp.Location = new System.Drawing.Point(0, 4);
            this.btnFFMPegHelp.Name = "btnFFMPegHelp";
            this.btnFFMPegHelp.Size = new System.Drawing.Size(20, 22);
            this.btnFFMPegHelp.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnFFMPegHelp, "This is a test");
            this.btnFFMPegHelp.UseVisualStyleBackColor = true;
            this.btnFFMPegHelp.Click += new System.EventHandler(this.btnFFMPegHelp_Click);
            // 
            // btnFFMpegFilePath
            // 
            this.btnFFMpegFilePath.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFFMpegFilePath.BackgroundImage")));
            this.btnFFMpegFilePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFFMpegFilePath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFFMpegFilePath.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFFMpegFilePath.Location = new System.Drawing.Point(581, 4);
            this.btnFFMpegFilePath.Name = "btnFFMpegFilePath";
            this.btnFFMpegFilePath.Size = new System.Drawing.Size(38, 23);
            this.btnFFMpegFilePath.TabIndex = 6;
            this.btnFFMpegFilePath.UseVisualStyleBackColor = true;
            this.btnFFMpegFilePath.Click += new System.EventHandler(this.btnFFMpegFilePath_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFFMpegFilePath);
            this.Controls.Add(this.btnFFMPegHelp);
            this.Controls.Add(this.txtFFMpegFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFFMpegFilePath;
        private System.Windows.Forms.Button btnFFMPegHelp;
        private System.Windows.Forms.Button btnFFMpegFilePath;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}