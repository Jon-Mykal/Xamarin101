using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using AwesomApp.Controls;
using AwesomApp.Droid.Renderers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AwesomApp_Entry), typeof(AwesomeApp_EntryRenderer_Android))]
namespace AwesomApp.Droid.Renderers
{
    public class AwesomeApp_EntryRenderer_Android : EntryRenderer
    {
        public AwesomeApp_EntryRenderer_Android(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Control.SetTextCursorDrawable(Resource.Drawable.my_cursor);
        }
    }
}