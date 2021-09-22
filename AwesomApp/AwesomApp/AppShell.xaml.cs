
using AwesomApp.Views;

using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AwesomApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddFoodPage), typeof(AddFoodPage));
            Routing.RegisterRoute(nameof(FoodDetailsPage), typeof(FoodDetailsPage));
        }

    }
}
