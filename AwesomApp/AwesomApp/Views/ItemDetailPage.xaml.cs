using AwesomApp.ViewModels;

using System.ComponentModel;

using Xamarin.Forms;

namespace AwesomApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}