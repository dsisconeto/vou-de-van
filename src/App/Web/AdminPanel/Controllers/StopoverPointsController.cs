using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VouDeVan.App.Web.AdminPainel.Controllers;
using VouDeVan.App.Web.AdminPainel.Models.StopoverPoints;
using VouDeVan.Core.Business.Domains.StopoverPoints;

namespace AdminPanel.Controllers
{
    public class StopoverPointsController : BaseController
    {
        private readonly StopoverPointServices _stopoverPointsServices;
        private readonly IMapper _mapper;

        public StopoverPointsController(StopoverPointServices stopoverPointServices,
            IMapper mapper)
        {
            _stopoverPointsServices = stopoverPointServices;
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
    }
}