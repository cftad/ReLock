using System;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

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

        public static bool ValidatePassword(string username, string password)
        {
            var pc = new PrincipalContext(ContextType.Machine);
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
        public static BitmapImage GetProfileImage()
        {
            string profileImagePath = @Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\AccountPictures\");
            string profileImage = Directory.GetFiles(profileImagePath).FirstOrDefault();

            var bitmap = AccountPictureConverter.GetImage448(profileImage);

            return AccountPictureConverter.GetImageBitmap(bitmap);
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

        public static BitmapImage GetLockScreenImage()
        {
            var registry = new Registry();
            // Obtain the last logged on users SID
            string securityIdentifier = registry.LastLoggedInSid();

            var lockScreenImage = registry.LockScreenImage();

            bool spotlightEnabled = true;

            // Obtain current spotlight image if it is enabled 
            if (spotlightEnabled)
            {
                return new BitmapImage(new Uri(GetSpotlightImage()));
            }

            // %USERPROFILE%\AppData\Roaming\Microsoft\Windows\Themes\TranscodedWallpaper
            // Fallback to user set image.
            return new BitmapImage(new Uri(@Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\Themes\\TranscodedWallpaper")));
        }

        /// <summary>
        /// Obtains the current spotlight image set.
        /// </summary>
        /// <remarks>
        /// The obtained image is found from
        /// %USERPROFILE%\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets\
        /// </remarks>
        /// <returns></returns>
        private static string GetSpotlightImage()
        {
            //Get Windows Spotlight Images Location Path. 
            string spotlightDirPath = 
                @Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets\");

            /* Save the name of the larger image from spotlight dir.
             * Normally the larger image present in this directory is the current lock screen image. */
            var imgName = string.Empty;

            DirectoryInfo folderInfo = new DirectoryInfo(spotlightDirPath);
            long largestSize = 0;

            foreach (var fi in folderInfo.GetFiles())
            {
                if (fi.Length > largestSize)
                {
                    largestSize = fi.Length;
                    imgName = fi.Name;
                }
            }

            return Path.Combine(spotlightDirPath, imgName); 
        }

        #endregion
    }
}
