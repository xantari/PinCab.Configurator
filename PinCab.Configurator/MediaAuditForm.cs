using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Models.PinballX;
using PinCab.Utils.Utils;
using PinCab.Utils.ViewModels;
using PinCab.Utils.WinForms.TabOrder;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCab.Configurator
{
    public partial class MediaAuditForm : Form
    {
        private readonly FrontEndManager _manager = new FrontEndManager();
        private List<FrontEndGameViewModel> _fullGameListCache { get; set; }
        public MediaAuditForm()
        {
            InitializeComponent();

            InitForm();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
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
        }

        private void ConfigureGrid()
        {
            foreach (DataGridViewColumn column in dataGridViewAuditList.Columns)
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
                RefreshAuditGrid(frontEnd);
            }
        }

        private void RefreshAuditGrid(FrontEnd frontEnd)
        {
            if (frontEnd.System == FrontEndSystem.PinballX)
            {
                var results = _manager.GetMediaAuditResults(frontEnd);
                dataGridViewAuditList.DataSource = results.ToSortableBindingList();
            }
            else
                MessageBox.Show("Front End Not implemented yet.");
        }

        //private void GameManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    //Save the settings of the grid and last selected front end
        //    if (cmbFrontEnd.SelectedIndex >= 0)
        //    {
        //        _manager.Settings.LastSelectedFrontEnd = (cmbFrontEnd.SelectedItem as FrontEnd).Name;
        //    }
        //    _manager.SaveSettings(_manager.Settings);
        //}

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/xantari/PinCab.Configurator/wiki/Media-Audit");
        }

        private void dataGridViewAuditList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridViewAuditList.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewAuditList.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show($"Are you sure you want to delete the {dataGridViewAuditList.SelectedRows.Count} media items?", "Are you sure?", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    foreach(DataGridViewRow row in dataGridViewAuditList.SelectedRows)
                    {
                        var itm = row.DataBoundItem as MediaAuditResult;
                        File.Delete(itm.FullPathToFile);
                        dataGridViewAuditList.Rows.Remove(row);
                    }
                }
            }
            else 
            {
                MessageBox.Show("You must select one or more rows.");
            }
        }
    }
}
