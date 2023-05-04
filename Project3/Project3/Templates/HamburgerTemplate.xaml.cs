using System;
using System.Collections.Generic;
using Project3.DataModels;
using Project3.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Project3.Templates
{
    public partial class HamburgerTemplate : ContentView
    {
        public HamburgerTemplate()
        {
            InitializeComponent();
            hamburger.IsVisible = false;
        }

        void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (hamburger.IsVisible)
                hamburger.IsVisible = false;
            else
            AnimateInHamburger();
        }


        /// <summary>
        /// Linear In animation of hamburger.
        /// </summary>
        private void AnimateInHamburger()
        {
            hamburger.IsVisible = true;
            var animation = new Animation();
            var leftPopupAnimation = new Animation(v => hamburger.TranslationX = v, -(Application.Current.MainPage.Width), 0, Easing.Linear);
            var opacityAnimation = new Animation(v => hamburger.Opacity = v, 0, 1, Easing.Linear);
            animation.Add(0, 1, leftPopupAnimation);
            animation.Add(0, 1, opacityAnimation);
            animation.Commit(this, "Slide", 16, 500, Easing.Linear);
        }

        async void HomeButton_Tapped(System.Object sender, System.EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new ShowPopupDemo());
        }

        void ListView_ItemTapped(System.Object sender, ItemTappedEventArgs e)
        {
            var item =(NavigationModel)e.Item;
            if(item!=null)
            {
                var page = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
               
                Navigation.PushAsync(page);
            }
        }
    }
}
