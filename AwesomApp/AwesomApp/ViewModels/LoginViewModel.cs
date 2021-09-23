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
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            LoginCmd = new AsyncCommand(Login);
        }

        public AsyncCommand LoginCmd { get; }


        async Task Login()
        {
            Preferences.Set("loggedIn", true);
            await Shell.Current.GoToAsync($"//{nameof(FoodEquipmentPage)}");
        }
    }
}
