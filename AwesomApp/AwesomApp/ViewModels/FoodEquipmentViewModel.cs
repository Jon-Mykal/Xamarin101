using AwesomApp.Contracts;
using AwesomApp.Models;
using AwesomApp.Services;
using AwesomApp.Views;

using DynamicData;

using ReactiveUI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AwesomApp.ViewModels
{
    public class FoodEquipmentViewModel : ViewModelBase
    {
        public FoodEquipmentViewModel()
        {
            IncreaseCountCmd = ReactiveCommand.Create(IncreaseCount);
            RefreshCmd = new AsyncCommand(Refresh);
            FavouriteCmd = new AsyncCommand<Food>(MakeFavourite);
            SelectedCmd = new AsyncCommand<object>(SelectFood);
            AddCmd = new AsyncCommand(AddFood);
            RemoveCmd = new AsyncCommand<Food>(RemoveFood);
            APICmd = new AsyncCommand(GetOwners);
            LogoutCmd = new AsyncCommand(Logout);
            Title = "Food Equipment";
            Food = new ObservableRangeCollection<Food>();
            //FoodGroups = new ObservableRangeCollection<Grouping<string, Food>>();

            //var image = "https://www.eatthis.com/wp-content/uploads/sites/4//media/images/ext/966368714/kfc-original-chicken-recipe.jpg?quality=82&strip=1&resize=640%2C360";
            //Food.Add(new Food { Kitchen = "KFC", Name = "Chicken Box", Image = image });
            //Food.Add(new Food { Kitchen = "Burger King", Name = "Whopper", Image = image });
            //Food.Add(new Food { Kitchen = "KFC", Name = "Meal Deal", Image = image });

            //FoodGroups.Add(new Grouping<string, Food>("KFC", Food.Take(2)));
        }

        public ObservableRangeCollection<Food> Food { get; set; }

        public ObservableRangeCollection<Grouping<string, Food>> FoodGroups { get; set; }

        string countDisplay = "Click Me!";
        int count = 0;
        public string CountDisplay
        {
            get => countDisplay;
            set => SetProperty(ref countDisplay, value);
        }


        public ICommand IncreaseCountCmd { get; }

        public AsyncCommand RefreshCmd { get; }

        public AsyncCommand<Food> FavouriteCmd { get; set; }

        public AsyncCommand<object> SelectedCmd { get; set; }

        public AsyncCommand<Food> RemoveCmd { get; set; }

        public AsyncCommand AddCmd { get; set; }

        public AsyncCommand APICmd { get; set; }

        public AsyncCommand LogoutCmd { get; set; }

        Food previouslySelectedFood;
        Food selectedFood;
        public Food SelectedFood
        {
            get => selectedFood;
            set => SetProperty(ref selectedFood, value);
        }


        async Task AddFood()
        {
            //var name = await App.Current.MainPage.DisplayPromptAsync("Name", "Name");
            //var kitchen = await App.Current.MainPage.DisplayPromptAsync("Kitchen", "Kitchen");

            //await FoodService.AddFood(name, kitchen);
            //await Refresh();
            await Shell.Current.GoToAsync(nameof(AddFoodPage));
        }

        async Task SelectFood(object args)
        {
            var food = args as Food;

            if (food == null)
            {
                return;
            }

            await Shell.Current.GoToAsync($"{nameof(FoodDetailsPage)}?FoodId={food.Id}");
        }

        async Task MakeFavourite(Food food)
        {
            if (food == null)
            {
                return;
            }

            await Application.Current.MainPage.DisplayAlert("Favourited", food.Name, "Ok");
        }

        async Task RemoveFood(Food food)
        {
            await FoodService.RemoveFood(food.Id);
            await Refresh();
        }
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(500);
            Food.Clear();
            var foods = await FoodService.GetAllFood();
            Food.AddRange(foods);
            IsBusy = false;

            DependencyService.Get<IToast>()?.MakeToast("Refreshed!");
        }

        void IncreaseCount()
        {
            count++;
            CountDisplay = $"You clicked {count} time(s)";
        }

        async Task Logout()
        {
            Preferences.Set("loggedIn", false);
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        async Task GetOwners()
        {
            var owners = await FoodService.GetOwners();
            await App.Current.MainPage.DisplayAlert("API Response", owners, "Ok");
        }
    }
}
