namespace PinCabScreenConfigurator
{
    partial class MainForm
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
            this.listBoxDisplays = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveDisplayLabel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateFFMpegCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshDisplayDepictionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateMonitorConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputScreenrestxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputFutureDMDiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setUltraDMDRegistryKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPinballXiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputDMDDeviceiniDMDExtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpDisplayInfoToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTextInfo = new System.Windows.Forms.Panel();
            this.txtData = new System.Windows.Forms.TextBox();
            this.panelMonitorDrawing = new System.Windows.Forms.Panel();
            this.cmbDisplayLabel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVisibleWindowXOffset = new System.Windows.Forms.TextBox();
            this.txtVisibleWindowYOffset = new System.Windows.Forms.TextBox();
            this.txtVisibleWindowWidth = new System.Windows.Forms.TextBox();
            this.txtVisibleWindowHeight = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.pnlTextInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Displays:";
            // 
            // listBoxDisplays
            // 
            this.listBoxDisplays.FormattingEnabled = true;
            this.listBoxDisplays.Location = new System.Drawing.Point(92, 27);
            this.listBoxDisplays.Name = "listBoxDisplays";
            this.listBoxDisplays.Size = new System.Drawing.Size(1018, 56);
            this.listBoxDisplays.TabIndex = 1;
            this.listBoxDisplays.SelectedIndexChanged += new System.EventHandler(this.listBoxDisplays_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Display Label:";
            // 
            // btnSaveDisplayLabel
            // 
            this.btnSaveDisplayLabel.Location = new System.Drawing.Point(494, 146);
            this.btnSaveDisplayLabel.Name = "btnSaveDisplayLabel";
            this.btnSaveDisplayLabel.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDisplayLabel.TabIndex = 4;
            this.btnSaveDisplayLabel.Text = "Save";
            this.btnSaveDisplayLabel.UseVisualStyleBackColor = true;
            this.btnSaveDisplayLabel.Click += new System.EventHandler(this.btnSaveDisplayLabel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.commandsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(719, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveConfigurationToolStripMenuItem,
            this.loadConfigurationToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveConfigurationToolStripMenuItem
            // 
            this.saveConfigurationToolStripMenuItem.Name = "saveConfigurationToolStripMenuItem";
            this.saveConfigurationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.saveConfigurationToolStripMenuItem.Text = "Save Configuration";
            // 
            // loadConfigurationToolStripMenuItem
            // 
            this.loadConfigurationToolStripMenuItem.Name = "loadConfigurationToolStripMenuItem";
            this.loadConfigurationToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.loadConfigurationToolStripMenuItem.Text = "Load Configuration";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateFFMpegCommandsToolStripMenuItem,
            this.refreshDisplayDepictionToolStripMenuItem,
            this.validateMonitorConfigurationToolStripMenuItem,
            this.outputScreenrestxtToolStripMenuItem,
            this.outputFutureDMDiniToolStripMenuItem,
            this.setUltraDMDRegistryKeyToolStripMenuItem,
            this.setPinballXiniToolStripMenuItem,
            this.outputDMDDeviceiniDMDExtToolStripMenuItem,
            this.dumpDisplayInfoToFileToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.commandsToolStripMenuItem.Text = "Commands";
            // 
            // generateFFMpegCommandsToolStripMenuItem
            // 
            this.generateFFMpegCommandsToolStripMenuItem.Name = "generateFFMpegCommandsToolStripMenuItem";
            this.generateFFMpegCommandsToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.generateFFMpegCommandsToolStripMenuItem.Text = "Generate FFMpeg Commands";
            this.generateFFMpegCommandsToolStripMenuItem.Click += new System.EventHandler(this.generateFFMpegCommandsToolStripMenuItem_Click);
            // 
            // refreshDisplayDepictionToolStripMenuItem
            // 
            this.refreshDisplayDepictionToolStripMenuItem.Name = "refreshDisplayDepictionToolStripMenuItem";
            this.refreshDisplayDepictionToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.refreshDisplayDepictionToolStripMenuItem.Text = "Refresh Display Depiction";
            this.refreshDisplayDepictionToolStripMenuItem.Click += new System.EventHandler(this.refreshDisplayDepictionToolStripMenuItem_Click);
            // 
            // validateMonitorConfigurationToolStripMenuItem
            // 
            this.validateMonitorConfigurationToolStripMenuItem.Name = "validateMonitorConfigurationToolStripMenuItem";
            this.validateMonitorConfigurationToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.validateMonitorConfigurationToolStripMenuItem.Text = "Validate Monitor Configuration";
            this.validateMonitorConfigurationToolStripMenuItem.Click += new System.EventHandler(this.validateMonitorConfigurationToolStripMenuItem_Click);
            // 
            // outputScreenrestxtToolStripMenuItem
            // 
            this.outputScreenrestxtToolStripMenuItem.Name = "outputScreenrestxtToolStripMenuItem";
            this.outputScreenrestxtToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.outputScreenrestxtToolStripMenuItem.Text = "Output Screenres.txt (B2S settings)";
            this.outputScreenrestxtToolStripMenuItem.Click += new System.EventHandler(this.outputScreenrestxtToolStripMenuItem_Click);
            // 
            // outputFutureDMDiniToolStripMenuItem
            // 
            this.outputFutureDMDiniToolStripMenuItem.Name = "outputFutureDMDiniToolStripMenuItem";
            this.outputFutureDMDiniToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.outputFutureDMDiniToolStripMenuItem.Text = "Output FutureDMD.ini";
            this.outputFutureDMDiniToolStripMenuItem.Click += new System.EventHandler(this.outputFutureDMDiniToolStripMenuItem_Click);
            // 
            // setUltraDMDRegistryKeyToolStripMenuItem
            // 
            this.setUltraDMDRegistryKeyToolStripMenuItem.Name = "setUltraDMDRegistryKeyToolStripMenuItem";
            this.setUltraDMDRegistryKeyToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.setUltraDMDRegistryKeyToolStripMenuItem.Text = "Set UltraDMD Registry Key";
            this.setUltraDMDRegistryKeyToolStripMenuItem.Click += new System.EventHandler(this.setUltraDMDRegistryKeyToolStripMenuItem_Click);
            // 
            // setPinballXiniToolStripMenuItem
            // 
            this.setPinballXiniToolStripMenuItem.Name = "setPinballXiniToolStripMenuItem";
            this.setPinballXiniToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.setPinballXiniToolStripMenuItem.Text = "Set PinballX.ini";
            this.setPinballXiniToolStripMenuItem.Click += new System.EventHandler(this.setPinballXiniToolStripMenuItem_Click);
            // 
            // outputDMDDeviceiniDMDExtToolStripMenuItem
            // 
            this.outputDMDDeviceiniDMDExtToolStripMenuItem.Name = "outputDMDDeviceiniDMDExtToolStripMenuItem";
            this.outputDMDDeviceiniDMDExtToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.outputDMDDeviceiniDMDExtToolStripMenuItem.Text = "Output DMDDevice.ini (DMDExt / VPinMAME)";
            this.outputDMDDeviceiniDMDExtToolStripMenuItem.Click += new System.EventHandler(this.outputDMDDeviceiniDMDExtToolStripMenuItem_Click);
            // 
            // dumpDisplayInfoToFileToolStripMenuItem
            // 
            this.dumpDisplayInfoToFileToolStripMenuItem.Name = "dumpDisplayInfoToFileToolStripMenuItem";
            this.dumpDisplayInfoToFileToolStripMenuItem.Size = new System.Drawing.Size(318, 22);
            this.dumpDisplayInfoToFileToolStripMenuItem.Text = "Dump Display Info to File";
            this.dumpDisplayInfoToFileToolStripMenuItem.Click += new System.EventHandler(this.dumpDisplayInfoToFileToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pnlTextInfo
            // 
            this.pnlTextInfo.Controls.Add(this.txtData);
            this.pnlTextInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTextInfo.Location = new System.Drawing.Point(0, 423);
            this.pnlTextInfo.Name = "pnlTextInfo";
            this.pnlTextInfo.Size = new System.Drawing.Size(719, 159);
            this.pnlTextInfo.TabIndex = 6;
            // 
            // txtData
            // 
            this.txtData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtData.Location = new System.Drawing.Point(0, 0);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(719, 159);
            this.txtData.TabIndex = 0;
            // 
            // panelMonitorDrawing
            // 
            this.panelMonitorDrawing.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMonitorDrawing.Location = new System.Drawing.Point(0, 175);
            this.panelMonitorDrawing.Name = "panelMonitorDrawing";
            this.panelMonitorDrawing.Size = new System.Drawing.Size(719, 248);
            this.panelMonitorDrawing.TabIndex = 7;
            this.panelMonitorDrawing.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMonitorDrawing_Paint);
            // 
            // cmbDisplayLabel
            // 
            this.cmbDisplayLabel.FormattingEnabled = true;
            this.cmbDisplayLabel.Items.AddRange(new object[] {
            "Playfield",
            "DMD",
            "Backglass",
            "Topper",
            "Apron",
            "Backglass & DMD",
            "Topper & DMD"});
            this.cmbDisplayLabel.Location = new System.Drawing.Point(91, 93);
            this.cmbDisplayLabel.Name = "cmbDisplayLabel";
            this.cmbDisplayLabel.Size = new System.Drawing.Size(244, 21);
            this.cmbDisplayLabel.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Visible Window X Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Visible Window Y Offset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(269, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Visible Window Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Visible Window Height";
            // 
            // txtVisibleWindowXOffset
            // 
            this.txtVisibleWindowXOffset.Location = new System.Drawing.Point(139, 121);
            this.txtVisibleWindowXOffset.Name = "txtVisibleWindowXOffset";
            this.txtVisibleWindowXOffset.Size = new System.Drawing.Size(100, 20);
            this.txtVisibleWindowXOffset.TabIndex = 13;
            // 
            // txtVisibleWindowYOffset
            // 
            this.txtVisibleWindowYOffset.Location = new System.Drawing.Point(138, 143);
            this.txtVisibleWindowYOffset.Name = "txtVisibleWindowYOffset";
            this.txtVisibleWindowYOffset.Size = new System.Drawing.Size(100, 20);
            this.txtVisibleWindowYOffset.TabIndex = 14;
            // 
            // txtVisibleWindowWidth
            // 
            this.txtVisibleWindowWidth.Location = new System.Drawing.Point(385, 124);
            this.txtVisibleWindowWidth.Name = "txtVisibleWindowWidth";
            this.txtVisibleWindowWidth.Size = new System.Drawing.Size(100, 20);
            this.txtVisibleWindowWidth.TabIndex = 15;
            // 
            // txtVisibleWindowHeight
            // 
            this.txtVisibleWindowHeight.Location = new System.Drawing.Point(388, 146);
            this.txtVisibleWindowHeight.Name = "txtVisibleWindowHeight";
            this.txtVisibleWindowHeight.Size = new System.Drawing.Size(100, 20);
            this.txtVisibleWindowHeight.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 582);
            this.Controls.Add(this.txtVisibleWindowHeight);
            this.Controls.Add(this.txtVisibleWindowWidth);
            this.Controls.Add(this.txtVisibleWindowYOffset);
            this.Controls.Add(this.txtVisibleWindowXOffset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDisplayLabel);
            this.Controls.Add(this.panelMonitorDrawing);
            this.Controls.Add(this.pnlTextInfo);
            this.Controls.Add(this.btnSaveDisplayLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxDisplays);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Pincab Screen Configurator";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlTextInfo.ResumeLayout(false);
            this.pnlTextInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxDisplays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveDisplayLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateFFMpegCommandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshDisplayDepictionToolStripMenuItem;
        private System.Windows.Forms.Panel pnlTextInfo;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Panel panelMonitorDrawing;
        private System.Windows.Forms.ToolStripMenuItem validateMonitorConfigurationToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbDisplayLabel;
        private System.Windows.Forms.ToolStripMenuItem outputScreenrestxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputFutureDMDiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setUltraDMDRegistryKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPinballXiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputDMDDeviceiniDMDExtToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVisibleWindowXOffset;
        private System.Windows.Forms.TextBox txtVisibleWindowYOffset;
        private System.Windows.Forms.TextBox txtVisibleWindowWidth;
        private System.Windows.Forms.TextBox txtVisibleWindowHeight;
        private System.Windows.Forms.ToolStripMenuItem saveConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpDisplayInfoToFileToolStripMenuItem;
    }
}

