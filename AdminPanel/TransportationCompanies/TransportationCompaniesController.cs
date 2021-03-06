﻿using System;
using System.Threading.Tasks;
using AdminPanel.Common;
using AutoMapper;
using Business.Support;
using Business.TransportationCompanies;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Storage;

namespace AdminPanel.TransportationCompanies
{
    [Route("empresas")]
    public class TransportationCompaniesController : BaseController
    {
        private readonly TransportationCompanyServices _transportationCompanyServices;
        private readonly IMapper _mapper;

        public TransportationCompaniesController(TransportationCompanyServices transportationCompanyServices,
            IMapper mapper, IToastNotification toastNotification) : base(toastNotification)
        {
            _transportationCompanyServices = transportationCompanyServices;
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("index-grid")]
        public async Task<PartialViewResult> IndexGrid([FromQuery] int page = 1)
        {
            var transportationCompanies = await _transportationCompanyServices.FindAllToGrid(page);
            var transportationCompaniesIndexViewModel =
                _mapper.Map<Paginate<TransportationCompanyIndexViewModel>>(transportationCompanies);

            return PartialView(transportationCompaniesIndexViewModel);
        }

        [HttpGet("cadastrar")]
        public IActionResult Create()
        {
            return View(new TransportationCompanyViewCreate());
        }

        [HttpPost("cadastrar"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [FromForm] TransportationCompanyViewCreate transportationCompanyViewCreate)
        {
            if (ModelState.IsValid == false)
            {
                return View(transportationCompanyViewCreate);
            }

            var transportationCompany = _mapper.Map<TransportationCompany>(transportationCompanyViewCreate);

            return await ToastMessage(async () =>
                {
                    await _transportationCompanyServices.Create(transportationCompany,
                        transportationCompanyViewCreate.Logo);

                    return "Empresa de Transporte cadastrada.";
                },
                () => RedirectToAction("Index"),
                () => View(transportationCompanyViewCreate));
        }

        [HttpGet("editar/{id}")]
        public async Task<IActionResult> Edit([FromRoute] string id)
        {
            if (ValidateGuid(id) == false)
            {
                return NotFound();
            }


            var transportationCompany = await _transportationCompanyServices.FindById(Guid.Parse(id));

            var transportationCompaniesEditViewModel =
                _mapper.Map<TransportationCompaniesEditViewModel>(transportationCompany);

            return View(transportationCompaniesEditViewModel);
        }

        [HttpPost("editar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id,
            [FromForm] TransportationCompaniesEditViewModel transportationCompaniesEditViewModel)
        {
            if (ValidateGuid(id) == false)
            {
                return NotFound();
            }

            if (ModelState.IsValid == false)
            {
                return View(transportationCompaniesEditViewModel);
            }

            var transportationCompany = await _transportationCompanyServices.FindById(Guid.Parse(id));


            transportationCompany = _mapper.Map(transportationCompaniesEditViewModel, transportationCompany);

            return await ToastMessage(async () =>
                {
                    await _transportationCompanyServices.Update(transportationCompany,
                        transportationCompaniesEditViewModel.Logo);

                    return "Empresa de transporte editada com sucesso.";
                },
                () => RedirectToAction("Index"),
                () => View(transportationCompaniesEditViewModel));
        }

        [HttpPost("deletar/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] string id)
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