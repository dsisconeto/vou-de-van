﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VouDeVan.App.Web.AdminPainel.Models;

namespace VouDeVan.App.Web.AdminPainel.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
