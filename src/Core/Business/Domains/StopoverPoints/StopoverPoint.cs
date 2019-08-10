using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VouDeVan.Core.Business.Domains.Geo;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.Core.Business.Domains.StopoverPoints
{
    public class StopoverPoint : DefaultEntity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public Guid CityId { get; set; }

        public City City { get; set; }


        [Required]
        [MaxLength(40)]
        public Status Status { get; set; }

    }
}
