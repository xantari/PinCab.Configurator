using EDIDParser;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pincab.ScreenUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsDisplayAPI;

namespace PinCabScreenConfigurator
{
    //https://stackoverflow.com/questions/5020559/screen-allscreen-is-not-giving-the-correct-monitor-count
    public partial class MainForm : Form
    {
        private List<DisplayDetail> _displayDetails { get; set; } = new List<DisplayDetail>();

        public MainForm()
        {
            InitializeComponent();
            LoadDisplayDetails();
            DisplayDisplayDetails();
            var displays = new ScreenDetails().GetDisplays();
            //panelMonitorDrawing.Refresh();
            ValidateMonitorConfiguration();
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

        private void btnSaveDisplayLabel_Click(object sender, EventArgs e)
        {
            int currentSelectedIndex = listBoxDisplays.SelectedIndex;
            if (listBoxDisplays.SelectedIndex >= 0)
            {
                var listItem = listBoxDisplays.SelectedItem as DisplayDetail;
                listItem.DisplayLabel = cmbDisplayLabel.Text;
                int intVal = 0;
                var parsed = Int32.TryParse(txtVisibleWindowWidth.Text, out intVal);
                if (parsed)
                    listItem.VisibleDisplayWidth = intVal;
                else
                    listItem.VisibleDisplayWidth = 0;
                parsed = Int32.TryParse(txtVisibleWindowHeight.Text, out intVal);
                if (parsed)
                    listItem.VisibleDisplayHeight = intVal;
                else
                    listItem.VisibleDisplayHeight = 0;
                parsed = Int32.TryParse(txtVisibleWindowXOffset.Text, out intVal);
                if (parsed)
                    listItem.OffsetX = intVal;
                else
                    listItem.OffsetX = 0;
                parsed = Int32.TryParse(txtVisibleWindowYOffset.Text, out intVal);
                if (parsed)
                    listItem.OffsetY = intVal;
                else
                    listItem.OffsetY = 0;
                DisplayDisplayDetails();
                listBoxDisplays.SelectedIndex = currentSelectedIndex;
            }
            else
            {
                MessageBox.Show("Please select a monitor");
            }
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
                string offsetX;
                if (display.OffsetX != 0) //They have configured a custom resolution to capture, meaning not full screen
                    offsetX = (display.Display.CurrentSetting.Position.X + display.OffsetX).ToString();
                else
                    offsetX = display.Display.CurrentSetting.Position.X.ToString();

                string offsetY;
                if (display.OffsetY != 0) //They have configured a custom resolution to capture, meaning not full screen
                    offsetY = (display.Display.CurrentSetting.Position.Y + display.OffsetY).ToString();
                else
                    offsetY = display.Display.CurrentSetting.Position.Y.ToString();

                string videoHeight;
                if (display.VisibleDisplayHeight != 0) //They have configured a custom resolution to capture, meaning not full screen
                    videoHeight = display.VisibleDisplayHeight.ToString();
                else
                    videoHeight = display.Display.CurrentSetting.Resolution.Height.ToString();

                string videoWidth;
                if (display.VisibleDisplayHeight != 0) //They have configured a custom resolution to capture, meaning not full screen
                    videoWidth = display.VisibleDisplayWidth.ToString();
                else
                    videoWidth = display.Display.CurrentSetting.Resolution.Width.ToString();
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

        private void listBoxDisplays_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Refresh();
            PopulateFormDisplayDetails();
        }

        private void PopulateFormDisplayDetails()
        {
            if (listBoxDisplays.SelectedItem != null)
            {
                var displayDetail = listBoxDisplays.SelectedItem as DisplayDetail;
                cmbDisplayLabel.Text = displayDetail.DisplayLabel;
                txtVisibleWindowHeight.Text = displayDetail.VisibleDisplayHeight.ToString();
                txtVisibleWindowWidth.Text = displayDetail.VisibleDisplayWidth.ToString();
                txtVisibleWindowXOffset.Text = displayDetail.OffsetX.ToString();
                txtVisibleWindowYOffset.Text = displayDetail.OffsetY.ToString();
            }
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            if (listBoxDisplays.SelectedItem != null)
            {
                if (this.OwnedForms.Count() > 0)
                {
                    for (int i = 0; i < this.OwnedForms.Count(); i++)
                    {
                        this.OwnedForms[i].Close();
                    }
                }
                var displayDetail = listBoxDisplays.SelectedItem as DisplayDetail;
                var newForm = new ScreenBoundsDisplayForm(displayDetail, this);
                newForm.Owner = this;
                newForm.Show();

                //Force it back over there, keeps gettign reset for some reason

                //e.Graphics.DrawRectangle(pen, rectangle);
                //IntPtr desktop = GetDC(IntPtr.Zero);
                //using (Graphics g = Graphics.FromHdc(desktop))
                //{
                //    g.
                //    g.DrawRectangle(pen, rectangle);
                //}
                //ReleaseDC(IntPtr.Zero, desktop);
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
                if (display.OffsetX != 0 || display.OffsetY != 0 || display.VisibleDisplayHeight != 0 || display.VisibleDisplayWidth != 0)
                {
                    var pen2 = new Pen(Color.Green, 2);
                    //We offset the rectangle here based off of what screen we are now on (this takes into account the "virtual desktop space" in windows) when
                    //you arrange your monitors in display settings
                    var rectangle2 = new Rectangle(screenRectangleX + (display.OffsetX / 10), screenRectangleY + (display.OffsetY / 10),
                        (display.VisibleDisplayWidth / 10), (display.VisibleDisplayHeight / 10));
                    e.Graphics.DrawRectangle(pen2, rectangle2);
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
                fileDialog.InitialDirectory = "c:\\";
                fileDialog.Filter = "JSON Files|*.json|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = Environment.MachineName + "_DisplayDetails.json";
                fileDialog.RestoreDirectory = true;


                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = fileDialog.FileName;
                    //using (TextWriter writer = new StreamWriter(filePath))
                    //{
                    //    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(_displayDetails.GetType());
                    //    x.Serialize(writer, _displayDetails);
                    //    writer.Close();
                    //}
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Converters.Add(new JavaScriptDateTimeConverter());
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
    }
}
