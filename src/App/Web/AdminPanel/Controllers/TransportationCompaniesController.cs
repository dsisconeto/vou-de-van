using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using VouDeVan.App.Web.AdminPainel.Models;
using VouDeVan.App.Web.AdminPainel.Models.TransportationCompany;
using VouDeVan.Core.Business.Domains.TransportationCompanies;
using VouDeVan.Core.Business.Support;


namespace VouDeVan.App.Web.AdminPainel.Controllers
{
    public class TransportationCompaniesController : BaseController
    {
        private readonly TransportationCompanyServices _transportationCompanyServices;
        private readonly IMapper _mapper;

        public TransportationCompaniesController(TransportationCompanyServices transportationCompanyServices,
            IMapper mapper)
        {
            _transportationCompanyServices = transportationCompanyServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> IndexGrid([FromQueryAttribute] int page = 1)
        {
            var transportationCompanies = await _transportationCompanyServices.FindAllToGrid(page);

            return PartialView(transportationCompanies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TransportationCompanyViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [FromForm] TransportationCompanyViewModel transportationCompanyViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(transportationCompanyViewModel);
            }

            var transportationCompany = _mapper.Map<TransportationCompany>(transportationCompanyViewModel);


            await _transportationCompanyServices.Create(transportationCompany);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (ValidateGuid(id) == false)
            {
                return NotFound();
            }

            var transportationCompany = await _transportationCompanyServices.FindById(Guid.Parse(id));


            var transportationCompanyViewModel = _mapper.Map<TransportationCompanyViewModel>(transportationCompany);

            return View(transportationCompanyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,
            [FromForm] TransportationCompanyViewModel transportationCompanyViewModel)
        {
            if (ValidateGuid(id) == false)
            {
                return NotFound();
            }


            if (ModelState.IsValid == false)
            {
                return View(transportationCompanyViewModel);
            }

            var transportationCompany = _mapper.Map<TransportationCompany>(transportationCompanyViewModel);

            await _transportationCompanyServices.Update(transportationCompany);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            if (ValidateGuid(id) == false)
            {
                return NotFound();
            }

            await _transportationCompanyServices.Delete(Guid.Parse(id));

            return RedirectToAction("Index");
        }
    }
}