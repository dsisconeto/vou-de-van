﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using Lottie.Forms.iOS.Renderers;
using UIKit;

namespace VouDeVan.App.Mobile.Passenger.iOS
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
            global::Xamarin.Forms.FormsMaterial.Init();
            LoadApplication(new Passanger.App());

            // Inicializa plugin do Google Maps
            Xamarin.FormsGoogleMaps.Init("AIzaSyBumjFnUe1V-Ci_70HVVabIbzNzRseJRJE");

            // Plugin de Ícones 'Iconize'
            Plugin.Iconize.Iconize.Init();

            // Plugin de Imagens Circulares 'Image Circle'
            ImageCircleRenderer.Init();

            // Plugin de Animações 'Lottie'
            AnimationViewRenderer.Init();

            return base.FinishedLaunching(app, options);
        }
    }
}
