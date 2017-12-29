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

        private List<string> _connectedServerInfos;
        public List<string> ConnectedServerInfos
        {
            get => _connectedServerInfos;
            set
            {
                _connectedServerInfos = value;
                NotifyPropertyChanged("ConnectedServerInfos");
            }
        }

        private string selectedServerAddress;
        private string protocolVersion;
        private string synchronizationTips = "Click Synchronize to see more details!";
 
        public MainWindowViewModel()
        {
            MouseOverCommand = new RelayCommand(OnInfoCircleHover, o => true);
            SynchronizeButtonClick = new RelayCommand(OnSynchronizeClick, o => true);
        }

        /// <summary>
        /// Info popup when you hover over black circle
        /// </summary>
        public void OnInfoCircleHover(object o)
        {
            MessageBox.Show("Synchronizes your local system clock with one on server yo selected in \"Select server\"");
        }

        /// <summary>
        /// Synchronizes system clock when you click on Synchronize button
        /// </summary>
        public void OnSynchronizeClick(object o)
        {
            if(NtpConnector.isConnected)
            MessageBox.Show("System clock synchronized!");
            NtpConnector.SynchronizeOnCurrentServer();
            SynchronizationTips = NtpConnector.RetrieveSynchronizationInfo();
        }

        /// <summary>
        /// All the thing that happen when you choose server to connect
        /// </summary>
        public void OnConnectionAttempt()
        {
            ServerChooser.FinalServerAddress = selectedServerAddress;

            if(NtpConnector.isConnected)
            {
                ProtocolVersion = NtpConnector.GetProtocolVersion();
                ConnectedServerInfos = NtpConnector.GetCurrentConnectedServerInfo();
            }
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
                OnConnectionAttempt();
            }
        }

        public String ProtocolVersion
        {
            get { return protocolVersion;  }
            set
            {
                protocolVersion = value;
                NotifyPropertyChanged("ProtocolVersion");
            }
        }

        public string SynchronizationTips
        {
            get => synchronizationTips;
            set
            {
                synchronizationTips = value;
                NotifyPropertyChanged("SynchronizationTips");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
//nice try mati
