using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Acr.UserDialogs;
using System.IO;

namespace Project3.Droid
{
    [Activity(Label = "Project3", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            UserDialogs.Init(() => this);
            Rg.Plugins.Popup.Popup.Init(this);
            string db_Name = "playerInfo_DB.db3";
            var folder_Path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
            string final_Path = Path.Combine(folder_Path,db_Name);
            LoadApplication(new App(final_Path));
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}