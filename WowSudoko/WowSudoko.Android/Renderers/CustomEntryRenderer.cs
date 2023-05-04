using System;
using System.ComponentModel;
using Android.Content;
using Android.Text;
using WowSudoko.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace WowSudoko.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Control != null)
            {
                Control.Background = null;
                Control.SetRawInputType(InputTypes.TextFlagNoSuggestions | InputTypes.ClassPhone);
                Control.SetPadding(0,0,0,0);
            }
        }
    }
}