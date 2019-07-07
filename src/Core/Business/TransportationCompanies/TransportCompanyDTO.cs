using System;

namespace VouDeVan.Core.Business.TransportationCompanies
{
    public struct TransportationCompanyDto
    {
        public Guid Id { get; set; }
        public string Cnpj { get; set; }
        public string FantasyName { get; set; }
        public string SocialName { get; set; }
        public string Address { get; set; }
        public string RepresentativeName { get; set; }
        public string RepresentativePhone { get; set; }
        public string Observation { get; set; }
        public Status Status { get; set; }
    }
}