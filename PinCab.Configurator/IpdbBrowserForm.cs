using DuoVia.FuzzyStrings;
using Ipdb.Models;
using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Utils;
using PinCab.Utils.WinForms;
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

namespace PinCab.Configurator
{
    public partial class IpdbBrowserForm : Form
    {
        private readonly DatabaseManager _dbManager = new DatabaseManager();
        private bool _hideForm = false; //for faster loading
        public IpdbBrowserForm(string startText = "", bool hideForm = false)
        {
            InitializeComponent();
            //ConfigureGrid();
            LoadDatabase();
            SearchGrid(startText);
            _hideForm = hideForm;
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
        }

        private void LoadDatabase()
        {
            var ipdbDatabase = _dbManager.GetIpdbContentDatabase();
            if (!_dbManager.DatabaseWorkFileExistsOnFilesystem(ipdbDatabase))
            {
                _dbManager.DownloadDatabase(ipdbDatabase, true);
            }
                
            _dbManager.LoadDatabase(ipdbDatabase);
        }

        private void ConfigureGrid()
        {
            foreach (DataGridViewColumn column in dataGridViewIpdb.Columns)
            {
                if (column.SortMode != DataGridViewColumnSortMode.NotSortable)
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.Resizable = DataGridViewTriState.True;
            }
            dataGridViewIpdb.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        public IpdbResult GetActiveRowEntry()
        {
            var data = ipdbDatabaseSettingBindingSource.Current as IpdbResult;
            return data;
        }

        private void SearchGrid(string text)
        {
            List<IpdbResult> results = new List<IpdbResult>();
            if (!string.IsNullOrEmpty(text))
            {
                results = _dbManager.IpdbDatabase.Data.Where(p => p.Title.FuzzyMatch(txtSearch.Text.ToLower()) > .5).ToList(); //Search by text
            }
    
            else
                results = _dbManager.IpdbDatabase.Data;

            ipdbDatabaseSettingBindingSource.DataSource = results.ToSortableBindingList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_hideForm)
                this.Hide();
            else
                this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (_hideForm)
                this.Hide();
            else
                this.Close();
        }

        private void dataGridViewIpdb_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //if (e.ListChangedType != ListChangedType.Reset)
            //{
            //    dataGridViewIpdb.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //}

            var results = ipdbDatabaseSettingBindingSource.DataSource as SortableBindingList<IpdbResult>;
            if (results != null && !string.IsNullOrEmpty(txtSearch.Text))
            {
                dataGridViewIpdb.ClearSelection();
                var options = results.Select(p => p.Title.LongestCommonSubsequence(txtSearch.Text)).ToList();
                //Find the index with the highest value and default select it
                var bestOption = options.OrderByDescending(p => p.Item2).FirstOrDefault();
                if (bestOption != null)
                {
                    var indexOfBest = options.IndexOf(bestOption);
                    dataGridViewIpdb.Rows[indexOfBest].Selected = true;
                    dataGridViewIpdb.CurrentCell = dataGridViewIpdb.Rows[indexOfBest].Cells[0]; //Scroll into view
                }
            }
        }

        public void SearchText(string text)
        {
            txtSearch.Text = text;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchGrid(txtSearch.Text);
        }

        private void dataGridViewIpdb_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1)
                return;
            this.DialogResult = DialogResult.OK;
            if (_hideForm)
                this.Hide();
            else
                this.Close();
        }
    }
}
