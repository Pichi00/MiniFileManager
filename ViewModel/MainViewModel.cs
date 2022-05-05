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
    class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Model.PathManager pathManager = new Model.PathManager();

        private string[] currentDrives;
        public string[] CurrentDrives
        {
            get => currentDrives;
            set
            {
                currentDrives = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentDrives)));
            }
        }

        private string currentDrive;
        public string CurrentDrive
        {
            get => currentDrive;
            set
            {
                currentDrive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentDrive)));
            }
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

        private ICommand getDrivesEvent;
        public ICommand GetDrivesEvent => getDrivesEvent ?? (getDrivesEvent = new RelayCommand(o => CurrentDrives = pathManager.getLogicalDrives(), null));

        private ICommand updatePathEvent;
        public ICommand UpdatePathEvent => updatePathEvent ?? (updatePathEvent = new RelayCommand(o => CurrentPath = "D:\\", null));

        private ICommand getSubfoldersEvent;
        public ICommand GetSubfoldersEvent => getSubfoldersEvent ?? (getSubfoldersEvent = new RelayCommand(o => CurrentSubfolders = Directory.GetDirectories(CurrentPath), null));
    }
}
