using System;
using System.Collections.Generic;
using LetsBingo.ViewModel;
using Xamarin.Forms;

namespace LetsBingo.Views
{
    public partial class IntroPage : ContentPage
    {
        public IntroPage()
        {
            InitializeComponent();
            BindingContext = new IntroPageModel();
        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}
