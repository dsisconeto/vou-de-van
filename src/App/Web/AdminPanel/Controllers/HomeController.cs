using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VouDeVan.App.Web.AdminPainel.Models;
using VouDeVan.App.Web.AdminPainel.Controllers;
using NToastNotify;

namespace VouDeVan.App.Web.AdminPainel.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IToastNotification _toastNotification;

        public HomeController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        public IActionResult Index()
        {
            _toastNotification.AddSuccessToastMessage("Same for success message");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
