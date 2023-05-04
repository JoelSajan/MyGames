using System;
using FreshMvvm;
using Xamarin.Forms;

namespace AppTTT
{
    public class MainMenuPageModel: FreshBasePageModel
    {
        private bool hasGoneInn;

        public MainMenuPageModel()
        {
            var data = new Data() { Name="JustinCooper",Adderss="Sample"};
            MessagingCenter.Subscribe<string,string>("this", "Hi", (sender,message) =>
            {
                hasGoneInn = true;
            });

        }

        public async void StartTheFun()
        {
            await CoreMethods.PushPageModel<MainPageModel>();
        }
    }
}
