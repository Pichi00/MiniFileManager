using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentSubfolders)));
            }
        }

        private string currentPath;
        public string CurrentPath
        {
            get => currentPath;
            set
            {
                currentPath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPath)));
            }
        }

        private FileModel selectedFile;
        public FileModel SelectedFile { 
            get => selectedFile;
            set 
            { 
                selectedFile = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedFile)));
            }
        }

        private ICommand getDrivesEvent;
        public ICommand GetDrivesEvent => getDrivesEvent ?? (getDrivesEvent = 
            new RelayCommand(
                o =>
                {
                    List<Drive> drives = new List<Drive>();
                    foreach(string d in FileManager.getDrives() )
                    {
                        drives.Add(new Drive(d));
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
                if(SelectedFile != null && SelectedFile.Type != FileTypes.types.FILE)
                {
                    CurrentPath = FileManager.getPathTo(SelectedFile, CurrentPath);
                    CurrentSubfolders = FileManager.updateSubfolders(CurrentPath);
                }                
            }, null));


        private ICommand updateDriveEvent;
        public ICommand UpdateDriveEvent => updateDriveEvent ?? (updateDriveEvent =
            new RelayCommand(o => {
                if(SelectedDrive != null)
                {
                    CurrentPath = SelectedDrive.ToString();
                    CurrentSubfolders = FileManager.updateSubfolders(CurrentPath);
                }
            }, null));

       
        /*private ICommand getSubfoldersEvent;
        public ICommand GetSubfoldersEvent => getSubfoldersEvent ?? (getSubfoldersEvent = new RelayCommand(o => CurrentSubfolders = Directory.GetDirectories(CurrentPath), null));*/
    }
}
