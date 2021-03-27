using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Utils;
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
    public partial class AddDatabaseForm : Form
    {
        private readonly ProgramSettingsManager _settingManager = new ProgramSettingsManager();
        private ProgramSettings _settings { get; set; }

        public AddDatabaseForm()
        {
            InitializeComponent();

            cmbContentDatabaseType.DataSource = EnumExtensions.GetEnumDescriptionList<DatabaseType>();
            _settings = _settingManager.LoadSettings();
            DialogResult = DialogResult.None;
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public ContentDatabase GetContentDatabaseFromForm()
        {
            var cd = new ContentDatabase()
            {
                AccessToken = txtContentDatabaseAccessToken.Text,
                Name = txtContentDatabaseName.Text,
                Url = txtContentDatabaseUrl.Text,
                Type = cmbContentDatabaseType.SelectedItem.ToString().GetValueFromDescription<DatabaseType>()
            };
            return cd;
        }

        private bool ValidateForm()
        {
            var dbAlreadyExists = _settings.Databases.Any(c => c.Name.ToLower() == txtContentDatabaseName.Text.ToLower());
            if (dbAlreadyExists)
            {
                MessageBox.Show("Database already exists with this name: " + txtContentDatabaseName.Text);
                return false;
            }
            if (string.IsNullOrEmpty(txtContentDatabaseName.Text))
            {
                MessageBox.Show("Database name is required.");
                return false;
            }
            if (string.IsNullOrEmpty(txtContentDatabaseUrl.Text))
            {
                MessageBox.Show("Database path / url is required.");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid = ValidateForm();

            if (valid)
            {
                var newCb = GetContentDatabaseFromForm();
                _settings.Databases.Add(newCb);
                _settingManager.SaveSettings(_settings);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnContentDatabaseUrl_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(txtContentDatabaseUrl.Text);
        }

        private void btnFilePathDatabaseBrowser_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "JSON Files|*.json|All files (*.*)|*.*";
                fileDialog.RestoreDirectory = true;
                var result = fileDialog.ShowDialog(this);
                if (result == DialogResult.OK)
                    txtContentDatabaseUrl.Text = fileDialog.FileName;
            }
        }
    }
}
