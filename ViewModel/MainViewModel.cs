using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO;

namespace MiniTC.ViewModel
{
    public class MainViewModel
    {
        private readonly PanelViewModel leftPanel;
        private readonly PanelViewModel rightPanel;

        public PanelViewModel LeftPanel
        {
            get { return leftPanel; }
        }
        public PanelViewModel RightPanel
        {
            get { return rightPanel; }
        }

        public MainViewModel()
        {
            leftPanel = new PanelViewModel();
            rightPanel = new PanelViewModel();
        }

        private ICommand copy;
        public ICommand Copy => copy ?? (copy =
            new RelayCommand(
                o => {
                copyFile();
                },
                o => (
                    LeftPanel.CurrentPath != null &&
                    RightPanel.CurrentPath != null &&
                    !LeftPanel.CurrentPath.Equals(RightPanel.CurrentPath) &&
                    LeftPanel.SelectedFile != null &&
                    LeftPanel.SelectedFile.Type == Model.FileTypes.types.FILE
                )));

        public void copyFile()
        {
                string file = LeftPanel.SelectedFile.Name;
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(RightPanel.CurrentPath, fileName);
                File.Copy(file, destFile, true);
                LeftPanel.UpdateFileList(LeftPanel.CurrentPath);
                RightPanel.UpdateFileList(RightPanel.CurrentPath);
                MessageBox.Show($"File {file} coppied to {destFile} successfully.");

        }
    }
}
