using System;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ReLock.Core.Device
{
    public class LocalUser
    {
        #region User
        /// <summary>
        /// Gets the username and domain of the current user.
        /// e.g WORK\JohnDoe
        /// </summary>
        /// <returns></returns>
        public static string GetUsername() => System.Security.Principal.WindowsIdentity.GetCurrent().Name;

        /// <summary>
        /// Gets the current users security identifier.
        /// </summary>
        /// <returns></returns>
        public static string GetSid() => UserPrincipal.Current.Sid.ToString();

        public static bool ValidatePassword(string username, string password, ContextType type)
        {
            var pc = new PrincipalContext(type);
            return pc.ValidateCredentials(username, password);
        }

        /// <summary>
        /// Gets the display name of the current user.
        /// e.g John Doe
        /// </summary>
        /// <returns>The display name of the current user.</returns>
        public static string GetDisplayName() => System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;

        #endregion
        #region Images

        /// <summary>
        /// Gets the profile image for the current user.
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetProfileImage()
        {
            string profileImagePath = @Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\AccountPictures\");
            string profileImage = Directory.GetFiles(profileImagePath).FirstOrDefault();

            return AccountPictureConverter.GetImage448(profileImage);

        }

        public static Uri GetProfileImagePath()
        {
            string profileImagePath = @Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\AccountPictures\");
            string profileImage = Directory.GetFiles(profileImagePath).FirstOrDefault();

            // Convert to bitmap and save before setting src
            try
            {
                var final = AccountPictureConverter.GetImage448(profileImage);
                final.Save("profile-img.png");

                if (File.Exists(".\\profile-img.png"))
                {
                    return new Uri(@".\profile-img.png", UriKind.Relative);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Unable to find image, use default icon.
            return new Uri(".\\Resources\\usericon.png");
        }

        public static Image GetLockScreenImage()
        {
            // TODO: Refactor as this call can take a few seconds to make.
            string securityIdentifier = GetSid();

            // Get registry values for lockscreen in local root
            const string RegistryImageRoot = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Authentication\LogonUI\";

            var keys = LocalSystem.GetRegistrySubkeys(RegistryImageRoot);

            if (keys.ContainsKey(securityIdentifier))
            {

            }

            // Fallback to user set image.
            return new Bitmap(@Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\Themes\\TranscodedWallpaper"));
        }

        #endregion
    }
}
