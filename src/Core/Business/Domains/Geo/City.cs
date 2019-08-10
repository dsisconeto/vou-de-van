using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.Core.Business.Domains.Geo
{
    public class City : DefaultEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public Guid StateId { get; set; }
        public State State { get; set; }
    }
}