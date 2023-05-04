using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Project3.Pages
{
    public partial class AvatharPage : ContentPage
    {
        public AvatharPage()
        {
            InitializeComponent();
            Content = new TableView
            {
                Intent = TableIntent.Settings,
                Root = new TableRoot("Table Title")
                {
                    new TableSection ("Section 1 Title") {
                        new TextCell {
                            Text = "TextCell Text",
                            Detail = "TextCell Detail"
                        },
                        new EntryCell {
                            Label = "EntryCell:",
                            Placeholder = "default keyboard",
                            Keyboard = Keyboard.Default
                        }
                    },
                    new TableSection ("Section 2 Title") {
                        new EntryCell {
                            Label = "Another EntryCell:",
                            Placeholder = "phone keyboard",
                            Keyboard = Keyboard.Telephone
                        },
                        new SwitchCell {
                            Text = "SwitchCell:"
                        },
                        new ViewCell()
                        {
                           View = new StackLayout()
                            {
                             Children =
                               {
                                   new Label()
                                   {
                                       Text="Sampple",
                                   }
                               }
                            }
                        }
                    }
                }
            };
        }
    }
}
