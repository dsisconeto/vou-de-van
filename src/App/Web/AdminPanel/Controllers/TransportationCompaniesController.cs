using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using VouDeVan.App.Web.AdminPainel.Controllers;
using VouDeVan.App.Web.AdminPainel.Models.TransportationCompanies;
using VouDeVan.App.Web.AdminPainel.Support.Storage;
using VouDeVan.Core.Business.Domains.TransportationCompanies;

namespace AdminPainel.Controllers
{
    public class TransportationCompaniesController : BaseController
    {
        private readonly IToastNotification _toastNotification;

        private readonly TransportationCompanyServices _transportationCompanyServices;
        private readonly IMapper _mapper;
        private readonly IStorage _storage;

        public TransportationCompaniesController(TransportationCompanyServices transportationCompanyServices,
            IMapper mapper, IStorage storage, IToastNotification toastNotification)
        {
            _transportationCompanyServices = transportationCompanyServices;
            _mapper = mapper;
            _storage = storage;

            _toastNotification = toastNotification;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> IndexGrid([FromQuery] int page = 1)
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

            try
            {
                // TODO gamiarra aqui
                if (transportationCompanyViewModel.LogoSizeIsValid == false)
                {
                    return View(transportationCompanyViewModel);
                }

                // TODO apagar se der erro tem que apagar  a imagem

                var transportationCompany = _mapper.Map<TransportationCompany>(transportationCompanyViewModel);
                transportationCompany.Logo = await _storage.Store<Logo>(transportationCompanyViewModel.Logo);

                await _transportationCompanyServices.Create(transportationCompany);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _toastNotification.AddErrorToastMessage(ex?.Message);

                if (ex.InnerException != null)
                    _toastNotification.AddErrorToastMessage(ex?.InnerException.Message);

                return View(transportationCompanyViewModel);
            }
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