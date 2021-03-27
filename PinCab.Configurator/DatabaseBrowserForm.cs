using DuoVia.FuzzyStrings;
using FluentDateTime;
using PinCab.Configurator.Models;
using PinCab.Configurator.Utils;
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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VirtualPinball.Database.Models;

namespace PinCab.Configurator
{
    public partial class DatabaseBrowserForm : Form
    {
        private readonly DatabaseManager _dbManager = new DatabaseManager();
        private readonly ProgramSettingsManager _settingManager = new ProgramSettingsManager();
        private IpdbBrowserForm _ipdbForm = new IpdbBrowserForm(string.Empty, true);

        private bool _loading = true;
        private ProgramSettings _settings { get; set; }

        private bool notifiedOfSaveWarning = false;

        public DatabaseBrowserForm()
        {
            InitializeComponent();

            _settings = _settingManager.LoadSettings();
            if (_settings == null) //Load the defaults and save to the filesystem
            {
                _settings = new ProgramSettings();
                _settingManager.SaveSettings(_settings);
            }

            _dbManager = new DatabaseManager(backgroundWorkerProgressBar.ReportProgress);

            if (!SystemInformation.TerminalServerSession)
                DoubleBuffered = true;
            else
                DoubleBuffered = false;

            ConfigureFilters();
            ConfigureGrid();
            LoadDatabaseGrid();
            _loading = false;
        }

        private void ConfigureFilters()
        {
            //Load from the last state (create a database form manager that persists filter selections to .json setting file)
            dateTimePickerBegin.Value = _settings.DatabaseBrowserSettings.BeginDate.BeginningOfDay();
            dateTimePickerEnd.Value = _settings.DatabaseBrowserSettings.EndDate.EndOfDay();
            var categoryList = EnumExtensions.GetEnumDescriptionList<MajorCategory>();
            categoryList.Insert(0, "All");
            cmbType.DataSource = categoryList;
            txtSearch.Text = _settings.DatabaseBrowserSettings.SearchTerm;

            //Load the database list
            var databaseNames = _settings.Databases
                .Where(c => c.Type == DatabaseType.PinballDatabase)
                .OrderBy(c => c.Name).Select(c => c.Name).ToList();
            databaseNames.Insert(0, "All");
            cmbDatabase.DataSource = databaseNames;

            foreach (string type in cmbType.Items)
            {
                if (type == _settings.DatabaseBrowserSettings.TypeFilter)
                    cmbType.SelectedItem = type;
            }

            foreach (string type in cmbDatabase.Items)
            {
                if (type == _settings.DatabaseBrowserSettings.DatabaseFilter)
                    cmbDatabase.SelectedItem = type;
            }

            foreach (var tag in _settings.DatabaseBrowserSettings.TagFilter)
            {
                TagObject tagwinforms = new TagObject(tag, RebindGridUsingFilter);
                tagwinforms.Init();
                flowLayoutPanelTags.Controls.Add(tagwinforms);
            }

            flowLayoutPanelTags.Padding = new Padding(3, 3, 3, 3);

            if (_settings.DatabaseBrowserSettings.WindowHeight > 0 && _settings.DatabaseBrowserSettings.WindowWidth > 0)
            {
                Height = _settings.DatabaseBrowserSettings.WindowHeight;
                Width = _settings.DatabaseBrowserSettings.WindowWidth;
            }
        }

        private void SetDatabaseGridWidths()
        {
            int count = 1;
            foreach (var setting in _settings.DatabaseBrowserSettings.DatabaseGridColumnWidths)
            {
                if (count <= dataGridViewEntryList.Columns.Count)
                    dataGridViewEntryList.Columns[count - 1].Width = setting;
                count++;
            }
            count = 1;
            foreach (var setting in _settings.DatabaseBrowserSettings.RelatedGridColumnWidths)
            {
                if (count <= dataGridViewChildEntries.Columns.Count)
                    dataGridViewChildEntries.Columns[count - 1].Width = setting;
                count++;
            }
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

            SetDatabaseGridWidths();
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

        public void SearchByText(string text, DateTime startDate, DateTime endDate, List<string> tags, string typeFilter = "All", string databaseFilter = "All")
        {
            _loading = true; //Don't cause excessive rebinds
            dateTimePickerEnd.Value = endDate;
            dateTimePickerBegin.Value = startDate;
            ClearAllTags();
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    TagObject tagwinforms = new TagObject(tag, RebindGridUsingFilter); //Pass in action on what to do if a tag is removed
                    tagwinforms.Init();
                    flowLayoutPanelTags.Controls.Add(tagwinforms);
                }
            }
            cmbType.SelectedItem = typeFilter;
            cmbDatabase.SelectedItem = databaseFilter;
            _loading = false;
            txtSearch.Text = text;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RebindGridUsingFilter(); //Don't filter by _loading here as this triggers the grid population
        }

        private List<DatabaseBrowserEntry> GetEntriesByFilterCriteria()
        {
            string searchTerm = txtSearch.Text.ToLower();
            IEnumerable<DatabaseBrowserEntry> list;
            list = _dbManager.Entries.Where(p => //(p.Title.FuzzyMatch(txtSearch.Text) > .1)
            p.Title.ToLower().Contains(searchTerm)
            || p.Description.ToLower().Contains(searchTerm)
            ); //Search by text

            list = list.Where(p => p.LastUpdated <= dateTimePickerEnd.Value.EndOfDay()
                && p.LastUpdated >= dateTimePickerBegin.Value.BeginningOfDay());

            if (cmbType.SelectedValue != null && cmbType.SelectedValue.ToString() != "All")
            {
                MajorCategory type = cmbType.SelectedValue.ToString().GetValueFromDescription<MajorCategory>();
                list = list.Where(p => p.Type == type);
            }
            if (cmbDatabase.SelectedItem != null && cmbDatabase.SelectedItem.ToString() != "All")
            {
                list = list.Where(p => p.DatabaseName == cmbDatabase.SelectedItem.ToString());
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
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            var list = GetEntriesByFilterCriteria();
            vpinDatabaseSettingBindingSource.DataSource = list.ToSortableBindingList();
            var tags = _dbManager.GetAllTags(list.ToList(), false).OrderBy(c => c).ToList();
            tags.Insert(0, "(Select Tag)");
            cmbTags.DataSource = tags;
            UpdateToolstripStatus();
            //watch.Stop();
            //Debug.WriteLine("Rebind took: " + watch.Elapsed);
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
            //else if (result.FunctionExecuted == DatabaseManagerBackgroundProgressAction.RebindDatabaseBrowserGrid.ToString())
            //{
            //    var list = vpinDatabaseSettingBindingSource.DataSource as SortableBindingList<DatabaseBrowserEntry>;
            //    var tags = _dbManager.GetAllTags(list.ToList(), false).OrderBy(c => c).ToList();
            //    tags.Insert(0, "(Select Tag)");
            //    cmbTags.DataSource = tags;
            //    UpdateToolstripStatus();
            //}
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
            //else if (arg.Action == DatabaseManagerBackgroundProgressAction.RebindDatabaseBrowserGrid)
            //{
            //    RebindGridUsingFilter();
            //    var toolResult = new ToolResult()
            //    {
            //        IsValid = true,
            //    };
            //    toolResult.ToolName = DatabaseManager.ToolName;
            //    toolResult.MessageType = ValidationMessageType.ToolMessage;
            //    toolResult.FunctionExecuted = DatabaseManagerBackgroundProgressAction.RebindDatabaseBrowserGrid.ToString();
            //    e.Result = toolResult;
            //}
        }

        private BackgroundWorker CreateBackgroundWorker()
        {
            var bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.DoWork += backgroundWorkerProgressBar_DoWork;
            bw.RunWorkerCompleted += backgroundWorkerProgressBar_RunWorkerCompleted;
            return bw;
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
            //Autosize the columns only if the user hasn't customized the grid settings or it saved the last
            //grid column sizes after first run of the program
            if (e.ListChangedType != ListChangedType.Reset && _settings.DatabaseBrowserSettings.DatabaseGridColumnWidths.Count == 0)
            {
                dataGridViewEntryList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            //dataGridViewEntryList.FastAutoSizeColumns();
            //var colSizes = WinformsExtensions.GetAutoSizeColumnsWidth(dataGridViewEntryList);
            //WinformsExtensions.SetAutoSizeColumnsWidth(dataGridViewEntryList, colSizes);
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
                RebindGridUsingFilter();
        }

        private void dateTimePickerBegin_ValueChanged(object sender, EventArgs e)
        {
            if (!_loading)
                RebindGridUsingFilter();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (!_loading)
                RebindGridUsingFilter();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_loading)
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
                if (!_loading)
                    RebindGridUsingFilter();
            }
        }

        private void ClearAllTags()
        {
            flowLayoutPanelTags.Controls.Clear();
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
            if (e.ListChangedType != ListChangedType.Reset && _settings.DatabaseBrowserSettings.RelatedGridColumnWidths.Count == 0)
            {
                dataGridViewEntryList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
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

            settings.DatabaseGridColumnWidths = new List<int>();
            foreach (DataGridViewColumn column in dataGridViewEntryList.Columns)
            {
                settings.DatabaseGridColumnWidths.Add(column.Width);
            }

            settings.RelatedGridColumnWidths = new List<int>();
            foreach (DataGridViewColumn column in dataGridViewChildEntries.Columns)
            {
                settings.RelatedGridColumnWidths.Add(column.Width);
            }

            settings.WindowHeight = Height;
            settings.WindowWidth = Width;

            _settings.DatabaseBrowserSettings = settings;

            _settingManager.SaveSettings(_settings);
        }

        private void chkFuzzyMatch_CheckedChanged(object sender, EventArgs e)
        {
            if (!_loading)
                RebindGridUsingFilter();
        }

        private DatabaseBrowserEntry GetActiveRow()
        {
            var data = dataGridViewEntryList.DataSource as BindingSource;
            return data.Current as DatabaseBrowserEntry;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = GetActiveRow();
            if (row != null)
            {
                var entryForm = new EditDatabaseEntryForm(cmbDatabase.SelectedItem.ToString(), row, _dbManager, _ipdbForm);
                var result = entryForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    //Reload the settings incase a new database was added
                    _settings = _settingManager.LoadSettings();

                    var contentDatabase = _settings.Databases.First(c => c.Name == cmbDatabase.SelectedItem.ToString());

                    var dbFile = entryForm.GetUpdatedDatabaseEntry();
                    dbFile = _dbManager.SanitizeEntry(dbFile);
                    //Upon Successful response update the entries list (_dbManager.Entires)
                    //var updatedDatabaseEntry = _dbManager.GetDatabaseBrowserEntry(contentDatabase, entryForm.GetUpdatedDatabaseEntry());

                    //Save the entry to the corresponding _dbManager.Databases (this happens automatically as we update the reference to it)
                    //var test = _dbManager.Databases[cmbDatabase.SelectedItem.ToString()].Entries.Where(c => c.Id == dbFile.Id);
                    var databasePath = _dbManager.GetFilesystemWorkPath(contentDatabase);
                    var databaseToSave = _dbManager.Databases[cmbDatabase.SelectedItem.ToString()];
                    _dbManager.SaveDatabaseCache<PinballDatabase>(databaseToSave, databasePath); //Save the actual database .json file

                    //Save the pre-processed database to the file system
                    var existingEntry = _dbManager.Entries.FirstOrDefault(c => c.Id == dbFile.Id);
                    _dbManager.MapDatabaseEntryToBrowserEntry(contentDatabase, dbFile, existingEntry);
                    _dbManager.SaveDatabaseCache<List<DatabaseBrowserEntry>>(_dbManager.Entries, _dbManager.PreprocessedDatabasePath);

                    //Refresh grid (will do that automatically)
                    NotifyUserOfSaveWarning();
                }
            }
        }

        public void NotifyUserOfSaveWarning()
        {
            if (!notifiedOfSaveWarning)
            {
                MessageBox.Show("Notice: Your entry has been saved to a temporary location. \r\n\r\n" +
                    "You must sync your changes before the entry is permanently  saved.\r\n\r\n" +
                    "If you fail to sync your changes and exist the program your changes could get overwritten by the scheduled refresh interval.\r\n\r\n" +
                    "If you don't want this to happen you can set the refresh interval to a very large value and always do manual refreshes or just remember to sync your changes before exiting the database browser.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                notifiedOfSaveWarning = true;
            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var entryForm = new EditDatabaseEntryForm(cmbDatabase.SelectedItem.ToString(), null, _dbManager, _ipdbForm);
            var result = entryForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                //Reload the settings incase a new database was added
                _settings = _settingManager.LoadSettings();

                var contentDatabase = _settings.Databases.First(c => c.Name == cmbDatabase.SelectedItem.ToString());

                var dbFile = entryForm.GetUpdatedDatabaseEntry();
                dbFile = _dbManager.SanitizeEntry(dbFile);
                //Upon Successful response update the entries list (_dbManager.Entires)
                //var updatedDatabaseEntry = _dbManager.GetDatabaseBrowserEntry(contentDatabase, entryForm.GetUpdatedDatabaseEntry());

                //Save tne entry to the corresponding _dbManager.Databases (this happens automatically as we update the reference to it)
                //var test = _dbManager.Databases[cmbDatabase.SelectedItem.ToString()].Entries.Where(c => c.Id == dbFile.Id);
                var databasePath = _dbManager.GetFilesystemWorkPath(contentDatabase);
                var databaseToSave = _dbManager.Databases[cmbDatabase.SelectedItem.ToString()];
                databaseToSave.Entries.Add(dbFile);
                _dbManager.SaveDatabaseCache<PinballDatabase>(databaseToSave, databasePath); //Save the actual database .json file

                //Save the pre-processed database to the file system
                //var existingEntry = _dbManager.Entries.FirstOrDefault(c => c.Id == dbFile.Id);
                var updatedDatabaseEntry = _dbManager.GetDatabaseBrowserEntry(contentDatabase, entryForm.GetUpdatedDatabaseEntry());
                _dbManager.Entries.Add(updatedDatabaseEntry);
                //_dbManager.MapDatabaseEntryToBrowserEntry(contentDatabase, dbFile, updatedDatabaseEntry);
                _dbManager.SaveDatabaseCache<List<DatabaseBrowserEntry>>(_dbManager.Entries, _dbManager.PreprocessedDatabasePath);

                //Refresh grid
                RebindGridUsingFilter();
                NotifyUserOfSaveWarning();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var row = GetActiveRow();
            if (row != null)
            {
                //Scan the database it's attached to to see how many related entries need to be removed

                //Prompt to user indicating how many other entries will be cleaned up

                //Remove the entry from _dbManager.Databases

                //Remove the entry from _dbManager.Entries

                //Save the actual database .json

                //Save the pre-processed database to the file system

                NotifyUserOfSaveWarning();
            }
        }
    }
}
