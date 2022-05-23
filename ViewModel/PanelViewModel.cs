using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.IO;
using MiniTC.Model;


namespace MiniTC.ViewModel
{
    using View;
    public class PanelViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Drive selectedDrive;

        public Drive SelectedDrive
        {
            get { return selectedDrive; }
            set
            {
                selectedDrive = value;
            }
        }

        private List<Drive> currentDrives;
        public List<Drive> CurrentDrives
        {
            get
            {
                return currentDrives;
            }
            set
            {
                currentDrives = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentDrives)));
            }
        }

        private List<FileModel> currentSubfolders;
        public List<FileModel> CurrentSubfolders
        {
            get => currentSubfolders;
            set
            {
                currentSubfolders = value;
            }
        }

        public PathModel CurrentPath
        {
            get;set;
        }

        private ICommand getDrivesEvent;
        public ICommand GetDrivesEvent => getDrivesEvent ?? (getDrivesEvent = 
            new RelayCommand(
                o =>
                {
                    List<Drive> drives = new List<Drive>();
                    foreach(string s in Directory.GetLogicalDrives())
                    {
                        drives.Add(new Drive(s));
                    }
                    if (CurrentDrives == null || CurrentDrives.Count != drives.Count)
                    {
                        CurrentDrives = drives;
                    }
                    
                    
                }, 
                null)
            );

        
        private ICommand updatePathEvent;
        public ICommand UpdatePathEvent => updatePathEvent ?? (updatePathEvent = 
            new RelayCommand(o => {
                UpdateFileList(CurrentPath);
                }, null));

        public void UpdateFileList(PathModel path)
        {

        }

        /*private ICommand getSubfoldersEvent;
        public ICommand GetSubfoldersEvent => getSubfoldersEvent ?? (getSubfoldersEvent = new RelayCommand(o => CurrentSubfolders = Directory.GetDirectories(CurrentPath), null));*/
    }
}
