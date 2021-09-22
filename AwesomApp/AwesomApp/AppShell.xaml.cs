
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

            /* IMPORTANT 
             Route names have to match exactly in the AppShell items
            or else problems will arise with the navigation.
             */
            Routing.RegisterRoute(nameof(AddFoodPage), typeof(AddFoodPage));
            Routing.RegisterRoute(nameof(FoodDetailsPage), typeof(FoodDetailsPage));
            Routing.RegisterRoute(nameof(FoodEquipmentPage), typeof(FoodEquipmentPage));
        }

    }
}
