using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetTime.Data;
using System.Windows;
using System.Windows.Input;

namespace InternetTime.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ICommand MouseOverCommand { get; set; }
        public ICommand SynchronizeButtonClick { get; set; }

        private string selectedServerAddress;
 
        public MainWindowViewModel()
        {
            MouseOverCommand = new RelayCommand(OnInfoCircleHover, o => true);
            SynchronizeButtonClick = new RelayCommand(OnSynchronizeClick, o => true);
        }

        public void OnInfoCircleHover(object o)
        {
            MessageBox.Show("Synchronizes your local system clock with one on server yo selected in \"Choose Server\"");
        }

        public void OnSynchronizeClick(object o)
        {
            MessageBox.Show("Jobs done");
            NtpConnector.SynchronizeOnCurrentServer();
        }
        
        public List<String> ServerAddresses
        {
            get { return ServerChooser.Servers; }
        }
        
        public String SelectedServerAddress
        {
            get { return selectedServerAddress; }
            set
            {
                selectedServerAddress = value;
                NotifyPropertyChanged("SelectedServerAddress");
                ServerChooser.FinalServerAddress = selectedServerAddress;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
