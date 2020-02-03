using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SharpLocker
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Taskbar.Hide();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            // Creds to keldnorman
            //https://github.com/Pickfordmatt/SharpLocker/issues/2
            Image myimage = new Bitmap(@Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\Themes\\TranscodedWallpaper"));

            BackgroundImage = myimage;
            BackgroundImageLayout = ImageLayout.Stretch;
            this.TopMost = true;
            string userName = System.Environment.UserName.ToString();
            Username.Text = userName;
            Username.BackColor = System.Drawing.Color.Transparent;
            int usernameloch = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 64;
            int usericonh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 29;
            int buttonh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 64;
            int usernameh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 50;
            int locked = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 57;
            int bottomname = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 95;
            LoginBox.Top = usernameloch;
            ProfileImage.Top = usericonh;
            LoginBtn.Top = buttonh;
            Username.Top = usernameh;
            Status.Top = locked;
            LoginBox.UseSystemPasswordChar = true;

            // Get the username. This returns Domain\Username
            string userNameText = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            // Get display picture and round it.
            ProfileImage.Image = Utils.GetUserProfileImage();

            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, ProfileImage.Width - 1, ProfileImage.Height - 1));
                ProfileImage.Region = new Region(gp);
            }

            // Set the text
            Username.Text = userNameText.Split('\\')[1];

            foreach (var screen in Screen.AllScreens)
            {

                Thread thread = new Thread(() => WorkThreadFunction(screen));
                thread.Start();
            }
        }


        public void WorkThreadFunction(Screen screen)
        {
            try
            {
                if (screen.Primary == true)
                {
                   
                }

                if (screen.Primary == false)
                {
                    int mostLeft = screen.WorkingArea.Left;
                    int mostTop = screen.WorkingArea.Top;
                    Debug.WriteLine(mostLeft.ToString(), mostTop.ToString());
                    using (Form form = new Form())
                    {
                        form.WindowState = FormWindowState.Normal;
                        form.StartPosition = FormStartPosition.Manual;
                        form.Location = new Point(mostLeft, mostTop);
                        form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        form.Size = new Size(screen.Bounds.Width, screen.Bounds.Height);
                        form.BackColor = Color.Black;
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x02000000;  // Turn off WS_CLIPCHILDREN
                parms.ExStyle |= 0x02000000;
                return parms;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        { 
            Taskbar.Show();
            base.OnClosing(e);
        }

        private void LoginBox_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(LoginBox);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Taskbar.Show();
            Application.Exit();
        }
    }

}
