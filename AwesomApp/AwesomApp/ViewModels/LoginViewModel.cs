using AwesomApp.Views;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AwesomApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel()
        {
            LoginCmd = new AsyncCommand(Login, IsValid);
            UserName = "";
            Password = "";
        }

        private string _userName,
                       _password;

        public string UserName
        {
            get => _userName;
            set  
            {
                var isSet = SetProperty(ref _userName, value);
                if (isSet)
                {
                    LoginCmd.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get => _password;   
            set
            {
                var isSet = SetProperty(ref _password, value);
                if (isSet)
                {
                    LoginCmd.RaiseCanExecuteChanged();
                }
            }
        }

        public AsyncCommand LoginCmd { get; }

        bool IsValid() => !string.IsNullOrWhiteSpace(_userName) && !string.IsNullOrWhiteSpace(_password);
        async Task Login()
        {
            if (!IsValid())
            {
                return;
            }

            if (UserName.Equals("admin") && Password.Equals("password123"))
            {
                Preferences.Set("loggedIn", true);
               
                
                await Shell.Current.GoToAsync($"//{nameof(FoodEquipmentPage)}");
            
            }
            else
            {
                await Shell.Current.DisplayAlert("Sign In Status", "Username or password is incorrect. Please try again", "Ok");
            }
        }
    }
}
