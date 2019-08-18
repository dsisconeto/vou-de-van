using AdminPanel.StopoverPoints;
using AdminPanel.TransportationCompanies;
using AutoMapper;
using Business.StopoverPoints;
using Business.Support;
using Business.TransportationCompanies;

namespace VouDeVan.App.Web.AdminPainel
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            MapperTransportationCompany();

            CreateMap<StopoverPoint, StopoverPointsViewModel>();
            CreateMap<StopoverPointsViewModel, StopoverPoint>();
        }


        public void MapperTransportationCompany()
        {
            CreateMap<TransportationCompany, TransportationCompanyViewModel>()
                .ForMember(dest => dest.Logo, opt => opt.Ignore());


            CreateMap<TransportationCompanyViewModel, TransportationCompany>()
                .ForMember(dest => dest.Logo, opt => opt.Ignore())
                .ForMember(
                    dest => dest.CNPJ,
                    source => source.MapFrom(tc => new Cnpj(tc.CNPJ).ToString())
                )
                .ForMember(
                    dest => dest.RepresentativePhone,
                    source => source.MapFrom(tc => new Phone(tc.RepresentativePhone).ToString())
                );
        }
    }
}