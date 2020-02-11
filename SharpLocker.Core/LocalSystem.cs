using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace SharpLocker.Core
{
    public class LocalSystem
    {
        /// <summary>
        /// Obtains the last logged on user from Registry
        /// </summary>
        /// <returns></returns>
        public static string GetLastLoggedOn()
        {
            const string RegistryRoot = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\";

            var keys = GetRegistrySubkeys(RegistryRoot);

            var lastLoggedOn = keys.FirstOrDefault(x => x.Key.Equals("LastLoggedOnDisplayName")).Value.ToString();

            return lastLoggedOn;
        }

        /// <summary>
        /// Obtains the registry subkeys for a specified root.
        /// </summary>
        /// <list type="bullet">
        /// <item><description><para><em>keys may not appear if compiled for the wrong system.</em></para></description></item>
        /// </list>
        /// <see cref="https://docs.microsoft.com/en-gb/windows/win32/sysinfo/32-bit-and-64-bit-application-data-in-the-registry?redirectedfrom=MSDN"/>
        /// <param name="registryRoot"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetRegistrySubkeys(string registryRoot)
        {
            Dictionary<string, object> registryValues = new Dictionary<string, object>();
            try
            {
                using (RegistryKey rootKey = Registry.LocalMachine.OpenSubKey(registryRoot))
                {
                    if (rootKey != null)
                    {
                        string[] valueNames = rootKey.GetValueNames();
                        foreach (string subKey in valueNames)
                        {
                            object value = rootKey.GetValue(subKey);
                            registryValues.Add(subKey, value);
                        }

                        rootKey.Close();
                    }

                }
            }
            catch (ArgumentNullException ae)
            {
                Console.WriteLine(ae.Message);
            }

            return registryValues;
        }

        /// <summary>
        /// Gets the current windows build version, useful for design changes in the lockscreen
        /// </summary>
        /// <returns></returns>
        public static int GetBuildVersion()
        {
            return Environment.OSVersion.Version.Build;
        }
    }
}
