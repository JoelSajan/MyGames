using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Acr.UserDialogs;
using Foundation;
using Lottie.Forms.iOS.Renderers;
using UIKit;

namespace Project3.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            AnimationViewRenderer.Init();
            Rg.Plugins.Popup.Popup.Init();
            string db_Name = "playerInfo_DB.db3";
            string folder_Path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            string final_Path = Path.Combine(folder_Path, "/PlayerInfo" + db_Name);
            LoadApplication(new App(final_Path));

            return base.FinishedLaunching(app, options);
        }
    }
}
