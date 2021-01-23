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
    public partial class PinMameRomBrowserForm : Form
    {
        private readonly VpinMameUtil _util = new VpinMameUtil();
        private List<VpinMameRomSetting> _roms = new List<VpinMameRomSetting>();
        private VPinMAMELib.Controller _controller = new VPinMAMELib.Controller();
        public PinMameRomBrowserForm()
        {
            InitializeComponent();

            ConfigureGrid();
            LoadRomList();
        }

        private void LoadRomList()
        {
            if (!_util.KeyExists())
            {
                txtLog.Text = "VPinMame Registry key not found. Have you installed VPinMame and registered it yet?";
                return;
            }
            _roms = _util.GetAllRomDetails();
            vpinMameRomSettingBindingSource.DataSource = _roms.ToSortableBindingList();
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
            vpinMameRomSettingBindingSource.DataSource = _roms.Where(p => p.RomName.Contains(txtRomSearch.Text)).ToSortableBindingList();
        }

        private void contextMenuStripGridActions_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int rowIndex = GetActiveRowIndex();
            if (rowIndex == -1)
            {
                txtLog.Text = "Selected a row or cell first.";
                return;
            }
            if (e.ClickedItem == editToolStripMenuItem)
                ShowRomEditor();
            else if (e.ClickedItem == copySelectedCellValueToAllROMSToolStripMenuItem)
                CopyCellDataToAllRoms();
            else if (e.ClickedItem == copySelectedRowDataToAllROMSToolStripMenuItem)
                CopyRowDataToAllRoms();
            else if (e.ClickedItem == runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem)
                DisplayRomUsingPinMame(true);
            else if (e.ClickedItem == runROMUsingNativeVPinMameToolStripMenuItem)
                DisplayRomUsingPinMame(false);
            else if (e.ClickedItem == stopRunningROMToolStripMenuItem)
                StopRunningRom();
        }

        private void StopRunningRom()
        {
            if (_controller.Running)
                _controller.Stop();
            stopRunningROMToolStripMenuItem.Visible = false;
            runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem.Visible = true;
            runROMUsingNativeVPinMameToolStripMenuItem.Visible = true;
        }

        private void CopyRowDataToAllRoms()
        {
            if (backgroundWorkerProgressBar.IsBusy)
                return;
            if (dataGridViewRomList.SelectedRows.Count == 0)
            {
                MessageBox.Show("You must select a row first.");
                return;
            }
            var selectedRom = dataGridViewRomList.SelectedRows[0].DataBoundItem as VpinMameRomSetting;
            var result = MessageBox.Show("Are you sure?\r\n\r\nThis will copy all values from rom: " + selectedRom.RomName + " to all other ROMs.\r\n\r\n Note: This does NOT edit the \"default\" key.", "Are you sure?", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (!backgroundWorkerProgressBar.IsBusy)
                {
                    txtLog.Text = string.Empty;
                    var action = new PinmameBackgroundAction();
                    action.Action = BackgroundProgressAction.PinMameWriteRowDataToAllPreviousRunRoms;
                    action.Setting = selectedRom;
                    backgroundWorkerProgressBar.RunWorkerAsync(action);
                }
            }
        }

        private void CopyCellDataToAllRoms()
        {
            if (backgroundWorkerProgressBar.IsBusy)
                return;
            if (dataGridViewRomList.SelectedCells.Count == 0)
            {
                MessageBox.Show("You must select a cell first.");
                return;
            }
            if (dataGridViewRomList.SelectedCells[0].ColumnIndex == 0) //Don't allow copy of rom name cell
            {
                MessageBox.Show("You must select a valid cell first.");
                return;
            }
            var selectedRom = dataGridViewRomList.SelectedCells[0].OwningRow.DataBoundItem as VpinMameRomSetting;
            var highlightedCellValue = dataGridViewRomList.SelectedCells[0].OwningColumn.DataPropertyName;
            var result = MessageBox.Show("Are you sure?\r\n\r\nThis will copy cell value: " + highlightedCellValue + " from rom: " + selectedRom.RomName + " to all other ROMs.\r\n\r\n Note: This does NOT edit the \"default\" key.", "Are you sure?", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (!backgroundWorkerProgressBar.IsBusy)
                {
                    txtLog.Text = string.Empty;
                    var action = new PinmameBackgroundAction();
                    action.Action = BackgroundProgressAction.PinMameWriteCellDataToAllPreviousRunRoms;
                    action.Setting = selectedRom;
                    action.CellsToCopy.Add(highlightedCellValue);
                    backgroundWorkerProgressBar.RunWorkerAsync(action);
                }
            }
        }

        private void DisplayRomUsingPinMame(bool externalDmd)
        {
            try
            {
                var rom = GetActiveRowRom();
                if (_controller.Running)
                    _controller.Stop();

                //11/29/2020 - MRO: There is an issue re-starting pinmame if the user uses External DMD device, and you click
                //the "X" on the window (you can do that on the taskbar), which closes the DMD window.
                //However after that point you can no longer start a DMD window anymore and the _controller.Hidden
                //property is stuck at "true" and you can't ever get it back. Not sure the work around to it.
                //Reinstantiating the _controller object doesn't seem to work either for some reason.
                _controller.GameName = rom.RomName;
                _controller.ShowFrame = false;
                _controller.Hidden = false;
                _controller.ShowDMDOnly = true;
                _controller.ShowTitle = false;
                if (externalDmd)
                {
                    _controller.ShowWinDMD = false;
                    _controller.ShowPinDMD = true;
                }
                else
                {
                    _controller.ShowWinDMD = true;
                    _controller.ShowPinDMD = false;
                }
                _controller.Run();
                stopRunningROMToolStripMenuItem.Visible = true;
                runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem.Visible = false;
                runROMUsingNativeVPinMameToolStripMenuItem.Visible = false;
            }
            catch (Exception ex)
            {
                txtLog.Text = "Error starting PinMAME. Error: " + ex.ToString();
            }
        }

        private void ShowRomEditor()
        {
            var rom = GetActiveRowRom();
            var editor = new PinMameRomSettingEditorForm(rom, _controller);
            var result = editor.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {
            LoadRomList();
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

        private void dataGridViewRomList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowRomEditor();
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
            RefreshGrid();
        }

        private void backgroundWorkerProgressBar_DoWork(object sender, DoWorkEventArgs e)
        {
            var arg = (PinmameBackgroundAction)e.Argument;
            if (arg.Action == BackgroundProgressAction.PinMameWriteRowDataToAllPreviousRunRoms)
            {
                var result = _util.SetPinMamePositionAllROMs(arg.Setting, true, backgroundWorkerProgressBar.ReportProgress);
                var toolResult = new ToolResult(result);
                toolResult.ToolName = VpinMameUtil.ToolName;
                toolResult.MessageType = ValidationMessageType.ToolMessage;
                toolResult.FunctionExecuted = arg.Action.ToString();
                e.Result = toolResult;
            }
            else if (arg.Action == BackgroundProgressAction.PinMameWriteCellDataToAllPreviousRunRoms)
            {
                var result = _util.SetPinMamePositionAllROMs(arg.Setting, true, backgroundWorkerProgressBar.ReportProgress);
                var toolResult = new ToolResult(result);
                toolResult.ToolName = VpinMameUtil.ToolName;
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
            txtLog.Select(txtLog.Text.Length, 0);
            txtLog.ScrollToCaret();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xantari/PinCab.Configurator/wiki/PinMAME-ROM-Browser");
        }
    }
}
