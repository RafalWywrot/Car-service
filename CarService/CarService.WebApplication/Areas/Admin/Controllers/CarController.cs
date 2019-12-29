using AutoMapper;
using CarService.Logic.Services.Abstract;
using CarService.WebApplication.Areas.Admin.Models;
using CarService.WebApplication.Helpers;
using CarService.WebApplication.Helpers.ActionFilters;
using CarService.WebApplication.Models.Car;
using CarService.WebApplication.Models.ServiceBooking;
using System.Collections.Generic;
using System.Web.Mvc;
namespace CarService.WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = SystemRoles.Admin)]
    public class CarController : Controller
    {
        private readonly ICarMainteanceService _carMainteanceService;

        public CarController(ICarMainteanceService carMainteanceService)
        {
            _carMainteanceService = carMainteanceService;
        }

        public ViewResult History(int carId)
        {
            var allBookings = _carMainteanceService.GetBookingsByCar(carId);
            var model = Mapper.Map<IEnumerable<ServiceBookingSummaryAdminViewModel>>(allBookings);
            return View(model);
        }
    }
}