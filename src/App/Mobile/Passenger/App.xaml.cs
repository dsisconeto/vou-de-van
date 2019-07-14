using VouDeVan.App.Mobile.Passanger.Views;
using Xamarin.Forms;
using Plugin.Iconize;

namespace VouDeVan.App.Mobile.Passanger
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

#if DEBUG
            HotReloader.Current.Run(this);
#endif

            Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
                                  .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                                  .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule())
                                  .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule())
                                  .With(new Plugin.Iconize.Fonts.MaterialModule());

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}