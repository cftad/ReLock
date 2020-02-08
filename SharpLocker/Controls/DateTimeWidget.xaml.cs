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

namespace SharpLocker.Controls
{
    /// <summary>
    /// Interaction logic for DateTimeWidget.xaml
    /// </summary>
    public partial class DateTimeWidget : UserControl
    {
        public DateTimeWidget()
        {
            InitializeComponent();
            Time.Content = DateTime.Now.ToString("HH:mm");
            Date.Content = DateTime.Now.ToString("dddd d MMMM");
        }
    }
}
