using PinCab.Utils;
using PinCab.Utils.Utils;
using PinCab.Configurator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PinCab.Utils.Models;
using System.IO;
using PinCab.Utils.Extensions;
using PinCab.Utils.WinForms;
using PinCab.Utils.WinForms.TabOrder;

namespace PinCab.Configurator
{
    /// <summary>
    /// Notes: UltraDMD reg key: Computer\HKEY_CURRENT_USER\Software\UltraDMD
    /// VPinMame: Computer\HKEY_CURRENT_USER\Software\Freeware\Visual PinMame (Default folder) and all the ROM folders
    /// </summary>
    public partial class SettingsForm : Form
    {
        private VpinMameUtil vpinMame { get; set; }
        private UltraDmdUtil ultraDmd { get; set; }
        private readonly ProgramSettingsManager _settingManager = new ProgramSettingsManager();

        public SettingsForm()
        {
            InitializeComponent();

            vpinMame = new VpinMameUtil();
            ultraDmd = new UltraDmdUtil();

            //this.toolTip1.SetToolTip(this.btnFFMPegHelp, "Location of the ffmpeg.exe file if you wish to use the screen recording feature of this program.");
            //this.toolTip1.SetToolTip(this.btnRecordTimeSecondsHelp, "Number of seconds to record the video. 5 Second increments up to 200 seconds. Minimum 5 seconds.");
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.DownFirst);
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var settings = _settingManager.LoadSettings();

            //List<DatabaseType> databaseTypes = Enum.GetValues(typeof(DatabaseType)).Cast<DatabaseType>().ToList();
            cmbContentDatabaseType.DataSource = EnumExtensions.GetEnumDescriptionList<DatabaseType>();

            if (settings != null)
            {
                txtFFMpegFilePath.Text = settings.RecordingSettings.FFMpegPath;
                txtOBSPath.Text = settings.RecordingSettings.ObsFullPath;
                txtOBSConfigPath.Text = settings.RecordingSettings.ObsConfigPath;
                numericStartRecordDelaySeconds.Value = settings.RecordingSettings.RecordTimeStartupDelaySeconds >= 5 ? settings.RecordingSettings.RecordTimeStartupDelaySeconds : 5;
                txtTempRecordingPath.Text = settings.RecordingSettings.RecordingTempFolderPath;
                numericRecordTimeSeconds.Value = settings.RecordingSettings.RecordTimeSeconds >= 5 ? settings.RecordingSettings.RecordTimeSeconds : 5;
                numericFramerate.Value = settings.RecordingSettings.RecordFramerate >= 15 ? settings.RecordingSettings.RecordFramerate : 15;
                txtPinballXIniFilePath.Text = settings.PinballXIniPath;
                txtPinballYLocation.Text = settings.PinballYSettingsPath;
                txtPinupPopperDbLocation.Text = settings.PinupPopperSqlLiteDbPath;
                txtB2SScreenresFilePath.Text = settings.B2SScreenResPath;
                txtPinupPlayerFilePath.Text = settings.PinupPlayerPath;
                txtFutureDMDFilePath.Text = settings.FutureDMDIniPath;
                txtDMDDeviceIniFilePath.Text = settings.DMDDeviceIniPath;
                txtPRocUserSettings.Text = settings.PRocUserSettingsPath;
                numericRecheckMinutes.Value = settings.DatabaseUpdateRecheckMinutes;

                contentDatabaseBindingSource.DataSource = settings.Databases.ToSortableBindingList<ContentDatabase>();

                lblVPinMameFound.Text = vpinMame.KeyExists().ToString();
                lblUltraDMDFound.Text = ultraDmd.KeyExists().ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var settings = _settingManager.LoadSettings();
            if (settings == null)
                settings = new ProgramSettings();
            settings.RecordingSettings.FFMpegPath = txtFFMpegFilePath.Text;
            settings.RecordingSettings.ObsFullPath = txtOBSPath.Text;
            settings.RecordingSettings.ObsConfigPath = txtOBSConfigPath.Text;
            settings.RecordingSettings.RecordTimeStartupDelaySeconds = Convert.ToInt32(numericStartRecordDelaySeconds.Value);
            settings.RecordingSettings.RecordingTempFolderPath = txtTempRecordingPath.Text;
            settings.RecordingSettings.RecordFramerate = Convert.ToInt32(numericFramerate.Value);
            settings.RecordingSettings.RecordTimeSeconds = Convert.ToInt32(numericRecordTimeSeconds.Value);
            settings.PinupPopperSqlLiteDbPath = txtPinupPopperDbLocation.Text;
            settings.PinballXIniPath = txtPinballXIniFilePath.Text;
            settings.PinballYSettingsPath = txtPinballYLocation.Text;
            settings.B2SScreenResPath = txtB2SScreenresFilePath.Text;
            settings.PinupPlayerPath = txtPinupPlayerFilePath.Text;
            settings.FutureDMDIniPath = txtFutureDMDFilePath.Text;
            settings.DMDDeviceIniPath = txtDMDDeviceIniFilePath.Text;
            settings.PRocUserSettingsPath = txtPRocUserSettings.Text;
            settings.DatabaseUpdateRecheckMinutes = Convert.ToInt32(numericRecheckMinutes.Value);

            settings.Databases = (contentDatabaseBindingSource.DataSource as SortableBindingList<ContentDatabase>).ToList();

            _settingManager.SaveSettings(settings);
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
                var result = fileDialog.ShowDialog(this);
                if (result == DialogResult.OK)
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
                fileDialog.ShowDialog(this);

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
                var result = fileDialog.ShowDialog(this);

                if (result == DialogResult.OK)
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
                var result = fileDialog.ShowDialog(this);

                if (result == DialogResult.OK)
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
                var result = fileDialog.ShowDialog(this);

                if (result == DialogResult.OK)
                    txtPinupPopperDbLocation.Text = fileDialog.FileName;
            }
        }

        private void btnB2SScreenresFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "txt Files|*.txt|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = "Screenres.txt";
                fileDialog.RestoreDirectory = true;
                var result = fileDialog.ShowDialog(this);

                if (result == DialogResult.OK)
                    txtB2SScreenresFilePath.Text = fileDialog.FileName;
            }
        }

        private void btnPinupPlayerFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "ini Files|*.ini|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = "PinUpPlayer.ini";
                fileDialog.RestoreDirectory = true;
                var result = fileDialog.ShowDialog(this);

                if (result == DialogResult.OK)
                    txtPinupPlayerFilePath.Text = fileDialog.FileName;
            }
        }

        private void btnFutureDMDFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "INI Files|*.ini|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = "FutureDMD.ini";
                fileDialog.RestoreDirectory = true;
                var result = fileDialog.ShowDialog(this);

                if (result == DialogResult.OK)
                    txtFutureDMDFilePath.Text = fileDialog.FileName;
            }
        }

        private void btnDMDDeviceIniFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "INI Files|*.ini|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = "*.ini";
                fileDialog.RestoreDirectory = true;
                var result = fileDialog.ShowDialog(this);

                if (result == DialogResult.OK)
                    txtDMDDeviceIniFilePath.Text = fileDialog.FileName;
            }
        }

        private void btnPRocUserSettingsFilePath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "YAML Files|*.yaml|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = "user_settings.yaml";
                fileDialog.RestoreDirectory = true;
                var result = fileDialog.ShowDialog(this);

                if (result == DialogResult.OK)
                    txtPRocUserSettings.Text = fileDialog.FileName;
            }
        }

        private void SettingsForm_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xantari/PinCab.Configurator/wiki/Settings");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xantari/PinCab.Configurator/wiki/Settings");
        }

        private void btnContentDatabaseUrl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtContentDatabaseUrl.Text);
        }

        private void btnOBSPath_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "EXE Files|*.exe|All files (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.FileName = "obs64.exe";
                fileDialog.RestoreDirectory = true;
                var result = fileDialog.ShowDialog(this);
                if (result == DialogResult.OK)
                    txtOBSPath.Text = fileDialog.FileName;
            }
        }

        private void btnOBSConfigPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fileDialog = new FolderBrowserDialog())
            {
                //typically C:\Users\{profilename}\AppData\Roaming\obs-studio
                var env = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                fileDialog.RootFolder = Environment.SpecialFolder.ApplicationData;
                fileDialog.ShowNewFolderButton = false;
                var expectedPath = $"{env}\\obs-studio";
                if (Directory.Exists(expectedPath))
                    fileDialog.SelectedPath = expectedPath;
                //$"{env}\\obs-studio";
                var result = fileDialog.ShowDialog(this);
                if (result == DialogResult.OK)
                    txtOBSConfigPath.Text = fileDialog.SelectedPath;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtContentDatabaseName.Text))
            {
                MessageBox.Show("You must enter a content database name.");
                return;
            }
            if (string.IsNullOrEmpty(txtContentDatabaseUrl.Text))
            {
                MessageBox.Show("You must enter a content database url.");
                return;
            }
            var currentDatabases = contentDatabaseBindingSource.DataSource as SortableBindingList<ContentDatabase>;
            var db = currentDatabases.FirstOrDefault(c => c.Name == txtContentDatabaseName.Text);
            bool isNewEntry = false;
            if (db == null) //new entry
            {
                db = new ContentDatabase();
                isNewEntry = true;
            }

            db.AccessToken = txtContentDatabaseAccessToken.Text;
            db.Name = txtContentDatabaseName.Text;
            var databaseType = cmbContentDatabaseType.SelectedItem.ToString().GetValueFromDescription<DatabaseType>();
            db.Type = databaseType;
            db.Url = txtContentDatabaseUrl.Text;

            var savedRowName = txtContentDatabaseName.Text;

            if (isNewEntry)
                currentDatabases.Add(db);
            //contentDatabaseBindingSource.DataSource = currentDatabases;
            //foreach (DataGridViewRow row in gvContentDatabases.Rows)
            //{
            //    var rowData = row.DataBoundItem as ContentDatabase;
            //    if (rowData.Name == savedRowName)
            //    {
            //        //gvContentDatabases.Rows[row.Index].Selected = true;
            //        gvContentDatabases.CurrentCell = gvContentDatabases[0, row.Index];
            //    }
            //}
        }

        private void gvContentDatabases_SelectionChanged(object sender, EventArgs e)
        {
            var data = contentDatabaseBindingSource.Current as ContentDatabase;
            txtContentDatabaseAccessToken.Text = data.AccessToken;
            txtContentDatabaseName.Text = data.Name;
            txtContentDatabaseUrl.Text = data.Url;
            cmbContentDatabaseType.SelectedItem = data.Type.GetDescriptionAttr();
        }

        private void btnFilePathDatabaseBrowser_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "JSON Files|*.json|All files (*.*)|*.*";
                fileDialog.RestoreDirectory = true;
                var result = fileDialog.ShowDialog(this);
                if (result == DialogResult.OK)
                    txtContentDatabaseUrl.Text = fileDialog.FileName;
            }
        }

        //private void gvContentDatabases_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        //{
        //    gvContentDatabases.ClearSelection();
        //    gvContentDatabases.Rows[e.RowIndex].Selected = true;
        //    gvContentDatabases.CurrentCell = gvContentDatabases[0, e.RowIndex];
        //}
    }
}
