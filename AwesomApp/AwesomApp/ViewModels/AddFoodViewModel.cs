using AwesomApp.Services;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace AwesomApp.ViewModels
{
    public class AddFoodViewModel : ViewModelBase
    {
        public AddFoodViewModel()
        {
            SaveCmd = new AsyncCommand(SaveFood, IsValid);
        }

        string name;
        public string Name 
        {
            get => name;
            set 
            {
                SetProperty(ref name, value);
                SaveCmd.RaiseCanExecuteChanged();
            } 
        }

        string kitchen;
        public string Kitchen
        {
            get => kitchen;
            set 
            { 
                SetProperty(ref kitchen, value);
                SaveCmd.RaiseCanExecuteChanged();
            } 
        }

        public AsyncCommand SaveCmd { get; }

        public bool IsValid() => !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(kitchen);

        async Task SaveFood()
        {
            try
            {
                if (!IsValid())
                {
                    return;
                }
                await FoodService.AddFood(Name, Kitchen);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
