using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VouDeVan.App.Web.AdminPainel.Models;
using VouDeVan.App.Web.AdminPainel.Models.TransportationCompany;
using VouDeVan.Core.Business.Domains.TransportationCompanies;
using VouDeVan.Core.Business.Support;


namespace VouDeVan.App.Web.AdminPainel.Controllers
{
    public class TransportationCompaniesController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult IndexGrid()
        {
            var transportationCompanies = new List<TransportationCompany>
            {
          
            };


            return PartialView(transportationCompanies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new TransportationCompanyViewModel();

            return View(viewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(TransportationCompanyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //CompanhiaRepository.Add(viewModel);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Funcionario funcionario = funci.GetFuncionario(id);
            //if (funcionario == null)
            //{
            //    return NotFound();
            //}

            //return View(funcionario);
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
