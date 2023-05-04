using System;
using System.Collections.Generic;
using LetsBingo.ViewModel;
using Xamarin.Forms;

namespace LetsBingo.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = new MenuPageModel();
        }
    }
}
