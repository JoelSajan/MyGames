using System;
using System.Collections.Generic;
using FreshMvvm;
using Xamarin.Forms;

namespace AppTTT
{
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        async void ButtonStart_Clicked(System.Object sender, System.EventArgs e)
        {

            var pagemodel = BindingContext as MainMenuPageModel;
            pagemodel.StartTheFun();
        }
        void ButtonEnd_Clicked(System.Object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
