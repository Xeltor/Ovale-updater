using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovale_updater.Functions
{
    class Filesystem
    {
        internal bool RemoveFolder(string FolderLocation)
        {
            try
            {
                var folder = new DirectoryInfo(FolderLocation);
                if (!EmptyFolder(folder))
                    return false;
                
                folder.Delete(true);
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool EmptyFolder(DirectoryInfo directoryInfo)
        {
            try
            {
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Attributes = FileAttributes.Normal;
                    file.Delete();
                }

                foreach (DirectoryInfo subfolder in directoryInfo.GetDirectories())
                {
                    if (!EmptyFolder(subfolder))
                        return false;
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
