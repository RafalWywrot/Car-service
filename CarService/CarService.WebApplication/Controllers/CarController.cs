using CarService.Logic.Services.Abstract;
using CarService.WebApplication.Helpers.Extensions;
using CarService.WebApplication.Models.Car;
using Microsoft.AspNet.Identity;
using System.Linq;
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
            var userId = User.Identity.GetUserId();
            var cars = _carService.GetUserCars(userId);
            return View(cars);
        }
        
        public ActionResult Add()
        {
            var model = new CarFormViewModel();
            InitializeCarDropdowns(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(CarFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InitializeCarDropdowns(model);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetModels(int brandId)
        {
            var models = _carService.GetModels(brandId);
            return Json(models.ToSelectListItems(x => x.Id, x => x.Name), JsonRequestBehavior.AllowGet);
        }
        
        private void InitializeCarDropdowns(CarFormViewModel model)
        {
            model.CarBrands = _carService.GetAll().ToSelectListItems(x => x.Id, x => x.Name);
            model.CarModels = _carService.GetModels(model.CarBrandId).ToSelectListItems(x => x.Id, x => x.Name);

            model.TransmissionOptions = _carService.GetTransmissionOptions().ToSelectListItems(x => x.Id, x => x.Name);
            model.FuelOptions = _carService.GetFuelTypes().ToSelectListItems(x => x.Id, x => x.Name);
        }
    }
}