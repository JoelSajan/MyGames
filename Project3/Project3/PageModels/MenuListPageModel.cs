using System;
using System.Collections.Generic;
using System.Windows.Input;
using Acr.UserDialogs;
using FreshMvvm;
using Project3.DataModels;
using Project3.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Project3.PageModels
{
    public class MenuListPageModel : FreshBasePageModel
    {
        public ICommand ClickCommand { get; set; }
        public ICommand SwipeGameCommand { get; set; }
        public IList<MenuDataModel> MenuItems { get; set; }
        public Random random { get; set; }
        public AnimationModel animationModel { get; set; }
        public MenuListPageModel()
        {
            random = new Random();
            ClickCommand = new Command(ClickCommandAsync);
            SwipeGameCommand = new Command(SwipeGameCommandAsync);
            MenuItems = new List<MenuDataModel>();
            MenuItems.Add(new MenuDataModel() { MenuName = "GAME" });
            MenuItems.Add(new MenuDataModel() { MenuName = "EXIT" });
            animationModel = new AnimationModel();
        }

        private void SwipeGameCommandAsync(object obj)
        {

        }

        public async void ClickCommandAsync(object obj)
        {
            //var confirmed = await UserDialogs.Instance.ConfirmAsync("Update Key", "Unavailable",
            //     "Learn More", "Cancel");
            //if (confirmed)
            //{
            //    Device.OpenUri(new Uri("https://help.bitwarden.com/article/update-encryption-key/"));
            //}
            //UserDialogs.Instance.Toast("Update Key");
            //var res = await UserDialogs.Instance.PromptAsync("What is your email?", "Confirm Email", "Confirm", "Cancel");
            //if(res.Ok)
            //{
            //   UserDialogs.Instance.Toast("Update Key");

            ////}
            //var progress = UserDialogs.Instance.Loading("Deleting Trip...", show: false, maskType: MaskType.Clear);
            //progress?.Show();

            //await PopupNavigation.Instance.PushAsync(new ShowPopupDemo());
            var menuItem = (MenuDataModel)obj;
            if (menuItem.MenuName == "GAME")
            {
                await CoreMethods.PushPageModel<MyGamePageModel>();
                 //Application.Current.MainPage = new NavigationPage(new MyGamePage());
            }
            else
            {
                System.Environment.Exit(0);
            }
        }
    }
}

