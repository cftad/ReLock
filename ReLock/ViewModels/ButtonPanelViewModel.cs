using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Regions;

namespace ReLock.ViewModels
{
    public class ButtonPanelViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public ButtonPanelViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            buttonCommand = new DelegateCommand(ButtonClicked);
        }

        private void ButtonClicked()
        {
            _regionManager.RequestNavigate("ContentRegion", "LoginScreen");
        }

        public ButtonPanelViewModel()
        {

        }
    }
}
