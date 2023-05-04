using System;
using System.ComponentModel;
using CoreGraphics;
using Project3.iOS.Renderers;
using Project3.PageModels;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SampleViewCell), typeof(SampleViewCellIOSRenderer))]
namespace Project3.iOS.Renderers
{
    public class SampleViewCellIOSRenderer : ViewCellRenderer
    {

        SampleViewCellIOS cell;

        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var Item = (SampleViewCell)item;
            cell = reusableCell as SampleViewCellIOS;
            if (cell == null)
                cell = new SampleViewCellIOS(item.GetType().FullName, Item);
            else
                cell.NativeCell.PropertyChanged -= OnNativeCellPropertyChanged;
            Item.PropertyChanged += OnNativeCellPropertyChanged;
            cell.UpdateCell(Item);
            return cell;
        }

        private void OnNativeCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var nativeCell = (SampleViewCell)sender;
            if (e.PropertyName == SampleViewCell.NameProperty.PropertyName)
            {
                cell.HeadingLabel.Text = nativeCell.Name;
            }
            else if (e.PropertyName == SampleViewCell.TitleProperty.PropertyName)
            {
                cell.SubheadingLabel.Text = nativeCell.Title;
            }
        }

        internal class SampleViewCellIOS : UITableViewCell, INativeElementView
        {
            public UILabel HeadingLabel { get; set; }
            public UILabel SubheadingLabel { get; set; }
            public UIImageView CellImageView { get; set; }

            public SampleViewCell NativeCell { get; private set; }
            public Element Element => NativeCell;

            public SampleViewCellIOS(string cellId, SampleViewCell cell) : base(UITableViewCellStyle.Default, cellId)
            {
                NativeCell = cell;

                SelectionStyle = UITableViewCellSelectionStyle.Gray;
                ContentView.BackgroundColor = UIColor.FromRGB(255, 255, 224);
                CellImageView = new UIImageView();

                HeadingLabel = new UILabel()
                {
                    Font = UIFont.FromName("Cochin-BoldItalic", 22f),
                    TextColor = UIColor.FromRGB(127, 51, 0),
                    BackgroundColor = UIColor.Clear
                };

                SubheadingLabel = new UILabel()
                {
                    Font = UIFont.FromName("AmericanTypewriter", 12f),
                    TextColor = UIColor.FromRGB(38, 127, 0),
                    TextAlignment = UITextAlignment.Center,
                    BackgroundColor = UIColor.Clear
                };

                ContentView.Add(HeadingLabel);
                ContentView.Add(SubheadingLabel);
            }

            public void UpdateCell(SampleViewCell cell)
            {
                HeadingLabel.Text = cell.Name;
                SubheadingLabel.Text = cell.Title;
            }

            public UIImage GetImage(string filename)
            {
                return (!string.IsNullOrWhiteSpace(filename)) ? UIImage.FromFile("Images/" + filename + ".jpg") : null;
            }

            public override void LayoutSubviews()
            {
                base.LayoutSubviews();

                HeadingLabel.Frame = new CGRect(5, 4, ContentView.Bounds.Width - 63, 25);
                SubheadingLabel.Frame = new CGRect(100, 18, 100, 20);
                CellImageView.Frame = new CGRect(ContentView.Bounds.Width - 63, 5, 33, 33);
            }
        }
    }
}
