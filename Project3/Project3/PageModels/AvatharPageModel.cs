using System;

using Xamarin.Forms;

namespace Project3.PageModels
{
    public class AvatharPageModel : ContentPage
    {
        public AvatharPageModel()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

