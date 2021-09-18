
using ReactiveUI;

using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.CommunityToolkit.ObjectModel;

namespace AwesomApp.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        public ViewModelBase()
        {
           
        }

        public string Title { get; set; }

        bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
    }
}
