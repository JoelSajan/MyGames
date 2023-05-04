using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WowSudoko.Views
{
    public partial class NewBallPage : ContentPage
    {
        public static int height { get; set; }
        public static int width { get; set; }

        public NewBallPage()
        {

            InitializeComponent();

            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
            height = (int)mainDisplayInfo.Height;
            width = (int)mainDisplayInfo.Width;
            width /= 2;
            height /= 2;
            var timer = new System.Timers.Timer();
            timer.Elapsed += (s, e) => StartBall();
            timer.Interval = 5000;
            timer.AutoReset = true;
            timer.Start();
            var ontapped = new TapGestureRecognizer();
            ontapped.Tapped += (s,e) => StartBall();
        }

        private void StartBall()
        {
            var random = new Random();
            var Directions = new List<double>() { -1, 1 };
            //ball.TranslateTo(-width, height, 2500);
            //ball.TranslateTo(width, random.Next(10, height), 2500);
            //ball.TranslateTo((width-100) / 2*Directions[random.Next(0, 2)], random.Next(100, height - 100)* Directions[random.Next(0, 2)], 1000,Easing.Linear);
           
        }
    }
}
