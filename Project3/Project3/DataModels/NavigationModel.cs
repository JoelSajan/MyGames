using System;
using Xamarin.Forms;

namespace Project3.DataModels
{
    public class NavigationModel
    {
        public string Title { get; set; }
        public ImageSource Image { get; set; }
        public Type TargetType { get; set; }
    }
}
