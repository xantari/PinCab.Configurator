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
            action.Action = DatabaseManagerBackgroundProgressAction.DownloadDatabases;
            backgroundWorkerProgressBar.RunWorkerAsync(action);
            //if (!_util.KeyExists())
            //{
            //    txtLog.Text = "VPinMame Registry key not found. Have you installed VPinMame and registered it yet?";
            //    return;
            //}
            //_roms = _util.GetAllRomDetails();
            //vpinMameRomSettingBindingSource.DataSource = _roms.ToSortableBindingList();
        }

        private void ConfigureGrid()
        {
            foreach (DataGridViewColumn column in dataGridViewRomList.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
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

        private void RefreshGrid()
        {
            LoadDatabaseGrid();
            if (!string.IsNullOrEmpty(txtRomSearch.Text))
                SearchByText();
        }

        private int GetActiveRowIndex()
        {
            int rowIndex = -1;
            //If the row is selected get that row index
            if (dataGridViewRomList.SelectedRows.Count > 0)
                rowIndex = dataGridViewRomList.SelectedRows[0].Index;
            //if the cell is selected, get the row index from that instead
            if (dataGridViewRomList.SelectedCells.Count > 0 && rowIndex == -1)
                rowIndex = dataGridViewRomList.SelectedCells[0].RowIndex;
            return rowIndex;
        }

        private VpinMameRomSetting GetActiveRowRom()
        {
            var data = dataGridViewRomList.DataSource as BindingSource;
            return data.Current as VpinMameRomSetting;
        }

        private void backgroundWorkerProgressBar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerProgressBar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 0;
            var result = e.Result as ToolValidationResult;
            if (result.OutputValidationMessages)
            {
                if (result.MessageType == ValidationMessageType.ToolMessage)
                    LogToolValidationResult(result.ToolName, result);
            }
            //RefreshGrid();
        }

        private void backgroundWorkerProgressBar_DoWork(object sender, DoWorkEventArgs e)
        {
            var arg = (DatabaseManagerBackgroundAction)e.Argument;
            if (arg.Action == DatabaseManagerBackgroundProgressAction.DownloadDatabases)
            {
                var result = _dbManager.RefreshAllDatabases();
                var toolResult = new ToolValidationResult(result);
                toolResult.ToolName = DatabaseManager.ToolName;
                toolResult.MessageType = ValidationMessageType.ToolMessage;
                toolResult.FunctionExecuted = arg.Action.ToString();
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
            txtLog.Select(txtLog.Text.Length,0);
            txtLog.ScrollToCaret();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xantari/PinCab.Configurator/wiki/Database-Browser");
        }
    }
}
