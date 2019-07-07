using AutoMapper;
using VouDeVan.Core.Business.TransportationCompanies;

namespace VouDeVan.Infrastructure.Database.TransportationCompanies
{
    public class TransportationCompanyProfile : Profile
    {
        public TransportationCompanyProfile()
        {
            CreateMap<TransportationCompanyDataRow, TransportationCompanyDto>();
            CreateMap<TransportationCompanyDto, TransportationCompanyDataRow>();

            CreateMap<TransportationCompany, TransportationCompanyDataRow>()
                .ForMember(row => row.Cnpj,
                    transportationCompany => transportationCompany.MapFrom(tc => tc.Cnpj.Number))
                .ForMember(row => row.RepresentativePhone,
                    transportationCompany => transportationCompany.MapFrom(tc => tc.Representative.Phone.ToString()))
                .ForMember(row => row.RepresentativeName,
                    transportationCompany => transportationCompany.MapFrom(tc => tc.Representative.Name))
                .ForMember(row => row.Status,
                    transportationCompany => transportationCompany.MapFrom(tc => tc.Status.ToString()));
        }
    }
}