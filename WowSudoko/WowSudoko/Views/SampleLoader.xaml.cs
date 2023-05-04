using System;
using System.Collections.Generic;
using WowSudoko.ViewModels;
using Xamarin.Forms;

namespace WowSudoko.Views
{
    public partial class SampleLoader : ContentPage
    {
        public SampleLoader()
        {
            InitializeComponent();
            BindingContext =new  SampleLoaderPageModel();

        }
    }
}
