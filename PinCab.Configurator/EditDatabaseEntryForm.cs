using PinCab.Utils;
using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Utils;
using PinCab.Utils.ViewModels;
using PinCab.Utils.WinForms;
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
using VirtualPinball.Database.Models;

namespace PinCab.Configurator
{
    public partial class EditDatabaseEntryForm : Form
    {
        private DatabaseBrowserEntry _entry { get; set; }
        //private string originalFileName { get; set; }
        private DatabaseManager _manager { get; set; }
        private IpdbBrowserForm _ipdbForm = null;
        private bool isNewEntry = false;
        private DatabaseEntry _dbEntry { get; set; }
        private string _databaseName { get; set; }
        private ProgramSettingsManager _settingsManager = new ProgramSettingsManager();
        private ProgramSettings _settings;

        public EditDatabaseEntryForm(string databaseName, DatabaseBrowserEntry entry, DatabaseManager manager, IpdbBrowserForm ipdbForm)
        {
            InitializeComponent();
            _manager = manager;
            _ipdbForm = ipdbForm;
            _entry = entry;
            _databaseName = databaseName;
            DialogResult = DialogResult.None;
            _settings = _settingsManager.LoadSettings();
            if (entry == null)
            {
                isNewEntry = true;
                _entry = new DatabaseBrowserEntry();
                _dbEntry = new DatabaseEntry();
                _dbEntry.Id = 1;
                if (manager.Databases[databaseName] != null && manager.Databases[databaseName].Entries.Count > 0)
                    _dbEntry.Id = manager.Databases[databaseName].Entries.Max(c => c.Id) + 1;
            }
            else
            {
                _dbEntry = manager.Databases[entry.DatabaseName].Entries.First(c => c.Id == entry.Id);
            }
            LoadForm();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
        }

        private void LoadForm()
        {
            if (_settings.DatabaseBrowserSettings?.AddEditWindowHeight > 0 && _settings.DatabaseBrowserSettings?.AddEditWindowWidth > 0)
            {
                this.Height = _settings.DatabaseBrowserSettings.AddEditWindowHeight;
                this.Width = _settings.DatabaseBrowserSettings.AddEditWindowWidth;
            }

            //Load the database list
            var databaseNames = _manager.Databases
                .OrderBy(c => c.Key).Select(c => c.Key).ToList();
            cmbDatabase.DataSource = databaseNames;

            foreach (string databaseName in cmbDatabase.Items)
            {
                if (databaseName == _databaseName)
                    cmbDatabase.SelectedItem = databaseName;
            }

            //if (!isNewEntry)
           cmbDatabase.Enabled = false; //Do not allow saving an entry accross databases, 3/27/2021 - Always set to readonly as we are always adding/editing based off of a specific database

            var categoryList = EnumExtensions.GetEnumDescriptionList<MajorCategory>();
            cmbCategory.DataSource = categoryList;

            foreach (string categoryName in cmbCategory.Items)
            {
                if (categoryName == _entry.Type.GetDescriptionAttr())
                    cmbCategory.SelectedItem = categoryName;
            }

            if (!isNewEntry)
                lblId.Text = _dbEntry.Id.ToString();
            else
                lblId.Text = "(Auto Generated)";

            txtUrl.Text = _dbEntry.Url;
            txtTitle.Text = _dbEntry.Title;
            txtFileName.Text = _dbEntry.FileName;
            txtDescription.Text = _dbEntry.Description;
            txtChangeLog.Text = _dbEntry.ChangeLog;
            txtFeatures.Text = _dbEntry.Features;
            txtAuthors.Text = _dbEntry.Authors;
            txtVersion.Text = _dbEntry.Version;
            txtManufacturer.Text = _dbEntry.Manufacturer;
            numericPlayers.Value = _dbEntry.Players.HasValue ? _dbEntry.Players.Value : 0;
            numericYear.Value = _dbEntry.Year.HasValue ? _dbEntry.Year.Value : 0;
            txtTheme.Text = _dbEntry.Theme;
            txtIpdbNumber.Text = _dbEntry.IpdbNumber.HasValue ? _dbEntry.IpdbNumber.Value.ToString() : "";
            numericFileBytes.Value = _dbEntry.FileSizeBytes.HasValue ? _dbEntry.FileSizeBytes.Value : 0;
            numericDownloadCount.Value = _dbEntry.DownloadCount.HasValue ? _dbEntry.DownloadCount.Value : 0;
            numericRating.Value = _dbEntry.Rating.HasValue ? _dbEntry.Rating.Value : 0;
            dateTimeModified.Value = _dbEntry.LastModifiedDateUtc.HasValue ? _dbEntry.LastModifiedDateUtc.Value : DateTime.UtcNow;

            lblReadableFileSize.Text = Convert.ToInt64(numericFileBytes.Value).FileSizeHumanReadable();

            if (_dbEntry.Tags != null)
            {
                foreach (var tag in _dbEntry.Tags)
                {
                    TagObject tagwinforms = new TagObject(tag, null);
                    tagwinforms.Init();
                    flowLayoutPanelTags.Controls.Add(tagwinforms);
                }
            }

            flowLayoutPanelTags.Padding = new Padding(3, 3, 3, 3);

            if (_dbEntry.AdditionalInfoUrls != null)
            {
                foreach (var url in _dbEntry.AdditionalInfoUrls)
                {
                    dataGridViewAdditionalUrls.Rows.Add(url);
                }
            }
            if (_dbEntry.ScreenshotUrls != null)
            {
                foreach (var url in _dbEntry.ScreenshotUrls)
                {
                    dataGridViewScreenshotUrls.Rows.Add(url);
                }
            }

            if (_dbEntry.DirectDownloadUrls != null)
            {
                foreach (var url in _dbEntry.DirectDownloadUrls)
                {
                    dataGridViewDirectDownloadUrls.Rows.Add(url);
                }
            }

            RefreashRelatedDatabaseEntries();
        }

        private void RefreashRelatedDatabaseEntries()
        {
            var relatedEntries = new List<DatabaseEntry>();
            if (_dbEntry.RelatedEntries != null)
            {
                foreach (var entryId in _dbEntry.RelatedEntries)
                {
                    var dbEntry = _manager.Databases[cmbDatabase.SelectedItem.ToString()].Entries.FirstOrDefault(c => c.Id == entryId);
                    if (dbEntry != null)
                        relatedEntries.Add(dbEntry);
                }
            }
            databaseEntryBindingSource.DataSource = relatedEntries.ToSortableBindingList<DatabaseEntry>();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public DatabaseEntry GetUpdatedDatabaseEntry()
        {
            _dbEntry.MajorCategory = cmbCategory.SelectedItem.ToString().GetValueFromDescription<MajorCategory>();
            _dbEntry.Url = txtUrl.Text;
            _dbEntry.Title = txtTitle.Text;
            _dbEntry.FileName = txtFileName.Text;
            _dbEntry.Description = txtDescription.Text;
            _dbEntry.ChangeLog = txtChangeLog.Text;
            _dbEntry.Features = txtFeatures.Text;
            _dbEntry.Authors = txtAuthors.Text;
            _dbEntry.Version = txtVersion.Text;
            _dbEntry.Manufacturer = txtManufacturer.Text;
            _dbEntry.Players = Convert.ToInt32(numericPlayers.Value);
            _dbEntry.Year = Convert.ToInt32(numericYear.Value);
            _dbEntry.Theme = txtTheme.Text;

            int ipdbNum = 0;
            bool result = int.TryParse(txtIpdbNumber.Text, out ipdbNum);
            if (result)
                _dbEntry.IpdbNumber = ipdbNum;
            else
                _dbEntry.IpdbNumber = null;

            _dbEntry.FileSizeBytes = Convert.ToInt32(numericFileBytes.Value);
            _dbEntry.DownloadCount = Convert.ToInt32(numericDownloadCount.Value);
            _dbEntry.Rating = Convert.ToInt32(numericRating.Value);
            _dbEntry.LastModifiedDateUtc = dateTimeModified.Value;
            _dbEntry.Tags = GetAllSelectedTags();
            _dbEntry.AdditionalInfoUrls = GetAllAdditionalUrls();
            _dbEntry.ScreenshotUrls = GetAllScreenshotUrls();
            _dbEntry.RelatedEntries = GetAllRelatedFileIds();
            _dbEntry.DirectDownloadUrls = GetAllDirectDownloadUrls();

            return _dbEntry;
        }

        private List<int> GetAllRelatedFileIds()
        {
            var list = new List<int>();
            foreach (DataGridViewRow row in dataGridViewRelatedEntries.Rows)
            {
                list.Add(Convert.ToInt32(row.Cells["idDataGridViewTextBoxColumn"].Value));
            }
            if (list.Count == 0)
                return null;
            return list.OrderBy(c => c).ToList();
        }

        private List<string> GetAllAdditionalUrls()
        {
            var list = new List<string>();
            foreach (DataGridViewRow row in dataGridViewAdditionalUrls.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells[0].Value?.ToString()))
                    list.Add(row.Cells[0].Value.ToString());
            }
            if (list.Count == 0)
                return null;
            return list;
        }

        private List<string> GetAllScreenshotUrls()
        {
            var list = new List<string>();
            foreach (DataGridViewRow row in dataGridViewScreenshotUrls.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells[0].Value?.ToString()))
                    list.Add(row.Cells[0].Value.ToString());
            }
            if (list.Count == 0)
                return null;
            return list;
        }

        private List<string> GetAllDirectDownloadUrls()
        {
            var list = new List<string>();
            foreach (DataGridViewRow row in dataGridViewDirectDownloadUrls.Rows)
            {
                if (!string.IsNullOrEmpty(row.Cells[0].Value?.ToString()))
                    list.Add(row.Cells[0].Value.ToString());
            }
            if (list.Count == 0)
                return null;
            return list;
        }

        private bool ValidateEntry()
        {
            List<string> issues = new List<string>();
            if (string.IsNullOrEmpty(txtTitle.Text))
                issues.Add("Title is a required field");
            if (string.IsNullOrEmpty(txtUrl.Text))
                issues.Add("Url is a required field");
            if (dateTimeModified.Value > DateTime.UtcNow)
                issues.Add("Modified date cannot be in the future.");

            int ipdbNum = 0;
            if (txtIpdbNumber.Text.Length > 0)
            {
                bool success = int.TryParse(txtIpdbNumber.Text, out ipdbNum);
                if (!success)
                    issues.Add("IPDB Number is not numeric.");
            }

            //Validate Url
            Uri uriResult;
            var successUri = Uri.TryCreate(txtUrl.Text, UriKind.Absolute, out uriResult);
            if (!successUri)
                issues.Add("Url entered is not a valid url. Url: " + txtUrl.Text);

            var additionalUrls = GetAllAdditionalUrls();
            if (additionalUrls != null)
            {
                foreach(var url in additionalUrls)
                {
                    successUri = Uri.TryCreate(url, UriKind.Absolute, out uriResult);
                    if (!successUri)
                        issues.Add("Additional url entered is not a valid url. Url: " + url);
                }
            }

            var screenshotUrls = GetAllScreenshotUrls();
            if (screenshotUrls != null)
            {
                foreach (var url in screenshotUrls)
                {
                    successUri = Uri.TryCreate(url, UriKind.Absolute, out uriResult);
                    if (!successUri)
                        issues.Add("Screenshot url entered is not a valid url. Url: " + url);
                }
            }

            var directDownloadUrls = GetAllDirectDownloadUrls();
            if (directDownloadUrls != null)
            {
                foreach (var url in directDownloadUrls)
                {
                    successUri = Uri.TryCreate(url, UriKind.Absolute, out uriResult);
                    if (!successUri)
                        issues.Add("Direct Download url entered is not a valid url. Url: " + url);
                }
            }

            //Ensure the url being added isn't already in the database
            if (_manager.Databases[_databaseName] != null && !string.IsNullOrEmpty(txtUrl.Text)) //Not a brand new entry in a new database
            {
                bool alreadyExists = _manager.Databases[_databaseName].Entries.Any(c => c.Url.ToLower() == txtUrl.Text.Trim().ToLower());
                if (alreadyExists)
                    issues.Add("Url already exists on another entry.");
            }

            if (issues.Count > 0)
                MessageBox.Show(string.Join("\r\n", issues), "Issues List");
            return (issues.Count == 0); //True if 0 (no issues), false if >= 1 issues
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var valid = ValidateEntry();
            if (!valid)
                return;

            var updatedDbEntry = GetUpdatedDatabaseEntry();

            //_manager.SaveGame(result, null);
            DialogResult = DialogResult.OK;
            Close();
        }

        public List<string> GetAllSelectedTags()
        {
            var list = new List<string>();
            foreach (var control in flowLayoutPanelTags.Controls)
            {
                list.Add((control as Label).Text);
            }
            return list;
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTag.Text))
            {
                string tag = txtTag.Text;
                TagObject tagwinforms = new TagObject(tag, null); //Pass in action on what to do if a tag is removed
                tagwinforms.Init();
                flowLayoutPanelTags.Controls.Add(tagwinforms);
            }
        }

        private void btnUrl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUrl.Text))
                System.Diagnostics.Process.Start(txtUrl.Text);
        }

        private void btnIpdbUrl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIpdbNumber.Text))
                System.Diagnostics.Process.Start("https://www.ipdb.org/machine.cgi?id=" + txtIpdbNumber.Text);
        }

        private void dateTimeModified_ValueChanged(object sender, EventArgs e)
        {
            lblLocalTime.Text = dateTimeModified.Value.ToLocalTime().ToString("MM/dd/yyyy HH:mm:ss tt");
        }

        private void btnFillFromIpdb_Click(object sender, EventArgs e)
        {
            _ipdbForm.SearchText(txtTitle.Text);
            if (isNewEntry)
                _ipdbForm.chkOverrideDisplayName.Checked = true;
            var result = _ipdbForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                //Fill the data
                var ipdbEntry = _ipdbForm.GetActiveRowEntry();
                if (_ipdbForm.chkOverrideDisplayName.Checked)
                    txtTitle.Text = ipdbEntry.Title;
                txtManufacturer.Text = ipdbEntry.ManufacturerShortName;
                if (ipdbEntry.DateOfManufacture.HasValue)
                    numericYear.Value = ipdbEntry.DateOfManufacture.Value.Year;
                txtTheme.Text = ipdbEntry.Theme;
                txtIpdbNumber.Text = ipdbEntry.IpdbId.ToString();
                numericPlayers.Value = ipdbEntry.Players.HasValue ? ipdbEntry.Players.Value : 0;
            }
        }

        private void dataGridViewScreenshotUrls_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewScreenshotUrls.SelectedRows.Count > 0)
            {
                var row = dataGridViewScreenshotUrls.SelectedRows[0];
                System.Diagnostics.Process.Start(row.Cells[0].Value.ToString());
            }
        }

        private void numericFileBytes_ValueChanged(object sender, EventArgs e)
        {
            lblReadableFileSize.Text = Convert.ToInt64(numericFileBytes.Value).FileSizeHumanReadable();
        }

        private void btnAddRelatedEntry_Click(object sender, EventArgs e)
        {
            var form = new AddRelatedDatabaseEntryForm(_dbEntry.Id, _databaseName, txtTitle.Text, _manager);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                var relatedEntry = form.GetActiveRowEntry();
                if (relatedEntry != null)
                {
                    if (_dbEntry.RelatedEntries == null)
                        _dbEntry.RelatedEntries = new List<int>();

                    if (!_dbEntry.RelatedEntries.Contains(relatedEntry.Id)) //Ensure it doesn't already exist
                    {
                        _dbEntry.RelatedEntries.Add(relatedEntry.Id);
                        RefreashRelatedDatabaseEntries();
                    }
                }
            }
        }

        private void EditDatabaseEntryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Reload the settings, if another window updated them (such as the AddRelatedDatabaseEntryForm)
            _settings = _settingsManager.LoadSettings();
            _settings.DatabaseBrowserSettings.AddEditWindowHeight = this.Height;
            _settings.DatabaseBrowserSettings.AddEditWindowWidth = this.Width;

            _settingsManager.SaveSettings(_settings);
        }

        private void dataGridViewDirectDownloadUrls_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewDirectDownloadUrls.SelectedRows.Count > 0)
            {
                var row = dataGridViewDirectDownloadUrls.SelectedRows[0];
                System.Diagnostics.Process.Start(row.Cells[0].Value.ToString());
            }
        }
    }
}
