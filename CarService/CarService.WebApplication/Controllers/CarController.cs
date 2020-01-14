using AutoMapper;
using CarService.Logic.Exceptions;
using CarService.Logic.ModelsDTO;
using CarService.Logic.Services.Abstract;
using CarService.WebApplication.Helpers;
using CarService.WebApplication.Helpers.Extensions;
using CarService.WebApplication.Models.Car;
using CarService.WebApplication.Models.ServiceBooking;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarService.WebApplication.Controllers
{
    [Authorize(Roles = SystemRoles.User)]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarMainteanceService _carMainteanceService;

        public CarController(ICarService carService, ICarMainteanceService carMainteanceService)
        {
            _carService = carService;
            _carMainteanceService = carMainteanceService;
        }

        // GET: Car
        public ActionResult Index()
        {
            return View(GetCars());
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
            _carService.AddCar(Mapper.Map<CarDTO>(model), User.Identity.GetUserId());
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int carId)
        {
            var model = Mapper.Map<CarFormViewModel>(_carService.GetCar(carId));
            InitializeCarDropdowns(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CarFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InitializeCarDropdowns(model);
                return View(model);
            }
            _carService.UpdateCar(Mapper.Map<CarDTO>(model));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult GetModels(int brandId)
        {
            var models = _carService.GetModels(brandId);
            return Json(models.ToSelectListItems(x => x.Id, x => x.Name), JsonRequestBehavior.AllowGet);
        }

        public ViewResult History(int carId)
        {
            var allBookings = _carMainteanceService.GetBookingsByCar(carId);
            var model = Mapper.Map<IEnumerable<ServiceBookingSummaryViewModel>>(allBookings);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int carId)
        {
            try
            {
                _carService.DeleteCar(carId);
                return RedirectToAction("Index");
            }
            catch (CarException)
            {
                ModelState.AddModelError(string.Empty, "Auto jest w trakcie niezakończonych usług. Nie możesz usunąć auta");
                return View("Index", GetCars());
            }
        }

        private IEnumerable<CarSummaryViewModel> GetCars()
        {
            var userId = User.Identity.GetUserId();
            var cars = _carService.GetUserCars(userId);
            return Mapper.Map<IEnumerable<CarSummaryViewModel>>(cars);
        }

        private void InitializeCarDropdowns(CarFormViewModel model)
        {
            var carBrands = _carService.GetAll();
            model.CarBrands = carBrands.ToSelectListItems(x => x.Id, x => x.Name);

            int carBrandId = model.CarBrandId == 0 ? carBrands.FirstOrDefault()?.Id ?? model.CarBrandId : model.CarBrandId;
            model.CarModels = _carService.GetModels(carBrandId).ToSelectListItems(x => x.Id, x => x.Name);

            model.TransmissionOptions = _carService.GetTransmissionOptions().ToSelectListItems(x => x.Id, x => x.Name);
            model.FuelOptions = _carService.GetFuelTypes().ToSelectListItems(x => x.Id, x => x.Name);
        }
    }
}