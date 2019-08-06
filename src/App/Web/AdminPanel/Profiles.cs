using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VouDeVan.App.Web.AdminPainel.Models.TransportationCompany;
using VouDeVan.Core.Business.Domains.TransportationCompanies;

namespace VouDeVan.App.Web.AdminPainel
{
    public class Profiles : Profile
    {

        public Profiles()
        {
            CreateMap<TransportationCompany, TransportationCompanyViewModel>();
            CreateMap<TransportationCompanyViewModel, TransportationCompany>();
        }
    }
}
