using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MiniTC.Model;

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
                FileManager.copyFile(LeftPanel, RightPanel);
                },
                o => (
                    LeftPanel.CurrentPath != null &&
                    RightPanel.CurrentPath != null &&
                    !LeftPanel.CurrentPath.Equals(RightPanel.CurrentPath) &&
                    LeftPanel.SelectedFile != null &&
                    LeftPanel.SelectedFile.Type == Model.FileTypes.types.FILE
                )));

        
    }
}
