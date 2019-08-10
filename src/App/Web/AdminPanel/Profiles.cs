using AutoMapper;
using VouDeVan.Core.Business.Domains.StopoverPoints;
using VouDeVan.App.Web.AdminPainel.Models.TransportationCompany;
using VouDeVan.Core.Business.Domains.TransportationCompanies;
using VouDeVan.App.Web.AdminPainel.Models.StopoverPoints;

namespace VouDeVan.App.Web.AdminPainel
{
    public class Profiles : Profile
    {

        public Profiles()
        {
            CreateMap<TransportationCompany, TransportationCompanyViewModel>();
            CreateMap<TransportationCompanyViewModel, TransportationCompany>();

            CreateMap<StopoverPoint, StopoverPointsViewModel>();
            CreateMap<StopoverPointsViewModel, StopoverPoint>();
        }
    }
}
