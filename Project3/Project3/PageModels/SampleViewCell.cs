using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project3.PageModels
{
    public class SampleViewCell : ViewCell
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title",typeof(string),typeof(SampleViewCell),"",BindingMode.TwoWay);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }


        public static readonly BindableProperty NameProperty =
            BindableProperty.Create("Name",typeof(string),typeof(SampleViewCell),"",BindingMode.TwoWay);

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly BindableProperty BindingCommandProperty =
            BindableProperty.Create("BindingCommand",typeof(Command),typeof(SampleViewCell),null,BindingMode.Default);

        public ICommand BindingCommand
        {
            get { return (Command)GetValue(BindingCommandProperty); }
            set { SetValue(BindingCommandProperty,value); }
        }
    }
}
