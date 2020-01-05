using EDIDParser;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pincab.ScreenUtil;
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
            settings = settings.LoadSettings();
            foreach(var display in settings?.DisplaySettings)
            {
                var loadedDisplaySettingToUpdate = _displayDetails.GetByDisplayName(display.DisplayName);
                loadedDisplaySettingToUpdate.DisplayLabel = display.DisplayLabel;
                loadedDisplaySettingToUpdate.RegionRectangles = display.RegionRectangles;
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
                var edidInfo = GetDisplayEdidData(display.DevicePath);
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

        private EDID GetDisplayEdidData(string devicePath)
        {
            var displayPath = devicePath.Split('#');

            if (!(displayPath.GetUpperBound(0) >= 2)) //Make sure we have all the display data to find the EDID info, if not leave it out. Really old monitors might not have this info
                return null;

            //Open the Display Reg-Key
            RegistryKey Display = Registry.LocalMachine;
            bool bFailed = false;
            try
            {
                Display = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\DISPLAY\" + displayPath[1] + "\\" + displayPath[2]);
            }
            catch
            {
                bFailed = true;
            }

            if (!bFailed & (Display != null))
            {
                var sSubkeys = Display.GetSubKeyNames();
                if (sSubkeys.Contains("Device Parameters"))
                {
                    RegistryKey DevParam = Display.OpenSubKey("Device Parameters");

                    //Get the EDID code
                    byte[] bObj = DevParam.GetValue("EDID", null) as byte[];
                    if (bObj != null)
                    {
                        return new EDID(bObj);
                    }
                    return null;
                }
            }
            return null;
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
            //TimeToSaveVideo = 00:00:30
            //video resolution = 1880x500
            string FFmpegCommandTemplate = @"FFMPEG.exe -f gdigrab -framerate {framerate} -offset_x {offsetX} -offset_y {offsetY} -video_size {videoresolution} -t {timeToSaveVideo} -i desktop -c:v h264_nvenc -an -qp 21 -pix_fmt yuv420p -movflags +faststart {pathToSaveFile}";
            foreach (var display in _displayDetails)
            {
                string frameRate = "30";
                string offsetX, offsetY, videoHeight, videoWidth;
                offsetX = offsetY = videoHeight = videoWidth = string.Empty;

                if (display.RegionRectangles.Count() > 0)
                {
                    foreach (var region in display.RegionRectangles)
                    {
                        if (region.RegionOffsetX != 0) //They have configured a custom resolution to capture, meaning not full screen
                            offsetX = (display.Display.CurrentSetting.Position.X + region.RegionOffsetX).ToString();
                        else
                            offsetX = display.Display.CurrentSetting.Position.X.ToString();

                        if (region.RegionOffsetY != 0) //They have configured a custom resolution to capture, meaning not full screen
                            offsetY = (display.Display.CurrentSetting.Position.Y + region.RegionOffsetY).ToString();
                        else
                            offsetY = display.Display.CurrentSetting.Position.Y.ToString();

                        if (region.RegionDisplayHeight != 0) //They have configured a custom resolution to capture, meaning not full screen
                            videoHeight = region.RegionDisplayHeight.ToString();
                        else
                            videoHeight = display.Display.CurrentSetting.Resolution.Height.ToString();

                        if (region.RegionDisplayHeight != 0) //They have configured a custom resolution to capture, meaning not full screen
                            videoWidth = region.RegionDisplayWidth.ToString();
                        else
                            videoWidth = display.Display.CurrentSetting.Resolution.Width.ToString();

                        string videoResolution = $"{videoWidth}x{videoHeight}";
                        string timeToSaveVideo = "00:00:30"; //30 seconds
                        string pathToSaveVideo = "C:\\" + (display.ToString() + " - " + region.RegionLabel).RemoveInvalidFilenameChars().Replace(".", "") + ".mp4";

                        txtData.Text += display + " - " + region.RegionLabel + " FFMpeg Command: \r\n";
                        txtData.Text += FFmpegCommandTemplate.Replace("{framerate}", frameRate)
                                    .Replace("{offsetX}", offsetX)
                                    .Replace("{offsetY}", offsetY)
                                    .Replace("{videoresolution}", videoResolution)
                                    .Replace("{timeToSaveVideo}", timeToSaveVideo)
                                    .Replace("{pathToSaveFile}", pathToSaveVideo) + "\r\n\r\n";
                    }
                }
                else //Capture the single display info with region offsets
                {
                    string videoResolution = $"{videoWidth}x{videoHeight}";
                    string timeToSaveVideo = "00:00:30"; //30 seconds
                    string pathToSaveVideo = "C:\\" + display.ToString().RemoveInvalidFilenameChars().Replace(".", "") + ".mp4";

                    txtData.Text += display + " FFMpeg Command: \r\n";
                    txtData.Text += FFmpegCommandTemplate.Replace("{framerate}", frameRate)
                                .Replace("{offsetX}", offsetX)
                                .Replace("{offsetY}", offsetY)
                                .Replace("{videoresolution}", videoResolution)
                                .Replace("{timeToSaveVideo}", timeToSaveVideo)
                                .Replace("{pathToSaveFile}", pathToSaveVideo) + "\r\n\r\n";
                }
            }
        }

        private void validateMonitorConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isValid = ValidateMonitorConfiguration();
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
                        txtData.Text += "Invalid monitor configuration detected due to negative position values. Virtual Pinball programs require all monitors to have positive position values. Monitor: " + display.ToString() + " " + display.Display.CurrentSetting.Position.ToString() + "\r\n";
                    isValid = false;
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
            cmbDisplayLabel.Text = string.Empty;
            cmbRegionColor.Text = string.Empty;
            cmbRegionLabel.Text = string.Empty;
            txtVisibleWindowHeight.Text = string.Empty;
            txtVisibleWindowWidth.Text = string.Empty;
            txtVisibleWindowXOffset.Text = string.Empty;
            txtVisibleWindowYOffset.Text = string.Empty;
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
            //e.Graphics.Clear(this.BackColor);
            foreach (var display in _displayDetails)
            {
                var pen = new Pen(Color.Red, 2);
                int screenRectangleX = display.Display.GetScreen().Bounds.X / 10;
                int screenRectangleY = display.Display.GetScreen().Bounds.Y / 10;
                int screenWidth = display.Display.GetScreen().Bounds.Width / 10;
                int screenHeight = display.Display.GetScreen().Bounds.Height / 10;
                //0,0 because it's in the context of the form that is already moved to the proper screen
                var rectangle = new Rectangle(screenRectangleX, screenRectangleY, screenWidth, screenHeight);
                //var rectangle = new Rectangle(2200, 0, 500, 500);
                e.Graphics.DrawRectangle(pen, rectangle);

                Font drawFont = new Font("Arial", 10, FontStyle.Bold);
                SolidBrush drawBrush = new SolidBrush(Color.Red);
                string resolution = display.Display.CurrentSetting.Resolution.Width.ToString() + "x" + display.Display.CurrentSetting.Resolution.Height.ToString();
                string offset = "X=" + display.Display.CurrentSetting.Position.X.ToString() + ", Y=" + display.Display.CurrentSetting.Position.Y.ToString();
                e.Graphics.DrawString(display.DisplayLabel + "\r\n" + resolution + "\r\n" + offset, drawFont, drawBrush, (display.Display.GetScreen().Bounds.X / 10) + 2, (display.Display.GetScreen().Bounds.Y) + 2); //2 is the rectangle line width, so move it inside of that

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
                        e.Graphics.DrawRectangle(pen2, rectangle2);
                    }
                }
            }
        }

        private void refreshDisplayDepictionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelMonitorDrawing.Refresh();
        }

        private void outputScreenrestxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }

        private void outputFutureDMDiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }

        private void setUltraDMDRegistryKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }

        private void setPinballXiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }

        private void outputDMDDeviceiniDMDExtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var about = new AboutBoxForm();
            about.Show();
        }

        private void dumpDisplayInfoToFileToolStripMenuItem_Click(object sender, EventArgs e)
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
            int intVal = 0;
            bool result = Int32.TryParse(txtVisibleWindowHeight.Text, out intVal);
            region.RegionDisplayHeight = intVal;
            result = Int32.TryParse(txtVisibleWindowWidth.Text, out intVal);
            region.RegionDisplayWidth = intVal;
            result = Int32.TryParse(txtVisibleWindowXOffset.Text, out intVal);
            region.RegionOffsetX = intVal;
            result = Int32.TryParse(txtVisibleWindowYOffset.Text, out intVal);
            region.RegionOffsetY = intVal;
            region.RegionLabel = cmbRegionLabel.Text;
            region.RegionColor = Color.FromName(cmbRegionColor.Text);
            listBoxDisplayRegions.Items.Add(region);
        }

        private void listBoxDisplayRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxDisplayRegions.SelectedItem != null)
            {
                var regionRectangle = listBoxDisplayRegions.SelectedItem as RegionRectangle;
                txtVisibleWindowHeight.Text = regionRectangle.RegionDisplayHeight.ToString();
                txtVisibleWindowWidth.Text = regionRectangle.RegionDisplayWidth.ToString();
                txtVisibleWindowXOffset.Text = regionRectangle.RegionOffsetX.ToString();
                txtVisibleWindowYOffset.Text = regionRectangle.RegionOffsetY.ToString();
                cmbRegionLabel.Text = regionRectangle.RegionLabel;
                cmbRegionColor.Text = regionRectangle.RegionColor.Name;
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
            int currentSelectedIndex = listBoxDisplays.SelectedIndex;
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
            }
            else
            {
                MessageBox.Show("Please select a display");
            }
        }

        private void SaveSettings()
        {
            ProgramSettings setting = new ProgramSettings();

            setting.DisplaySettings = new List<DisplaySettings>();
            foreach (var display in _displayDetails)
            {
                setting.DisplaySettings.Add(new DisplaySettings()
                {
                    DisplayLabel = display.DisplayLabel,
                    DisplayName = display.Display.DisplayName,
                    RegionRectangles = display.RegionRectangles
                });
            }

            setting.SaveSettings();
        }

        private void saveConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.Show();
        }

        private void loadConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramSettings setting = new ProgramSettings();
            setting.SaveSettings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var response = MessageBox.Show("Do you want to save your settings?", "Save Settings?", MessageBoxButtons.YesNo);
            if (response == DialogResult.Yes)
            {
                SaveSettings();
            }
        }
    }
}
