using System;
using System.Collections.Generic;
using Project3.DataModels;
using Syncfusion.DataSource;
using Xamarin.Forms;

namespace Project3.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            DataSource dataSource = new DataSource();
            dataSource.Source = new PlayerList();
            //dataSource.SortDescriptors.Add(new SortDescriptor("PlayerName"));
            dataSource.GroupDescriptors.Add(new GroupDescriptor()
            {
                PropertyName = "PlayerName",
                KeySelector = (object obj1) =>
                {
                    var item = (obj1 as Player);
                    return item.PlayerName[0].ToString();
                }
            });
            StackLayout stack = new StackLayout();
            stack.Children.Add(new Label()
            {
                TextColor = Color.Black,
                FontSize = 14,
                HeightRequest = 50,
                Text = "Contact List",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                BackgroundColor = Color.Gray
            });

            var listView = new ListView();
            listView.ItemTemplate = new DataTemplate(() =>
            {
                var label = new Label()
                {
                    TextColor = Color.Black,
                    FontSize = 12,
                    VerticalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Color.White,
                };
                label.SetBinding(Label.TextProperty, new Binding("PlayerName"));
                var viewCell = new ViewCell() { View = label };
                viewCell.BindingContextChanged += ViewCell_BindingContextChanged;
                return viewCell;
            });
            listView.ItemsSource = dataSource.DisplayItems;
            stack.Children.Add(listView);
            Content = stack;
        }

        private void ViewCell_BindingContextChanged(object sender, EventArgs e)
        {
            var viewCell = sender as ViewCell;
            //if (viewCell.BindingContext is GroupResult)
            //{
            //    var label = new Label()
            //    {
            //        TextColor = Color.Black,
            //        FontSize = 14,
            //        HeightRequest = 50,
            //        HorizontalTextAlignment = TextAlignment.Center,
            //        VerticalTextAlignment = TextAlignment.Center,
            //        BackgroundColor = Color.Gray
            //    };
            //    label.SetBinding(Label.TextProperty, new Binding("Key"));
            //    viewCell.View = label;
            //}
        }
    }
}
