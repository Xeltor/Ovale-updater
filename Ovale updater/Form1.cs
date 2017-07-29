using Ovale_updater.Enums;
using Ovale_updater.Functions;
using Ovale_updater.Github;
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

namespace Ovale_updater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Run();
        }

        private async void Run()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.WoWLocation) || 
                !Directory.Exists($"{Properties.Settings.Default.WoWLocation}\\interface\\addons") ||
                !Directory.Exists($"{Properties.Settings.Default.WoWLocation}\\interface\\addons\\{Repo.Xeltors_Ovale_Scripts}") ||
                !Directory.Exists($"{Properties.Settings.Default.WoWLocation}\\interface\\addons\\{Repo.Ovale}"))
            {
                EnableButton($"Install");
            }

            else
            {
                var git = new Git();

                string version = await git.BrancheVersion(Repo.Xeltors_Ovale_Scripts);
                string current = await git.CurrentVersion(Repo.Xeltors_Ovale_Scripts);

                if (version != current)
                {
                    DisableButton($"Updating Ovale Scripts");
                    await git.Update(Repo.Xeltors_Ovale_Scripts);
                }

                version = await git.BrancheVersion(Repo.Ovale);
                current = await git.CurrentVersion(Repo.Ovale);

                if (version != current)
                {
                    DisableButton($"Updating Ovale");
                    await git.Update(Repo.Ovale);
                }

                OvaleScriptsLogTextbox.Text = await git.Log(Repo.Xeltors_Ovale_Scripts);
                OvaleLogTextbox.Text = await git.Log(Repo.Ovale);

                EnableButton($"Update");
            }
        }

        public void EnableButton(string Text)
        {
            CombiButton.Enabled = true;
            CombiButton.Text = Text;
            CombiButton.BackColor = Color.Green;
        }

        public void DisableButton(string Text)
        {
            CombiButton.Enabled = false;
            CombiButton.Text = Text;
            CombiButton.BackColor = default(Color);
        }

        private async void CombiButton_Click(object sender, EventArgs e)
        {
            if (CombiButton.Text == "Install")
            {
                DisableButton($"Installing");
                var installer = new Installer();

                var result = await installer.FindWoW();

                switch(result)
                {
                    case Error.AddonFolderNotFound:
                        MessageBox.Show("Could not locate the World of Warcraft addons folder.", "Addons not found!");
                        EnableButton($"Install");
                        return;
                    case Error.CouldNotRemoveOvale:
                        MessageBox.Show("Could not remove Ovale from the addons folder, please remove it manually and try the install again.", "Ovale present!");
                        EnableButton($"Install");
                        return;
                    case Error.CouldNotRemoveOvaleScripts:
                        MessageBox.Show("Could not remove Xeltors_Ovale_Scripts from the addons folder, please remove it manually and try the install again.", "Xeltors Ovale Scripts present!");
                        EnableButton($"Install");
                        return;
                }

                var git = new Git();

                OvaleScriptsLogTextbox.Text = await git.Log(Repo.Xeltors_Ovale_Scripts);
                OvaleLogTextbox.Text = await git.Log(Repo.Ovale);

                EnableButton("Update");
            }

            else if (CombiButton.Text == "Update")
            {
                DisableButton($"Updating");

                var git = new Git();
                var log = "";

                string version = await git.BrancheVersion(Repo.Ovale);
                string current = await git.CurrentVersion(Repo.Ovale);

                if (version != current)
                {
                    log += $"Ovale: Updated to {version}" + Environment.NewLine;
                    await git.Update(Repo.Ovale);
                    OvaleLogTextbox.Text = await git.Log(Repo.Ovale);
                }
                else
                    log += $"Ovale: No updates." + Environment.NewLine;

                version = await git.BrancheVersion(Repo.Xeltors_Ovale_Scripts);
                current = await git.CurrentVersion(Repo.Xeltors_Ovale_Scripts);

                if (version != current)
                {
                    log += $"Ovale scripts: Updated to {version}";
                    await git.Update(Repo.Xeltors_Ovale_Scripts);
                    OvaleScriptsLogTextbox.Text = await git.Log(Repo.Xeltors_Ovale_Scripts);
                }
                else
                    log += $"Ovale scripts: No updates." + Environment.NewLine;
                
                MessageBox.Show(log, "Update completed");

                EnableButton($"Update");
            }
        }
    }
}
