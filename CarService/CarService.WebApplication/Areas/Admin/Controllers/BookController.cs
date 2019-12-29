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
    public class BookController : Controller
    {
        private readonly ICarMainteanceService _carMainteanceService;
        private readonly IBookingService _bookingService;
        private readonly ICarService _carService;

        public BookController(ICarMainteanceService carMainteanceService, IBookingService bookingService, ICarService carService)
        {
            _carMainteanceService = carMainteanceService;
            _bookingService = bookingService;
            _carService = carService;
        }

        public ActionResult Index()
        {
            var allBookings = _carMainteanceService.GetAllBookings();
            var model = Mapper.Map<IEnumerable<ServiceBookingSummaryAdminViewModel>>(allBookings);
            return View(model);
        }

        public ViewResult Show(int bookingServiceId)
        {
            var bookingService = _carMainteanceService.GetBooking(bookingServiceId);
            var car = _carService.GetCarDetails(bookingService.Car.Id);
            var model = new ServiceBookingDetailAdminViewModel
            {
                ServiceDetails = Mapper.Map<ServiceBookingSummaryViewModel>(bookingService),
                CarDetails = car
            };
            return View(model);
        }

        public ActionResult EditDate(int bookingServiceId)
        {
            var bookingService = _carMainteanceService.GetBooking(bookingServiceId);
            var model = Mapper.Map<ServiceBookingDateAdminViewModel>(bookingService);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditDate(ServiceBookingDateAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _carMainteanceService.UpdateDateServiceBooking(model.Id, model.DateCreated.Value);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult SetAsVerified(int bookingServiceId)
        {
            try
            {
                _bookingService.SetStatusAsVerified(bookingServiceId);   
                return Json(new { });
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [BookingServiceStatusAfterVerifyFilter]
        public JsonResult SetAsAccepted(int bookingServiceId)
        {
            try
            {
                _bookingService.SetStatusAsAccepted(bookingServiceId);
                return Json(new { });
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public JsonResult SetAsDecline(int bookingServiceId)
        {
            try
            {
                _bookingService.SetStatusAsDeclined(bookingServiceId);
                return Json(new { });
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public JsonResult SetAsInProgress(int bookingServiceId)
        {
            try
            {
                _bookingService.SetStatusInProgress(bookingServiceId);
                return Json(new { });
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public JsonResult SetAsFinished(int bookingServiceId)
        {
            try
            {
                _bookingService.SetStatusAsFinished(bookingServiceId);
                return Json(new { });
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}