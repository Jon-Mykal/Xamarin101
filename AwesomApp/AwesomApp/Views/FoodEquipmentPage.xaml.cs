using AwesomApp.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodEquipmentPage : ContentPage
    {

        public FoodEquipmentPage()
        {
            InitializeComponent();
            BindingContext = new FoodEquipmentViewModel();
        }

     
    }
}