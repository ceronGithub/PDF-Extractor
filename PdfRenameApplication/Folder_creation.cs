using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfRenameApplication
{
    internal class Folder_creation
    {
        string pathFolder = @"" + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Desktop\\PDF-OUTPUT";
        string project = "";

        public string folderPathStringMain()
        {
            return pathFolder;
        }

        public string folderPathStringProject()
        {
            return project = pathFolder + "\\Report on - " + DateTime.Now.ToString("MM-dd-yyyy");
        }

        public void folderCreationMainFolder()
        {
            if (!Directory.Exists(folderPathStringMain()))
            {
                // create folder
                Directory.CreateDirectory(folderPathStringMain());
                MessageBox.Show("Folder is created @ \n" + folderPathStringMain());
            }
            else
            {
                //MessageBox.Show("Folder compilation is existing.");
            }
        }

        public void folderCreationProjectFolder()
        {
            if (!Directory.Exists(folderPathStringProject()))
            {
                // create folder
                Directory.CreateDirectory(folderPathStringProject());
                MessageBox.Show("Folder is created @ \n" + folderPathStringProject());
            }
            else
            {
                //MessageBox.Show("Folder compilation is existing.");
            }
        }
    }
}
