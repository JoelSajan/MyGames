using System;
using System.Collections.Generic;
using Project3.AudioManager;
using Xamarin.Forms;

namespace Project3
{
    public partial class AudioPlayerPage : ContentPage
    {
        public AudioPlayerPage()
        {
            InitializeComponent();
            BindingContext = new AudioPlayerViewModel();

        }
    }
}
