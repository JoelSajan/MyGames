using System;
using System.Collections.Generic;
using Project3.PageModels;
using Project3.Templates;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Project3.Pages
{
    public partial class ShowPopupDemo : PopupPage
    {
        public ShowPopupDemo()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.Text.ToUpper() == "YEP!")
            {
                var myGamePage = Navigation.NavigationStack[1];
                var myGamePageModel = (MyGamePageModel)myGamePage.BindingContext;
                await myGamePageModel.NavigateToRoot();
            }
            await PopupNavigation.Instance.PopAsync(true);
        }
    }
}
