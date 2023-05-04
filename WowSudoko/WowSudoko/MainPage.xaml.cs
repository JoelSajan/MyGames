using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WowSudoko
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            AnimatedTextControl.IsRunning = !AnimatedTextControl.IsRunning;
            RunButton.Text = AnimatedTextControl.IsRunning ? "Run" : "Stop";
        }
    }
}
