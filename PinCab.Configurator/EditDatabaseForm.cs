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
using VirtualPinball.Database.Models;

namespace PinCab.Configurator
{
    public partial class EditDatabaseForm : Form
    {
        private PinballDatabase db { get; set; }
        public EditDatabaseForm(PinballDatabase database)
        {
            InitializeComponent();

            db = database;
            DialogResult = DialogResult.None;
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);

            lblLastUpdated.Text = database.LastUpdateDateUtc.ToString() + " Local: " + database.LastUpdateDateUtc.ToLocalTime();
            txtContactUrl.Text = database.ContactUrl;
            txtDescription.Text = database.Description;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public PinballDatabase SetDatabaseData()
        {
            db.ContactUrl = txtContactUrl.Text;
            db.Description = txtDescription.Text;
            return db;
        }

        private bool ValidateForm()
        {
            if (!string.IsNullOrEmpty(txtContactUrl.Text) &&
                !(txtContactUrl.Text.StartsWith("http") || txtContactUrl.Text.StartsWith("mailto")))
            {
                MessageBox.Show("Contact Url must start with http:/https: or mailto:");
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool valid = ValidateForm();

            if (valid)
            {
                SetDatabaseData();
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
