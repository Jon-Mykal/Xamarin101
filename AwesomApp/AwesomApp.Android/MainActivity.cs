using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using AwesomApp.Contracts;

namespace AwesomApp.Droid
{
    [Activity(Label = "AwesomApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            // Register Syncfusion License
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTE5MzE0QDMxMzkyZTMzMmUzMFFSNEM4TW56Tmt5N1QwMTZkaXhiUXYvNVBrNmZCb2N4TEoxNkdubGgxT2s9");
            base.OnCreate(savedInstanceState);

            // Register the dependency in the IoC container
            DependencyService.Register<IToast, Toaster_Android>();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}