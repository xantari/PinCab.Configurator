namespace PinCab.Configurator
{
    partial class PinMameRomSettingEditorForm
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
            this.lblRomName = new System.Windows.Forms.Label();
            this.chkEnableAntiAlias = new System.Windows.Forms.CheckBox();
            this.chkSkipStartup = new System.Windows.Forms.CheckBox();
            this.numericAntiAliasPercentage = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericOpacity = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkBorder = new System.Windows.Forms.CheckBox();
            this.chkTitle = new System.Windows.Forms.CheckBox();
            this.chkScanLines = new System.Windows.Forms.CheckBox();
            this.chkDirectDraw = new System.Windows.Forms.CheckBox();
            this.chkShowVpinMameDmd = new System.Windows.Forms.CheckBox();
            this.chkDirect3d = new System.Windows.Forms.CheckBox();
            this.chkAt91Jit = new System.Windows.Forms.CheckBox();
            this.chkExternalDmdDevice = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericHeight = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericWidth = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericOffsetX = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericOffsetY = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericIntensityPerc0 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericIntensityPerc33 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numericIntensityPerc66 = new System.Windows.Forms.NumericUpDown();
            this.chkColorize = new System.Windows.Forms.CheckBox();
            this.chkCabinetMode = new System.Windows.Forms.CheckBox();
            this.chkIgnoreRomCrcCheck = new System.Windows.Forms.CheckBox();
            this.chkRotateLeft = new System.Windows.Forms.CheckBox();
            this.chkRotateRight = new System.Windows.Forms.CheckBox();
            this.chkFlipX = new System.Windows.Forms.CheckBox();
            this.chkFlipY = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numericSyncLevel = new System.Windows.Forms.NumericUpDown();
            this.chkResamplingQuality = new System.Windows.Forms.CheckBox();
            this.chkDoubleDisplaySize = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numericFastFrames = new System.Windows.Forms.NumericUpDown();
            this.chkCompactMode = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.numericSampleRate = new System.Windows.Forms.NumericUpDown();
            this.cmbSoundMode = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkUseSamples = new System.Windows.Forms.CheckBox();
            this.chkEnableSound = new System.Windows.Forms.CheckBox();
            this.colorDialogDmdColor = new System.Windows.Forms.ColorDialog();
            this.labelDmdColor = new System.Windows.Forms.Label();
            this.btnDmdColor = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericAntiAliasPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntensityPerc0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntensityPerc33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntensityPerc66)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSyncLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFastFrames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSampleRate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rom Name:";
            // 
            // lblRomName
            // 
            this.lblRomName.AutoSize = true;
            this.lblRomName.Location = new System.Drawing.Point(81, 9);
            this.lblRomName.Name = "lblRomName";
            this.lblRomName.Size = new System.Drawing.Size(86, 13);
            this.lblRomName.TabIndex = 1;
            this.lblRomName.Text = "Rom Name Here";
            // 
            // chkEnableAntiAlias
            // 
            this.chkEnableAntiAlias.AutoSize = true;
            this.chkEnableAntiAlias.Location = new System.Drawing.Point(12, 31);
            this.chkEnableAntiAlias.Name = "chkEnableAntiAlias";
            this.chkEnableAntiAlias.Size = new System.Drawing.Size(119, 17);
            this.chkEnableAntiAlias.TabIndex = 2;
            this.chkEnableAntiAlias.Text = "Enable Anti Aliasing";
            this.chkEnableAntiAlias.ThreeState = true;
            this.chkEnableAntiAlias.UseVisualStyleBackColor = true;
            // 
            // chkSkipStartup
            // 
            this.chkSkipStartup.AutoSize = true;
            this.chkSkipStartup.Location = new System.Drawing.Point(12, 54);
            this.chkSkipStartup.Name = "chkSkipStartup";
            this.chkSkipStartup.Size = new System.Drawing.Size(84, 17);
            this.chkSkipStartup.TabIndex = 3;
            this.chkSkipStartup.Text = "Skip Startup";
            this.chkSkipStartup.ThreeState = true;
            this.chkSkipStartup.UseVisualStyleBackColor = true;
            // 
            // numericAntiAliasPercentage
            // 
            this.numericAntiAliasPercentage.Location = new System.Drawing.Point(429, 33);
            this.numericAntiAliasPercentage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericAntiAliasPercentage.Name = "numericAntiAliasPercentage";
            this.numericAntiAliasPercentage.Size = new System.Drawing.Size(120, 20);
            this.numericAntiAliasPercentage.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(315, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Anti Alias Percentage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Opacity";
            // 
            // numericOpacity
            // 
            this.numericOpacity.Location = new System.Drawing.Point(429, 56);
            this.numericOpacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericOpacity.Name = "numericOpacity";
            this.numericOpacity.Size = new System.Drawing.Size(120, 20);
            this.numericOpacity.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            // chkBorder
            // 
            this.chkBorder.AutoSize = true;
            this.chkBorder.Location = new System.Drawing.Point(12, 77);
            this.chkBorder.Name = "chkBorder";
            this.chkBorder.Size = new System.Drawing.Size(87, 17);
            this.chkBorder.TabIndex = 10;
            this.chkBorder.Text = "Show Border";
            this.chkBorder.ThreeState = true;
            this.chkBorder.UseVisualStyleBackColor = true;
            // 
            // chkTitle
            // 
            this.chkTitle.AutoSize = true;
            this.chkTitle.Location = new System.Drawing.Point(12, 100);
            this.chkTitle.Name = "chkTitle";
            this.chkTitle.Size = new System.Drawing.Size(91, 17);
            this.chkTitle.TabIndex = 11;
            this.chkTitle.Text = "Show Titlebar";
            this.chkTitle.ThreeState = true;
            this.chkTitle.UseVisualStyleBackColor = true;
            // 
            // chkScanLines
            // 
            this.chkScanLines.AutoSize = true;
            this.chkScanLines.Location = new System.Drawing.Point(12, 123);
            this.chkScanLines.Name = "chkScanLines";
            this.chkScanLines.Size = new System.Drawing.Size(109, 17);
            this.chkScanLines.TabIndex = 12;
            this.chkScanLines.Text = "Show Scan Lines";
            this.chkScanLines.ThreeState = true;
            this.chkScanLines.UseVisualStyleBackColor = true;
            // 
            // chkDirectDraw
            // 
            this.chkDirectDraw.AutoSize = true;
            this.chkDirectDraw.Location = new System.Drawing.Point(12, 169);
            this.chkDirectDraw.Name = "chkDirectDraw";
            this.chkDirectDraw.Size = new System.Drawing.Size(82, 17);
            this.chkDirectDraw.TabIndex = 13;
            this.chkDirectDraw.Text = "Direct Draw";
            this.chkDirectDraw.ThreeState = true;
            this.chkDirectDraw.UseVisualStyleBackColor = true;
            // 
            // chkShowVpinMameDmd
            // 
            this.chkShowVpinMameDmd.AutoSize = true;
            this.chkShowVpinMameDmd.Location = new System.Drawing.Point(12, 192);
            this.chkShowVpinMameDmd.Name = "chkShowVpinMameDmd";
            this.chkShowVpinMameDmd.Size = new System.Drawing.Size(169, 17);
            this.chkShowVpinMameDmd.TabIndex = 14;
            this.chkShowVpinMameDmd.Text = "Show Native VPinMame DMD";
            this.chkShowVpinMameDmd.ThreeState = true;
            this.chkShowVpinMameDmd.UseVisualStyleBackColor = true;
            // 
            // chkDirect3d
            // 
            this.chkDirect3d.AutoSize = true;
            this.chkDirect3d.Location = new System.Drawing.Point(12, 215);
            this.chkDirect3d.Name = "chkDirect3d";
            this.chkDirect3d.Size = new System.Drawing.Size(71, 17);
            this.chkDirect3d.TabIndex = 15;
            this.chkDirect3d.Text = "Direct 3D";
            this.chkDirect3d.ThreeState = true;
            this.chkDirect3d.UseVisualStyleBackColor = true;
            // 
            // chkAt91Jit
            // 
            this.chkAt91Jit.AutoSize = true;
            this.chkAt91Jit.Location = new System.Drawing.Point(12, 146);
            this.chkAt91Jit.Name = "chkAt91Jit";
            this.chkAt91Jit.Size = new System.Drawing.Size(153, 17);
            this.chkAt91Jit.TabIndex = 16;
            this.chkAt91Jit.Text = "Enable At91jit (Jit Compiler)";
            this.chkAt91Jit.ThreeState = true;
            this.chkAt91Jit.UseVisualStyleBackColor = true;
            // 
            // chkExternalDmdDevice
            // 
            this.chkExternalDmdDevice.AutoSize = true;
            this.chkExternalDmdDevice.Location = new System.Drawing.Point(12, 238);
            this.chkExternalDmdDevice.Name = "chkExternalDmdDevice";
            this.chkExternalDmdDevice.Size = new System.Drawing.Size(265, 17);
            this.chkExternalDmdDevice.TabIndex = 17;
            this.chkExternalDmdDevice.Text = "Enable External DMD Device (PinDMD / DMDExt)";
            this.chkExternalDmdDevice.ThreeState = true;
            this.chkExternalDmdDevice.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Height";
            // 
            // numericHeight
            // 
            this.numericHeight.Location = new System.Drawing.Point(429, 79);
            this.numericHeight.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericHeight.Name = "numericHeight";
            this.numericHeight.Size = new System.Drawing.Size(120, 20);
            this.numericHeight.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(383, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Width";
            // 
            // numericWidth
            // 
            this.numericWidth.Location = new System.Drawing.Point(429, 105);
            this.numericWidth.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericWidth.Name = "numericWidth";
            this.numericWidth.Size = new System.Drawing.Size(120, 20);
            this.numericWidth.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "DMD Virtual Window Offset X";
            // 
            // numericOffsetX
            // 
            this.numericOffsetX.Location = new System.Drawing.Point(429, 129);
            this.numericOffsetX.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericOffsetX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericOffsetX.Name = "numericOffsetX";
            this.numericOffsetX.Size = new System.Drawing.Size(120, 20);
            this.numericOffsetX.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "DMD Virtual Window Offset Y";
            // 
            // numericOffsetY
            // 
            this.numericOffsetY.Location = new System.Drawing.Point(429, 157);
            this.numericOffsetY.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.numericOffsetY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericOffsetY.Name = "numericOffsetY";
            this.numericOffsetY.Size = new System.Drawing.Size(120, 20);
            this.numericOffsetY.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Intensity Percentage at 0% (off)";
            // 
            // numericIntensityPerc0
            // 
            this.numericIntensityPerc0.Location = new System.Drawing.Point(429, 190);
            this.numericIntensityPerc0.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericIntensityPerc0.Name = "numericIntensityPerc0";
            this.numericIntensityPerc0.Size = new System.Drawing.Size(120, 20);
            this.numericIntensityPerc0.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(284, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Intensity Percentage at 33%";
            // 
            // numericIntensityPerc33
            // 
            this.numericIntensityPerc33.Location = new System.Drawing.Point(429, 214);
            this.numericIntensityPerc33.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericIntensityPerc33.Name = "numericIntensityPerc33";
            this.numericIntensityPerc33.Size = new System.Drawing.Size(120, 20);
            this.numericIntensityPerc33.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(284, 237);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Intensity Percentage at 66%";
            // 
            // numericIntensityPerc66
            // 
            this.numericIntensityPerc66.Location = new System.Drawing.Point(429, 235);
            this.numericIntensityPerc66.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericIntensityPerc66.Name = "numericIntensityPerc66";
            this.numericIntensityPerc66.Size = new System.Drawing.Size(120, 20);
            this.numericIntensityPerc66.TabIndex = 30;
            // 
            // chkColorize
            // 
            this.chkColorize.AutoSize = true;
            this.chkColorize.Location = new System.Drawing.Point(12, 261);
            this.chkColorize.Name = "chkColorize";
            this.chkColorize.Size = new System.Drawing.Size(116, 17);
            this.chkColorize.TabIndex = 32;
            this.chkColorize.Text = "Enable Colorization";
            this.chkColorize.ThreeState = true;
            this.chkColorize.UseVisualStyleBackColor = true;
            // 
            // chkCabinetMode
            // 
            this.chkCabinetMode.AutoSize = true;
            this.chkCabinetMode.Location = new System.Drawing.Point(12, 284);
            this.chkCabinetMode.Name = "chkCabinetMode";
            this.chkCabinetMode.Size = new System.Drawing.Size(92, 17);
            this.chkCabinetMode.TabIndex = 33;
            this.chkCabinetMode.Text = "Cabinet Mode";
            this.chkCabinetMode.ThreeState = true;
            this.chkCabinetMode.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreRomCrcCheck
            // 
            this.chkIgnoreRomCrcCheck.AutoSize = true;
            this.chkIgnoreRomCrcCheck.Location = new System.Drawing.Point(12, 307);
            this.chkIgnoreRomCrcCheck.Name = "chkIgnoreRomCrcCheck";
            this.chkIgnoreRomCrcCheck.Size = new System.Drawing.Size(143, 17);
            this.chkIgnoreRomCrcCheck.TabIndex = 34;
            this.chkIgnoreRomCrcCheck.Text = "Ignore ROM CRC Check";
            this.chkIgnoreRomCrcCheck.ThreeState = true;
            this.chkIgnoreRomCrcCheck.UseVisualStyleBackColor = true;
            // 
            // chkRotateLeft
            // 
            this.chkRotateLeft.AutoSize = true;
            this.chkRotateLeft.Location = new System.Drawing.Point(12, 330);
            this.chkRotateLeft.Name = "chkRotateLeft";
            this.chkRotateLeft.Size = new System.Drawing.Size(79, 17);
            this.chkRotateLeft.TabIndex = 35;
            this.chkRotateLeft.Text = "Rotate Left";
            this.chkRotateLeft.ThreeState = true;
            this.chkRotateLeft.UseVisualStyleBackColor = true;
            // 
            // chkRotateRight
            // 
            this.chkRotateRight.AutoSize = true;
            this.chkRotateRight.Location = new System.Drawing.Point(12, 353);
            this.chkRotateRight.Name = "chkRotateRight";
            this.chkRotateRight.Size = new System.Drawing.Size(86, 17);
            this.chkRotateRight.TabIndex = 36;
            this.chkRotateRight.Text = "Rotate Right";
            this.chkRotateRight.ThreeState = true;
            this.chkRotateRight.UseVisualStyleBackColor = true;
            // 
            // chkFlipX
            // 
            this.chkFlipX.AutoSize = true;
            this.chkFlipX.Location = new System.Drawing.Point(12, 376);
            this.chkFlipX.Name = "chkFlipX";
            this.chkFlipX.Size = new System.Drawing.Size(52, 17);
            this.chkFlipX.TabIndex = 37;
            this.chkFlipX.Text = "Flip X";
            this.chkFlipX.ThreeState = true;
            this.chkFlipX.UseVisualStyleBackColor = true;
            // 
            // chkFlipY
            // 
            this.chkFlipY.AutoSize = true;
            this.chkFlipY.Location = new System.Drawing.Point(12, 399);
            this.chkFlipY.Name = "chkFlipY";
            this.chkFlipY.Size = new System.Drawing.Size(52, 17);
            this.chkFlipY.TabIndex = 38;
            this.chkFlipY.Text = "Flip Y";
            this.chkFlipY.ThreeState = true;
            this.chkFlipY.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(363, 270);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Sync Level";
            // 
            // numericSyncLevel
            // 
            this.numericSyncLevel.Location = new System.Drawing.Point(428, 268);
            this.numericSyncLevel.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericSyncLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericSyncLevel.Name = "numericSyncLevel";
            this.numericSyncLevel.Size = new System.Drawing.Size(120, 20);
            this.numericSyncLevel.TabIndex = 39;
            // 
            // chkResamplingQuality
            // 
            this.chkResamplingQuality.AutoSize = true;
            this.chkResamplingQuality.Location = new System.Drawing.Point(12, 422);
            this.chkResamplingQuality.Name = "chkResamplingQuality";
            this.chkResamplingQuality.Size = new System.Drawing.Size(116, 17);
            this.chkResamplingQuality.TabIndex = 41;
            this.chkResamplingQuality.Text = "Resampling Quality";
            this.chkResamplingQuality.ThreeState = true;
            this.chkResamplingQuality.UseVisualStyleBackColor = true;
            // 
            // chkDoubleDisplaySize
            // 
            this.chkDoubleDisplaySize.AutoSize = true;
            this.chkDoubleDisplaySize.Location = new System.Drawing.Point(12, 445);
            this.chkDoubleDisplaySize.Name = "chkDoubleDisplaySize";
            this.chkDoubleDisplaySize.Size = new System.Drawing.Size(120, 17);
            this.chkDoubleDisplaySize.TabIndex = 42;
            this.chkDoubleDisplaySize.Text = "Double Display Size";
            this.chkDoubleDisplaySize.ThreeState = true;
            this.chkDoubleDisplaySize.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(359, 297);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 13);
            this.label12.TabIndex = 44;
            this.label12.Text = "Fast Frames";
            // 
            // numericFastFrames
            // 
            this.numericFastFrames.Location = new System.Drawing.Point(429, 295);
            this.numericFastFrames.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericFastFrames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericFastFrames.Name = "numericFastFrames";
            this.numericFastFrames.Size = new System.Drawing.Size(120, 20);
            this.numericFastFrames.TabIndex = 43;
            // 
            // chkCompactMode
            // 
            this.chkCompactMode.AutoSize = true;
            this.chkCompactMode.Location = new System.Drawing.Point(12, 468);
            this.chkCompactMode.Name = "chkCompactMode";
            this.chkCompactMode.Size = new System.Drawing.Size(98, 17);
            this.chkCompactMode.TabIndex = 45;
            this.chkCompactMode.Text = "Compact Mode";
            this.chkCompactMode.ThreeState = true;
            this.chkCompactMode.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(359, 323);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Sample Rate";
            // 
            // numericSampleRate
            // 
            this.numericSampleRate.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericSampleRate.Location = new System.Drawing.Point(429, 321);
            this.numericSampleRate.Maximum = new decimal(new int[] {
            96000,
            0,
            0,
            0});
            this.numericSampleRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericSampleRate.Name = "numericSampleRate";
            this.numericSampleRate.Size = new System.Drawing.Size(120, 20);
            this.numericSampleRate.TabIndex = 46;
            // 
            // cmbSoundMode
            // 
            this.cmbSoundMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSoundMode.FormattingEnabled = true;
            this.cmbSoundMode.Items.AddRange(new object[] {
            "0 = Builtin PinMAME Emulation",
            "1 = Alternate Sound File Support",
            "2 = PinSound"});
            this.cmbSoundMode.Location = new System.Drawing.Point(366, 347);
            this.cmbSoundMode.Name = "cmbSoundMode";
            this.cmbSoundMode.Size = new System.Drawing.Size(183, 21);
            this.cmbSoundMode.TabIndex = 48;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(292, 350);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 49;
            this.label14.Text = "Sound Mode";
            // 
            // chkUseSamples
            // 
            this.chkUseSamples.AutoSize = true;
            this.chkUseSamples.Location = new System.Drawing.Point(12, 491);
            this.chkUseSamples.Name = "chkUseSamples";
            this.chkUseSamples.Size = new System.Drawing.Size(88, 17);
            this.chkUseSamples.TabIndex = 50;
            this.chkUseSamples.Text = "Use Samples";
            this.chkUseSamples.ThreeState = true;
            this.chkUseSamples.UseVisualStyleBackColor = true;
            // 
            // chkEnableSound
            // 
            this.chkEnableSound.AutoSize = true;
            this.chkEnableSound.Location = new System.Drawing.Point(12, 514);
            this.chkEnableSound.Name = "chkEnableSound";
            this.chkEnableSound.Size = new System.Drawing.Size(93, 17);
            this.chkEnableSound.TabIndex = 51;
            this.chkEnableSound.Text = "Enable Sound";
            this.chkEnableSound.ThreeState = true;
            this.chkEnableSound.UseVisualStyleBackColor = true;
            // 
            // labelDmdColor
            // 
            this.labelDmdColor.AutoSize = true;
            this.labelDmdColor.Location = new System.Drawing.Point(363, 377);
            this.labelDmdColor.Name = "labelDmdColor";
            this.labelDmdColor.Size = new System.Drawing.Size(59, 13);
            this.labelDmdColor.TabIndex = 52;
            this.labelDmdColor.Text = "DMD Color";
            // 
            // btnDmdColor
            // 
            this.btnDmdColor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDmdColor.Location = new System.Drawing.Point(428, 372);
            this.btnDmdColor.Name = "btnDmdColor";
            this.btnDmdColor.Size = new System.Drawing.Size(75, 23);
            this.btnDmdColor.TabIndex = 53;
            this.btnDmdColor.UseVisualStyleBackColor = false;
            this.btnDmdColor.Click += new System.EventHandler(this.btnDmdColor_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(249, 422);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(299, 109);
            this.textBox1.TabIndex = 54;
            this.textBox1.Text = "Notes: \r\n-1 in numeric fields means this value is not set in the registry\r\n\r\nFor " +
    "Checkboxes, with a black box, that also means it is not set in the registry.";
            // 
            // PinMameRomSettingEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 583);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnDmdColor);
            this.Controls.Add(this.labelDmdColor);
            this.Controls.Add(this.chkEnableSound);
            this.Controls.Add(this.chkUseSamples);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbSoundMode);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numericSampleRate);
            this.Controls.Add(this.chkCompactMode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.numericFastFrames);
            this.Controls.Add(this.chkDoubleDisplaySize);
            this.Controls.Add(this.chkResamplingQuality);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericSyncLevel);
            this.Controls.Add(this.chkFlipY);
            this.Controls.Add(this.chkFlipX);
            this.Controls.Add(this.chkRotateRight);
            this.Controls.Add(this.chkRotateLeft);
            this.Controls.Add(this.chkIgnoreRomCrcCheck);
            this.Controls.Add(this.chkCabinetMode);
            this.Controls.Add(this.chkColorize);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericIntensityPerc66);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericIntensityPerc33);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericIntensityPerc0);
            this.Controls.Add(this.numericOffsetY);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericOffsetX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericWidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericHeight);
            this.Controls.Add(this.chkExternalDmdDevice);
            this.Controls.Add(this.chkAt91Jit);
            this.Controls.Add(this.chkDirect3d);
            this.Controls.Add(this.chkShowVpinMameDmd);
            this.Controls.Add(this.chkDirectDraw);
            this.Controls.Add(this.chkScanLines);
            this.Controls.Add(this.chkTitle);
            this.Controls.Add(this.chkBorder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericOpacity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericAntiAliasPercentage);
            this.Controls.Add(this.chkSkipStartup);
            this.Controls.Add(this.chkEnableAntiAlias);
            this.Controls.Add(this.lblRomName);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(578, 622);
            this.Name = "PinMameRomSettingEditorForm";
            this.Text = "PinMAME ROM Setting Editor";
            ((System.ComponentModel.ISupportInitialize)(this.numericAntiAliasPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntensityPerc0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntensityPerc33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntensityPerc66)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSyncLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFastFrames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSampleRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRomName;
        private System.Windows.Forms.CheckBox chkEnableAntiAlias;
        private System.Windows.Forms.CheckBox chkSkipStartup;
        private System.Windows.Forms.NumericUpDown numericAntiAliasPercentage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericOpacity;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkBorder;
        private System.Windows.Forms.CheckBox chkTitle;
        private System.Windows.Forms.CheckBox chkScanLines;
        private System.Windows.Forms.CheckBox chkDirectDraw;
        private System.Windows.Forms.CheckBox chkShowVpinMameDmd;
        private System.Windows.Forms.CheckBox chkDirect3d;
        private System.Windows.Forms.CheckBox chkAt91Jit;
        private System.Windows.Forms.CheckBox chkExternalDmdDevice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericHeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericOffsetX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericOffsetY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericIntensityPerc0;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericIntensityPerc33;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericIntensityPerc66;
        private System.Windows.Forms.CheckBox chkColorize;
        private System.Windows.Forms.CheckBox chkCabinetMode;
        private System.Windows.Forms.CheckBox chkIgnoreRomCrcCheck;
        private System.Windows.Forms.CheckBox chkRotateLeft;
        private System.Windows.Forms.CheckBox chkRotateRight;
        private System.Windows.Forms.CheckBox chkFlipX;
        private System.Windows.Forms.CheckBox chkFlipY;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericSyncLevel;
        private System.Windows.Forms.CheckBox chkResamplingQuality;
        private System.Windows.Forms.CheckBox chkDoubleDisplaySize;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericFastFrames;
        private System.Windows.Forms.CheckBox chkCompactMode;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericSampleRate;
        private System.Windows.Forms.ComboBox cmbSoundMode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkUseSamples;
        private System.Windows.Forms.CheckBox chkEnableSound;
        private System.Windows.Forms.ColorDialog colorDialogDmdColor;
        private System.Windows.Forms.Label labelDmdColor;
        private System.Windows.Forms.Button btnDmdColor;
        private System.Windows.Forms.TextBox textBox1;
    }
}