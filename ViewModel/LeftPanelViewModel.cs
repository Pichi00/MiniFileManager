using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.IO;

namespace MiniTC.ViewModel
{
    class LeftPanelViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Model.PathManager pathManager = new Model.PathManager();
        public View.Panel leftPanel = new View.Panel();
        public View.Panel rightPanel = new View.Panel();

        public LeftPanelViewModel()
        {
            UpdateLeftPathCommand = new RelayCommand(updateLeftPath, null);
        }

        

        private string leftDrive = "X:\\";
        public string LeftDrive
        {
            get => leftDrive;
            set
            {
                leftDrive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LeftDrive)));
            }
        }
        public void setCurrDrive(string cd)
        {
            LeftDrive = cd;
        }

        private string currentPath = "C:\\";
        public string CurrentPath
        {
            get => currentPath;
            set
            {
                currentPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPath)));
            }
        }

        private string[] currentSubfolders;

        public string[] CurrentSubfolders
        {
            get => currentSubfolders;
            set
            {
                currentSubfolders = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentSubfolders)));
            }
        }

       

        /*private ICommand updatePathEvent;
        //public ICommand UpdatePathEvent => updatePathEvent ?? (updatePathEvent = new RelayCommand(o => CurrentPath = CurrentDrive, null));
        public ICommand UpdatePathEvent
        {
            get
            {
                CurrentDrive = leftPanel.currDrive;
                updatePathEvent = new RelayCommand(o => CurrentPath = CurrentDrive, null);
                return updatePathEvent;
            }
        }*/

        public ICommand UpdateLeftPathCommand { get; set; }

        private void updateLeftPath(object sender)
        {
            
            if(sender == null)
            {
                Console.WriteLine("null");
            }
            else
            {
                Console.WriteLine(leftPanel.currDrive.ToString());
            }
            
        }

        private ICommand getSubfoldersEvent;
        public ICommand GetSubfoldersEvent => getSubfoldersEvent ?? (getSubfoldersEvent = new RelayCommand(o => CurrentSubfolders = Directory.GetDirectories(CurrentPath), null));
    }
}
