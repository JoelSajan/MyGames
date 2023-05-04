using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WowSudoko.Views
{
    public partial class Animations : ContentPage
    {
        public Animations()
        {
            InitializeComponent();
        }

        async void Single_Clicked(System.Object sender, System.EventArgs e)
        {
            await Image1.RelScaleTo(2,500);
        }

        async void Composite_Clicked(System.Object sender, System.EventArgs e)
        {
            await Image2.RelScaleTo(3, 1000);
            await Image3.ScaleTo(30, 500);

        }

        async void Compound_Clicked(System.Object sender, System.EventArgs e)
        {

            await Task.WhenAll(
                Image3.RotateTo(-360,10000),
                Image3.FadeTo(0, 10000));
        }

        void Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            ViewExtensions.TranslateTo(Image3 ,100,100,250);
            ViewExtensions.CancelAnimations(Image2);
            ViewExtensions.CancelAnimations(Image3);
        }
    }
}
