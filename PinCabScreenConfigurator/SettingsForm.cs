using PinCabScreenConfigurator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCabScreenConfigurator
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.btnFFMPegHelp, "Location of the ffmpeg.exe file if you wish to use the screen recording feature of this program.");
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ProgramSettings settings = new ProgramSettings();
            settings = settings.LoadSettings();

            txtFFMpegFilePath.Text = settings.FFMpegFullPath;

            //// Set window location
            //if (Settings.Default.SettingsWindowLocation != null)
            //{
            //    this.Location = Settings.Default.SettingsWindowLocation;
            //}

            //// Set window size
            //if (Settings.Default.SettingsWindowSize != null)
            //{
            //    this.Size = Settings.Default.SettingsWindowSize;
            //}
        }

        private void btnFFMPegHelp_Click(object sender, EventArgs e)
        {

        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //// Copy window location to app settings
            //Settings.Default.SettingsWindowLocation = Location;

            //// Copy window size to app settings
            //if (this.WindowState == FormWindowState.Normal)
            //{
            //    Settings.Default.SettingsWindowSize = this.Size;
            //}
            //else
            //{
            //    Settings.Default.SettingsWindowSize = this.RestoreBounds.Size;
            //}

            //// Save settings
            //Settings.Default.Save();
        }

        private void btnFFMpegFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = "c:\\";
                fileDialog.Filter = "EXE Files|*.exe|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = "ffmpeg.exe";
                fileDialog.RestoreDirectory = true;
                fileDialog.ShowDialog();

                txtFFMpegFilePath.Text = fileDialog.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProgramSettings settings = new ProgramSettings();
            settings = settings.LoadSettings();
            settings.FFMpegFullPath = txtFFMpegFilePath.Text;
            settings.SaveSettings();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
