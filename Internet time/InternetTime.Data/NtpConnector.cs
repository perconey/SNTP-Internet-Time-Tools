using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rebex.Net;
using System.Windows;

namespace InternetTime.Data
{
    public static class NtpConnector
    {
        public static Ntp connectedNtpServer = null;

        static NtpConnector()
        {
            //connectedNtpServer = new Ntp(ServerChooser.FinalServerAddress);
            //MessageBox.Show("Connected to: " + ServerChooser.FinalServerAddress);
        }

        public static void ConnectToAddress()
        {
            if(connectedNtpServer != null)
            {
                try
                {
                    connectedNtpServer = new Ntp(ServerChooser.FinalServerAddress);
                    MessageBox.Show("Connected to: " + ServerChooser.FinalServerAddress);
                }catch(Exception ex)
                {
                    MessageBox.Show("An error has occurred, please try to connect again!\n" +
                        "Error message: " + ex.Message);
                }
            }
        }

        public static void ConnectByAddress(string addr)
        {
            try
            {
                connectedNtpServer = new Ntp(addr);
                MessageBox.Show("Connected to: " + ServerChooser.FinalServerAddress);
            }catch(Exception ex)
            {
                MessageBox.Show("An error has occurred, please try to connect again!\n" +
                "Error message: " + ex.Message);
            }

        }

        public static void SynchronizeOnCurrentServer()
        {
            try
            {
                connectedNtpServer.SynchronizeSystemClock();
            }catch(Exception ex)
            {
                MessageBox.Show("Hola Hola Amigo, which server do you want to use for synchronization");
            }
        }

    }
}
