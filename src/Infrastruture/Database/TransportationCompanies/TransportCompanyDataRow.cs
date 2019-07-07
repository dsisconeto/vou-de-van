using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VouDeVan.Infrastructure.Database.TransportationCompanies
{
    [Table("TransportationCompanies")]
    public class TransportationCompanyDataRow : DefaultDataRow
    {
        [MaxLength(14)] public string Cnpj { get; set; }
        [MaxLength(50)] public string FantasyName { get; set; }
        [MaxLength(100)] public string SocialName { get; set; }
        [MaxLength(400)] public string Address { get; set; }
        [MaxLength(100)] public string RepresentativeName { get; set; }
        [MaxLength(11)] public string RepresentativePhone { get; set; }
        [Column(TypeName = "text")] public string Observation { get; set; }
        [MaxLength(40)] public string Status { get; set; }
    }
}