using AdminPanel.Common;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace AdminPanel.Home
{
    public class HomeController : BaseController
    {

        public HomeController(IToastNotification toastNotification) :base(toastNotification)
        {

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
