using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomApp.ViewModels
{
    public class AppShellViewModel : ViewModelBase
    {
        public AppShellViewModel()
        {

        }
        private string _header,
            _legalese,
            _menuItem,
            _listItem;

        public string Header
        {
            get => _header;
            set => SetProperty(ref _header, value);  
        }

        public string Legalese
        {
            get => _legalese;
            set => SetProperty(ref _legalese, value);
        }

        public string MenuItem
        {
            get => _menuItem;
            set => SetProperty(ref _menuItem, value);  
        }

        public string ListItem
        {
            get => _listItem;
            set => SetProperty(ref _listItem, value);
        }
    }
}
