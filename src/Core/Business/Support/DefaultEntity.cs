using System;
using System.ComponentModel.DataAnnotations;

namespace VouDeVan.Core.Business.Support
{
    public class DefaultEntity
    {
        [Required]
        public Guid Id { get; set; }

        [Required] public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdateAt { get; set; }
    }
}
