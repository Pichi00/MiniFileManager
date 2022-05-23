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
    class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
                    CurrentDrives = drives;
                }, 
                null)
            );

        
        /*private ICommand updatePathEvent;
        public ICommand UpdatePathEvent => updatePathEvent ?? (updatePathEvent = 
            new RelayCommand(o => {
                var upe = o as View.UpdatePathEventArgs;
                CurrentPath = upe?.Drive ?? "X";
                }, null));

        private ICommand getSubfoldersEvent;
        public ICommand GetSubfoldersEvent => getSubfoldersEvent ?? (getSubfoldersEvent = new RelayCommand(o => CurrentSubfolders = Directory.GetDirectories(CurrentPath), null));*/
    }
}
