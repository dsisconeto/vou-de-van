using System;
using System.ComponentModel.DataAnnotations;
using Business.Support;

namespace Business.Geo
{
    public class City : DefaultEntity
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Guid StateId { get; set; }

        public virtual State State { get; set; }
    }
}