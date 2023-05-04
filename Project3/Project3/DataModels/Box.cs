using System;
using PropertyChanged;
using Xamarin.Forms;

namespace Project3.DataModels
{
    [AddINotifyPropertyChangedInterface]
    public class Box
    {
        public Color boxcolor { get; set; } = Color.Orange;
        public string number { get; set; }
        public Command SelectedBox { get; set; }
    }
}
