using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiniTC.View
{
    /// <summary>
    /// Logika interakcji dla klasy Panel.xaml
    /// </summary>
    public partial class Panel : UserControl
    {
        public Panel()
        {
            InitializeComponent();
        }


        //Update drives event
        public static readonly RoutedEvent UpdateDrivesEvent =
        EventManager.RegisterRoutedEvent(nameof(UpdateDrivesEventHandler),
                     RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                     typeof(Panel));

        public event RoutedEventHandler UpdateDrivesEventHandler
        {
            add { AddHandler(UpdateDrivesEvent, value); }
            remove { RemoveHandler(UpdateDrivesEvent, value); }
        }

        void RaiseUpdateDrivesEvent()
        {
            //argument zdarzenia
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Panel.UpdateDrivesEvent);
            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }

        private void ComboBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseUpdateDrivesEvent();
        }

        public static readonly DependencyProperty CurrentDriveProperty =
            DependencyProperty.Register(
                    nameof(CurrentDrive),
                    typeof(string),
                    typeof(Panel)
                );

        public string CurrentDrive
        {

            get { return (string)GetValue(CurrentDriveProperty); }
            set { SetValue(CurrentDriveProperty, value); }
        }

        
        /* Update path event
        public static readonly RoutedEvent UpdatePathEvent =
       EventManager.RegisterRoutedEvent(nameof(UpdatePathEventHandler),
                    RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                    typeof(Panel));

        public event RoutedEventHandler UpdatePathEventHandler
        {
            add { AddHandler(UpdatePathEvent, value); }
            remove { RemoveHandler(UpdatePathEvent, value); }
        }

       /* void RaiseUpdatePathEvent()
        {
            //argument zdarzenia
            UpdatePathEventArgs newEventArgs = new UpdatePathEventArgs(Panel.UpdatePathEvent, "Z");

            //wywołanie zdarzenia
            RaiseEvent(newEventArgs);
        }*/

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            //CurrentPathTextBox.Text = DrivesComboBox.SelectedItem.ToString();
        }

    }
}
