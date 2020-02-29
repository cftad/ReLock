using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Management;
using Microsoft.Win32;

namespace ReLock.Core.Device
{
    public class LocalSystem
    {

        /// <summary>
        /// Gets the current windows build version, useful for design changes in the lockscreen
        /// </summary>
        /// <returns></returns>
        public static int GetBuildVersion()
        {
            return Environment.OSVersion.Version.Build;
        }

        /// <summary>
        /// Obtains the Icon for current network interface in use
        /// </summary>
        /// <returns></returns>
        public static string GetInterfaceIcon()
        {
            var intfc = NetworkInterface.GetAllNetworkInterfaces().Where(x => x.OperationalStatus == OperationalStatus.Up);

            var intf = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(x => x.OperationalStatus == OperationalStatus.Up);

            if (intf != null)
                switch (intf.NetworkInterfaceType)
                {
                    case NetworkInterfaceType.Ethernet:
                        return "\xE839";
                    case NetworkInterfaceType.Wireless80211:
                        return "\xE701";
                    default: return "\xE839";
                }
            return "\xE839";
        }

        public static string GetLanguageCode()
        {
            CultureInfo ci = CultureInfo.InstalledUICulture;
            return ci.TwoLetterISOLanguageName;
        }
    }
}
