﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id)
        {
            //if (id != funcionario.FuncionarioId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                //fCompanhiaRepositoryunci.UpdateFuncionario(funcionario);
                return RedirectToAction("Index");
            }

            //return View(companhias);
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            //CompanhiaRepository.DeleteFuncionario(id);
            return RedirectToAction("Index");
        }
    }
}