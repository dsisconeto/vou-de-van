using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using VouDeVan.App.Mobile.Passanger.Controls;
using VouDeVan.App.Mobile.Passenger.Droid.Renderers;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Entry), typeof(CustomEntryRenderer), new[] { typeof(CustomVisual) })]

namespace VouDeVan.App.Mobile.Passenger.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.SetBackground(null);
            }
        }
    }
}