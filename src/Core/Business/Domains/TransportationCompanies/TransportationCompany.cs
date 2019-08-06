using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.Core.Business.Domains.TransportationCompanies
{
    public class TransportationCompany : DefaultEntity
    {
        [Required]
        [MaxLength(14)]
        public string CNPJ { get; set; }

        [Required]
        [MaxLength(50)]
        public string FantasyName { get; set; }

        [Required]
        [MaxLength(100)]
        public string SocialName { get; set; }

        [Required]
        [MaxLength(400)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string RepresentativeName { get; set; }

        [Required]
        [MaxLength(11)]
        public string RepresentativePhone { get; set; }

        [Column(TypeName = "text")]
        public string Observation { get; set; }

        [Required]
        [MaxLength(40)]
        public Status Status { get; set; }
    }
}
