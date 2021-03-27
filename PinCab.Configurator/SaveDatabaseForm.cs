using Octokit;
using PinCab.Utils.Models;
using PinCab.Utils.Utils;
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
    public partial class SaveDatabaseForm : Form
    {
        private DatabaseManager _dbManager { get; set; }
        private ProgramSettings _settings { get; set; }

        public SaveDatabaseForm(ProgramSettings settings, DatabaseManager dbManager)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            _dbManager = dbManager;
            _settings = settings;

            LoadDatabases();
            (new TabOrderManager(this)).SetTabOrder(TabOrderManager.TabScheme.AcrossFirst);
        }

        private void LoadDatabases()
        {
            foreach (var database in _settings.Databases)
            {
                checkedListBoxDatabases.Items.Add(database);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            txtLog.Text = string.Empty;
            foreach (var selectedDatabase in checkedListBoxDatabases.SelectedItems)
            {
                var db = selectedDatabase as ContentDatabase;
                var workPath = _dbManager.GetFilesystemWorkPath(db);
                if (db.IsUrl()) //Upload to Github
                {
                    //string message = $"Wrote file from: {workPath} to {finalLocation}";
                    if (string.IsNullOrEmpty(txtCommitMessage.Text))
                    {
                        txtLog.Text += $"Unable to update Git Repo: {db.Url}. You forgot to include a commit message.\r\n";
                        continue;
                    }
                    try
                    {
                        var client = new GitHubClient(new ProductHeaderValue("pincab-configurator"));
                        var tokenAuth = new Credentials(db.AccessToken);
                        client.Credentials = tokenAuth;

                        //Determine the Git url based off of the current fragement
                        var uri = new Uri(db.Url);
                        //Example: "https://github.com/xantari/DBRepoTest.git"
                        string username = uri.Segments[1].Replace("/", "");
                        string repoName = uri.Segments[2].Replace("/", "");
                        string branchName = uri.Segments[3].Replace("/", "");
                        //Directory path is everything from segments[4] and beyond
                        string dirPathAndFile = string.Empty;
                        for (int i = 4; i < uri.Segments.Count(); i++)
                        {
                            dirPathAndFile += uri.Segments[i];
                        }
                        string fileName = uri.Segments.Last().Replace("/", "");
                        var gitCloneUrl = "https://github.com/" + uri.Segments[1] + uri.Segments[2].Replace("/", "") + ".git";

                        var repos = await client.Repository.GetAllForCurrent();
                        var repo = repos.FirstOrDefault(c => c.CloneUrl.ToLower() == gitCloneUrl.ToLower());
                        if (repo != null)
                        {
                            var parent = await client.Git.Reference.Get(username, repoName, "heads/" + branchName);
                            //var tree = await client.Git.Tree.GetRecursive(repo.NodeId, "Test");
                            var latestCommit = await client.Git.Commit.Get(username, repoName, parent.Object.Sha);
                            var currentTree = await client.Git.Tree.GetRecursive(username, repoName, latestCommit.Tree.Sha);
                            var file = currentTree.Tree.FirstOrDefault(c => c.Path == dirPathAndFile);
                            if (file != null)
                            {
                                var blob = await client.Git.Blob.Get(username, repoName, file.Sha);
                                var newblob = new NewBlob();
                                newblob.Encoding = EncodingType.Base64;
                                //string textContent = File.ReadAllText(workPath);
                                var plainTextBytes = File.ReadAllBytes(workPath);
                                var base64 = Convert.ToBase64String(plainTextBytes);
                                newblob.Content = base64;
                                var addBlob = await client.Git.Blob.Create(username, repoName, newblob);
                                var nt = new NewTree();
                                //Code from here: https://github.com/octokit/octokit.net/issues/1610
                                currentTree.Tree
                                            .Where(x => x.Type != TreeType.Tree)
                                            .Select(x => new NewTreeItem
                                            {
                                                Path = x.Path,
                                                Mode = x.Mode,
                                                Type = x.Type.Value,
                                                Sha = x.Sha
                                            })
                                            .ToList()
                                            .ForEach(x => nt.Tree.Add(x));

                                //Remove the current file tree node
                                var treeNodeToRemove = nt.Tree.FirstOrDefault(c => c.Path == dirPathAndFile);
                                nt.Tree.Remove(treeNodeToRemove);

                                //Now add a new tree node to the file
                                var treeItem = new NewTreeItem();
                                treeItem.Path = file.Path;
                                treeItem.Mode = file.Mode;
                                treeItem.Type = TreeType.Blob;
                                treeItem.Sha = addBlob.Sha;
                                nt.Tree.Add(treeItem);

                                var newTree = await client.Git.Tree.Create(username, repoName, nt);
                                var newCommit = new NewCommit(txtCommitMessage.Text, newTree.Sha, parent.Object.Sha);
                                var commit = await client.Git.Commit.Create(username, repoName, newCommit);
                                var reference = await client.Git.Reference.Update(username, repoName, "heads/" + branchName, new ReferenceUpdate(commit.Sha));
                                Log.Information("Repository updated. {@repo}", reference);
                                txtLog.Text += $"Repository Updated. Repo: {repo.CloneUrl} Reference: {reference.Object.Sha}\r\n";
                            }
                            else 
                            {
                                Log.Information("Could not find file in repo. {repo}", db.Url);
                                txtLog.Text += $"Could not find file in repo. {db.Url}\r\n";
                            }
                            //var currentBlob = await client.Git.Blob.Get(username, repoName,)
                        }
                        else
                        {
                            string message = $"Repo not found or you don't have access. Name: {db.Name} Repo: {db.Url}";
                            txtLog.Text += message + "\r\n";
                            Log.Warning(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Error occurred: {ex}", ex.Message);
                        txtLog.Text += ex.Message + "\r\n\r\n";
                    }
                }
                else //Save to final file system location
                {
                    var finalLocation = db.Url;
                    string message = $"Wrote file from: {workPath} to {finalLocation}";
                    if (!File.Exists(workPath))
                    {
                        message = $"Work file has not been created yet. Did you enter atleast one entry yet? Work file: {workPath}";
                        txtLog.Text += message + "\r\n";
                        Log.Warning(message);
                        continue;
                    }
                    Log.Information(message);
                    File.Copy(workPath, finalLocation, true);
                    txtLog.Text += message + "\r\n";
                }
            }

            DialogResult = DialogResult.None;
            return;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
