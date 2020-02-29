using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReLock.ViewModels
{
    public class LoginFormViewModel : BindableBase
    {
        private string profileImage;
        public string ProfileImage
        {
            get { return profileImage; }
            set { SetProperty(ref profileImage, value); }
        }
        public LoginFormViewModel()
        {

        }
    }
}
