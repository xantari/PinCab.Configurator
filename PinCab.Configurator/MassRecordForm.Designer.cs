
namespace PinCab.Configurator
{
    partial class MassRecordForm
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
            this.chkCreatePlayfield = new System.Windows.Forms.CheckBox();
            this.chkCreateBackglass = new System.Windows.Forms.CheckBox();
            this.chkCreateDmd = new System.Windows.Forms.CheckBox();
            this.chkCreateToppers = new System.Windows.Forms.CheckBox();
            this.chkSkipPlayfield = new System.Windows.Forms.CheckBox();
            this.chkSkipExistingBackglass = new System.Windows.Forms.CheckBox();
            this.chkSkipDmd = new System.Windows.Forms.CheckBox();
            this.chkSkipTopper = new System.Windows.Forms.CheckBox();
            this.btnBegin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbFrontEnd = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // chkCreatePlayfield
            // 
            this.chkCreatePlayfield.AutoSize = true;
            this.chkCreatePlayfield.Location = new System.Drawing.Point(12, 64);
            this.chkCreatePlayfield.Name = "chkCreatePlayfield";
            this.chkCreatePlayfield.Size = new System.Drawing.Size(134, 17);
            this.chkCreatePlayfield.TabIndex = 0;
            this.chkCreatePlayfield.Text = "Create Playfield Videos";
            this.chkCreatePlayfield.UseVisualStyleBackColor = true;
            // 
            // chkCreateBackglass
            // 
            this.chkCreateBackglass.AutoSize = true;
            this.chkCreateBackglass.Location = new System.Drawing.Point(12, 87);
            this.chkCreateBackglass.Name = "chkCreateBackglass";
            this.chkCreateBackglass.Size = new System.Drawing.Size(144, 17);
            this.chkCreateBackglass.TabIndex = 1;
            this.chkCreateBackglass.Text = "Create Backglass Videos";
            this.chkCreateBackglass.UseVisualStyleBackColor = true;
            // 
            // chkCreateDmd
            // 
            this.chkCreateDmd.AutoSize = true;
            this.chkCreateDmd.Location = new System.Drawing.Point(12, 110);
            this.chkCreateDmd.Name = "chkCreateDmd";
            this.chkCreateDmd.Size = new System.Drawing.Size(120, 17);
            this.chkCreateDmd.TabIndex = 2;
            this.chkCreateDmd.Text = "Create DMD Videos";
            this.chkCreateDmd.UseVisualStyleBackColor = true;
            // 
            // chkCreateToppers
            // 
            this.chkCreateToppers.AutoSize = true;
            this.chkCreateToppers.Location = new System.Drawing.Point(12, 133);
            this.chkCreateToppers.Name = "chkCreateToppers";
            this.chkCreateToppers.Size = new System.Drawing.Size(129, 17);
            this.chkCreateToppers.TabIndex = 3;
            this.chkCreateToppers.Text = "Create Topper Videos";
            this.chkCreateToppers.UseVisualStyleBackColor = true;
            // 
            // chkSkipPlayfield
            // 
            this.chkSkipPlayfield.AutoSize = true;
            this.chkSkipPlayfield.Location = new System.Drawing.Point(169, 64);
            this.chkSkipPlayfield.Name = "chkSkipPlayfield";
            this.chkSkipPlayfield.Size = new System.Drawing.Size(158, 17);
            this.chkSkipPlayfield.TabIndex = 4;
            this.chkSkipPlayfield.Text = "Skip Existing Playfield Video";
            this.chkSkipPlayfield.UseVisualStyleBackColor = true;
            // 
            // chkSkipExistingBackglass
            // 
            this.chkSkipExistingBackglass.AutoSize = true;
            this.chkSkipExistingBackglass.Location = new System.Drawing.Point(169, 87);
            this.chkSkipExistingBackglass.Name = "chkSkipExistingBackglass";
            this.chkSkipExistingBackglass.Size = new System.Drawing.Size(168, 17);
            this.chkSkipExistingBackglass.TabIndex = 5;
            this.chkSkipExistingBackglass.Text = "Skip Existing Backglass Video";
            this.chkSkipExistingBackglass.UseVisualStyleBackColor = true;
            // 
            // chkSkipDmd
            // 
            this.chkSkipDmd.AutoSize = true;
            this.chkSkipDmd.Location = new System.Drawing.Point(169, 110);
            this.chkSkipDmd.Name = "chkSkipDmd";
            this.chkSkipDmd.Size = new System.Drawing.Size(144, 17);
            this.chkSkipDmd.TabIndex = 6;
            this.chkSkipDmd.Text = "Skip Existing DMD Video";
            this.chkSkipDmd.UseVisualStyleBackColor = true;
            // 
            // chkSkipTopper
            // 
            this.chkSkipTopper.AutoSize = true;
            this.chkSkipTopper.Location = new System.Drawing.Point(169, 133);
            this.chkSkipTopper.Name = "chkSkipTopper";
            this.chkSkipTopper.Size = new System.Drawing.Size(153, 17);
            this.chkSkipTopper.TabIndex = 7;
            this.chkSkipTopper.Text = "Skip Existing Topper Video";
            this.chkSkipTopper.UseVisualStyleBackColor = true;
            // 
            // btnBegin
            // 
            this.btnBegin.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnBegin.Location = new System.Drawing.Point(12, 157);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(75, 23);
            this.btnBegin.TabIndex = 8;
            this.btnBegin.Text = "Begin";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(119, 157);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbFrontEnd
            // 
            this.cmbFrontEnd.DisplayMember = "Name";
            this.cmbFrontEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrontEnd.FormattingEnabled = true;
            this.cmbFrontEnd.Location = new System.Drawing.Point(69, 7);
            this.cmbFrontEnd.Name = "cmbFrontEnd";
            this.cmbFrontEnd.Size = new System.Drawing.Size(107, 21);
            this.cmbFrontEnd.TabIndex = 11;
            this.cmbFrontEnd.ValueMember = "System";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Front End";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Method";
            // 
            // cmbMethod
            // 
            this.cmbMethod.DisplayMember = "Name";
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Location = new System.Drawing.Point(68, 34);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(254, 21);
            this.cmbMethod.TabIndex = 13;
            this.cmbMethod.ValueMember = "System";
            // 
            // MassRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 187);
            this.Controls.Add(this.cmbMethod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFrontEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.chkSkipTopper);
            this.Controls.Add(this.chkSkipDmd);
            this.Controls.Add(this.chkSkipExistingBackglass);
            this.Controls.Add(this.chkSkipPlayfield);
            this.Controls.Add(this.chkCreateToppers);
            this.Controls.Add(this.chkCreateDmd);
            this.Controls.Add(this.chkCreateBackglass);
            this.Controls.Add(this.chkCreatePlayfield);
            this.Name = "MassRecordForm";
            this.Text = "Mass Record Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCreatePlayfield;
        private System.Windows.Forms.CheckBox chkCreateBackglass;
        private System.Windows.Forms.CheckBox chkCreateDmd;
        private System.Windows.Forms.CheckBox chkCreateToppers;
        private System.Windows.Forms.CheckBox chkSkipPlayfield;
        private System.Windows.Forms.CheckBox chkSkipExistingBackglass;
        private System.Windows.Forms.CheckBox chkSkipDmd;
        private System.Windows.Forms.CheckBox chkSkipTopper;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbFrontEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMethod;
    }
}