using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLocker
{
    static class Utils
    {
        /// <summary>
        /// Gets the profile image for the current user.
        /// </summary>
        /// <returns></returns>
        public static Image GetUserProfileImage()
        {
            string profileImagePath = @Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\AccountPictures\");
            string profileImage = Directory.GetFiles(profileImagePath).FirstOrDefault();

            // Convert to bitmap
            return AccountPictureConverter.GetImage448(profileImage);
        }

        public static Image GetUserImage()
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp\" + Environment.UserName + ".bmp"))
            {
                return Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Temp\" + Environment.UserName + ".bmp");
            }
            else
            {
                return null;
            }
        }
    }
}
