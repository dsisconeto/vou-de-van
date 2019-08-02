using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace VouDeVan.App.Mobile.Passenger.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = false, NoHistory = true)]
    public class SplashScreen : Activity
    {
        static readonly string TAG = "X:" + typeof(SplashScreen).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG, "SplashActivity.OnCreate");
        }

        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            var startupWork = new Task(SimulateStartup);
            startupWork.Start();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        // Simulates background work that happens behind the splash screen
        private async void SimulateStartup()
        {
            await Task.Delay(1000);

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}