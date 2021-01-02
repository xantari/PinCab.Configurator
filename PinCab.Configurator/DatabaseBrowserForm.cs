using PinCab.Configurator.Models;
using PinCab.Configurator.Utils;
using PinCab.Utils;
using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Utils;
using PinCab.Utils.WinForms;
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
    public partial class DatabaseBrowserForm : Form
    {
        private readonly DatabaseManager _dbManager = new DatabaseManager();
        private readonly List<DatabaseBrowserEntry> Entries = new List<DatabaseBrowserEntry>();
        public DatabaseBrowserForm()
        {
            InitializeComponent();

            _dbManager = new DatabaseManager(backgroundWorkerProgressBar.ReportProgress);

            ConfigureGrid();
            LoadDatabaseGrid();
        }

        private void LoadDatabaseGrid()
        {
            txtLog.Text += "Loading Databases...\r\n";
            var action = new DatabaseManagerBackgroundAction();
            action.Action = DatabaseManagerBackgroundProgressAction.DownloadAndLoadDatabase;
            backgroundWorkerProgressBar.RunWorkerAsync(action);
        }

        private void ConfigureGrid()
        {
            foreach (DataGridViewColumn column in dataGridViewEntryList.Columns)
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

        private void txtRomSearch_TextChanged(object sender, EventArgs e)
        {
            SearchByText();
        }

        private void SearchByText()
        {
            vpinDatabaseSettingBindingSource.DataSource = Entries.Where(p => p.Title.Contains(txtRomSearch.Text)).ToSortableBindingList();
        }

        private void contextMenuStripGridActions_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int rowIndex = GetActiveRowIndex();
            if (rowIndex == -1)
            {
                txtLog.Text = "Selected a row or cell first.";
                return;
            }
            //if (e.ClickedItem == editToolStripMenuItem)
            //    ShowRomEditor();
            //else if (e.ClickedItem == copySelectedCellValueToAllROMSToolStripMenuItem)
            //    CopyCellDataToAllRoms();
            //else if (e.ClickedItem == copySelectedRowDataToAllROMSToolStripMenuItem)
            //    CopyRowDataToAllRoms();
            //else if (e.ClickedItem == runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem)
            //    DisplayRomUsingPinMame(true);
            //else if (e.ClickedItem == runROMUsingNativeVPinMameToolStripMenuItem)
            //    DisplayRomUsingPinMame(false);
            //else if (e.ClickedItem == stopRunningROMToolStripMenuItem)
            //    StopRunningRom();
        }

        //private void RefreshGrid()
        //{
        //    LoadDatabaseGrid();
        //    if (!string.IsNullOrEmpty(txtRomSearch.Text))
        //        SearchByText();
        //}

        private int GetActiveRowIndex()
        {
            int rowIndex = -1;
            //If the row is selected get that row index
            if (dataGridViewEntryList.SelectedRows.Count > 0)
                rowIndex = dataGridViewEntryList.SelectedRows[0].Index;
            //if the cell is selected, get the row index from that instead
            if (dataGridViewEntryList.SelectedCells.Count > 0 && rowIndex == -1)
                rowIndex = dataGridViewEntryList.SelectedCells[0].RowIndex;
            return rowIndex;
        }

        private DatabaseBrowserEntry GetActiveRowRom()
        {
            var data = dataGridViewEntryList.DataSource as BindingSource;
            return data.Current as DatabaseBrowserEntry;
        }

        private void backgroundWorkerProgressBar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerProgressBar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 0;
            var result = e.Result as ToolResult;
            if (result.OutputMessages)
            {
                if (result.MessageType == ValidationMessageType.ToolMessage)
                    LogToolValidationResult(result.ToolName, result);
            }
            if (result.FunctionExecuted == DatabaseManagerBackgroundProgressAction.DownloadDatabases.ToString())
            {
                //RefreshGrid();
            }
            else if (result.FunctionExecuted == DatabaseManagerBackgroundProgressAction.ProcessDatabase.ToString())
            {
                //RefreshGrid();
            }
            else if (result.FunctionExecuted == DatabaseManagerBackgroundProgressAction.DownloadAndLoadDatabase.ToString())
            {
                if (result.Result != null)
                {
                    var entries = result.Result as List<DatabaseBrowserEntry>;
                    dataGridViewEntryList.DataSource = entries.ToSortableBindingList();
                }
            }
        }

        private void backgroundWorkerProgressBar_DoWork(object sender, DoWorkEventArgs e)
        {
            var arg = (DatabaseManagerBackgroundAction)e.Argument;
            if (arg.Action == DatabaseManagerBackgroundProgressAction.DownloadDatabases)
            {
                var result = _dbManager.RefreshAllDatabases();
                var toolResult = new ToolResult(result);
                toolResult.ToolName = DatabaseManager.ToolName;
                toolResult.MessageType = ValidationMessageType.ToolMessage;
                toolResult.FunctionExecuted = arg.Action.ToString();
                e.Result = toolResult;
            }
            if (arg.Action == DatabaseManagerBackgroundProgressAction.ProcessDatabase)
            {
                var result = _dbManager.GetAllEntries();
                var toolResult = new ToolResult();
                toolResult.ToolName = DatabaseManager.ToolName;
                toolResult.MessageType = ValidationMessageType.ToolMessage;
                toolResult.FunctionExecuted = arg.Action.ToString();
                toolResult.Result = result;
                e.Result = toolResult;
            }
            if (arg.Action == DatabaseManagerBackgroundProgressAction.DownloadAndLoadDatabase)
            {
                var result = _dbManager.RefreshAllDatabases();
                List<DatabaseBrowserEntry> entries = new List<DatabaseBrowserEntry>();
                if (result.IsValid)
                {
                    _dbManager.LoadAllDatabases();
                    entries = _dbManager.GetAllEntries();
                }
                var toolResult = new ToolResult(result);
                toolResult.ToolName = DatabaseManager.ToolName;
                toolResult.MessageType = ValidationMessageType.ToolMessage;
                toolResult.FunctionExecuted = arg.Action.ToString();
                toolResult.Result = entries;
                toolResult.Messages.Add(new ValidationMessage()
                {
                    Level = MessageLevel.Information,
                    Message = "Grid loaded."
                });
                e.Result = toolResult;
            }
        }

        public void LogToolValidationResult(string command, ValidationResult result)
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

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xantari/PinCab.Configurator/wiki/Database-Browser");
        }

        private void refreshDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Fake the system out by rolling back to a point where it thinks my local database is stale.
            _dbManager.Settings.LastDatabaseRefreshTimeUtc = DateTime.UtcNow.AddDays(-365);
            LoadDatabaseGrid();
        }

        private void dataGridViewEntryList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewEntryList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
