using AwesomApp.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        const string key = "loggedIn";
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Preferences.ContainsKey(key))
            {
                var loggedIn = Preferences.Get(key, false);
                if (loggedIn)
                {
                    await Shell.Current.GoToAsync($"//{nameof(FoodEquipmentPage)}");
                }
            }
        }

        
        //public async void OnLoginBtnClicked(object sender, EventArgs e)
        //{
        //    Preferences.Set(key, true);
        //    await Shell.Current.GoToAsync($"//{nameof(FoodEquipmentPage)}");
        //}
    }
}