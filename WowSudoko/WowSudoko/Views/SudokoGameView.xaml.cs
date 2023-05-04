using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace WowSudoko.Views
{
    public partial class SudokoGameView : ContentPage
    {
        public SudokoGameView()
        {
            InitializeComponent();
            App.Current.UserAppTheme = OSAppTheme.Light;
            loaderImage.IsRunning = true;
        }



        void Animate_Check_Button(System.Object sender, System.EventArgs e)
        {
            var animation = new Animation();
            animation.Add(0,0.33,new Animation(v=>CheckButton.Scale = v,1,1.25,Easing.Linear));
            animation.Add(0.3, 0.66, new Animation(v => CheckButton.Scale = v, 1.25,0.5, Easing.Linear));
            animation.Add(0.66, 1, new Animation(v => CheckButton.Scale = v, 0.5, 1, Easing.Linear));
            animation.Commit(this, "Animation", 16,220,Easing.Linear,null, () => false);
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            App.Current.UserAppTheme = (App.Current.UserAppTheme == OSAppTheme.Dark) ? OSAppTheme.Light : OSAppTheme.Dark;
        }

        void Entry_PropertyChanged(System.Object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var regex = new Regex("[1-9]");
            var box = sender as Entry;
            if (box != null && !string.IsNullOrEmpty(box.Text))
            {
                if (box?.Text?.Length == 2)
                {
                    box.Text = box?.Text?.Remove(1);
                }
                else if (!regex.IsMatch(box?.Text?.ToString()))
                {
                    box.Text = box?.Text.Remove(0);
                }
            }
            else if (box != null && box.Text != null && string.IsNullOrEmpty(box?.Text) &&  e.PropertyName == "Text")
            {
                box.BackgroundColor = Color.FromHex("#FFA500");
                var framebox = box.Parent as Frame;
                framebox.BorderColor = Color.FromHex("#FFA500");
            }
        }
    }
}
