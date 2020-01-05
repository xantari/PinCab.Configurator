﻿using PinCabScreenConfigurator.Properties;
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
    /// <summary>
    /// Notes: UltraDMD reg key: Computer\HKEY_CURRENT_USER\Software\UltraDMD
    /// VPinMame: Computer\HKEY_CURRENT_USER\Software\Freeware\Visual PinMame (Default folder) and all the ROM folders
    /// </summary>
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            //this.toolTip1.SetToolTip(this.btnFFMPegHelp, "Location of the ffmpeg.exe file if you wish to use the screen recording feature of this program.");
            //this.toolTip1.SetToolTip(this.btnRecordTimeSecondsHelp, "Number of seconds to record the video. 5 Second increments up to 200 seconds. Minimum 5 seconds.");
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ProgramSettings settings = new ProgramSettings();
            settings = settings.LoadSettings();

            if (settings != null)
            {
                txtFFMpegFilePath.Text = settings.FFMpegFullPath;
                txtTempRecordingPath.Text = settings.RecordingTempFolderPath;
                numericRecordTimeSeconds.Value = settings.RecordTimeSeconds >= 5 ? settings.RecordTimeSeconds : 5;
                numericFramerate.Value = settings.RecordFramerate >= 15 ? settings.RecordFramerate : 15;
                txtPinballXIniFilePath.Text = settings.PinballXIniPath;
                txtPinballYLocation.Text = settings.PinballYSettingsPath;
                txtPinupPopperDbLocation.Text = settings.PinupPopperSqlLiteDbPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProgramSettings settings = new ProgramSettings();
            settings = settings.LoadSettings();
            if (settings == null)
                settings = new ProgramSettings();
            settings.FFMpegFullPath = txtFFMpegFilePath.Text;
            settings.RecordingTempFolderPath = txtTempRecordingPath.Text;
            settings.RecordFramerate = Convert.ToInt32(numericFramerate.Value);
            settings.RecordTimeSeconds = Convert.ToInt32(numericRecordTimeSeconds.Value);
            settings.PinupPopperSqlLiteDbPath = txtPinupPopperDbLocation.Text;
            settings.PinballXIniPath = txtPinballXIniFilePath.Text;
            settings.PinballYSettingsPath = txtPinballYLocation.Text;

            settings.SaveSettings();
            this.Close();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnFFMpegFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "EXE Files|*.exe|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = "ffmpeg.exe";
                fileDialog.RestoreDirectory = true;
                fileDialog.ShowDialog();

                txtFFMpegFilePath.Text = fileDialog.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTempRecordFilePath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fileDialog = new FolderBrowserDialog())
            {
                fileDialog.ShowDialog();

                txtTempRecordingPath.Text = fileDialog.SelectedPath;
            }
        }

        private void btnPinballYFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "txt Files|*.txt|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = "settings.txt";
                fileDialog.RestoreDirectory = true;
                fileDialog.ShowDialog();

                txtPinballYLocation.Text = fileDialog.FileName;
            }
        }

        private void btnPinballXIniFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "INI Files|*.ini|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = "pinballx.ini";
                fileDialog.RestoreDirectory = true;
                fileDialog.ShowDialog();

                txtPinballXIniFilePath.Text = fileDialog.FileName;
            }
        }

        private void btnPinupPopperFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Sqllite DB Files|*.db|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = "PUPDatabase.db";
                fileDialog.RestoreDirectory = true;
                fileDialog.ShowDialog();

                txtPinupPopperDbLocation.Text = fileDialog.FileName;
            }
        }
    }
}