using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using AwesomApp.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Essentials;

namespace AwesomApp.Droid
{
    public class Toaster_Android : IToast
    {
        public void MakeToast(string message)
        {
            Toast.MakeText(Platform.AppContext, message, ToastLength.Long).Show();
        }
    }
}