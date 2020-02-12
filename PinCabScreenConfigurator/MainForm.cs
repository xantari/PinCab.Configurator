using EDIDParser;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pincab.ScreenUtil;
using Pincab.ScreenUtil.Models;
using Pincab.ScreenUtil.Utils;
using PinCabScreenConfigurator.Utils;
using Serilog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsDisplayAPI;

namespace PinCabScreenConfigurator
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

        public MainForm()
        {
            InitializeComponent();
            LoadDisplayDetails();

            //Load Default file settings data and update the Display Details
            UpdateDisplayDetailsFromSettingsFile();

            LoadScreenBoundsDisplayForms();
            DisplayDisplayDetails();
            //var displays = new ScreenDetails().GetDisplays();
            //panelMonitorDrawing.Refresh();
            ValidateMonitorConfiguration();
        }

        private void UpdateDisplayDetailsFromSettingsFile()
        {
            ProgramSettings settings = new ProgramSettings();
            _settings = settings.LoadSettings();
            if (_settings != null)
            {
                foreach (var display in _settings?.DisplaySettings)
                {
                    var loadedDisplaySettingToUpdate = _displayDetails.GetByDisplayName(display.DisplayName);
                    loadedDisplaySettingToUpdate.DisplayLabel = display.DisplayLabel;
                    loadedDisplaySettingToUpdate.RegionRectangles = display.RegionRectangles;

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
            bool isValid = ValidateMonitorConfiguration(false);
            if (!isValid)
            {
                txtData.Text += "Please correct your screen configuration first. Cannot output FFMPeg commands at this time.\r\n";
                return;
            }

            var commands = _displayDetails.GetFfMpegCommandsForAllMonitors(30, new TimeSpan(0, 0, 30));
            txtData.Text += " FFMpeg Command: \r\n" + string.Join("\r\n\r\n", commands.ToArray());
        }

        private bool ValidateMonitorConfiguration(bool writeLog = true)
        {
            bool isValid = true;
            //Ensure no monitors have negative coordinates (always left to right)
            foreach (var display in _displayDetails)
            {
                if (display.Display.CurrentSetting.Position.X < 0 || display.Display.CurrentSetting.Position.Y < 0)
                {
                    if (writeLog)
                        txtData.Text += $"Invalid monitor configuration detected due to negative position values. Virtual Pinball programs require all monitors to have positive position values. Monitor: {display.ToString()} {display.Display.CurrentSetting.Position.ToString()}\r\n";
                    isValid = false;
                }
                var scalingFactor = display.GetScalingFactor();
                if (scalingFactor != 1.0f)
                {
                    if (writeLog)
                        txtData.Text += $"Scaling factor not set to 100%. Change your DPI settings to be 100%. Current Scaling: {(scalingFactor * 100)}%. Monitor: {display.ToString()} {display.Display.CurrentSetting.Position.ToString()}\r\n";
                    isValid = false;
                }
            }
            if (!_displayDetails.Any(p => p.DisplayLabel != null && p.DisplayLabel.ToLower().Contains("playfield")))
            {
                if (writeLog)
                    txtData.Text += "No Playfield Monitor selected yet. Please select a playfield monitor and give it a label of Playfield.\r\n";
                isValid = false;
            }
            var playfieldDisplay = _displayDetails.FirstOrDefault(p => p.DisplayLabel != null && p.DisplayLabel.ToLower().Contains("playfield"));
            if (playfieldDisplay != null && !playfieldDisplay.Display.IsGDIPrimary)
            {
                if (writeLog)
                    txtData.Text += "Your playfield display must be monitor 1 and marked as the primary monitor.\r\n";
                isValid = false;
            }
            //Check if DMD is recommended 4:1 ratio
            var dmdDisplay = _displayDetails.FirstOrDefault(p => p.DisplayLabel.Contains("DMD"));
            var regionDmdRectangle = dmdDisplay?.RegionRectangles?.FirstOrDefault(p => p.RegionLabel.Contains("DMD"));
            if (regionDmdRectangle == null)
            {
                if (writeLog)
                    txtData.Text += "Unable to locate DMD monitor. Have you specified it yet?\r\n";
                isValid = false;
            }
            else
            {
                if (regionDmdRectangle.RegionDisplayHeight == 0 || regionDmdRectangle.RegionDisplayWidth == 0)
                {
                    if (writeLog)
                        txtData.Text += "DMD Region incomplete. Width or Height is specified as 0.\r\n";
                    isValid = false;
                }
                else
                {
                    if ((regionDmdRectangle.RegionDisplayHeight / Convert.ToDecimal(regionDmdRectangle.RegionDisplayWidth)) != 0.4M) //Not a 4:1 ratio
                    {
                        if (writeLog)
                            txtData.Text += "WARNING: DMD Region is not recommended 4:1 ratio.\r\n";
                        // isValid = true;
                    }
                }
            }


            if (!isValid)
            {
                if (writeLog)
                    txtData.Text += "Screen configuration is INVALID.\r\n";
            }
            else
            {
                if (writeLog)
                    txtData.Text += "Screen configuration is VALID.\r\n";
            }
            return isValid;
        }

        private void ClearFormFields()
        {
            InProcessOfClearingFormFields = true;
            cmbDisplayLabel.Text = string.Empty;
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
            var form = ScreenBoundDisplayForms.FirstOrDefault(p => p.Key == display.Display.DisplayName);
            form.Value?.Show();
            PopulateFormDisplayDetails();
        }

        private void PopulateFormDisplayDetails()
        {
            if (listBoxDisplays.SelectedItem != null)
            {
                var displayDetail = listBoxDisplays.SelectedItem as DisplayDetail;
                cmbDisplayLabel.Text = displayDetail.DisplayLabel;
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
            var region = new RegionRectangle();
            region.RegionDisplayHeight = Convert.ToInt32(numericUpDownRegionHeight.Value);
            region.RegionDisplayWidth = Convert.ToInt32(numericUpDownRegionWidth.Value);
            region.RegionOffsetX = Convert.ToInt32(numericUpDownRegionXOffset.Value);
            region.RegionOffsetY = Convert.ToInt32(numericUpDownRegionYOffset.Value);
            region.RegionLabel = cmbRegionLabel.Text;
            region.RegionColor = Color.FromName(cmbRegionColor.Text);
            listBoxDisplayRegions.Items.Add(region);
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
            int currentSelectedIndex = listBoxDisplays.SelectedIndex;
            //int currentSelectedRegion = listBoxDisplayRegions.SelectedIndex;
            if (listBoxDisplays.SelectedIndex >= 0)
            {
                var listItem = listBoxDisplays.SelectedItem as DisplayDetail;
                listItem.DisplayLabel = cmbDisplayLabel.Text;
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
            _settings.SaveSettings();
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
                _settings = (new ProgramSettings()).LoadSettings();
            }
        }

        private void loadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramSettings setting = new ProgramSettings();
            _settings = setting.LoadSettings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var response = MessageBox.Show("Do you want to save your settings?", "Save Settings?", MessageBoxButtons.YesNo);
            if (response == DialogResult.Yes)
            {
                SaveSettings();
            }
            Log.Information("Application Ending... Good Bye!");
            Log.CloseAndFlush();
        }

        private void monitorConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateMonitorConfiguration();
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
            //TODO: Launch the help page (index.html)
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
            if (displayDetail != null && listBoxDisplayRegions.SelectedIndex >= 0)
            {
                var form = ScreenBoundDisplayForms.FirstOrDefault(p => p.Key == displayDetail.Display.DisplayName);
                var regionRectangleEditing = displayDetail.RegionRectangles.FirstOrDefault(p => p.RegionLabel == cmbRegionLabel.Text);
                if (regionRectangleEditing != null)
                {
                    regionRectangleEditing.RegionOffsetX = Convert.ToInt32(numericUpDownRegionXOffset.Value);
                    regionRectangleEditing.RegionOffsetY = Convert.ToInt32(numericUpDownRegionYOffset.Value);
                    regionRectangleEditing.RegionDisplayHeight = Convert.ToInt32(numericUpDownRegionHeight.Value);
                    regionRectangleEditing.RegionDisplayWidth = Convert.ToInt32(numericUpDownRegionWidth.Value);
                }
                int currentSelectedIndex = listBoxDisplayRegions.SelectedIndex;
                listBoxDisplayRegions.Items.Clear();
                foreach (var region in displayDetail.RegionRectangles)
                {
                    listBoxDisplayRegions.Items.Add(region);
                }
                listBoxDisplayRegions.SelectedIndex = currentSelectedIndex;

                form.Value?.Refresh();
                DrawMonitorDepiction();
                //panelMonitorDrawing.Refresh();
            }
        }

        private void numericUpDownRegionXOffset_ValueChanged(object sender, EventArgs e)
        {
            if (!InProcessOfChangingRegions && !InProcessOfClearingFormFields)
            {
                RefreshDisplayOnRegionUpdate();
            }
        }

        private void numericUpDownRegionYOffset_ValueChanged(object sender, EventArgs e)
        {
            if (!InProcessOfChangingRegions && !InProcessOfClearingFormFields)
            {
                RefreshDisplayOnRegionUpdate();
            }
        }

        private void numericUpDownRegionWidth_ValueChanged(object sender, EventArgs e)
        {
            if (!InProcessOfChangingRegions && !InProcessOfClearingFormFields)
            {
                RefreshDisplayOnRegionUpdate();
            }
        }

        private void numericUpDownRegionHeight_ValueChanged(object sender, EventArgs e)
        {
            if (!InProcessOfChangingRegions && !InProcessOfClearingFormFields)
            {
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
            ValidationHelper helper = new ValidationHelper(_settings, _displayDetails, txtData);
            helper.WritePinballXSettings();
        }

        private void validatePinballXiniToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ValidationHelper helper = new ValidationHelper(_settings, _displayDetails, txtData);
            helper.ValidatePinballX();
        }
    }
}
