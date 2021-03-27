
namespace PinCab.Configurator
{
    partial class SaveDatabaseForm
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
            this.checkedListBoxDatabases = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCommitMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkedListBoxDatabases
            // 
            this.checkedListBoxDatabases.CheckOnClick = true;
            this.checkedListBoxDatabases.FormattingEnabled = true;
            this.checkedListBoxDatabases.Location = new System.Drawing.Point(12, 58);
            this.checkedListBoxDatabases.Name = "checkedListBoxDatabases";
            this.checkedListBoxDatabases.Size = new System.Drawing.Size(441, 139);
            this.checkedListBoxDatabases.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(118, 203);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 203);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(12, 251);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(760, 131);
            this.txtLog.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Log:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(434, 39);
            this.label2.TabIndex = 14;
            this.label2.Text = "Select the databases you wish to save from the temporary location to the final re" +
    "sting spot. \r\n\r\nNote: This only supports local file system and public/private Gi" +
    "thub Repos.";
            // 
            // txtCommitMessage
            // 
            this.txtCommitMessage.Location = new System.Drawing.Point(472, 58);
            this.txtCommitMessage.Multiline = true;
            this.txtCommitMessage.Name = "txtCommitMessage";
            this.txtCommitMessage.Size = new System.Drawing.Size(287, 139);
            this.txtCommitMessage.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Commit Message (Only for Github)";
            // 
            // SaveDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 392);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCommitMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.checkedListBoxDatabases);
            this.MinimumSize = new System.Drawing.Size(800, 431);
            this.Name = "SaveDatabaseForm";
            this.Text = "Save Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxDatabases;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCommitMessage;
        private System.Windows.Forms.Label label3;
    }
}