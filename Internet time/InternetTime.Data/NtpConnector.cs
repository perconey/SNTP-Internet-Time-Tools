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
        public static bool isConnected = false;
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
                    isConnected = true;
                }catch(Exception ex)
                {
                    MessageBox.Show("An error has occurred, please try to connect again!\n" +
                        "Error message: " + ex.Message);
                    isConnected = false;

                }
            }
        }

        public static void ConnectByAddress(string addr)
        {
            try
            {
                connectedNtpServer = new Ntp(addr);
                MessageBox.Show("Connected to: " + addr);
                isConnected = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error has occurred, please try to connect again!\n" +
                "Error message: " + ex.Message);
                isConnected = false;
            }

        }
        
        public static void SynchronizeOnCurrentServer()
        {
            try
            {
                connectedNtpServer.SynchronizeSystemClock();
                isConnected = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hola Hola Amigo, which server do you want to use for synchronization");
                isConnected = false;
            }
        }

        public static string GetProtocolVersion()
        {
            try
            {
                return $"Protocol version: {connectedNtpServer.VersionNumber}";
            }catch(Exception ex)
            {
                return "Error";
            }
        }

        public static List<string> GetCurrentConnectedServerInfo()
        {
            try
            {
                List<string> info = new List<string>();
                NtpResponse response = connectedNtpServer.GetTime();
                NtpPacket packet = response.Packet;
                string l1, l2, s1, s2;
                
                l1 = packet.OriginateTimestamp.ToString() + ":" + packet.OriginateTimestamp.Microsecond.ToString();
                l2 = packet.DestinationTimestamp.ToUniversalTime().ToString() + ":" + packet.OriginateTimestamp.Microsecond.ToString();

                s1 = packet.ReceiveTimestamp.ToUniversalTime().ToLongTimeString() + ":" + packet.ReceiveTimestamp.Microsecond;
                s2 = packet.TransmitTimestamp.ToUniversalTime().ToLongTimeString() + ":" + packet.TransmitTimestamp.Microsecond;

                info.Add($"Request sent at: {l1} UTC" +
                    $" local time and received its response at {l2} UTC");
                info.Add($"Currently connected server ({ServerChooser.FinalServerAddress}) has stratum {packet.Stratum} and runs NTP version {packet.VersionNumber.ToString()}");
                info.Add($"Choosed server received our request at {s1} UTC and sent response at {s2} UTC");

                return info;
            }
            catch(Exception ex)
            {
                MessageBox.Show("An error has occurred, please try to connect again!\n" +
                               "Error message: " + ex.Message);
                return new List<string>();
            }
        }
    }
}
