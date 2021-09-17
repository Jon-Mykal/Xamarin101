using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;

namespace AwesomApp.ViewModels
{
    public class FoodEquipmentViewModel : BindableObject
    {
        public FoodEquipmentViewModel()
        {
            IncreaseCountCmd = new Command(IncreaseCount);
        }
        string countDisplay = "Click Me!";
        int count = 0;
        public string CountDisplay
        {
            get => countDisplay;
            set
            {
                // If incoming value (value) is 
                // the same as the current value (countDisplay)
                // don't change
                if (value == countDisplay)
                {
                    return;
                }

                countDisplay = value;
                OnPropertyChanged();
            }
        }

        public ICommand IncreaseCountCmd { get; }

        void IncreaseCount()
        {
            count++;
            CountDisplay = $"You clicked {count} time(s)";
        }
    }
}
