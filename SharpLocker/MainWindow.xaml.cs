using System;
using System.Windows;
using SharpLocker.ViewModels;

namespace SharpLocker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LoginViewModel _loginViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _loginViewModel = new LoginViewModel();
            DataContext = _loginViewModel;
        }
    }
}
