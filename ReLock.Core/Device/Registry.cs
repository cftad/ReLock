using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ReLock.Core.Device
{
    public class Registry
    {
        /// <summary>
        /// Obtains the last logged in users security identifier
        /// </summary>
        /// <returns></returns>
        public string LastLoggedInSid()
        {
            // Local root for login UI
            const string registryRoot = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\";

            var keys = GetSubkeys(registryRoot);

            var sid = keys.FirstOrDefault(x => x.Key == "LastLoggedOnUserSID").Value;

            return Convert.ToString(sid);
        }

        /// <summary>
        /// Obtains the last logged on user display name from registry
        /// </summary>
        /// <returns></returns>
        public string LastLoggedOnDisplayName()
        {
            const string RegistryRoot = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\";

            var keys = GetSubkeys(RegistryRoot);

            var displayName = keys.FirstOrDefault(x => x.Key.Equals("LastLoggedOnDisplayName")).Value;

            return Convert.ToString(displayName);
        }

        public string LockScreenImage()
        {
            // Local root for login UI
            const string registryRoot = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\Creative";

            string securityIdentifier = LastLoggedInSid();

            var keys = GetSubkeys($"{registryRoot}\\{securityIdentifier}");

            foreach (var key in keys)
            {
                Console.WriteLine($"{key.Key} -> {key.Value}");
            }

            //if (keys.ContainsKey(securityIdentifier))
            //{

            //}

            return null;

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
        private Dictionary<string, object> GetSubkeys(string registryRoot)
        {
            Dictionary<string, object> registryValues = new Dictionary<string, object>();

            try
            {
                using (RegistryKey rootKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(registryRoot))
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

    }
}
