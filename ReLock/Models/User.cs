using System;
using System.Windows.Media.Imaging;

namespace ReLock.Models
{
    public class User 
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string DisplayName { get; set; }

        public BitmapImage ProfileImage { get; set; }

        public BitmapImage BackgroundImage { get; set; }

    }
}