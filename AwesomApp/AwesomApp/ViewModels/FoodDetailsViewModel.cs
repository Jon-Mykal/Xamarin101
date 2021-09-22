using AwesomApp.Models;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace AwesomApp.ViewModels
{
    
    public class FoodDetailsViewModel
    {

        public FoodDetailsViewModel()
        {
            DoneCmd = new AsyncCommand(GoBack);
        }

        public Food Food { get; set; }

        public AsyncCommand DoneCmd { get; set; }

        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
