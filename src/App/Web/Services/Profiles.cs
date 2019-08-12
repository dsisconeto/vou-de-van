using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using VouDeVan.App.Web.Services.TransportationCompanies;
using VouDeVan.Core.Business.Domains.TransportationCompanies;
using VouDeVan.Core.Support.TransportationCompanies;

namespace VouDeVan.App.Web.Services
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            
            CreateMap<TransportationCompany, TransportationCompaniesGetQueryViewModel>();
            CreateMap<TransportationCompanyGetQueryWithValidation, TransportationCompaniesGetQuery>();
        }
    }
}