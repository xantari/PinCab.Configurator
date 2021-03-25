using PinCab.Utils;
using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Utils;
using PinCab.Utils.ViewModels;
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
    public partial class EditDatabaseEntryForm : Form
    {
        private FrontEndGameViewModel _setting { get; set; }
        //private string originalFileName { get; set; }
        private FrontEndManager _manager { get; set; }
        private string _databaseFile { get; set; }
        private IpdbBrowserForm _ipdbForm = null;
        private bool isNewEntry = false;
        public EditDatabaseEntryForm(FrontEndGameViewModel setting, string databaseFile, FrontEndManager manager, IpdbBrowserForm ipdbForm)
        {
            InitializeComponent();
        }

        private void LoadForm()
        {
            txtManufacturer.Text = _setting.Manufacturer;
            txtTheme.Text = _setting.Theme;
            txtAuthor.Text = _setting.Author;
            txtVersion.Text = _setting.Version;
            txtIpdb.Text = _setting.IPDBNumber;
            txtAdded.Text = _setting.DateAdded.ToString();
            txtGameUrl.Text = _setting.TableFileUrl;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //var result = GetSettingFromControls();
            //if (string.IsNullOrEmpty(result.Description))
            //{
            //    MessageBox.Show("Description is a required field");
            //    return;
            //}
            //if (string.IsNullOrEmpty(result.FileName))
            //{
            //    MessageBox.Show("File Name is a required field");
            //    return;
            //}

            //_manager.SaveGame(result, null);
            //DialogResult = DialogResult.OK;
            //Close();
        }

        private void btnIpdbUrl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIpdb.Text))
                System.Diagnostics.Process.Start("https://www.ipdb.org/machine.cgi?id=" + txtIpdb.Text);
        }

        private void btnFillFromIpdb_Click(object sender, EventArgs e)
        {
            //_ipdbForm.SearchText(txtTableName.Text);
            //if (isNewEntry)
            //    _ipdbForm.chkOverrideDisplayName.Checked = true;
            //var result = _ipdbForm.ShowDialog(this);
            //if (result == DialogResult.OK)
            //{
            //    //Fill the data
            //    var ipdbEntry = _ipdbForm.GetActiveRowEntry();
            //    if (_ipdbForm.chkOverrideDisplayName.Checked)
            //        txtDisplayName.Text = ipdbEntry.Title;
            //    txtManufacturer.Text = ipdbEntry.ManufacturerShortName;
            //    txtYear.Text = ipdbEntry.DateOfManufacture?.Year.ToString();
            //    txtTheme.Text = ipdbEntry.Theme;
            //    txtIpdb.Text = ipdbEntry.IpdbId.ToString();
            //    txtType.Text = ipdbEntry.TypeShortName;
            //    txtPlayers.Text = ipdbEntry.Players.ToString();
            //}
        }

        private void btnGameUrl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGameUrl.Text))
                System.Diagnostics.Process.Start(txtGameUrl.Text);
        }
    }
}
