using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SharpLocker.Annotations;
using SharpLocker.Core;
using SharpLocker.Models;

namespace SharpLocker.ViewModels
{
    class LoginViewModel : INotifyPropertyChanged
    {
        private User user;

        public LoginViewModel()
        {
            user = new User
            {
                UserName = UserSettings.GetUsername(),
                DisplayName = UserSettings.GetDisplayName(),
                Password = string.Empty
            };
        }

        public string UserName
        {
            get => user.UserName;
            set
            {
                if (user.UserName != value)
                {
                    user.UserName = value;
                    GetOnPropertyChanged(nameof(user.UserName));
                }
            }
        }

        public string DisplayName
        {
            get => user.DisplayName;
            set
            {
                if (user.DisplayName != value)
                {
                    user.DisplayName = value;
                    GetOnPropertyChanged(nameof(user.DisplayName));
                }
            }
        }

        public string Password
        {
            get => user.Password;
            set
            {
                if (user.Password != value)
                {
                    user.Password = value;
                    GetOnPropertyChanged(nameof(user.Password));
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void GetOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
