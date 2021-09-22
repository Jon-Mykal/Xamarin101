using AwesomApp.Services;
using AwesomApp.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(FoodId), nameof(FoodId))]
    public partial class FoodDetailsPage : ContentPage
    {

        public int FoodId { get; set; }
        public FoodDetailsPage()
        {
            InitializeComponent();
            BindingContext = new FoodDetailsViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var foods = await FoodService.GetAllFood();
            var food = foods.FirstOrDefault(f => f.Id == FoodId);

            if (food != null)
            {
                ((FoodDetailsViewModel)BindingContext).Food = food;
            }
        }
    }
}