using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VouDeVan.App.Web.AdminPainel.Models;
using VouDeVan.App.Web.AdminPainel.Models.TransportationCompany;
using VouDeVan.Core.Business.Support;
using VouDeVan.Core.Business.TransportationCompanies;

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
                new TransportationCompany(
                    Guid.NewGuid(),
                    "AAA",
                    "aaa",
                    new Cnpj("78.744.332/0001-78"),
                    "1313",
                    new Representative("Gus", new Phone("(63) 99268-9898")),
                    "123131",
                    Status.Active
                ),
                new TransportationCompany(
                    Guid.NewGuid(),
                    "BBB",
                    "bbb",
                    new Cnpj("17.642.990/0001-64"),
                    "e1e423",
                    new Representative("Gus", new Phone("(63) 99268-9898")),
                    "424",
                    Status.Active
                ),
                new TransportationCompany(
                    Guid.NewGuid(),
                    "BBB",
                    "bbb",
                    new Cnpj("17.642.990/0001-64"),
                    "e1e423",
                    new Representative("Gus", new Phone("(63) 99268-9898")),
                    "424",
                    Status.Active
                ),
                new TransportationCompany(
                    Guid.NewGuid(),
                    "BBB",
                    "bbb",
                    new Cnpj("17.642.990/0001-64"),
                    "e1e423",
                    new Representative("Gus", new Phone("(63) 99268-9898")),
                    "424",
                    Status.Active
                )
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
