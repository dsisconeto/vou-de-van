using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Business.Support;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace AdminPanel.Common
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


        public async Task<IActionResult> ToastMessage(
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