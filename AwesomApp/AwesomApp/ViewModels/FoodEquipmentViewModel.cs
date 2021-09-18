using AwesomApp.Models;

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

            Title = "Food Equipment";
            Food = new ObservableRangeCollection<Food>();
            FoodGroups = new ObservableRangeCollection<Grouping<string, Food>>();

            var image = "https://www.eatthis.com/wp-content/uploads/sites/4//media/images/ext/966368714/kfc-original-chicken-recipe.jpg?quality=82&strip=1&resize=640%2C360";
            Food.Add(new Food { Kitchen = "KFC", Name = "Chicken Box", Image = image });
            Food.Add(new Food { Kitchen = "Burger King", Name = "Whopper", Image = image });
            Food.Add(new Food { Kitchen = "KFC", Name = "Meal Deal", Image = image });

            FoodGroups.Add(new Grouping<string, Food>("KFC", Food.Take(2)));
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

        Food previouslySelectedFood;
        Food selectedFood;
        public Food SelectedFood
        {
            get => selectedFood;
            set
            {
                if (value != null)
                {
                    Application.Current.MainPage.DisplayAlert("Selected", value.Name, "Ok");
                    previouslySelectedFood = value;
                    value = null;
                }

                SetProperty(ref selectedFood, value);
            }
        }


        async Task MakeFavourite(Food food)
        {
            if (food == null)
            {
                return;
            }

            await Application.Current.MainPage.DisplayAlert("Favourited", food.Name, "Ok");
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }

        void IncreaseCount()
        {
            count++;
            CountDisplay = $"You clicked {count} time(s)";
        }
    }
}
