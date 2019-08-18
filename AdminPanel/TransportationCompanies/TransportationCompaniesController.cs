using System;
using System.Threading.Tasks;
using AdminPanel.Common;
using AutoMapper;
using Business.TransportationCompanies;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Storage;

namespace AdminPanel.TransportationCompanies
{
    public class TransportationCompaniesController : BaseController
    {
        private readonly TransportationCompanyServices _transportationCompanyServices;
        private readonly IMapper _mapper;
        private readonly IStorage _storage;

        public TransportationCompaniesController(TransportationCompanyServices transportationCompanyServices,
            IMapper mapper, IStorage storage, IToastNotification toastNotification) : base(toastNotification)
        {
            _transportationCompanyServices = transportationCompanyServices;
            _mapper = mapper;
            _storage = storage;
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

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [FromForm] TransportationCompanyViewModel transportationCompanyViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(transportationCompanyViewModel);
            }


            // TODO apagar se der erro tem que apagar  a imagem

            var transportationCompany = _mapper.Map<TransportationCompany>(transportationCompanyViewModel);
            transportationCompany.Logo = await _storage.Store<Logo>(transportationCompanyViewModel.Logo);


            return await ToastMessage(async () =>
                {
                    await _transportationCompanyServices.Create(transportationCompany);

                    return "Empresa de Transporte cadastrada.";
                },
                () => RedirectToAction("Index"),
                () => View(transportationCompanyViewModel));
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


            return await ToastMessage(async () =>
                {
                    await _transportationCompanyServices.Update(transportationCompany);

                    return "Empresa de transporte editada com sucesso.";
                },
                () => RedirectToAction("Index"),
                () => View(transportationCompanyViewModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            if (ValidateGuid(id) == false)
            {
                return NotFound();
            }

            // TODO verificar relações 

            return await ToastMessage(async () =>
                {
                    await _transportationCompanyServices.Delete(Guid.Parse(id));

                    return "Empresa de transporte deletada com sucesso.";
                },
                () => RedirectToAction("Index"),
                () => RedirectToAction("Index"));
        }
    }
}