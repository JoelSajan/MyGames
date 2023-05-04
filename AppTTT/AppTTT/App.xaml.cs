using System;
using FreshMvvm;
using FreshTinyIoC;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppTTT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Setup.Registrations(FreshTinyIoCContainer.Current);
            var page = FreshPageModelResolver.ResolvePageModel<MainMenuPageModel>();
            
            MainPage = new FreshNavigationContainer(page);
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
