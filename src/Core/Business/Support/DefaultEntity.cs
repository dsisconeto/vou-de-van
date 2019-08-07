using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VouDeVan.Core.Business.Support
{
    public class DefaultEntity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required] public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required] public DateTime UpdateAt { get; set; }
    }
}