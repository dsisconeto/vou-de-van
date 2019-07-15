using System;
using System.Collections.Generic;
using System.Text;

namespace VouDeVan.App.Mobile.Passanger.Models
{
    public class Route
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Title => $"{Origin} - {Destination}";
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
    }
}
