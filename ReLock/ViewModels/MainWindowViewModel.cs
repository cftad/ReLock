using System.ComponentModel;
using Prism.Mvvm;

namespace ReLock.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "ReLock";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
        }
    }
}
