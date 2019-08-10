using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VouDeVan.App.Web.AdminPainel.Controllers;
using VouDeVan.App.Web.AdminPainel.Models.TransportationCompanies;
using VouDeVan.Core.Business.Domains.StopoverPoints;
using VouDeVan.Core.Business.Domains.TransportationCompanies;
using VouDeVan.App.Web.AdminPainel.Models.StopoverPoints;

namespace VouDeVan.App.Web.AdminPainel
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<TransportationCompany, TransportationCompanyViewModel>();
            CreateMap<TransportationCompanyViewModel, TransportationCompany>()
                .ForMember(dest => dest.Logo, opt => opt.Ignore());
            CreateMap<StopoverPoint, StopoverPointsViewModel>();
            CreateMap<StopoverPointsViewModel, StopoverPoint>();
        }
    }
}
