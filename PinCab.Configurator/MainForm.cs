using Newtonsoft.Json;
using PinCab.Utils;
using PinCab.Configurator.Utils;
using Serilog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WindowsDisplayAPI;
using PinCab.Utils.Models;
using PinCab.Utils.Utils.PinballY;
using PinCab.Utils.Utils;

namespace PinCab.Configurator
{
    /// <summary>
    /// The main program form.
    /// This program relies on the WindowsDisplayApi nuget instead of Screens.AllScreens built in .NET Framework object as it gives much more details about
    /// screen layout. Additionally we can use it to dynamically display on the fly updated screen layouts, where as the Screens.AllScreens is only loaded ONCE when you start
    /// the application. At some point in the future I will put in a timer here that periodically repaints the screen layouts as they are being moved in windows so you can see the same
    /// screen layout you see in Windows on the fly.
    /// </summary>
    /// <remarks>
    /// 1/4/2020 - Initial creation
    /// </remarks>
    //https://stackoverflow.com/questions/5020559/screen-allscreen-is-not-giving-the-correct-monitor-count
    public partial class MainForm : Form
    {
        private List<DisplayDetail> _displayDetails { get; set; } = new List<DisplayDetail>();

        public ConcurrentDictionary<string, ScreenBoundsDisplayForm> ScreenBoundDisplayForms { get; set; } = new ConcurrentDictionary<string, ScreenBoundsDisplayForm>();

        private bool InProcessOfChangingRegions = false;
        private bool InProcessOfClearingFormFields = false;

        private ProgramSettings _settings;

        private FormHelper helper;

        public static bool ChangesOccurred = false;
        private int _currentlySelectedDisplayIndex = -1;
        private ProgramSettingsManager settingManager = new ProgramSettingsManager();

        public MainForm()
        {
            InitializeComponent();
            LoadDisplayDetails();

            //Load Default file settings data and update the Display Details
            UpdateDisplayDetailsFromSettingsFile();

            LoadScreenBoundsDisplayForms();
            DisplayDisplayDetails();

            helper = new FormHelper(_settings, _displayDetails, txtData, backgroundWorkerProgressBar);
            //var displays = new ScreenDetails().GetDisplays();
            //panelMonitorDrawing.Refresh();
            ValidateMonitorConfiguration();
        }

        private void UpdateDisplayDetailsFromSettingsFile()
        {
            _settings = settingManager.LoadSettings();
            if (_settings == null)
            {
                string msg = "Settings file not found. Creating brand new file.";
                Log.Information(msg);
                txtData.Text += msg + "\r\n";
                _settings = new ProgramSettings();
                settingManager.SaveSettings(_settings);
            }
            foreach (var display in _settings?.DisplaySettings)
            {
                var loadedDisplaySettingToUpdate = _displayDetails.GetByDisplayName(display.DisplayName);
                if (loadedDisplaySettingToUpdate != null)
                {
                    loadedDisplaySettingToUpdate.DisplayLabel = display.DisplayLabel;
                    loadedDisplaySettingToUpdate.RegionRectangles = display.RegionRectangles;
                }
                else
                {
                    Log.Information("Display: {display} not found. Unable to find settings file data to the display. You may need to manually edit the DisplaySettings.json file to re-number your displays or reboot windows if you just installed graphics driver updates to restore the original display numbers.", display.DisplayName);
                    txtData.Text += $"Display: {display.DisplayName} not found. Unable to find settings file data to the display. You may need to manually edit the DisplaySettings.json file to re-number your displays or reboot windows if you just installed graphics driver updates to restore the original display numbers.\r\n";
                }
            }
        }

        private void LoadScreenBoundsDisplayForms()
        {
            ScreenBoundDisplayForms.Clear();
            foreach (var display in _displayDetails)
            {
                var newForm = new ScreenBoundsDisplayForm(display, this);
                newForm.Owner = this;
                newForm.Hide();
                ScreenBoundDisplayForms.TryAdd(display.Display.DisplayName, newForm);
            }

        }

        private void LoadDisplayDetails()
        {
            _displayDetails.Clear();
            foreach (var display in Display.GetDisplays())
            {
                var screen = Screen.AllScreens.FirstOrDefault(p => p.DeviceName == display.DisplayName);
                var edidInfo = display.DevicePath.GetDisplayEdidData();
                _displayDetails.Add(new DisplayDetail() { Display = display, EdidInfo = edidInfo });
            }
        }

        private void DisplayDisplayDetails()
        {
            listBoxDisplays.Items.Clear();
            foreach (var display in _displayDetails)
            {
                listBoxDisplays.Items.Add(display);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generateFFMpegCommandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = _displayDetails.ValidateDisplayConfiguration();
            if (!result.IsValid)
            {
                txtData.Text += "Please correct your screen configuration first. Cannot output FFMPeg commands at this time.\r\n";
                return;
            }

            if (string.IsNullOrEmpty(_settings.FFMpegFullPath))
            {
                txtData.Text += "FFMpeg path not defined.\r\n";
                return;
            }

            if (string.IsNullOrEmpty(_settings.RecordingTempFolderPath))
            {
                txtData.Text += "Recording temp folder path not defined.\r\n";
                return;
            }

            var commands = _displayDetails.GetFfMpegCommandsForAllMonitors(_settings.RecordFramerate, new TimeSpan(0, 0, _settings.RecordTimeSeconds),
                _settings.RecordingTempFolderPath, _settings.FFMpegFullPath);
            txtData.Text += " FFMpeg Command: \r\n" + string.Join("\r\n\r\n", commands.ToArray());
        }

        private bool ValidateMonitorConfiguration()
        {
            var result = _displayDetails.ValidateDisplayConfiguration();

            helper.LogValidationResult("ValidateMonitorConfiguration", result);

            if (!result.IsValid)
                txtData.Text += "Screen configuration is INVALID.\r\n";
            else
                txtData.Text += "Screen configuration is VALID.\r\n";
            return result.IsValid;
        }

        private void ClearFormFields()
        {
            InProcessOfClearingFormFields = true;
            txtDisplayLabel.Text = string.Empty;
            cmbRegionColor.Text = string.Empty;
            cmbRegionLabel.Text = string.Empty;
            numericUpDownRegionHeight.Value = 0;
            numericUpDownRegionWidth.Value = 0;
            numericUpDownRegionXOffset.Value = 0;
            numericUpDownRegionYOffset.Value = 0;
            InProcessOfClearingFormFields = false;
        }

        private void listBoxDisplays_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFormFields();
            this.Refresh();
            var display = listBoxDisplays.SelectedItem as DisplayDetail;
            foreach (var hideForm in ScreenBoundDisplayForms)
            {
                hideForm.Value?.Hide();
            }

            _currentlySelectedDisplayIndex = listBoxDisplays.SelectedIndex;
            var form = ScreenBoundDisplayForms.FirstOrDefault(p => p.Key == display?.Display.DisplayName);
            form.Value?.Show();
            PopulateFormDisplayDetails();
        }

        private void PopulateFormDisplayDetails()
        {
            if (listBoxDisplays.SelectedItem != null)
            {
                var displayDetail = listBoxDisplays.SelectedItem as DisplayDetail;
                txtDisplayLabel.Text = displayDetail.DisplayLabel;
                listBoxDisplayRegions.Items.Clear();
                foreach (var region in displayDetail.RegionRectangles)
                {
                    listBoxDisplayRegions.Items.Add(region);
                }
                if (displayDetail.RegionRectangles.Count() > 0)
                    listBoxDisplayRegions.SelectedIndex = 0;
            }
        }

        private void panelMonitorDrawing_Paint(object sender, PaintEventArgs e)
        {
            DrawMonitorDepiction();
        }

        private void DrawMonitorDepiction()
        {
            //e.Graphics.Clear(this.BackColor);
            var graphics = panelMonitorDrawing.CreateGraphics();
            graphics.Clear(Color.Black);
            foreach (var display in _displayDetails)
            {
                var pen = new Pen(Color.Red, 2);
                int screenRectangleX = (display.Display.GetScreen().Bounds.X / 10) + 5;
                int screenRectangleY = (display.Display.GetScreen().Bounds.Y / 10) + 5;
                int screenWidth = display.Display.GetScreen().Bounds.Width / 10;
                int screenHeight = display.Display.GetScreen().Bounds.Height / 10;
                //0,0 because it's in the context of the form that is already moved to the proper screen
                var rectangle = new Rectangle(screenRectangleX, screenRectangleY, screenWidth, screenHeight);
                //var rectangle = new Rectangle(2200, 0, 500, 500);
                graphics.DrawRectangle(pen, rectangle);

                Font drawFont = new Font("Arial", 10, FontStyle.Bold);
                SolidBrush drawBrush = new SolidBrush(Color.Red);
                string resolution = display.Display.CurrentSetting.Resolution.Width.ToString() + "x" + display.Display.CurrentSetting.Resolution.Height.ToString();
                string offset = "X=" + display.Display.CurrentSetting.Position.X.ToString() + ", Y=" + display.Display.CurrentSetting.Position.Y.ToString();
                graphics.DrawString(display.DisplayLabel + "\r\n" + resolution + "\r\n" + offset, drawFont, drawBrush,
                    (display.Display.GetScreen().Bounds.X / 10) + 7, (display.Display.GetScreen().Bounds.Y) + 7); //2 is the rectangle line width, so move it inside of that

                //Draw the visible screen area for this screen (meaning it isn't going to display full screen, instead it will be bound by a box)
                //This is typically for LCD DMD folks, who are using a large screen, but only showing a portion of the screen in the backbox
                foreach (var region in display.RegionRectangles)
                {
                    if (region.RegionOffsetX != 0 || region.RegionOffsetY != 0 || region.RegionDisplayHeight != 0 || region.RegionDisplayWidth != 0)
                    {
                        var pen2 = new Pen(region.RegionColor, 2);
                        //We offset the rectangle here based off of what screen we are now on (this takes into account the "virtual desktop space" in windows) when
                        //you arrange your monitors in display settings
                        var rectangle2 = new Rectangle(screenRectangleX + (region.RegionOffsetX / 10), screenRectangleY + (region.RegionOffsetY / 10),
                            (region.RegionDisplayWidth / 10), (region.RegionDisplayHeight / 10));
                        graphics.DrawRectangle(pen2, rectangle2);
                    }
                }
            }
        }

        private void refreshDisplayDepictionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrawMonitorDepiction();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutBoxForm();
            about.Show();
        }


        private void Serializer_Error(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs e)
        {
            e.ErrorContext.Handled = true;
        }

        private void btnAddRegionToDisplay_Click(object sender, EventArgs e)
        {
            if (cmbRegionLabel.SelectedItem == null)
            {
                MessageBox.Show("You must give this region a label");
                return;
            }
            if (cmbRegionColor.SelectedItem == null)
            {
                MessageBox.Show("Please select a color");
                return;
            }

            //See if this region already exists, if so update it
            var displayDetail = listBoxDisplays.SelectedItem as DisplayDetail;
            var regionRectangleEditing = displayDetail.RegionRectangles.FirstOrDefault(p => p.RegionLabel == cmbRegionLabel.Text);
            if (regionRectangleEditing != null)
            {
                regionRectangleEditing.RegionDisplayHeight = Convert.ToInt32(numericUpDownRegionHeight.Value);
                regionRectangleEditing.RegionDisplayWidth = Convert.ToInt32(numericUpDownRegionWidth.Value);
                regionRectangleEditing.RegionOffsetX = Convert.ToInt32(numericUpDownRegionXOffset.Value);
                regionRectangleEditing.RegionOffsetY = Convert.ToInt32(numericUpDownRegionYOffset.Value);
                regionRectangleEditing.RegionLabel = cmbRegionLabel.Text;
                regionRectangleEditing.RegionColor = Color.FromName(cmbRegionColor.Text);
            }
            else
            {
                var region = new RegionRectangle();
                region.RegionDisplayHeight = Convert.ToInt32(numericUpDownRegionHeight.Value);
                region.RegionDisplayWidth = Convert.ToInt32(numericUpDownRegionWidth.Value);
                region.RegionOffsetX = Convert.ToInt32(numericUpDownRegionXOffset.Value);
                region.RegionOffsetY = Convert.ToInt32(numericUpDownRegionYOffset.Value);
                region.RegionLabel = cmbRegionLabel.Text;
                region.RegionColor = Color.FromName(cmbRegionColor.Text);
                displayDetail.RegionRectangles.Add(region);
                listBoxDisplayRegions.Items.Add(region);
            }

            int currentSelectedIndex = listBoxDisplayRegions.SelectedIndex;
            listBoxDisplayRegions.Items.Clear();
            foreach (var region in displayDetail.RegionRectangles)
            {
                listBoxDisplayRegions.Items.Add(region);
            }
            if (listBoxDisplayRegions.Items.Count > 0)
                listBoxDisplayRegions.SelectedIndex = currentSelectedIndex;
            else
                listBoxDisplayRegions.SelectedIndex = -1;

            MainForm.ChangesOccurred = true;
            RefreshDisplayOnRegionUpdate();
        }

        private void listBoxDisplayRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDisplayRegions.SelectedItem != null)
            {
                var regionRectangle = listBoxDisplayRegions.SelectedItem as RegionRectangle;

                InProcessOfChangingRegions = true;

                numericUpDownRegionHeight.Value = regionRectangle.RegionDisplayHeight;
                numericUpDownRegionWidth.Value = regionRectangle.RegionDisplayWidth;
                numericUpDownRegionXOffset.Value = regionRectangle.RegionOffsetX;
                numericUpDownRegionYOffset.Value = regionRectangle.RegionOffsetY;
                cmbRegionLabel.Text = regionRectangle.RegionLabel;
                cmbRegionColor.Text = regionRectangle.RegionColor.Name;
                InProcessOfChangingRegions = false;
            }
        }

        private void listBoxDisplayRegions_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var display = listBoxDisplays.SelectedItem as DisplayDetail;
                var region = listBoxDisplayRegions.SelectedItem as RegionRectangle;
                display.RegionRectangles.Remove(region);
                listBoxDisplayRegions.Items.RemoveAt(listBoxDisplayRegions.SelectedIndex);
            }
        }

        private void btnSaveDisplayConfig_Click(object sender, EventArgs e)
        {
            SaveDisplayConfig();
        }

        private void SaveDisplayConfig()
        {
            MainForm.ChangesOccurred = true;
            int currentSelectedIndex = listBoxDisplays.SelectedIndex;
            //int currentSelectedRegion = listBoxDisplayRegions.SelectedIndex;
            if (listBoxDisplays.SelectedIndex >= 0)
            {
                var listItem = listBoxDisplays.SelectedItem as DisplayDetail;
                listItem.DisplayLabel = txtDisplayLabel.Text;
                listItem.RegionRectangles.Clear();
                foreach (var regionListItem in listBoxDisplayRegions.Items)
                {
                    var region = regionListItem as RegionRectangle;
                    listItem.RegionRectangles.Add(region);
                }

                DisplayDisplayDetails();
                listBoxDisplays.SelectedIndex = currentSelectedIndex;
                //listBoxDisplayRegions.SelectedIndex = currentSelectedRegion;
            }
            else
            {
                MessageBox.Show("Please select a display");
            }
        }

        private void SaveSettings()
        {
            _settings.DisplaySettings = new List<DisplaySettings>();
            foreach (var display in _displayDetails)
            {
                _settings.DisplaySettings.Add(new DisplaySettings()
                {
                    DisplayLabel = display.DisplayLabel,
                    DisplayName = display.Display.DisplayName,
                    RegionRectangles = display.RegionRectangles
                });
            }

            Log.Information("Saved Settings. {@settings}", _settings);
            settingManager.SaveSettings(_settings);
        }

        private void saveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                _settings = settingManager.LoadSettings();
            }
        }

        private void loadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _settings = settingManager.LoadSettings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ChangesOccurred)
            {
                var response = MessageBox.Show("Do you want to save your settings?", "Save Settings?", MessageBoxButtons.YesNo);
                if (response == DialogResult.Yes)
                {
                    SaveSettings();
                }
            }

            Log.Information("Application Ending... Good Bye!");
            Log.CloseAndFlush();
        }

        private void monitorConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            ValidateMonitorConfiguration();
        }

        private void dumpDisplayInfoToFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            using (SaveFileDialog fileDialog = new SaveFileDialog())
            {
                fileDialog.Filter = "JSON Files|*.json|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = Environment.MachineName + "_DisplayDetails.json";
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = fileDialog.FileName;

                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    serializer.NullValueHandling = NullValueHandling.Ignore;
                    serializer.Formatting = Formatting.Indented;
                    serializer.Error += Serializer_Error; //Ignore errors
                    using (StreamWriter sw = new StreamWriter(filePath, false))
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, _displayDetails);
                    }
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xantari/PinCab.Configurator/wiki");
        }

        private void dumpHighLevelDisplayInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var display in _displayDetails)
            {
                txtData.Text += display.ToString() + ":\r\n";
                txtData.Text += $"  Resolution: {display.Display.CurrentSetting.Resolution.Width}x{display.Display.CurrentSetting.Resolution.Height}\r\n";
                txtData.Text += $"  Virtual Resolution Offsets: X:{display.Display.CurrentSetting.Position.X} Y:{display.Display.CurrentSetting.Position.Y}\r\n";
                txtData.Text += $"  Virtual Resolution:{display.VirtualResolutionWidth()} Y:{display.VirtualResolutionHeight()}\r\n";

                if (display.RegionRectangles.Count() > 0)
                    txtData.Text += "  Region Rectangles Defined:\r\n";
                foreach (var region in display.RegionRectangles)
                {
                    txtData.Text += "    " + region.ToString() + ":\r\n";
                    txtData.Text += $"      Region Virtual Offsets (Upper left hand corner of rectangle) X: {display.VirtualResolutionOffsetX(region)} Y: {display.VirtualResolutionOffsetY(region)}\r\n";
                    txtData.Text += $"      Region Virtual Resolution: {region.RegionDisplayWidth}x{region.RegionDisplayHeight}\r\n";
                    txtData.Text += $"      Region Virtual Offets (Lower right hand corner of rectangle) X: {display.VirtualResolutionOffsetXLowerRightCorner(region)} Y: {display.VirtualResolutionOffsetYLowerRightCorner(region)}\r\n";
                }
            }
        }

        private void RefreshDisplayOnRegionUpdate()
        {
            var displayDetail = listBoxDisplays.SelectedItem as DisplayDetail;
            if (displayDetail != null)// && listBoxDisplayRegions.SelectedIndex >= 0)
            {
                var form = ScreenBoundDisplayForms.FirstOrDefault(p => p.Key == displayDetail.Display.DisplayName);
                form.Value?.Refresh();
                DrawMonitorDepiction();
            }
        }

        private void numericUpDownRegionXOffset_ValueChanged(object sender, EventArgs e)
        {
            if (!InProcessOfChangingRegions && !InProcessOfClearingFormFields)
            {
                var displayDetail = listBoxDisplays.SelectedItem as DisplayDetail;
                var regionRectangleEditing = displayDetail.RegionRectangles.FirstOrDefault(p => p.RegionLabel == cmbRegionLabel.Text);
                if (regionRectangleEditing != null)
                {
                    regionRectangleEditing.RegionOffsetX = Convert.ToInt32(numericUpDownRegionXOffset.Value);
                }
                RefreshDisplayOnRegionUpdate();
            }
        }

        private void numericUpDownRegionYOffset_ValueChanged(object sender, EventArgs e)
        {
            if (!InProcessOfChangingRegions && !InProcessOfClearingFormFields)
            {
                var displayDetail = listBoxDisplays.SelectedItem as DisplayDetail;
                var regionRectangleEditing = displayDetail.RegionRectangles.FirstOrDefault(p => p.RegionLabel == cmbRegionLabel.Text);
                if (regionRectangleEditing != null)
                {
                    regionRectangleEditing.RegionOffsetY = Convert.ToInt32(numericUpDownRegionYOffset.Value);
                }
                RefreshDisplayOnRegionUpdate();
            }
        }

        private void numericUpDownRegionWidth_ValueChanged(object sender, EventArgs e)
        {
            if (!InProcessOfChangingRegions && !InProcessOfClearingFormFields)
            {
                var displayDetail = listBoxDisplays.SelectedItem as DisplayDetail;
                var regionRectangleEditing = displayDetail.RegionRectangles.FirstOrDefault(p => p.RegionLabel == cmbRegionLabel.Text);
                if (regionRectangleEditing != null)
                {
                    regionRectangleEditing.RegionDisplayWidth = Convert.ToInt32(numericUpDownRegionWidth.Value);
                }
                RefreshDisplayOnRegionUpdate();
            }
        }

        private void numericUpDownRegionHeight_ValueChanged(object sender, EventArgs e)
        {
            if (!InProcessOfChangingRegions && !InProcessOfClearingFormFields)
            {
                var displayDetail = listBoxDisplays.SelectedItem as DisplayDetail;
                var regionRectangleEditing = displayDetail.RegionRectangles.FirstOrDefault(p => p.RegionLabel == cmbRegionLabel.Text);
                if (regionRectangleEditing != null)
                {
                    regionRectangleEditing.RegionDisplayHeight = Convert.ToInt32(numericUpDownRegionHeight.Value);
                }
                RefreshDisplayOnRegionUpdate();
            }
        }

        private void cmbRegionLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!InProcessOfChangingRegions && !InProcessOfClearingFormFields)
            {
                RefreshDisplayOnRegionUpdate();
            }
        }

        private void cmbRegionColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!InProcessOfChangingRegions && !InProcessOfClearingFormFields)
            {
                RefreshDisplayOnRegionUpdate();
            }
        }

        private void writePinballXiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.WritePinballXSettings();
        }

        private void validatePinballXiniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.ValidatePinballX();
        }

        private void validatefutureDMDiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.ValidateFutureDmd();
        }

        private void writeFutureDMDiniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.WriteFutureDMDSettings();
        }

        private void validateb2SScreenrestxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.ValidateB2sSettings();
        }

        private void writeB2sSettingsScreenrestxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.WriteB2sSettings();
        }

        private void validateallSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            //TODO: Fill this in
            MessageBox.Show("Not implemented yet.");
        }

        private void b2SScreenresEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ScreenResEditorForm();
            var result = form.ShowDialog();
        }

        private void validateultraDMDRegistryKeyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.ValidateUltraDmdSettings();
        }

        private void writeUltraDMDRegistryKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.WriteUltraDmdSettings();
        }

        private void writeDmdDeviceiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.WriteDmdDeviceIniSettings();
        }

        private void validateDmdDeviceiniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.ValidateDmdDeviceIniSettings();
        }

        private void validatetoolStripMenuItemValidateVPinMameDefaultRegistryKey_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.ValidateVpinMameDefaultKey();
        }

        private void writevPinMameDefaultRegistryKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.WriteVpinMameDefaultKey();
        }
        private void validateToolStripMenuItemValidateVPinMameAllRomsRegistryKeys_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            var msg = "Beginning pinmame ROM validation. Please wait....\r\n";
            Log.Information(msg);
            txtData.Text += msg;
            helper.ValidateVpinMameRomKeys();
        }
        private void writevPinMameUpdateAllROMsRegistryKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            var msg = "Beginning pinmame ROM DMD region writes. Please wait....\r\n";
            Log.Information(msg);
            txtData.Text += msg;
            helper.WriteVpinMameRomKeys();
        }

        private void backgroundWorkerProgressBar_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            //lblProgressText.Text = e.ProgressPercentage.ToString() + "%";
        }

        private void backgroundWorkerProgressBar_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 0;
            //lblProgressText.Text = string.Empty;
            var result = e.Result as ToolValidationResult;
            if (result.OutputValidationMessages)
            {
                if (result.MessageType == ValidationMessageType.ToolMessage)
                    helper.LogToolValidationResult(result.ToolName, result);
                else
                    helper.LogValidationResult(result.ToolName, result);
            }
        }

        private void pinMameROMBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PinMameRomBrowserForm();
            var result = form.ShowDialog();
        }

        private void validatepinupPlayerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.ValidatePinupPlayerSettings();
        }

        private void writepinupPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.WritePinupPlayerSettings();
        }

        private void writeAllSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemented yet");
        }

        private void pinballFX2FX3DisplayOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.WritePinballFxSettings();
        }

        private void validatepinballYSettingstxtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.ValidatePinballYSettings();
        }

        private void writepinballYSettingstxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.WritePinballYSettings();
        }

        private void validatepROCSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.WritePRocSettings();
        }

        private void writepRocSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helper.ClearMessages();
            helper.WritePRocSettings();
        }

        private void gameManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new GameManagerForm();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                _settings = settingManager.LoadSettings();
            }
        }

        private void listBoxDisplays_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBoxDisplays.SelectedIndex == _currentlySelectedDisplayIndex) //if they marked the same one, keep the display hidden so they can toggle it on/off
            {
                _currentlySelectedDisplayIndex = -1;
                listBoxDisplays.SelectedIndex = -1;
            }
        }

        private void databaseManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DatabaseBrowserForm();
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                _settings = settingManager.LoadSettings();
            }
        }
    }
}
