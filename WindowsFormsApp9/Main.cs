﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

            //Creds to keldnorman
            //https://github.com/Pickfordmatt/SharpLocker/issues/2
            Image myimage = new Bitmap(@Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft\\Windows\\Themes\\TranscodedWallpaper"));

            BackgroundImage = myimage;
            BackgroundImageLayout = ImageLayout.Stretch;
            this.TopMost = true;
            string userName = System.Environment.UserName.ToString();
            label2.Text = userName;
            label2.BackColor = System.Drawing.Color.Transparent;
            int usernameloch = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 64;
            int usericonh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 29;
            int buttonh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 64;
            int usernameh = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 50;
            int locked = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 57;
            int bottomname = (Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height) / 100) * 95;
            textBox2.Top = usernameloch;
            pictureBox1.Top = usericonh;
            button1.Top = buttonh;
            label2.Top = usernameh;
            label1.Top = locked;
            textBox2.UseSystemPasswordChar = true;

            //Get the username. This returns Domain\Username
            string userNameText = System.Security.Principal.WindowsIdentity.GetCurrent().Name;

            pictureBox1.Image = Utils.GetUserProfileImage();
            //Set the text
            label2.Text = userNameText.Split('\\')[1];

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
                // log errors
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Taskbar.Show();
            System.Windows.Forms.Application.Exit();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
                Taskbar.Show();
            base.OnClosing(e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(textBox2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Taskbar.Show();
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Taskbar.Show();
            System.Windows.Forms.Application.Exit();
        }
    }
    

}
