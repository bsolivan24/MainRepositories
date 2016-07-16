using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace VpnMonitor
{
    public class NetworkHelper
    {
        public bool IsNetworkConnected(NetwoorkInfo networkInfo)
        {
            return false;
        }

        internal static NetworkInterface[] GetNetworkInterfaces()
        {
            return NetworkInterface.GetAllNetworkInterfaces();
        }
    }
}
