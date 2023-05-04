using System;
using System.IO;
using Prism.DryIoc;
using Prism.Ioc;
using WowSudoko.Managers;
using WowSudoko.ViewModels;
using WowSudoko.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WowSudoko
{
    public partial class App : PrismApplication
    {
        public static INavigation GlobalNavigation { get; private set; }
        private static SQLHelperManager db;
        public static SQLHelperManager SudokoDatabase
        {
            get{
                    if (db == null)
                    {
                      db = new SQLHelperManager(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"Sudoko.db3"));
                    }
                return db;
               }
        }

        public App()
        {
            InitializeComponent();
            //Current.MainPage.Navigation.PushModalAsync(new MicroAnimations());
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<SudokoMenuView>();
            containerRegistry.RegisterForNavigation<MicroAnimations>();
            containerRegistry.RegisterForNavigation<SudokoGameView>();
            containerRegistry.RegisterForNavigation<XamarinFormsFiveView>();
            containerRegistry.RegisterForNavigation<FlyoutPageView>();
        }

        protected async override void OnInitialized()
        {
            var result = await NavigationService.NavigateAsync("SudokoMenuView");
        }
    }
}
