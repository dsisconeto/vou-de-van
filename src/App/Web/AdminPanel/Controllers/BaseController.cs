using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using NToastNotify;
using VouDeVan.App.Web.AdminPainel.Models.Common;
using VouDeVan.Core.Business.Support;

namespace VouDeVan.App.Web.AdminPainel.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IToastNotification _toastNotification;

        public BaseController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public bool ValidateGuid(string id) => id != null && Guid.TryParse(id, out _);


        public async Task<IActionResult> Business(
            Func<Task<string>> funcBusiness,
            Func<IActionResult> success,
            Func<IActionResult> error)
        {
            try
            {
                var message = await funcBusiness();

                _toastNotification.AddSuccessToastMessage(message);

                return success();
            }
            catch (BusinessException e)
            {
                _toastNotification.AddErrorToastMessage(e.Message);
                return error();
            }
        }
    }
}