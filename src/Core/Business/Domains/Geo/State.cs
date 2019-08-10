using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.Core.Business.Domains.Geo
{
    public class State : DefaultEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
