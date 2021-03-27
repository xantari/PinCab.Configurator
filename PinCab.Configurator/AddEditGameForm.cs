using PinCab.Utils;
using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Utils;
using PinCab.Utils.ViewModels;
using PinCab.Utils.WinForms.TabOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCab.Configurator
{
    public partial class AddEditGameForm : Form
    {
        private FrontEndGameViewModel _setting { get; set; }
        //private string originalFileName { get; set; }
        private FrontEndManager _manager { get; set; }
        private string _databaseFile { get; set; }
        private IpdbBrowserForm _ipdbForm = null;
        private bool isNewEntry = false;
        public AddEditGameForm(FrontEndGameViewModel setting, string databaseFile, FrontEndManager manager, IpdbBrowserForm ipdbForm)
        {
            InitializeComponent();
            _setting = setting;
            _manager = manager;
            _databaseFile = databaseFile;
            _ipdbForm = ipdbForm;
            if (string.IsNullOrEmpty(setting.Description))
            {
                isNewEntry = true;
            }
            if (_ipdbForm == null)
                _ipdbForm = new IpdbBrowserForm(txtTableName.Text, true);
            LoadForm();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
        }

        private void LoadForm()
        {
            txtTableName.Text = _setting.FileName;
            txtDisplayName.Text = _setting.Description;
            txtManufacturer.Text = _setting.Manufacturer;
            txtYear.Text = _setting.Year;
            txtTheme.Text = _setting.Theme;
            txtAuthor.Text = _setting.Author;
            txtVersion.Text = _setting.Version;
            txtIpdb.Text = _setting.IPDBNumber;
            txtType.Text = _setting.Type;
            txtRom.Text = _setting.Rom;
            txtPlayers.Text = _setting.Players;
            txtPlayCount.Text = _setting.TimesPlayed.ToString();
            txtSeconds.Text = _setting.SecondsPlayed.ToString();
            txtAdded.Text = _setting.DateAdded.ToString();
            txtModified.Text = _setting.DateModified.ToString();
            txtComment.Text = _setting.Comment;
            txtGameUrl.Text = _setting.TableFileUrl;
            chkHideBackglass.Checked = _setting.HideBackglass;
            chkHideDmd.Checked = _setting.HideDmd;
            chkHideTopper.Checked = _setting.HideTopper;
            chkEnabled.Checked = _setting.Enabled;
            chkFavorite.Checked = _setting.Favorite;

            //Load the alternate exe list
            if (_setting.FrontEnd.System == FrontEndSystem.PinballX)
            {
                var system = _manager.PinballXSystems.FirstOrDefault(c => c.DatabaseFiles.Contains(_databaseFile));
                cmbAlternateExe.Items.AddRange(system.Executables.ToArray());
            }
            if (string.IsNullOrEmpty(_setting.AlternateExe))
                cmbAlternateExe.SelectedItem = "<default>";
            else
                cmbAlternateExe.SelectedItem = _setting.AlternateExe;
        }

        private FrontEndGameViewModel GetSettingFromControls()
        {
            _setting.FileName = txtTableName.Text.IfEmptyThenNull();
            _setting.Description = txtDisplayName.Text.IfEmptyThenNull();
            _setting.Manufacturer = txtManufacturer.Text.IfEmptyThenNull();
            _setting.Year = txtYear.Text.IfEmptyThenNull();
            _setting.Theme = txtTheme.Text.IfEmptyThenNull();
            _setting.Author = txtAuthor.Text.IfEmptyThenNull();
            _setting.Version = txtVersion.Text.IfEmptyThenNull();
            _setting.IPDBNumber = txtIpdb.Text.IfEmptyThenNull();
            _setting.Type = txtType.Text.IfEmptyThenNull();
            _setting.Rom = txtRom.Text.IfEmptyThenNull();
            _setting.Players = txtPlayCount.Text.IfEmptyThenNull();
            _setting.TimesPlayed = Convert.ToInt32(txtPlayCount.Text);
            _setting.SecondsPlayed = Convert.ToInt32(txtSeconds.Text);
            _setting.Enabled = chkEnabled.Checked;
            if (!string.IsNullOrEmpty(txtAdded.Text))
            {
                DateTime result;
                var success = DateTime.TryParse(txtAdded.Text, out result);
                if (success)
                    _setting.DateAdded = result;

            }
            if (!string.IsNullOrEmpty(txtModified.Text))
            {
                DateTime result;
                var success = DateTime.TryParse(txtModified.Text, out result);
                if (success)
                    _setting.DateModified = result;
            }

            if (cmbAlternateExe.SelectedText == "<default>" || string.IsNullOrEmpty(cmbAlternateExe.SelectedText))
                _setting.AlternateExe = null;
            else
                _setting.AlternateExe = cmbAlternateExe.SelectedText.IfEmptyThenNull();
            _setting.Comment = txtComment.Text.IfEmptyThenNull();
            _setting.TableFileUrl = txtGameUrl.Text.IfEmptyThenNull();
            _setting.HideBackglass = chkHideBackglass.Checked;
            _setting.HideDmd = chkHideDmd.Checked;
            _setting.HideTopper = chkHideTopper.Checked;

            return _setting;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var result = GetSettingFromControls();
            if (string.IsNullOrEmpty(result.Description))
            {
                MessageBox.Show("Description is a required field");
                return;
            }
            if (string.IsNullOrEmpty(result.FileName))
            {
                MessageBox.Show("File Name is a required field");
                return;
            }

            _manager.SaveGame(result, null);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "All files (*.*)|*.*|VPX Files|*.vpx|FPT Files|*.fpx|VPT Files|*.vpt";
                fileDialog.FilterIndex = 1;
                if (_setting.FrontEnd.System == FrontEndSystem.PinballX)
                {
                    var system = _manager.PinballXSystems.FirstOrDefault(c => c.DatabaseFiles.Contains(_databaseFile));
                    fileDialog.InitialDirectory = system.TablePath;
                }
                fileDialog.RestoreDirectory = true;
                var result = fileDialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var fi = new FileInfo(fileDialog.FileName);
                    var endIndex = fi.Name.LastIndexOf(fi.Extension);
                    //originalFileName = txtTableName.Text;
                    txtTableName.Text = fi.Name.Substring(0, endIndex);
                    if (isNewEntry)
                    {
                        txtModified.Text = fi.LastWriteTime.ToString();
                        txtAdded.Text = fi.CreationTime.ToString();
                    }
                }
            }
        }

        private void btnIpdbUrl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIpdb.Text))
                System.Diagnostics.Process.Start("https://www.ipdb.org/machine.cgi?id=" + txtIpdb.Text);
        }

        private void btnFillFromIpdb_Click(object sender, EventArgs e)
        {
            _ipdbForm.SearchText(txtTableName.Text);
            if (isNewEntry)
                _ipdbForm.chkOverrideDisplayName.Checked = true;
            var result = _ipdbForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                //Fill the data
                var ipdbEntry = _ipdbForm.GetActiveRowEntry();
                if (_ipdbForm.chkOverrideDisplayName.Checked)
                    txtDisplayName.Text = ipdbEntry.Title;
                txtManufacturer.Text = ipdbEntry.ManufacturerShortName;
                txtYear.Text = ipdbEntry.DateOfManufacture?.Year.ToString();
                txtTheme.Text = ipdbEntry.Theme;
                txtIpdb.Text = ipdbEntry.IpdbId.ToString();
                txtType.Text = ipdbEntry.TypeShortName;
                txtPlayers.Text = ipdbEntry.Players.ToString();
            }
        }

        private void btnGameUrl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGameUrl.Text))
                System.Diagnostics.Process.Start(txtGameUrl.Text);
        }

        private void btnDatabaseBrowser_Click(object sender, EventArgs e)
        {
            var form = new DatabaseBrowserForm();
            form.SearchByText(txtDisplayName.Text, new DateTime(1900, 1, 1), DateTime.Today.AddDays(1), new List<string>());
            var result = form.ShowDialog(this);
        }

        private void btnShowNew_Click(object sender, EventArgs e)
        {
            var selectedSystem = _manager.GetPinballXSystemByDatabaseFile(_databaseFile);

            if (selectedSystem.Type == Platform.VP || selectedSystem.Type == Platform.FP)
            {
                var addNewForm = new AddNewGameForm(_setting.FrontEnd, _setting.DatabaseFile, _manager);
                var result = addNewForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    if (addNewForm.lstFiles.SelectedItem != null) //Can't select from an empty list
                    {
                        var fi = new FileInfo(addNewForm.lstFiles.SelectedItem.ToString());
                        var endIndex = fi.Name.LastIndexOf(fi.Extension);
                        //originalFileName = txtTableName.Text;
                        txtTableName.Text = fi.Name.Substring(0, endIndex);
                        if (isNewEntry)
                        {
                            txtModified.Text = fi.LastWriteTime.ToString();
                            txtAdded.Text = fi.CreationTime.ToString();
                        }
                    }
                }
            }
            else
                MessageBox.Show("Show New not available for systems other then Future Pinball and Virtual Pinball.");
        }

        private void txtTableName_Leave(object sender, EventArgs e)
        {
            if (!isNewEntry)
            {
                var newValue = txtTableName.Text;
                var oldValue = _setting.FileName;

                //See if the table name has changed. If so popup the window to aid the user in renaming media
                //https://github.com/xantari/PinCab.Configurator/issues/11
                if (newValue != oldValue)
                {
                    var renameForm = new RenameGameForm(_setting, txtTableName.Text, _manager);
                    var result = renameForm.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        txtTableName.Text = _setting.FileName;
                    }
                    else
                        txtTableName.Text = oldValue;
                }
            }
        }
    }
}
