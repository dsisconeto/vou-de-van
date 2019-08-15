using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "decimal(10,8)")]
        public decimal Latitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(11,8)")]
        public decimal Longitude { get; set; }

        [Required]
        public Guid CityId { get; set; }

        public virtual City City { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}
