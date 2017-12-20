using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTime.Data
{
    public static class ServerChooser
    {
        public static List<String> Servers = new List<string>()
        {
            "pl.pool.ntp.org","de.pool.ntp.org","by.pool.ntp.org","fr.pool.ntp.org"
        };

        private static StringBuilder _serverAddress = new StringBuilder();

        public static  StringBuilder ServerAdress { get => _serverAddress; set => _serverAddress = value; }

        public static string FinalServerAddress;


    }
}
