using Ovale_updater.Enums;
using Ovale_updater.Github;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ovale_updater.Functions
{
    class Installer
    {
        internal async Task<Error> FindWoW()
        {
            MessageBox.Show($"Please select the installation location of your World of Warcraft game client.", "WoW Location?");

            string location = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                location = folderBrowserDialog1.SelectedPath;
            }

            if (!Directory.Exists($"{location}\\interface\\addons"))
                return Error.AddonFolderNotFound;

            var fs = new Filesystem();
            if (Directory.Exists($"{location}\\interface\\addons\\{Repo.Ovale}"))
            {
                var result = fs.RemoveFolder($"{location}\\interface\\addons\\{Repo.Ovale}");

                if (!result)
                    return Error.CouldNotRemoveOvale;
            }

            if (Directory.Exists($"{location}\\interface\\addons\\{Repo.Xeltors_Ovale_Scripts}"))
            {
                var result = fs.RemoveFolder($"{location}\\interface\\addons\\{Repo.Xeltors_Ovale_Scripts}");

                if (!result)
                    return Error.CouldNotRemoveOvaleScripts;
            }

            Properties.Settings.Default.WoWLocation = location;
            Properties.Settings.Default.Save();

            var git = new Git();

            await git.Clone(Repo.Ovale);
            await git.Clone(Repo.Xeltors_Ovale_Scripts);

            return Error.None;
        }

        internal bool UpdateAddons()
        {
            return true;
        }
    }
}
