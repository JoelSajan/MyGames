using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Project3.DataModels;
using Xamarin.Forms;

namespace Project3.Pages
{
    public partial class MenuPage : ContentPage
    {
        public AnimationModel animationModel { get; set; }
        public Random random { get; set; }
        public Animation animation { get; set; }
        public MenuPage()
        {
            InitializeComponent();
            //random = new Random();
            //animationModel = new AnimationModel();
            //animation = new Animation();
            //int i = 0;
            //for (i = 0; i < 10; i++)
            //{
            //    H.Text = ((char)random.Next('A', 'Z')).ToString();
            //    var textFieldTranslate = new Animation(v => H.TranslationX = v, 1, 0);
            //    var textFieldChangeOpacity = new Animation(v => H.Opacity = v, 0, 1);
            //    animation.Add(0, 1, textFieldTranslate);
            //    animation.Add(0, 0.2, textFieldChangeOpacity);
            //    animation.Commit(this, "Slide", 250, 500, Easing.Linear);
            //    A.Text = ((char)random.Next('A', 'Z')).ToString();
            //    N.Text = ((char)random.Next('A', 'Z')).ToString();
            //    G.Text = ((char)random.Next('A', 'Z')).ToString();
            //    Task.Delay(1000);
            //}
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            //HangLabel.TranslateTo(0,-(Application.Current.MainPage.Height),1000,Easing.Linear);
            //var item= MenuLayout.Children;
            //var view = (item.GetEnumerator() as IEnumerable<View>).ToList();

            //var Sender = (Frame)sender;
            //Sender.TranslationX(0, -(Application.Current.MainPage.Height), 1000, Easing.Linear);
        }
    }
}
