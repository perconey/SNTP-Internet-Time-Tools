using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTime.Data
{
    static class ServerChooser
    {
        private static StringBuilder _serverAddress = new StringBuilder();

        public static  StringBuilder ServerAdress { get => _serverAddress; set => _serverAddress = value; }

        public static string FinalServerAddress;


    }
}
