using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Utils;
using PinCab.Utils.WinForms.TabOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualPinball.Database.Models;

namespace PinCab.Configurator
{
    public partial class AddRelatedDatabaseEntryForm : Form
    {
        private DatabaseManager _dbManager { get; set; }
        private string _databaseName { get; set; }
        private string _title { get; set; }
        private int _currentId { get; set; }
        private ProgramSettingsManager _settingsManager = new ProgramSettingsManager();
        private ProgramSettings _settings;

        public AddRelatedDatabaseEntryForm(int currentId, string databaseName, string title, DatabaseManager manager)
        {
            InitializeComponent();
            _dbManager = manager;
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
            DialogResult = DialogResult.None;
            _databaseName = databaseName;
            _title = title;
            _currentId = currentId;
            _settings = _settingsManager.LoadSettings();

            if (_settings.DatabaseBrowserSettings?.AddRelatedWindowHeight > 0 && _settings.DatabaseBrowserSettings?.AddRelatedWindowWidth > 0)
            {
                this.Height = _settings.DatabaseBrowserSettings.AddRelatedWindowHeight;
                this.Width = _settings.DatabaseBrowserSettings.AddRelatedWindowWidth;
            }

            ConfigureGrid();
            LoadForm();
        }

        private void ConfigureGrid()
        {
            foreach (DataGridViewColumn column in dataGridViewRelated.Columns)
            {
                if (column.SortMode != DataGridViewColumnSortMode.NotSortable)
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.Resizable = DataGridViewTriState.True;
            }
            dataGridViewRelated.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            int count = 1;
            foreach (var setting in _settings.DatabaseBrowserSettings.AddRelatedDatabaseEntryColumnWidths)
            {
                if (count <= dataGridViewRelated.Columns.Count)
                    dataGridViewRelated.Columns[count - 1].Width = setting;
                count++;
            }
        }

        private void LoadForm()
        {
            databaseEntryBindingSource.DataSource = _dbManager.Databases[_databaseName].Entries.ToSortableBindingList<DatabaseEntry>();
            txtSearch.Text = _title;
        }

        public DatabaseEntry GetActiveRowEntry()
        {
            return databaseEntryBindingSource.Current as DatabaseEntry;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.ToLower();
            //Exclude our self from the search of related entries
            IEnumerable<DatabaseEntry> list = _dbManager.Databases[_databaseName].Entries.Where(c => c.Id != _currentId);
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                list = list.Where(p => //(p.Title.FuzzyMatch(txtSearch.Text) > .1)
                    (p.Title != null && p.Title.ToLower().Contains(searchTerm))
                    || (p.Description != null && p.Description.ToLower().Contains(searchTerm))
                    || (p.TagsString != null && p.TagsString.ToLower().Contains(searchTerm))
                    || (p.IpdbNumber != null && p.IpdbNumber.ToString() == searchTerm)
                    || (p.FileName != null && p.FileName.ToLower().Contains(searchTerm)) 
                    ); //Search by text
            }

            databaseEntryBindingSource.DataSource = list.ToSortableBindingList();
        }

        private void dataGridViewRelated_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (e.ListChangedType != ListChangedType.Reset && _settings.DatabaseBrowserSettings.AddRelatedDatabaseEntryColumnWidths.Count == 0)
            {
                dataGridViewRelated.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
        }

        private void AddRelatedDatabaseEntryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Reload the settings, if another window updated them (such as the AddRelatedDatabaseEntryForm)
            _settings = _settingsManager.LoadSettings();
            _settings.DatabaseBrowserSettings.AddRelatedDatabaseEntryColumnWidths = new List<int>();
            foreach (DataGridViewColumn column in dataGridViewRelated.Columns)
            {
                _settings.DatabaseBrowserSettings.AddRelatedDatabaseEntryColumnWidths.Add(column.Width);
            }

            _settings.DatabaseBrowserSettings.AddRelatedWindowHeight = this.Height;
            _settings.DatabaseBrowserSettings.AddRelatedWindowWidth = this.Width;

            _settingsManager.SaveSettings(_settings);
        }
    }
}
