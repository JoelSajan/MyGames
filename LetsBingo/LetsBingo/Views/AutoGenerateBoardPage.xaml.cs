using System;
using System.Collections.Generic;
using LetsBingo.Managers;
using LetsBingo.ViewModel;
using Xamarin.Forms;

namespace LetsBingo.Views
{
    public partial class AutoGenerateBoardPage : ContentPage
    {
        public AutoGenerateBoardPage()
        {
            InitializeComponent();
            BindingContext = new AutoGenerateBoardPageModel(new PageService());

        }

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}
