using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SharpLocker
{
    static class Utils
    {
        ///// <summary>
        ///// Gets the profile image for the current user.
        ///// </summary>
        ///// <returns></returns>
        //public static Image GetUserProfileImage()
        //{
        //    string profileImagePath = @Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\AccountPictures\");
        //    string profileImage = Directory.GetFiles(profileImagePath).FirstOrDefault();

        //    // Convert to bitmap
        //    return AccountPictureConverter.GetImage448(profileImage);
        //}

        public static System.Windows.Media.ImageSource GetUserProfileImage()
        {
            string profileImagePath = @Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\AccountPictures\");
            string profileImage = Directory.GetFiles(profileImagePath).FirstOrDefault();

            // Convert to bitmap and save before setting src
            var final = AccountPictureConverter.GetImage448(profileImage);
            final.Save("profile-img.png");

            if (File.Exists(".\\profile-img.png"))
            { 
               return new BitmapImage(new Uri(@".\profile-img.png", UriKind.Relative));
            }

            return null;
        }

        /// <summary>
        /// Gets the background image for the current user.
        /// </summary>
        /// <returns></returns>
        public static Image GetUserBackgroundImage()
        {
            return new Bitmap(@Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\Themes\TranscodedWallpaper"));
        }

        /// <summary>
        /// Gets the username and domain of the current user.
        /// </summary>
        /// <returns></returns>
        public static string GetUsername()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        /// <summary>
        /// Gets the current windows build version, useful for design changes in the lockscreen
        /// </summary>
        /// <returns></returns>
        public static int GetBuildVer()
        {
            return Environment.OSVersion.Version.Build;
        }


        [DllImport("shell32.dll", EntryPoint = "#261",
            CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern void GetUserTilePath(
            string username,
            UInt32 whatever, // 0x80000000
            StringBuilder picpath, int maxLength);

        public static string GetUserTilePath(string username)
        {   // username: use null for current user
            var sb = new StringBuilder(1000);
            GetUserTilePath(username, 0x80000000, sb, sb.Capacity);
            return sb.ToString();
        }

        public static Image GetUserTile(string username)
        {
            return Image.FromFile(GetUserTilePath(username));
        }
    }
}
