namespace PinCab.Configurator
{
    partial class ScreenResEditorForm
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
            this.txtPlayfieldWidth = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPlayfieldHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBackglassWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBackglassHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDisplay = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBackglassXOffset = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBackglassYOffset = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDmdWidth = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDmdHeight = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDmdXOffset = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDmdYOffset = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.chkYFlip = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlayfieldWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlayfieldHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBackglassWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBackglassHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBackglassXOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBackglassYOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDmdWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDmdHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDmdXOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDmdYOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Playfield Width";
            // 
            // txtPlayfieldWidth
            // 
            this.txtPlayfieldWidth.Location = new System.Drawing.Point(112, 9);
            this.txtPlayfieldWidth.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.txtPlayfieldWidth.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.txtPlayfieldWidth.Name = "txtPlayfieldWidth";
            this.txtPlayfieldWidth.Size = new System.Drawing.Size(120, 20);
            this.txtPlayfieldWidth.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(3, 324);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(112, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPlayfieldHeight
            // 
            this.txtPlayfieldHeight.Location = new System.Drawing.Point(112, 35);
            this.txtPlayfieldHeight.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.txtPlayfieldHeight.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.txtPlayfieldHeight.Name = "txtPlayfieldHeight";
            this.txtPlayfieldHeight.Size = new System.Drawing.Size(120, 20);
            this.txtPlayfieldHeight.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Playfield Height";
            // 
            // txtBackglassWidth
            // 
            this.txtBackglassWidth.Location = new System.Drawing.Point(112, 87);
            this.txtBackglassWidth.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.txtBackglassWidth.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.txtBackglassWidth.Name = "txtBackglassWidth";
            this.txtBackglassWidth.Size = new System.Drawing.Size(120, 20);
            this.txtBackglassWidth.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Backglass Width";
            // 
            // txtBackglassHeight
            // 
            this.txtBackglassHeight.Location = new System.Drawing.Point(112, 113);
            this.txtBackglassHeight.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.txtBackglassHeight.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.txtBackglassHeight.Name = "txtBackglassHeight";
            this.txtBackglassHeight.Size = new System.Drawing.Size(120, 20);
            this.txtBackglassHeight.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Backglass Height";
            // 
            // cmbDisplay
            // 
            this.cmbDisplay.FormattingEnabled = true;
            this.cmbDisplay.Location = new System.Drawing.Point(112, 61);
            this.cmbDisplay.Name = "cmbDisplay";
            this.cmbDisplay.Size = new System.Drawing.Size(456, 21);
            this.cmbDisplay.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Backglass Display";
            // 
            // txtBackglassXOffset
            // 
            this.txtBackglassXOffset.Location = new System.Drawing.Point(112, 139);
            this.txtBackglassXOffset.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.txtBackglassXOffset.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.txtBackglassXOffset.Name = "txtBackglassXOffset";
            this.txtBackglassXOffset.Size = new System.Drawing.Size(120, 20);
            this.txtBackglassXOffset.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Backglass X Offset";
            // 
            // txtBackglassYOffset
            // 
            this.txtBackglassYOffset.Location = new System.Drawing.Point(112, 165);
            this.txtBackglassYOffset.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.txtBackglassYOffset.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.txtBackglassYOffset.Name = "txtBackglassYOffset";
            this.txtBackglassYOffset.Size = new System.Drawing.Size(120, 20);
            this.txtBackglassYOffset.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Backglass Y Offset";
            // 
            // txtDmdWidth
            // 
            this.txtDmdWidth.Location = new System.Drawing.Point(112, 197);
            this.txtDmdWidth.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.txtDmdWidth.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.txtDmdWidth.Name = "txtDmdWidth";
            this.txtDmdWidth.Size = new System.Drawing.Size(120, 20);
            this.txtDmdWidth.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "DMD Display Width";
            // 
            // txtDmdHeight
            // 
            this.txtDmdHeight.Location = new System.Drawing.Point(112, 223);
            this.txtDmdHeight.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.txtDmdHeight.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.txtDmdHeight.Name = "txtDmdHeight";
            this.txtDmdHeight.Size = new System.Drawing.Size(120, 20);
            this.txtDmdHeight.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "DMD Display Height";
            // 
            // txtDmdXOffset
            // 
            this.txtDmdXOffset.Location = new System.Drawing.Point(112, 249);
            this.txtDmdXOffset.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.txtDmdXOffset.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.txtDmdXOffset.Name = "txtDmdXOffset";
            this.txtDmdXOffset.Size = new System.Drawing.Size(120, 20);
            this.txtDmdXOffset.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 251);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "DMD Display X Offset";
            // 
            // txtDmdYOffset
            // 
            this.txtDmdYOffset.Location = new System.Drawing.Point(112, 275);
            this.txtDmdYOffset.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.txtDmdYOffset.Minimum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            -2147483648});
            this.txtDmdYOffset.Name = "txtDmdYOffset";
            this.txtDmdYOffset.Size = new System.Drawing.Size(120, 20);
            this.txtDmdYOffset.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(0, 278);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "DMD Display Y Offset";
            // 
            // chkYFlip
            // 
            this.chkYFlip.AutoSize = true;
            this.chkYFlip.Location = new System.Drawing.Point(6, 301);
            this.chkYFlip.Name = "chkYFlip";
            this.chkYFlip.Size = new System.Drawing.Size(367, 17);
            this.chkYFlip.TabIndex = 24;
            this.chkYFlip.Text = "Y-Flip (Flips the DMD/LED display upside down, used in P2K Style cabs)";
            this.chkYFlip.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHelp.Location = new System.Drawing.Point(254, 324);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 25;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // ScreenResEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 357);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.chkYFlip);
            this.Controls.Add(this.txtDmdYOffset);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDmdXOffset);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDmdHeight);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDmdWidth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBackglassYOffset);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBackglassXOffset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDisplay);
            this.Controls.Add(this.txtBackglassHeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBackglassWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPlayfieldHeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPlayfieldWidth);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenResEditorForm";
            this.Text = "B2S Screenres.txt Editor";
            ((System.ComponentModel.ISupportInitialize)(this.txtPlayfieldWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlayfieldHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBackglassWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBackglassHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBackglassXOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBackglassYOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDmdWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDmdHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDmdXOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDmdYOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtPlayfieldWidth;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown txtPlayfieldHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtBackglassWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtBackglassHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDisplay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown txtBackglassXOffset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown txtBackglassYOffset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown txtDmdWidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown txtDmdHeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown txtDmdXOffset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown txtDmdYOffset;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkYFlip;
        private System.Windows.Forms.Button btnHelp;
    }
}