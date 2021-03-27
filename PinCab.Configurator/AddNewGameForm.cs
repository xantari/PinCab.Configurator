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
    public partial class AddNewGameForm : Form
    {
        private string _databaseFile { get; set; }
        private FrontEndManager _manager { get; set; }
        private FrontEnd _frontEnd { get; set; }
        public AddNewGameForm(FrontEnd frontEnd, string databaseFile, FrontEndManager manager)
        {
            InitializeComponent();
            _databaseFile = databaseFile;
            _manager = manager;
            _frontEnd = frontEnd;
            LoadNewEntries();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
        }

        private void LoadNewEntries()
        {
            if (_frontEnd.System == FrontEndSystem.PinballX)
            {
                var selectedSystem = _manager.GetPinballXSystemByDatabaseFile(_databaseFile);
                var gameList = _manager.GetGamesForFrontEndAndDatabase(_frontEnd, _databaseFile);

                //Now find all files in the systems folder that don't already exist in the gameList
                var di = new DirectoryInfo(selectedSystem.TablePath);
                if (di.Exists)
                {
                    var files = di.GetFiles();
                    var tablePathsAlreadyInDatabase = gameList.Select(c => c.FullPathToTable);
                    foreach (var file in files)
                    {
                        if (selectedSystem.Type == Platform.VP &&
                            file.Extension.In(".vpt", ".vpx") &&
                            !tablePathsAlreadyInDatabase.Any(c => c == file.FullName))
                        {
                            lstFiles.Items.Add(file.FullName);
                        }
                        else if (selectedSystem.Type == Platform.FP &&
                            file.Extension.In(".fpt") &&
                            !tablePathsAlreadyInDatabase.Any(c => c == file.FullName))
                        {
                            lstFiles.Items.Add(file.FullName);
                        }
                    }
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
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
    }
}
