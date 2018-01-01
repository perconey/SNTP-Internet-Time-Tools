using System.Collections.Generic;
using System.Windows;

namespace InternetTime.Data
{
    public static class NtpConnectionInfo
    {

        public static List<string> ConnectionInfoArgs = null;

        static NtpConnectionInfo()
        {
            if(NtpConnector.isConnected)
            ConnectionInfoArgs = NtpConnector.GetCurrentConnectedServerInfo();
            else
            {
                MessageBox.Show("Can't import server info when there is no connected server!");
            }
        }


    }
}
