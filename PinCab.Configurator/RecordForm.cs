using PinCab.Utils.Models;
using PinCab.Utils.Utils;
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
    public partial class RecordForm : Form
    {
        private readonly FrontEndManager _manager = new FrontEndManager();

        public RecordForm()
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

            if (_manager.Settings.RecordingSettings != null)
            {
                txtStartupDelaySeconds.Text = _manager.Settings.RecordingSettings.RecordTimeStartupDelaySeconds.ToString();
                txtFramerate.Text = _manager.Settings.RecordingSettings.RecordFramerate.ToString();
                txtRecordTimeSeconds.Text = _manager.Settings.RecordingSettings.RecordTimeSeconds.ToString();

                if (!string.IsNullOrEmpty(_manager.Settings.RecordingSettings.LastSelectedRecordingMethod))
                {
                    foreach (var itm in cmbMethod.Items)
                    {
                        if (itm.ToString() == _manager.Settings.RecordingSettings.LastSelectedRecordingMethod)
                            cmbMethod.SelectedItem = itm;
                    }
                }
                if (!string.IsNullOrEmpty(_manager.Settings.RecordingSettings.PlayfieldRecordMode))
                {
                    foreach (var itm in cmbPlayfield.Items)
                    {
                        if (itm.ToString() == _manager.Settings.RecordingSettings.PlayfieldRecordMode)
                            cmbPlayfield.SelectedItem = itm;
                    }
                }
                if (!string.IsNullOrEmpty(_manager.Settings.RecordingSettings.BackglassRecordMode))
                {
                    foreach (var itm in cmbBackglass.Items)
                    {
                        if (itm.ToString() == _manager.Settings.RecordingSettings.BackglassRecordMode)
                            cmbBackglass.SelectedItem = itm;
                    }
                }
                if (!string.IsNullOrEmpty(_manager.Settings.RecordingSettings.DMDRecordMode))
                {
                    foreach (var itm in cmbDMD.Items)
                    {
                        if (itm.ToString() == _manager.Settings.RecordingSettings.DMDRecordMode)
                            cmbDMD.SelectedItem = itm;
                    }
                }
                if (!string.IsNullOrEmpty(_manager.Settings.RecordingSettings.TopperRecordMode))
                {
                    foreach (var itm in cmbTopper.Items)
                    {
                        if (itm.ToString() == _manager.Settings.RecordingSettings.TopperRecordMode)
                            cmbTopper.SelectedItem = itm;
                    }
                }
                if (!string.IsNullOrEmpty(_manager.Settings.RecordingSettings.FullDMDRecordMode))
                {
                    foreach (var itm in cmbFullDMD.Items)
                    {
                        if (itm.ToString() == _manager.Settings.RecordingSettings.FullDMDRecordMode)
                            cmbFullDMD.SelectedItem = itm;
                    }
                }
                if (!string.IsNullOrEmpty(_manager.Settings.RecordingSettings.ApronRecordMode))
                {
                    foreach (var itm in cmbApron.Items)
                    {
                        if (itm.ToString() == _manager.Settings.RecordingSettings.ApronRecordMode)
                            cmbApron.SelectedItem = itm;
                    }
                }
            }
        }

        private void ConfigureGrid()
        {
            foreach (DataGridViewColumn column in dataGridViewGameList.Columns)
            {
                if (column.SortMode != DataGridViewColumnSortMode.NotSortable)
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.Resizable = DataGridViewTriState.True;
            }

            SetDatabaseGridWidths();
        }

        private void SetDatabaseGridWidths()
        {
            int count = 1;
            foreach (var setting in _manager.Settings.RecordingSettings.DatabaseGridColumnWidths)
            {
                if (count <= dataGridViewGameList.Columns.Count)
                    dataGridViewGameList.Columns[count - 1].Width = setting;
                count++;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {

        }

        private void RecordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int value;
            bool success = int.TryParse(txtRecordTimeSeconds.Text, out value);
            if (success)
                _manager.Settings.RecordingSettings.RecordTimeStartupDelaySeconds = value;

            success = int.TryParse(txtFramerate.Text, out value);
            if (success)
                _manager.Settings.RecordingSettings.RecordFramerate = value;

            success = int.TryParse(txtStartupDelaySeconds.Text, out value);
            if (success)
                _manager.Settings.RecordingSettings.RecordTimeStartupDelaySeconds = value;

            _manager.Settings.RecordingSettings.DatabaseGridColumnWidths = new List<int>();
            foreach (DataGridViewColumn column in dataGridViewGameList.Columns)
            {
                _manager.Settings.RecordingSettings.DatabaseGridColumnWidths.Add(column.Width);
            }

            _manager.Settings.RecordingSettings.WindowHeight = Height;
            _manager.Settings.RecordingSettings.WindowWidth = Width;

            _manager.Settings.RecordingSettings.LastSelectedRecordingMethod = cmbMethod.Text;
            _manager.Settings.RecordingSettings.PlayfieldRecordMode = cmbPlayfield.Text;
            _manager.Settings.RecordingSettings.BackglassRecordMode = cmbBackglass.Text;
            _manager.Settings.RecordingSettings.DMDRecordMode = cmbDMD.Text;
            _manager.Settings.RecordingSettings.TopperRecordMode = cmbTopper.Text;
            _manager.Settings.RecordingSettings.FullDMDRecordMode = cmbFullDMD.Text;
            _manager.Settings.RecordingSettings.ApronRecordMode = cmbApron.Text;

            _manager.SaveSettings(_manager.Settings);
        }
    }
}
