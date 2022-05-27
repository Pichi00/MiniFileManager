using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using MiniTC.ViewModel;

namespace MiniTC.Model
{
    public class FileManager
    {
        public static string[] getDrives()
        {
            return Directory.GetLogicalDrives();
        } 

        public static string getParentPath(string path)
        {
            if(Directory.GetParent(path) == null)
            {
                return path;
            }
            return Directory.GetParent(path).FullName;
        }

        public static List<FileModel> updateSubfolders(string path)
        {
            List<FileModel> subfolders = new List<FileModel>();
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            foreach (string d in directories)
            {
                subfolders.Add(new FileModel(d, FileTypes.types.DIR));
            }
            foreach (string f in files)
            {
                subfolders.Add(new FileModel(f, FileTypes.types.FILE));
            }
            return subfolders;
        }

        public static void copyFile(PanelViewModel source, PanelViewModel destination)
        {
            string file = source.SelectedFile.Name;
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(destination.CurrentPath, fileName);
            File.Copy(file, destFile, true);
            source.CurrentSubfolders = FileManager.updateSubfolders(source.CurrentPath);
            destination.CurrentSubfolders = FileManager.updateSubfolders(destination.CurrentPath);
            MessageBox.Show($"File {file} coppied to {destFile} successfully.");

        }
    }
}
