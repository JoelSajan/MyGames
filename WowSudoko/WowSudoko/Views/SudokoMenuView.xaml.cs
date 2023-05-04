using System;
using System.Collections.Generic;
using Lottie.Forms;
using Prism.Navigation;
using Rg.Plugins.Popup.Extensions;
using WowSudoko.Popup;
using WowSudoko.ViewModels;
using Xamarin.Forms;

namespace WowSudoko.Views
{
    public partial class SudokoMenuView : ContentPage
    {
        public SudokoMenuView()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var pageModel = this.BindingContext as SudokoMenuViewModel;
            pageModel.PlayButtonCommand.Execute( sender.GetType().ToString() == "AnimationView" ? (sender as AnimationView).BindingContext?.ToString(): "");
        }

        void Settings_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushPopupAsync(new SettingsPopupPage());
        }

        void Path_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            
        }

        void Path_UnFocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
        }

        void lottieAnimation_OnClick(System.Object sender, System.EventArgs e)
        {
        }
    }
}
