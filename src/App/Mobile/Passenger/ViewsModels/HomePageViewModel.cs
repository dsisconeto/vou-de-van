using System;
using System.Collections.Generic;
using System.Text;
using VouDeVan.App.Mobile.Passanger.Models;

namespace VouDeVan.App.Mobile.Passanger.ViewsModels
{
    public class HomePageViewModel
    {
        public List<Route> Routes { get; set; } = new List<Route>();
    }
}
