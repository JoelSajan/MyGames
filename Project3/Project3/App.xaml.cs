using System;
using Akavache;
using FreshMvvm;
using FreshTinyIoC;
using Project3.Management;
using Project3.PageModels;
using Project3.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project3
{
    public partial class App : Application
    {
        public static string db_Locatoin { get; set; }
        public App()
        {
            InitializeComponent();
            
            var page = FreshPageModelResolver.ResolvePageModel<MenuListPageModel>();
            MainPage = new FreshNavigationContainer( page );
        }

        public App(string dbLoc)
        {
            InitializeComponent();
            InitializeMethod(dbLoc);
        }

        private void InitializeMethod(string dbLoc)
        {
            FreshTinyIoCContainer.Current.Register<ISettingsService, SettingsService>();
            BlobCache.ApplicationName = "Project3";
            BlobCache.EnsureInitialized();
            db_Locatoin = dbLoc;
            var page = FreshPageModelResolver.ResolvePageModel<MenuListPageModel>();
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
