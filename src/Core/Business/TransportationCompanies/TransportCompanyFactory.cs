using System;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.Core.Business.TransportationCompanies
{
    public class TransportationCompanyFactory
    {
        public TransportationCompany MakeByDto(TransportationCompanyDto dto)
        {
            return new TransportationCompany(
                dto.Id,
                dto.FantasyName,
                dto.SocialName,
                new Cnpj(dto.Cnpj),
                dto.Address,
                new Representative(dto.RepresentativeName, new Phone(dto.RepresentativePhone)),
                dto.Observation,
                Status.Active
            );
        }
    }
}