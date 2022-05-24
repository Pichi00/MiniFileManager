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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPath)));
            }
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
                if(SelectedFile != null && SelectedFile.Type == FileTypes.types.DIR)
                {
                    CurrentPath = SelectedFile.Name;
                    UpdateFileList(CurrentPath);
                }                
            }, null));


        private ICommand updateDriveEvent;
        public ICommand UpdateDriveEvent => updateDriveEvent ?? (updateDriveEvent =
            new RelayCommand(o => {
                if(SelectedDrive != null)
                {
                    CurrentPath = SelectedDrive.ToString();
                    UpdateFileList(CurrentPath);
                }
            }, null));

        private ICommand back;
        public ICommand Back => back ?? (back =
            new RelayCommand(
            o =>{
                CurrentPath = Directory.GetParent(CurrentPath).FullName;
                UpdateFileList(CurrentPath);
            },
            o => (
            CurrentPath != null &&
            Directory.GetParent(CurrentPath) != null
            )));

        public void UpdateFileList(string path)
        {
            CurrentPath = path;
            CurrentSubfolders = new List<FileModel>();
            /*if (Directory.GetParent(path.Text) != null)
            {

            }*/
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            foreach(string d in directories)
            {
                CurrentSubfolders.Add(new FileModel(d, FileTypes.types.DIR));
            }
            foreach(string f in files)
            {
                CurrentSubfolders.Add(new FileModel(f, FileTypes.types.FILE));
            }
        }

        /*private ICommand getSubfoldersEvent;
        public ICommand GetSubfoldersEvent => getSubfoldersEvent ?? (getSubfoldersEvent = new RelayCommand(o => CurrentSubfolders = Directory.GetDirectories(CurrentPath), null));*/
    }
}
