using FluentDateTime;
using Newtonsoft.Json;
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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCab.Configurator
{
    public partial class DatabaseBrowserForm : Form
    {
        private readonly DatabaseManager _dbManager = new DatabaseManager();
        private readonly DatabaseBrowserSettingsManager _settingManager = new DatabaseBrowserSettingsManager();
        //private BackgroundQueue _queue = new BackgroundQueue();

        public DatabaseBrowserForm()
        {
            InitializeComponent();

            _dbManager = new DatabaseManager(backgroundWorkerProgressBar.ReportProgress);

            if (!SystemInformation.TerminalServerSession)
                DoubleBuffered = true;
            else
                DoubleBuffered = false;

            ConfigureFilters();
            ConfigureGrid();
            LoadDatabaseGrid();
        }

        private void ConfigureFilters()
        {
            //TODO: Load from the last state (create a database form manager that persists filter selections to .json setting file)
            var settings = _settingManager.LoadSettings();
            if (settings == null) //Load the defaults and save to the filesystem
            {
                settings = new DatabaseBrowserSettings();
                _settingManager.SaveSettings(settings);
            }
            dateTimePickerBegin.Value = settings.BeginDate.BeginningOfDay();
            dateTimePickerEnd.Value = settings.EndDate.EndOfDay();
            var databaseTypeList = EnumExtensions.GetEnumDescriptionList<DatabaseEntryType>();
            databaseTypeList.Insert(0, "All");
            cmbType.DataSource = databaseTypeList;
            txtSearch.Text = settings.SearchTerm;

            foreach (string type in cmbType.Items)
            {
                if (type == settings.TypeFilter)
                    cmbType.SelectedItem = type;
            }

            foreach (string type in cmbDatabase.Items)
            {
                if (type == settings.DatabaseFilter)
                    cmbDatabase.SelectedItem = type;
            }

            foreach(var tag in settings.TagFilter)
            {
                TagObject tagwinforms = new TagObject(tag, RebindGridUsingFilter);
                tagwinforms.Init();
                flowLayoutPanelTags.Controls.Add(tagwinforms);
            }

            flowLayoutPanelTags.Padding = new Padding(3, 3, 3, 3);
        }

        private void LoadDatabaseGrid()
        {
            txtLog.Text += "Loading Databases...\r\n";
            toolStripStatusLabel.Text = "Loading Databases...";
            var action = new DatabaseManagerBackgroundAction();
            action.Action = DatabaseManagerBackgroundProgressAction.DownloadAndLoadDatabase;
            backgroundWorkerProgressBar.RunWorkerAsync(action);
            //_queue.QueueTask(() => DownloadAndLoadDatabase());
            //_queue.QueueTask(() => LoadTags());

            //// The Progress<T> constructor captures our UI context,
            ////  so the lambda will be run on the UI thread.
            //var progress = new Progress<int>(percent =>
            //{
            //    toolStripProgressBar.Value = percent;
            //});

            //await Task.Run(() => DownloadAndLoadDatabase());
            //await Task.Run(() => LoadTags());
        }

        private void ConfigureGrid()
        {
            foreach (DataGridViewColumn column in dataGridViewEntryList.Columns)
            {
                if (column.SortMode != DataGridViewColumnSortMode.NotSortable)
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.Resizable = DataGridViewTriState.True;
            }
            dataGridViewEntryList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

            foreach (DataGridViewColumn column in dataGridViewChildEntries.Columns)
            {
                if (column.SortMode != DataGridViewColumnSortMode.NotSortable)
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.Resizable = DataGridViewTriState.True;
            }
            dataGridViewChildEntries.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //Speed tweak testing
            //dataGridViewEntryList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            //dataGridViewEntryList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            //dataGridViewEntryList.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            //dataGridViewEntryList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //dataGridViewEntryList.RowHeadersVisible = false;
            //// Double buffering can make DGV slow in remote desktop
            //if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            //{
            //    typeof(DataGridView).InvokeMember(
            //       "DoubleBuffered",
            //       BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            //       null,
            //       dataGridViewEntryList,
            //       new object[] { true });
            //}
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RebindGridUsingFilter();
        }

        private List<DatabaseBrowserEntry> GetEntriesByFilterCriteria()
        {
            var list = _dbManager.Entries.Where(p => p.Title.ToLower().Contains(txtSearch.Text.ToLower())); //Search by text
            list = list.Where(p => p.LastUpdated <= dateTimePickerEnd.Value.EndOfDay()
                && p.LastUpdated >= dateTimePickerBegin.Value.BeginningOfDay());

            if (cmbType.SelectedValue != null && cmbType.SelectedValue.ToString() != "All")
            {
                DatabaseEntryType type = cmbType.SelectedValue.ToString().GetValueFromDescription<DatabaseEntryType>();
                list = list.Where(p => p.Type == type);
            }
            if (cmbDatabase.SelectedItem != null && cmbDatabase.SelectedItem.ToString() != "All")
            {
                DatabaseType type = cmbDatabase.SelectedItem.ToString().GetValueFromDescription<DatabaseType>();
                list = list.Where(p => p.DatabaseType == type);
            }
            var tags = GetAllSelectedTags();
            if (tags != null && tags.Count > 0)
            {
                list = list.Where(c => c.Tags.Any(g => tags.Contains(g))
                 || c.RelatedEntries.Any(d => d.Tags.Any(k => tags.Contains(k)))
                );
            }
            return list.ToList();
        }

        private void RebindGridUsingFilter()
        {
            var list = GetEntriesByFilterCriteria();
            vpinDatabaseSettingBindingSource.DataSource = list.ToSortableBindingList();
            var tags = _dbManager.GetAllTags(list.ToList(), false).OrderBy(c => c).ToList();
            tags.Insert(0, "(Select Tag)");
            cmbTags.DataSource = tags;
            UpdateToolstripStatus();
        }

        private void contextMenuStripGridActions_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int rowIndex = GetActiveRowIndex();
            if (rowIndex == -1)
            {
                txtLog.Text = "Select a row or cell first.";
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

        private DatabaseBrowserEntry GetActiveRowEntry()
        {
            var data = vpinDatabaseSettingBindingSource.Current as DatabaseBrowserEntry;
            return data;
        }

        private DatabaseBrowserEntry GetChildActiveRowEntry()
        {
            var data = bindingSourceChildEntries.Current as DatabaseBrowserEntry;
            return data;
        }

        private void backgroundWorkerProgressBar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerProgressBar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar.Value = 0;
            var result = e.Result as ToolResult;
            if (result.OutputMessages)
            {
                if (result.MessageType == ValidationMessageType.ToolMessage)
                    LogToolValidationResult(result.ToolName, result);
            }
            if (result.FunctionExecuted == DatabaseManagerBackgroundProgressAction.DownloadAndLoadDatabase.ToString())
            {
                if (result.Result != null)
                {
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    var entries = GetEntriesByFilterCriteria();
                    vpinDatabaseSettingBindingSource.DataSource = entries.ToSortableBindingList();
                    stopWatch.Stop();
                    TimeSpan ts = stopWatch.Elapsed;
                    var msg = $"Grid binding took: {ts.TotalSeconds} seconds";
                    Log.Information(msg);
                    var logResult = new ValidationResult()
                    {
                        IsValid = true
                    };
                    logResult.Messages.Add(new ValidationMessage()
                    {
                        Level = MessageLevel.Information,
                        Message = msg
                    });
                    LogToolValidationResult(result.ToolName, logResult);

                    var action = new DatabaseManagerBackgroundAction();
                    action.Action = DatabaseManagerBackgroundProgressAction.LoadTags;
                    backgroundWorkerProgressBar.RunWorkerAsync(action);
                    //For debugging tags and consolidating them
                    //var tags = _dbManager.GetAllTags().OrderBy(c => c).ToList();
                    //using (StreamWriter sw = new StreamWriter("C:\\test.json", false))
                    //using (JsonWriter writer = new JsonTextWriter(sw))
                    //{
                    //    JsonSerializer serializer = new JsonSerializer();
                    //    serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                    //    serializer.NullValueHandling = NullValueHandling.Ignore;
                    //    serializer.Formatting = Formatting.Indented;
                    //    serializer.Serialize(writer, tags);
                    //}
                }
            }
            else if (result.FunctionExecuted == DatabaseManagerBackgroundProgressAction.LoadTags.ToString())
            {
                var tags = result.Result as List<string>;
                cmbTags.DataSource = tags;
            }
            UpdateToolstripStatus();
        }

        private void UpdateToolstripStatus()
        {
            var entriesInGrid = vpinDatabaseSettingBindingSource.DataSource as SortableBindingList<DatabaseBrowserEntry>;
            toolStripStatusLabel.Text = $"Total Database Entries: {_dbManager.Entries.Count} Filtered: {entriesInGrid.Count}";
        }

        private void backgroundWorkerProgressBar_DoWork(object sender, DoWorkEventArgs e)
        {
            var arg = (DatabaseManagerBackgroundAction)e.Argument;
            if (arg.Action == DatabaseManagerBackgroundProgressAction.DownloadAndLoadDatabase)
            {
                e.Result = DownloadAndLoadDatabase();
            }
            else if (arg.Action == DatabaseManagerBackgroundProgressAction.LoadTags)
            {
                e.Result = LoadTags();
            }
        }

        private ToolResult DownloadAndLoadDatabase()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = _dbManager.RefreshAllDatabases();
            List<DatabaseBrowserEntry> entries = new List<DatabaseBrowserEntry>();
            if (result.IsValid)
            {
                _dbManager.LoadAllDatabases();
                //A true value indicates there was a re-download of one or more databases from the internet
                //so we will need to re-create the cached data
                var forceReload = (bool)result.Result;
                entries = _dbManager.GetAllEntries(forceReload);
            }
            var toolResult = new ToolResult(result);
            toolResult.ToolName = DatabaseManager.ToolName;
            toolResult.MessageType = ValidationMessageType.ToolMessage;
            toolResult.FunctionExecuted = DatabaseManagerBackgroundProgressAction.DownloadAndLoadDatabase.ToString();
            toolResult.Result = entries;
            toolResult.Messages.AddRange(_dbManager.GetDatabaseVersionMessages());
            toolResult.Messages.Add(new ValidationMessage()
            {
                Level = MessageLevel.Information,
                Message = "Grid loaded."
            });
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Log.Information($"Database Loaded in: {ts.TotalSeconds} seconds");
            toolResult.Messages.Add(new ValidationMessage()
            {
                Level = MessageLevel.Information,
                Message = $"Database Loaded in: {ts.TotalSeconds} seconds"
            });
            return toolResult;
        }

        private ToolResult LoadTags()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //var tagsByCritera = GetEntriesByFilterCriteria(); //vs: _dbManager.Entries (all entries)
            var list = vpinDatabaseSettingBindingSource.DataSource as SortableBindingList<DatabaseBrowserEntry>;
            var tags = _dbManager.GetAllTags(list.ToList()).OrderBy(c => c).ToList();
            tags.Insert(0, "(Select Tag)");
            var toolResult = new ToolResult();
            toolResult.ToolName = DatabaseManager.ToolName;
            toolResult.MessageType = ValidationMessageType.ToolMessage;
            toolResult.FunctionExecuted = DatabaseManagerBackgroundProgressAction.LoadTags.ToString();
            toolResult.Result = tags;
            toolResult.Messages.Add(new ValidationMessage()
            {
                Level = MessageLevel.Information,
                Message = "Tags loaded."
            });
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Log.Information($"Tags Loaded in: {ts.TotalSeconds} seconds");
            toolResult.Messages.Add(new ValidationMessage()
            {
                Level = MessageLevel.Information,
                Message = $"Tags Loaded in: {ts.TotalSeconds} seconds"
            });
            return toolResult;
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
            Process.Start("https://github.com/xantari/PinCab.Configurator/wiki/Database-Browser");
        }

        private void refreshDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Fake the system out by rolling back to a point where it thinks my local database is stale.
            _dbManager.Settings.LastDatabaseRefreshTimeUtc = DateTime.UtcNow.AddDays(-365);
            LoadDatabaseGrid();
        }

        private void dataGridViewEntryList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (e.ListChangedType != ListChangedType.Reset)
            {
                dataGridViewEntryList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            //dataGridViewEntryList.FastAutoSizeColumns();
            //var colSizes = WinformsExtensions.GetAutoSizeColumnsWidth(dataGridViewEntryList);
            //WinformsExtensions.SetAutoSizeColumnsWidth(dataGridViewEntryList, colSizes);
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            RebindGridUsingFilter();
        }

        private void dateTimePickerBegin_ValueChanged(object sender, EventArgs e)
        {
            RebindGridUsingFilter();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            RebindGridUsingFilter();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RebindGridUsingFilter();
        }

        private void cmbTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTags.SelectedItem != null && cmbTags.SelectedItem.ToString() != "(Select Tag)")
            {
                string tag = cmbTags.SelectedItem.ToString();
                TagObject tagwinforms = new TagObject(tag, RebindGridUsingFilter); //Pass in action on what to do if a tag is removed
                tagwinforms.Init();
                flowLayoutPanelTags.Controls.Add(tagwinforms);
                RebindGridUsingFilter();
            }
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

        private void IpdbInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = GetActiveRowEntry();
            if (row != null)
            {
                if (row.IpdbId.HasValue)
                {
                    Process.Start($"https://www.ipdb.org/machine.cgi?id={row.IpdbId.Value}");
                }
            }
        }

        private void goToUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = GetActiveRowEntry();
            if (row != null)
            {
                if (!string.IsNullOrEmpty(row.Url))
                {
                    Process.Start(row.Url);
                }
            }
        }

        private void dataGridViewEntryList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            var row = GetActiveRowEntry();
            if (row != null)
            {
                if (!string.IsNullOrEmpty(row.Url))
                {
                    Process.Start(row.Url);
                }
            }
        }

        private void dataGridViewEntryList_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            var row = GetActiveRowEntry();
            if (!row.IpdbId.HasValue)
                contextMenuStripGridActions.Items["IpdbInfoToolStripMenuItem"].Enabled = false;
            else
                contextMenuStripGridActions.Items["IpdbInfoToolStripMenuItem"].Enabled = true;
        }

        private void dataGridViewChildEntries_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewChildEntries.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        private void dataGridViewChildEntries_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            var row = GetChildActiveRowEntry();
            if (!row.IpdbId.HasValue)
                contextMenuStripChildEntries.Items["toolStripMenuItemChildIpdb"].Enabled = false;
            else
                contextMenuStripChildEntries.Items["toolStripMenuItemChildIpdb"].Enabled = true;
        }

        private void toolStripMenuItemChildIpdb_Click(object sender, EventArgs e)
        {
            var row = GetChildActiveRowEntry();
            if (row != null)
            {
                if (row.IpdbId.HasValue)
                {
                    Process.Start($"https://www.ipdb.org/machine.cgi?id={row.IpdbId.Value}");
                }
            }
        }

        private void toolStripMenuItemChildUrl_Click(object sender, EventArgs e)
        {
            var row = GetChildActiveRowEntry();
            if (row != null)
            {
                if (!string.IsNullOrEmpty(row.Url))
                {
                    Process.Start(row.Url);
                }
            }
        }

        private void dataGridViewChildEntries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            var row = GetChildActiveRowEntry();
            if (row != null)
            {
                if (!string.IsNullOrEmpty(row.Url))
                {
                    Process.Start(row.Url);
                }
            }
        }

        private void dataGridViewEntryList_SelectionChanged(object sender, EventArgs e)
        {
            var entry = GetActiveRowEntry();
            //Now bind the child grid
            bindingSourceChildEntries.DataSource = entry?.RelatedEntries.ToSortableBindingList();
        }

        private void DatabaseBrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var settings = new DatabaseBrowserSettings();
            settings.BeginDate = dateTimePickerBegin.Value;
            settings.EndDate = dateTimePickerEnd.Value;
            settings.SearchTerm = txtSearch.Text;
            settings.TypeFilter = cmbType.SelectedItem.ToString();
            settings.DatabaseFilter = cmbDatabase.SelectedItem.ToString();
            settings.TagFilter = GetAllSelectedTags();

            foreach (DataGridViewColumn column in dataGridViewEntryList.Columns)
            {
                settings.DatabaseGridColumnWidths.Add(column.Width);
            }
            foreach (DataGridViewColumn column in dataGridViewChildEntries.Columns)
            {
                settings.RelatedGridColumnWidths.Add(column.Width);
            }

            _settingManager.SaveSettings(settings);
        }
    }
}
