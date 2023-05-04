using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project3.Pages
{
    public class Box : ContentView
    {
        public int row { get; set; }
        public int coloum { get; set; }
        public Frame frame { get; set; }
        public int index { get; set; }
        public Label MainLabel { get; set; }
        public string winText { get; set; }
        public Box(string mainText="",int index=0)
        {
            this.index = index;
            MainLabel = new Label()
            {
                Text = mainText,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large,typeof(Label)),
                StyleClass = new List<string>() {"labelStyle"},
            };

            frame = new Frame
            {
                Padding = 5,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                CornerRadius = 10,
                Content = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children =
                    {
                        MainLabel,
                    }
                },
                StyleClass = new List<string>() { "framStyle" }
            };
            Content = frame;
        }

        public async Task AnimateWinAsync(bool isReverse)
        {
            uint length = 150;
            await Task.WhenAll(this.ScaleTo(3, length), this.RotateTo(180, length));
            MainLabel.Text = isReverse ? MainLabel.Text : winText;
            await Task.WhenAll(this.ScaleTo(1, length), this.RotateTo(360, length));
            this.Rotation = 0;
        }
    }
}

