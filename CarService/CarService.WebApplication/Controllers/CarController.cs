using CarService.Logic.Services.Abstract;
using System.Web.Mvc;

namespace CarService.WebApplication.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Brands()
        {
            var models = _carService.GetAll();
            return View(models);
        }

        public ActionResult Models(int brandId)
        {
            var models = _carService.GetModels(brandId);
            return View(models);
        }
    }
}