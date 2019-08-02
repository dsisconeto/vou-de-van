using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms.GoogleMaps;
using System.Threading.Tasks;
using Plugin.Permissions.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;

namespace VouDeVan.App.Mobile.Passanger.Views.Routes
{
    public partial class RoutesPage : ContentPage
    {
        public RoutesPage()
        {
            InitializeComponent();

            //NavigationPage.SetHasNavigationBar(this, false);

            LoadMapStyle();

            //TODO: Colocar a restrição de apps na API
            Init();
        }

        public void Init()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (Map.MyLocationEnabled)
                {
                    var granted = await GetPermissions();
                    if (!granted)
                        return;
                }

                SetupLocations();
                SavePreferences();
            });
        }

        private async Task<bool> GetPermissions()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                {
                    await DisplayAlert("Permita acesso a Localização", "VouDeVan funciona muito melhor com ", "OK");
                }

                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                if (results.ContainsKey(Permission.Location))
                    status = results[Permission.Location];
            }

            if (status == PermissionStatus.Granted)
            {
                return true;
            }

            if (status != PermissionStatus.Unknown)
            {
                await DisplayAlert("Localização não habilitada", "Por favor, tente novamente.", "OK");
            }

            return false;
        }

        private void SetupLocations()
        {
            Map.MyLocationEnabled = true;
            Map.UiSettings.MyLocationButtonEnabled = true;

            var lastLatitudePosition = "0";
            var lastLongitudePosition = "0";

            if (Application.Current.Properties.ContainsKey("user_location_latitude"))
                lastLatitudePosition = Application.Current.Properties["user_location_latitude"]?.ToString();

            if (Application.Current.Properties.ContainsKey("user_location_longitude"))
                lastLongitudePosition = Application.Current.Properties["user_location_longitude"]?.ToString();


            //Map.Pins.Add(_myLocation);
            //Map.SelectedPin = _myLocation;
            Map.MoveToRegion(MapSpan.FromCenterAndRadius(_myLocation.Position, Distance.FromMeters(1000)), true);
        }

        private void SavePreferences()
        {
            Application.Current.Properties["user_location_latitude"] = Map.CameraPosition.Target.Latitude;
            Application.Current.Properties["user_location_longitude"] = Map.CameraPosition.Target.Longitude;
            _ = Application.Current.SavePropertiesAsync();
        }

        private void LoadMapStyle()
        {
            var assembly = typeof(RoutesPage).GetTypeInfo().Assembly;

            using (var stream = assembly.GetManifestResourceStream("VouDeVan.App.Mobile.Passanger.Controls.Effects.CustomMapStyle.json"))
            {
                if (stream == null)
                    return;

                var text = "";

                using (var reader = new StreamReader(stream))
                    text = reader.ReadToEnd();

                Map.MapStyle = MapStyle.FromJson(text);
            }

            Map.UiSettings.ZoomControlsEnabled = false;
        }

        readonly Pin _myLocation = new Pin()
        {
            Type = PinType.Generic,
            Label = "Meu Local",
            Address = "Palmas, Tocantins, Brasil",
            Position = new Position(-10.2490914d, -48.3242858d)
        };
    }
}