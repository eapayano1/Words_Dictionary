using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WordsDictionary.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected BaseViewModel (INavigationService navigationService, IPageDialogService pageDialogService) 
        {
         

        }

    }
}
