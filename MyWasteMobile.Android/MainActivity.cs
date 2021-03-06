using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Platform;
using Plugin.Media;

namespace MyWasteMobile.Android
{

    [Activity(Label = "MyWasteMobile", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override async void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			await CrossMedia.Current.Initialize();

			CachedImageRenderer.Init(enableFastRenderer:true);
			//CachedImageRenderer.InitImageViewHandler();

			UserDialogs.Init(this);
			CarouselView.FormsPlugin.Android.CarouselViewRenderer.Init();


			LoadApplication(new App());
        }

	}
}


