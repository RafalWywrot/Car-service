using AutoMapper;
using CarService.Logic.ModelsDTO;
using CarService.Logic.Services.Abstract;
using CarService.WebApplication.Helpers.Extensions;
using CarService.WebApplication.Models.Car;
using CarService.WebApplication.Models.ServiceBooking;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace CarService.WebApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly ICarMainteanceService _carMainteanceService;
        private readonly ICarService _carService;

        public BookController(ICarMainteanceService carMainteanceService, ICarService carService)
        {
            _carMainteanceService = carMainteanceService;
            _carService = carService;
        }

        public ActionResult Index()
        {
            var model = _carMainteanceService.GetServices();
            return View(model);
        }

        public ViewResult AddServiceBooking()
        {
            var model = new ServiceBookingFormViewModel();
            InitializeDropdown(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddServiceBooking(ServiceBookingFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InitializeDropdown(model);
                return View(model);
            }

            //_carMainteanceService.AddServiceBooking();
            return RedirectToAction("Index");
        }

        private void InitializeDropdown(ServiceBookingFormViewModel model)
        {
            var userId = User.Identity.GetUserId();
            model.Cars = _carService.GetUserCars(userId).ToSelectListItems(x => x.Id, x => x.Model);
            model.Services = _carMainteanceService.GetServices().ToSelectListItems(x => x.Id, x => x.Name);
        }
    }
}