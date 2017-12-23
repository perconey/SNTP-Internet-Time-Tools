using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetTime.Data;
using System.Windows;

namespace InternetTime.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string selectedServerAddress;
        public MainWindowViewModel()
        {

        }
        
        public List<String> ServerAddresses
        {
            get { return ServerChooser.Servers; }
        }
        RelayCommand
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
