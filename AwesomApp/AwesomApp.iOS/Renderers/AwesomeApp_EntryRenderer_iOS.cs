using AwesomApp.Controls;
using AwesomApp.iOS.Renderers;

using Foundation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AwesomApp_Entry), typeof(AwesomeApp_EntryRenderer_iOS))]
namespace AwesomApp.iOS.Renderers
{
    public class AwesomeApp_EntryRenderer_iOS : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TintColor = UIColor.FromRGB(29, 93, 236);
            }
        }
    }
}