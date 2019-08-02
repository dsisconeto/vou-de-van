using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using ImageCircle.Forms.Plugin.Droid;
using Lottie.Forms.Droid;
using Plugin.Permissions;

namespace VouDeVan.App.Mobile.Passenger.Droid
{
    [Activity(Label = "VouDeVan.App.Mobile.Passenger", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);

            // Pacote de permissões
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);

            // Inicializa plugin do Google Maps
            Xamarin.FormsGoogleMaps.Init(this, savedInstanceState);

            // Plugin de Ícones 'Iconize'
            Plugin.Iconize.Iconize.Init(Resource.Id.toolbar, Resource.Id.sliding_tabs);

            // Plugin de Imagens Circulares 'Image Circle'
            ImageCircleRenderer.Init();

            // Plugin de Animações 'Lottie'
            AnimationViewRenderer.Init();

            //Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
            //Window.SetBackgroundDrawableResource(Resource.Drawable);
            //SetStatusBarColor(Android.Graphics.Color.Transparent);

            LoadApplication(new Passanger.App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}