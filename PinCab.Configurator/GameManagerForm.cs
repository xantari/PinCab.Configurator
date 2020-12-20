using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Models.PinballX;
using PinCab.Utils.Utils;
using PinCab.Utils.ViewModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCab.Configurator
{
    public partial class GameManagerForm : Form
    {
        private readonly FrontEndManager _manager = new FrontEndManager();
        private List<FrontEndGameViewModel> _fullGameListCache { get; set; }
        public GameManagerForm()
        {
            InitializeComponent();

            InitForm();
        }

        private void InitForm()
        {
            var frontEnds = _manager.GetListOfActiveFrontEnds();
            if (frontEnds.Count == 0)
            {
                txtLog.Text = "No Front Ends detected. Have you pointed to the settings file for atleast one front end?";
                return;
            }
            else
            {
                cmbFrontEnd.Items.AddRange(frontEnds.ToArray());
            }
            ConfigureGrid();
            LoadDefaultsFromSavedSettings();
        }

        private void LoadDefaultsFromSavedSettings()
        {
            if (!string.IsNullOrEmpty(_manager.Settings.LastSelectedFrontEnd))
            {
                foreach (var itm in cmbFrontEnd.Items)
                {
                    var frontEnd = itm as FrontEnd;
                    if (frontEnd.Name == _manager.Settings.LastSelectedFrontEnd)
                        cmbFrontEnd.SelectedItem = itm;
                }
            }
            if (!string.IsNullOrEmpty(_manager.Settings.LastSelectedDatabaseFile))
            {
                foreach (var itm in cmbDatabase.Items)
                {
                    if (itm.ToString() == _manager.Settings.LastSelectedDatabaseFile)
                        cmbDatabase.SelectedItem = itm;
                }
            }
        }

        private void ConfigureGrid()
        {
            foreach (DataGridViewColumn column in dataGridViewGameList.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbFrontEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            var frontEnd = cmbFrontEnd.SelectedItem as FrontEnd;
            if (frontEnd != null)
            {
                cmbDatabase.Items.Clear();
                if (frontEnd.System == FrontEndSystem.PinballX)
                {
                    foreach (var system in _manager.PinballXSystems) //Get the short name of the database, not the full path
                        cmbDatabase.Items.AddRange(system.GetDatabaseFilesWithoutDatabasePath().ToArray());
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mediaAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDatabase.SelectedIndex >= 0)
            {
                var frontEnd = cmbFrontEnd.SelectedItem as FrontEnd;
                _fullGameListCache = _manager.GetGamesForFrontEndAndDatabase(frontEnd, cmbDatabase.SelectedItem.ToString());
                dataGridViewGameList.DataSource = _fullGameListCache.ToSortableBindingList();
            }
        }

        private void GameManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Save the settings of the grid and last selected front end
            if (cmbFrontEnd.SelectedIndex >= 0)
            {
                _manager.Settings.LastSelectedFrontEnd = (cmbFrontEnd.SelectedItem as FrontEnd).Name;
            }
            if (cmbDatabase.SelectedIndex >= 0)
            {
                _manager.Settings.LastSelectedDatabaseFile = cmbDatabase.SelectedItem.ToString();
            }
            _manager.SaveSettings(_manager.Settings);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            dataGridViewGameList.DataSource = _fullGameListCache.Where(p => 
                (!string.IsNullOrEmpty(p.Rom) && p.Rom.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.Year) && p.Year.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.FileName) && p.FileName.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.Description) && p.Description.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.Comment) && p.Comment.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.Author) && p.Author.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.AlternateExe) && p.AlternateExe.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.Manufacturer) && p.Manufacturer.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.Theme) && p.Theme.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.Type) && p.Type.ToLower().Contains(searchText)) ||
                (!string.IsNullOrEmpty(p.Version) && p.Version.ToLower().Contains(searchText))
                ).ToSortableBindingList();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xantari/PinCab.Configurator/wiki/Game-Manager");
        }
    }
}
