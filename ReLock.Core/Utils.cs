using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Media;
using Color = System.Drawing.Color;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace ReLock.Core
{
    public static class Utils
    {
        public static void BlockNonPrimaryScreens()
        {
            foreach (var screen in Screen.AllScreens)
            {
                if (!screen.Primary)
                {
                    Thread thread = new Thread(() => WorkThreadFunction(screen));
                    thread.Start();
                }
            }

            void WorkThreadFunction(Screen screen)
            {
                try
                {
                    using (var form = new Form())
                    {
                        form.WindowState = FormWindowState.Normal;
                        form.StartPosition = FormStartPosition.Manual;
                        form.Location = new Point(screen.WorkingArea.Left, screen.WorkingArea.Top);
                        form.FormBorderStyle = FormBorderStyle.None;
                        form.Size = new Size(screen.Bounds.Width, screen.Bounds.Height);
                        form.BackColor = Color.Black;
                        form.ShowDialog();
                    }

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
        }
    }
}
