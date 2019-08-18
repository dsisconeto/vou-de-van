using AdminPanel.Common;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace  AdminPanel.Users
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
