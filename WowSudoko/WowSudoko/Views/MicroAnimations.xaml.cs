using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace WowSudoko.Views
{
    public partial class MicroAnimations : ContentPage
    {
        private float price { get; set; }
        public float Price {
            get {
                return price;
                }
            set {
                price = value;
                OnPropertyChanged();
                }
        }
        public MicroAnimations()
        {
            InitializeComponent();
            IconList = PopulateIconList();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = this;
        }

        public static ObservableCollection<AnimationClass> PopulateIconList()
        {
            return new ObservableCollection<AnimationClass>()
            {
               new AnimationClass(){Color = Color.Violet, Amount="300$",Item="Food" , Image = "Food.png"},
               new AnimationClass(){Color = Color.Indigo, Amount="500$",Item="Travel" , Image = "Travel.png"},
               new AnimationClass(){Color = Color.Blue, Amount="200$",Item="Rent", Image = "Rent.png" },
               new AnimationClass(){Color = Color.Green, Amount="150$",Item="Cosmetics", Image = "Cosmetics.png" }
            };
        }

        private ObservableCollection<AnimationClass> iconlist;

        public ObservableCollection<AnimationClass> IconList
        {
            get { return iconlist; }
            set
            {
                iconlist = value;
                OnPropertyChanged();
            }
        }

        public class AnimationClass
        {
            public Color Color { get; set; }
            public string Item { get; set; }
            public string Amount { get; set; }
            public string Image { get; set; }
            public bool IsSelected { get; set; }
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
           Price = 0.0f;
           var grid = (Grid)sender;
           var stackLayout = (StackLayout)grid.Parent;
           var scrollView = (ScrollView)stackLayout.Parent;
           var selectedItem = grid.BindingContext as AnimationClass;
           selectedItem.IsSelected = true;
           

            foreach (var item in stackLayout.Children)
            {
                var otherOnes = (Grid)item;
                var selecteditem =  otherOnes.FindByName<StackLayout>("descpLabel");
                var selectedbv = otherOnes.FindByName<BoxView>("boxViewColor");
                selecteditem.TranslateTo(-20, 0, 200, Easing.Linear);
                selecteditem.IsVisible = false;
                selectedbv.IsVisible = false;
            }

            var selected_item = grid.FindByName<StackLayout>("descpLabel");
            var selected_bv = grid.FindByName<BoxView>("boxViewColor");
            selected_item.IsVisible = true;
            selected_bv.IsVisible = true;
            selected_item.TranslateTo(0, 0, 250, Easing.SinInOut);
            AnimatePrice(float.Parse(selectedItem.Amount.Replace("$","")));
            scrollView.ScrollToAsync(grid, ScrollToPosition.MakeVisible, true);

        }

        public void AnimatePrice(float price)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            Device.StartTimer(TimeSpan.FromSeconds(1/100f),()=>
            {
                double t = stopWatch.Elapsed.TotalMilliseconds % 500 / 500;
                Price = Math.Min((float)price , (float)(10*t)+ Price);
                if (Price >= (float)price)
                {
                    stopWatch.Stop();
                    return false;
                }
                return true;
            });
        }
    }
}
