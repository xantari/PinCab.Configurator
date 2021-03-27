using PinCab.Utils.Extensions;
using PinCab.Utils.Models;
using PinCab.Utils.Utils;
using PinCab.Utils.ViewModels;
using PinCab.Utils.WinForms.TabOrder;
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
    public partial class RenameGameForm : Form
    {
        private FrontEndManager _manager { get; set; }
        private FrontEndGameViewModel _setting { get; set; }
        private string _newName { get; set; }
        public RenameGameForm(FrontEndGameViewModel setting, string newName, FrontEndManager manager)
        {
            InitializeComponent();
            _manager = manager;
            _setting = setting;
            _newName = newName;
            LoadData();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
        }

        private void LoadData()
        {
            lblCurrentName.Text = _setting.FileName;
            lblNewName.Text = _newName;

            if (!string.IsNullOrEmpty(_setting.FullPathToB2s))
                chkFilesToRename.Items.Add(_setting.FullPathToB2s, true);
            if (!string.IsNullOrEmpty(_setting.FullPathToTable))
                chkFilesToRename.Items.Add(_setting.FullPathToTable, true);
            foreach(var file in _setting.MediaItems)
            {
                chkFilesToRename.Items.Add(file.MediaFullPath, true);
            }
            chkSelectAll.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var oldName = _setting.FileName;
            _setting.FileName = _newName;

            //Rename all the selected files
            for (int i = 0; i < chkFilesToRename.Items.Count; i++)
            {
                if (chkFilesToRename.GetItemChecked(i))
                {
                    var fileToRename = chkFilesToRename.Items[i].ToString();
                    var fileInfo = new FileInfo(fileToRename);
                    var newFilePath = $"{fileInfo.DirectoryName}\\{_newName}{fileInfo.Extension}";
                    File.Move(fileToRename, newFilePath);
                }
            }

            //Save the database
            _manager.SaveGame(_setting, oldName);
            //Refresh the model as they may not have selected all files to rename. In this case
            //what happens is that some of the media audit statuses disappear
            _manager.RefreshGameModel(_setting, _manager.GetPinballXSystemByDatabaseFile(_setting.DatabaseFile));

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for(int i = 0; i < chkFilesToRename.Items.Count; i++)
            {
                chkFilesToRename.SetItemChecked(i, chkSelectAll.Checked);
            }
        }
    }
}
