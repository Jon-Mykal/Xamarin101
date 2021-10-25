using AwesomApp.Views;

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AwesomApp
{
    public partial class App : Application
    {

        public App()
        {
            // Register Syncfusion License
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTE5MzE0QDMxMzkyZTMzMmUzMFFSNEM4TW56Tmt5N1QwMTZkaXhiUXYvNVBrNmZCb2N4TEoxNkdubGgxT2s9");
            InitializeComponent();
            MainPage = new AppShell();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
