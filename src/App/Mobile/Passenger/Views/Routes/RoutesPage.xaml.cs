using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.GoogleMaps;
using System.Threading.Tasks;
using Plugin.Permissions.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VouDeVan.App.Mobile.Passanger.Views.Routes
{
    public partial class RoutesPage : ContentPage
    {
        public RoutesPage()
        {
            InitializeComponent();

            //TODO: Colocar a restrição de apps na API
            Init();
        }

        public void Init()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var granted = await GetPermissions();
                if (!granted)
                    return;

                SetupLocations();
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
            else if (status != PermissionStatus.Unknown)
            {
                await DisplayAlert("Localização não habilitada", "Por favor, tente novamente.", "OK");
            }

            return false;
        }

        private void SetupLocations()
        {
            Map.MyLocationEnabled = true;
            Map.UiSettings.MyLocationButtonEnabled = true;
            //var currentLoc = await VM.UpdateCurrentLocation();
            //if (currentLoc == null)
            //{
            //    await DisplayAlert("Error", "Could not get current location. Please tap a location on the map", "Okay");
            //    return;
            //}
            //TheMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(currentLoc.Data.Latitude, currentLoc.Data.Longitude), new Distance(50)));

            //var hashLoc = await VM.LoadHashLocation();
            //if (hashLoc == null)
            //{
            //    await DisplayAlert("Error", "Could not load DJIA for today, please check internet connection", "Okay");
            //    return;
            //}
            //var hashPos = new Position(hashLoc.NearestHashLocation.Latitude, hashLoc.NearestHashLocation.Longitude);
            //var myPos = new Position(currentLoc.Data.Latitude, currentLoc.Data.Longitude);
            //var bounds = new Bounds(myPos, hashPos);
            //var update = CameraUpdateFactory.NewBounds(bounds, 50);
            //await TheMap.AnimateCamera(update);
        }
    }
}