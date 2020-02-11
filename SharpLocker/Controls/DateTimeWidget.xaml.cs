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
using System.Windows.Threading;

namespace SharpLocker.Controls
{
    /// <summary>
    /// Interaction logic for DateTimeWidget.xaml
    /// </summary>
    public partial class DateTimeWidget : UserControl
    {
        public static readonly DependencyProperty DateProperty = DependencyProperty.Register(
            "Date", typeof(string), typeof(DateTimeWidget), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty TimeProperty = DependencyProperty.Register(
            "Time", typeof(string), typeof(DateTimeWidget), new PropertyMetadata(default(string)));

        public string Time
        {
            get { return (string) GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public string Date
        {
            get { return (string) GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public DateTimeWidget()
        {
            InitializeComponent();
            Date = DateTime.Now.ToString();
            Time = DateTime.Now.ToString();
        }
    }
}
