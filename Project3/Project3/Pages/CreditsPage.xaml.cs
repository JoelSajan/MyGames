using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Project3.Pages
{
    public partial class CreditsPage : ContentPage
    {
        uint i { get; set; } = 50;
        public CreditsPage()
        {
            InitializeComponent();
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            //i = i+5;
            var random = new Random();
            var frame = (Frame)sender;
            int height = Convert.ToInt32((Application.Current.MainPage.Height));
            int width = Convert.ToInt32(Application.Current.MainPage.Width);
            Rectangle rect = new Rectangle(random.Next(0, width-50),
                random.Next(0, height - 50), i,i);
            await frame.LayoutTo(rect,240);
        }
    }
}
