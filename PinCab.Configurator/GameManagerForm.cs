using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Models.PinballX;
using PinCab.Utils.Utils;
using PinCab.Utils.ViewModels;
using PinCab.Utils.WinForms;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private IpdbBrowserForm _ipdbForm = new IpdbBrowserForm(string.Empty, true);
        //private bool _loading = true;
        public GameManagerForm()
        {
            InitializeComponent();

            InitForm();
            //_loading = false;
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
                    if (((DatabaseFileViewModel)itm).DatabaseFilePathShort == _manager.Settings.LastSelectedDatabaseFile)
                        cmbDatabase.SelectedItem = itm;
                }
            }
        }

        private void ConfigureGrid()
        {
            foreach (DataGridViewColumn column in dataGridViewGameList.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.Resizable = DataGridViewTriState.True;
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
                        cmbDatabase.Items.AddRange(system.GetDatabaseFileViewModel().ToArray());
                    txtLog.Text = string.Join("\r\n", _manager.GetFrontEndWarnings(frontEnd));
                }
                else
                    MessageBox.Show("Front End Not implemented yet.");
            }
        }

        private FrontEndGameViewModel GetActiveRow()
        {
            var data = dataGridViewGameList.DataSource as BindingSource;
            return data.Current as FrontEndGameViewModel;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = GetActiveRow();
            if (row != null)
            {
                var mediaAuditForm = new AddEditGameForm(row, row.DatabaseFile, _manager, _ipdbForm);
                var result = mediaAuditForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    RefreshGameGrid();
                }
            }
        }

        private void mediaAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mediaAuditForm = new MediaAuditForm();
            var result = mediaAuditForm.ShowDialog(this);
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGameGrid();
            LogGameDiscrepencies();
        }

        private void RefreshGameGrid()
        {
            if (cmbDatabase.SelectedIndex >= 0)
            {
                var frontEnd = cmbFrontEnd.SelectedItem as FrontEnd;
                var databaseItem = cmbDatabase.SelectedItem as DatabaseFileViewModel;
                _fullGameListCache = _manager.GetGamesForFrontEndAndDatabase(frontEnd, databaseItem.DatabaseFilePathShort);
                var list = GetSearchCriteria();
                frontEndGameBindingSource.DataSource = list.ToSortableBindingList();

                if (frontEnd.System == FrontEndSystem.PinballX)
                {
                    var system = _manager.PinballXSystems.FirstOrDefault(p => p.DatabaseFiles.Any(c => c.Contains(databaseItem.DatabaseFilePathShort)));
                    if (system.Enabled)
                        lblDatabaseStatus.Text = "Enabled";
                    else
                        lblDatabaseStatus.Text = "Disabled";
                }
                UpdateToolstripStatus();
            }
        }

        private List<FrontEndGameViewModel> GetSearchCriteria()
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                return _fullGameListCache.Where(p =>
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
                    ).ToList();
            }
            return _fullGameListCache;
        }

        private void UpdateToolstripStatus()
        {
            var entriesInGrid = frontEndGameBindingSource.DataSource as SortableBindingList<FrontEndGameViewModel>;
            toolStripStatusLabel.Text = $"Total Database Entries: {_fullGameListCache.Count} Filtered: {entriesInGrid.Count}";
        }

        private void AddOrUpdateLog(string text)
        {
            if (string.IsNullOrEmpty(txtLog.Text))
                txtLog.Text = text;
            else
                txtLog.Text += "\r\n" + text;
        }

        private void LogGameDiscrepencies()
        {
            if (_fullGameListCache.Any(p => p.MissingTable))
            {
                AddOrUpdateLog("Missing tables have been found. Rows highlighted in RED with discrepencies.");
            }
        }

        private void DisplayGameDiscrepencies()
        {
            foreach (DataGridViewRow row in dataGridViewGameList.Rows)
            {
                var model = row.DataBoundItem as FrontEndGameViewModel;
                if (model.MissingTable)
                    row.DefaultCellStyle.BackColor = Color.Red;
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
                var databaseItem = cmbDatabase.SelectedItem as DatabaseFileViewModel;
                _manager.Settings.LastSelectedDatabaseFile = databaseItem.DatabaseFilePathShort;
            }
            _manager.SaveSettings(_manager.Settings);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshGameGrid();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/xantari/PinCab.Configurator/wiki/Game-Manager");
        }

        private void viewIPDBPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewGameList.SelectedCells.Count > 0)
            {
                var cell = dataGridViewGameList.SelectedCells[0];
                var selectedRow = dataGridViewGameList.Rows[cell.RowIndex].DataBoundItem as FrontEndGameViewModel;
                if (!string.IsNullOrEmpty(selectedRow.IPDBNumber))
                    Process.Start("https://www.ipdb.org/machine.cgi?id=" + selectedRow.IPDBNumber);
            }
        }

        private void dataGridViewGameList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewGameList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            DisplayGameDiscrepencies();
        }

        private void dataGridViewGameList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            var row = GetActiveRow();
            if (row != null)
            {
                var mediaAuditForm = new AddEditGameForm(row, row.DatabaseFile, _manager, _ipdbForm);
                var result = mediaAuditForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    RefreshGameGrid();
                }
            }
        }

        private void deleteGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var deleteFromDatabase = MessageBox.Show($"Are you sure you want to delete the {dataGridViewGameList.SelectedRows.Count} selected items from the database?", "Are you sure?", MessageBoxButtons.YesNo);

            if (deleteFromDatabase == DialogResult.No)
                return;

            List<FrontEndGameViewModel> selectedRowsToDelete = new List<FrontEndGameViewModel>();
            foreach (DataGridViewRow selectedRow in dataGridViewGameList.SelectedRows)
            {
                selectedRowsToDelete.Add(selectedRow.DataBoundItem as FrontEndGameViewModel);
            }

            var removeTableFileList = selectedRowsToDelete.Where(p => !string.IsNullOrEmpty(p.FullPathToTable)).Select(p => p.FullPathToTable).ToList();
            var removeB2sFileList = selectedRowsToDelete.Where(p => !string.IsNullOrEmpty(p.FullPathToB2s)).Select(p => p.FullPathToB2s).ToList();
            var removeMediaFileList = selectedRowsToDelete.Where(p => p.MediaItems.Count() > 0).SelectMany(c => c.MediaItems).Select(c => c.MediaFullPath).ToList();

            DialogResult removeTableFiles = DialogResult.No;
            DialogResult removeB2sFiles = DialogResult.No;
            DialogResult removeMediaFiles = DialogResult.No;
            if (removeTableFileList.Count > 0)
                removeTableFiles = MessageBox.Show($"Do want to delete the actual table files?\r\n {string.Join("\r\n", removeTableFileList)}", "Delete Table Files?", MessageBoxButtons.YesNo);
            if (removeB2sFileList.Count > 0)
                removeB2sFiles = MessageBox.Show($"Do want to delete the actual B2S files?\r\n {string.Join("\r\n", removeB2sFileList)}", "Delete B2S Files?", MessageBoxButtons.YesNo);
            if (removeMediaFileList.Count > 0)
                removeMediaFiles = MessageBox.Show($"Do want to delete the media files?\r\n {string.Join("\r\n", removeMediaFiles)}", "Delete Media Files?", MessageBoxButtons.YesNo);

            if (deleteFromDatabase == DialogResult.Yes)
            {
                if (dataGridViewGameList.SelectedRows.Count > 0)
                {
                    var databaseFile = string.Empty;
                    foreach (DataGridViewRow selectedRow in dataGridViewGameList.SelectedRows)
                    {
                        var model = selectedRow.DataBoundItem as FrontEndGameViewModel;
                        databaseFile = model.DatabaseFile;
                        _manager.DeleteGame(model);
                        _fullGameListCache.Remove(model);
                    }
                    var frontEnd = cmbFrontEnd.SelectedItem as FrontEnd;
                    _manager.SaveDatabase(frontEnd.System, databaseFile);
                    RefreshGameGrid();
                }
            }
            if (removeTableFiles == DialogResult.Yes)
            {
                foreach (var fileToDelete in removeTableFileList)
                    File.Delete(fileToDelete);
            }
            if (removeB2sFiles == DialogResult.Yes)
            {
                foreach (var fileToDelete in removeB2sFileList)
                    File.Delete(fileToDelete);
            }
            if (removeMediaFiles == DialogResult.Yes)
            {
                foreach (var fileToDelete in removeMediaFileList)
                    File.Delete(fileToDelete);
            }
        }

        private void massRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mediaAuditForm = new MassRecordForm();
            var result = mediaAuditForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                RefreshGameGrid();
            }
        }

        private void refreshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshGameGrid();
        }

        private void openMediaFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frontEnd = cmbFrontEnd.SelectedItem as FrontEnd;
            if (frontEnd.System == FrontEndSystem.PinballX)
            {
                if (_manager.PinballXSystems.Count > 0)
                    Process.Start(_manager.PinballXSystems[0].MediaPath);
            }
        }

        private void addGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newGame = new FrontEndGameViewModel();
            var frontEnd = cmbFrontEnd.SelectedItem as FrontEnd;
            var databaseFile = cmbDatabase.SelectedItem as DatabaseFileViewModel;
            newGame.FrontEnd = frontEnd;
            newGame.DatabaseFile = databaseFile.DatabaseFile;
            var mediaAuditForm = new AddEditGameForm(newGame, newGame.DatabaseFile, _manager, _ipdbForm);
            var result = mediaAuditForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                RefreshGameGrid();
            }
        }

        private void backgroundWorkerProgressBar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void tableAuditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void launchDirectlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = GetActiveRow();
            if (row != null)
            {
                //Get the selected database file so we know how to launch the game
                var result = _manager.LaunchGame(row, LaunchType.LaunchGame);
                if (!result.IsValid)
                {
                    LogToolValidationResult("Launch Directly", result);
                }
            }
        }

        private void launchInConfigModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = GetActiveRow();
            if (row != null)
            {
                //Get the selected database file so we know how to launch the game
                var result = _manager.LaunchGame(row, LaunchType.LaunchGameInConfigMode);
                if (!result.IsValid)
                {
                    LogToolValidationResult("Launch In Config Mode", result);
                }
            }
        }

        //TODO: Indicate to user that pinballY and Pinup Popper don't support this feature
        private void launchUsingFrontEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = GetActiveRow();
            if (row != null)
            {
                //Get the selected database file so we know how to launch the game
                var result = _manager.LaunchGame(row, LaunchType.LaunchGameUsingFrontEnd);
                if (!result.IsValid)
                {
                    LogToolValidationResult("Launch Using Front End", result);
                }
            }
        }

        public void LogToolValidationResult(string command, ToolResult result)
        {
            var sb = new StringBuilder();
            if (result?.Messages.Count() > 0)
            {
                sb.Append($"{command} messages: \r\n");
                foreach (var message in result.Messages)
                {
                    if (message.Level == MessageLevel.Error)
                        Log.Error("{command}: Error: {message}", command, message.Message);
                    if (message.Level == MessageLevel.Warning)
                        Log.Warning("{command}: Warning: {message}", command, message.Message);
                    if (message.Level == MessageLevel.Information)
                        Log.Information("{command}: Information: {message}", command, message.Message);
                    sb.Append(message.Message + "\r\n");
                }
            }

            txtLog.Text += sb.ToString();
            txtLog.Select(txtLog.Text.Length, 0);
            txtLog.ScrollToCaret();
        }
    }
}
