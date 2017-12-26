using Rebex.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
