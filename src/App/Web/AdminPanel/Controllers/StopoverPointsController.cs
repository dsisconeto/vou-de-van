using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VouDeVan.App.Web.AdminPainel.Controllers;
using VouDeVan.App.Web.AdminPainel.Models.StopoverPoints;
using VouDeVan.Core.Business.Domains.Geo;
using VouDeVan.Core.Business.Domains.StopoverPoints;
using System.Linq;
using System.Collections;

namespace AdminPanel.Controllers
{
    public class StopoverPointsController : BaseController
    {
        private readonly StopoverPointServices _stopoverPointsServices;
        private readonly CityServices _cityServices;
        private readonly IMapper _mapper;

        public StopoverPointsController(StopoverPointServices stopoverPointServices,
            CityServices cityServices,
            IMapper mapper)
        {
            _stopoverPointsServices = stopoverPointServices;
            _cityServices = cityServices;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> IndexGrid([FromQueryAttribute] int page = 1)
        {
            var stopoverPoints = await _stopoverPointsServices.FindAllToGrid(page);
   
            return PartialView(stopoverPoints);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new StopoverPointsViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [FromForm] StopoverPointsViewModel stopoverPointsViewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View(stopoverPointsViewModel);
            }

            var stopoverPoint = _mapper.Map<StopoverPoint>(stopoverPointsViewModel);

            await _stopoverPointsServices.Create(stopoverPoint);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetCitiesSelect2(string term)
        {
            var lista = _cityServices.FindAll(1).Select(city => new { Value = city.Id.ToString(), Text = $"{city.Name} - {city.State.Initials}" });

            return Json(lista);
        }
    }
}