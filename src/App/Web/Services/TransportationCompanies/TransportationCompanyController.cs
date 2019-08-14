using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VouDeVan.Core.Business.Domains.TransportationCompanies;
using VouDeVan.Core.Support;
using VouDeVan.Core.Support.TransportationCompanies;


namespace VouDeVan.App.Web.Services.TransportationCompanies
{
    [ApiController]
    [Route("transportation-companies")]
    public class TransportationCompanyController
    {
        private readonly TransportationCompanyServices _transportationCompanyServices;
        private readonly IMapper _mapper;

        public TransportationCompanyController(TransportationCompanyServices transportationCompanyServices,
            IMapper mapper)
        {
            _transportationCompanyServices = transportationCompanyServices;
            _mapper = mapper;
        }

        //[HttpGet]
        //public async Task<Paginate<TransportationCompaniesGetQueryViewModel>> Get(
        //    [FromQuery] TransportationCompanyGetQueryWithValidation transportationCompanyGetQueryWithValidation)

        //{
        //    var transportationCompaniesGetQuery =
        //        _mapper.Map<TransportationCompanyGetQueryWithValidation, TransportationCompaniesGetQuery>(
        //            transportationCompanyGetQueryWithValidation);

        //    var transportationCompaniesPaginate =
        //        await _transportationCompanyServices.FindByGetQuery(transportationCompaniesGetQuery);

        //    var items = _mapper.Map<List<TransportationCompany>, List<TransportationCompaniesGetQueryViewModel>>(
        //        transportationCompaniesPaginate.Items);

        //    return new Paginate<TransportationCompaniesGetQueryViewModel>
        //    {
        //        PerPage = transportationCompaniesPaginate.PerPage,
        //        Items = items,
        //        Page = transportationCompaniesPaginate.Page,
        //        Total = transportationCompaniesPaginate.Total,
        //    };
        //}
    }
}