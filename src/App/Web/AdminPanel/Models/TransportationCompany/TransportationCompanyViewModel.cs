using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VouDeVan.Core.Business.TransportationCompanies;

namespace VouDeVan.App.Web.AdminPainel.Models.TransportationCompany
{
    public class TransportationCompanyViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Nome Fantasia")]
        public string FantasyName { get; set; }

        [Required]
        [DisplayName("Nome Social")]

        // TODO: fazer as validações do lado do cliente com os demais atributos
        public string SocialName { get; set; }
        public string Address { get; set; }
        public string RepresentativeName { get; set; }
        public string RepresentativePhone { get; set; }
        public string Observation { get; set; }
        public Status Status { get; set; }
    }
}
