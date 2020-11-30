using PinCab.ScreenUtil.Extensions;
using PinCab.ScreenUtil.Models;
using PinCab.ScreenUtil.Utils;
using PinCab.ScreenUtil.WinForms;
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
        private VPinMAMELib.Controller controller = new VPinMAMELib.Controller();
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
            {
                var rom = GetActiveRowRom();
                var editor = new PinMameRomSettingEditorForm(rom);
                var result = editor.ShowDialog();
            }
            else if (e.ClickedItem == copySelectedCellValueToAllROMSToolStripMenuItem)
            {

            }
            else if (e.ClickedItem == copySelectedRowDataToAllROMSToolStripMenuItem)
            {

            }
            else if (e.ClickedItem == runROMUsingExternalDMDDeviceDMDExtToolStripMenuItem)
            {

            }
            else if (e.ClickedItem == runROMUsingNativeVPinMameToolStripMenuItem)
            {

            }
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
    }
}
