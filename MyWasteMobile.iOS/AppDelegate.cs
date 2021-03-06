using Foundation;
using UIKit;

namespace MyWasteMobile.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

			FFImageLoading.Forms.Platform.CachedImageRenderer.Init();

			return base.FinishedLaunching(app, options);

        }
    }
}

