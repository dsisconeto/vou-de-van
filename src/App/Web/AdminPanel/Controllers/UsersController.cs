using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using VouDeVan.App.Web.AdminPainel.Models;
using VouDeVan.App.Web.AdminPainel.Controllers;

namespace VouDeVan.App.Web.AdminPainel.Controllers
{
    public class UsersController : BaseController
    {

        public UsersController(IToastNotification toastNotification) : base(toastNotification)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
