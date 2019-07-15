using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Iconize;
using VouDeVan.App.Mobile.Passanger.Models;
using VouDeVan.App.Mobile.Passanger.ViewsModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VouDeVan.App.Mobile.Passanger.Views.Home
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = new HomePageViewModel
            {
                Routes = new List<Route>() {
                    new Route
                    {
                        Origin = "Palmas",
                        Destination = "Paraíso",
                        ImageUrl = "map.png",
                        Date = DateTime.Now
                    },
                    new Route
                    {
                        Origin = "Palmas",
                        Destination = "Gurupi",
                        ImageUrl = "map.png",
                        Date = DateTime.Now
                    },
                    new Route
                    {
                        Origin = "Paraiso",
                        Destination = "Gurupi",
                        ImageUrl = "map.png",
                        Date = DateTime.Now
                    }
                }
            };
        }
    }
}