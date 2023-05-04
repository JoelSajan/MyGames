//using System;
//using System.ComponentModel;
//using System.Runtime.Remoting.Contexts;
//using System.Threading.Tasks;
//using Android.App;
//using Android.Graphics.Drawables;
//using Android.Views;
//using Android.Widget;
//using Project3.PageModels;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;

//namespace Project3.Droid.Renderers
//{
//    public class SampleViewCellAndroidRenderer : ViewCellRenderer
//    {
//        NativeAndroidCell cell;

//        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Android.Content.Context context)
//        {
//            var nativeCell = (SampleViewCell)item;
//            Console.WriteLine("\t\t" + nativeCell.Name);

//            cell = convertView as NativeAndroidCell;
//            if (cell == null)
//            {
//                cell = new NativeAndroidCell(context, nativeCell);
//            }
//            else
//            {
//                cell.SampleViewCell.PropertyChanged -= OnNativeCellPropertyChanged;
//            }

//            nativeCell.PropertyChanged += OnNativeCellPropertyChanged;

//            cell.UpdateCell(nativeCell);
//            return cell;
//        }

//        void OnNativeCellPropertyChanged(object sender, PropertyChangedEventArgs e)
//        {
//            var nativeCell = (SampleViewCell)sender;
//            if (e.PropertyName == SampleViewCell.NameProperty.PropertyName)
//            {
//                cell.HeadingTextView.Text = nativeCell.Name;
//            }
//            else if (e.PropertyName == SampleViewCell.TitleProperty.PropertyName)
//            {
//                cell.SubheadingTextView.Text = nativeCell.Title;
//            }
//        }

//        internal class NativeAndroidCell : LinearLayout, INativeElementView
//        {
//            public TextView HeadingTextView { get; set; }
//            public TextView SubheadingTextView { get; set; }
//            public ImageView ImageView { get; set; }

//            public SampleViewCell SampleViewCell { get; private set; }
//            public Element Element => SampleViewCell;

//            public NativeAndroidCell(Android.Content.Context context, SampleViewCell cell) : base(context)
//            {
//                SampleViewCell = cell;

//                var view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.NativeAndroidCell, null);
//                HeadingTextView = view.FindViewById<TextView>(Resource.Id.HeadingText);
//                SubheadingTextView = view.FindViewById<TextView>(Resource.Id.SubheadingText);
//                ImageView = view.FindViewById<ImageView>(Resource.Id.Image);

//                AddView(view);
//            }

//            public void UpdateCell(SampleViewCell cell)
//            {
//                HeadingTextView.Text = cell.Name;
//                SubheadingTextView.Text = cell.Title;

//                // Dispose of the old image
//                if (ImageView.Drawable != null)
//                {
//                    using (var image = ImageView.Drawable as BitmapDrawable)
//                    {
//                        if (image != null)
//                        {
//                            if (image.Bitmap != null)
//                            {
//                                image.Bitmap.Dispose();
//                            }
//                        }
//                    }
//                }

//                //SetImage(cell.ImageFilename);
//            }

//            public void SetImage(string filename)
//            {
//                if (!string.IsNullOrWhiteSpace(filename))
//                {
//                    // Display new image
//                    Context.Resources.GetBitmapAsync(filename).ContinueWith((t) =>
//                    {
//                        var bitmap = t.Result;
//                        if (bitmap != null)
//                        {
//                            ImageView.SetImageBitmap(bitmap);
//                            bitmap.Dispose();
//                        }
//                    }, TaskScheduler.FromCurrentSynchronizationContext());
//                }
//                else
//                {
//                    // Clear the image
//                    ImageView.SetImageBitmap(null);
//                }
//            }
//        }
//    }
//}
