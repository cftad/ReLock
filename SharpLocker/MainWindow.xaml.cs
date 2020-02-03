using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SharpLocker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Binding Image = new Binding("Image")
            {
                Source = Utils.GetUserProfileImage()
            };


            Init();
        }

        /// <summary>
        /// Sets up the window
        /// </summary>
        public void Init()
        {
            // Sets up 
            //UserProfileImage.Source = Utils.GetUserProfileImage();
            Username.Content = Utils.GetUsername();

            Utils.GetUserTile(Utils.GetUsername());
        }


        public void StyleInit()
        {
            int usernameloch = (Convert.ToInt32(SystemParameters.VirtualScreenHeight) / 100) * 64;
            int usericonh = (Convert.ToInt32(SystemParameters.VirtualScreenHeight) / 100) * 29;
            int buttonh = (Convert.ToInt32(SystemParameters.VirtualScreenHeight) / 100) * 64;
            int usernameh = (Convert.ToInt32(SystemParameters.VirtualScreenHeight) / 100) * 50;
            int locked = (Convert.ToInt32(SystemParameters.VirtualScreenHeight) / 100) * 57;
            int bottomname = (Convert.ToInt32(SystemParameters.VirtualScreenHeight) / 100) * 95;

        }
    }
}
