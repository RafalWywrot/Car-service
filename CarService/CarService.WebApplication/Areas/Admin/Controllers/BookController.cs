using AutoMapper;
using CarService.Logic.Services.Abstract;
using CarService.Repository.CustomTypes;
using CarService.WebApplication.Areas.Admin.Models;
using CarService.WebApplication.Helpers;
using CarService.WebApplication.Helpers.ActionFilters;
using CarService.WebApplication.Models.Car;
using CarService.WebApplication.Models.ServiceBooking;
using CarService.WebApplication.Models.User;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarService.WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = SystemRoles.Admin + ", " + SystemRoles.Mechanic)]
    public class BookController : Controller
    {
        private readonly ICarMainteanceService _carMainteanceService;
        private readonly IBookingService _bookingService;
        private readonly ICarService _carService;
        private readonly ApplicationUserManager _userManager;

        public BookController(ICarMainteanceService carMainteanceService, IBookingService bookingService, ICarService carService, ApplicationUserManager userManager)
        {
            _carMainteanceService = carMainteanceService;
            _bookingService = bookingService;
            _carService = carService;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            var allUnfinishedBookings = _carMainteanceService.GetUnfinishedBookings();
            if (User.IsInRole(SystemRoles.Admin))
            {
                var model = Mapper.Map<IEnumerable<ServiceBookingSummaryAdminViewModel>>(allUnfinishedBookings);
                return View("Index", model);
            }
            var userId = User.Identity.GetUserId();
            var modelForMechanic = new ServiceBookingSeparatedAdminViewModel
            {
                ServicesAlreadyAssigned = Mapper.Map<IEnumerable<ServiceBookingSummaryAdminViewModel>>(allUnfinishedBookings.Where(x => x.MechanicId == userId)),
                ServicesUnassignedToAnyMechanic = Mapper.Map<IEnumerable<ServiceBookingSummaryAdminViewModel>>(allUnfinishedBookings.Where(x => string.IsNullOrEmpty(x.MechanicId)))
            };
            return View("IndexMechanic", modelForMechanic);
        }
        
        public ActionResult Archived()
        {
            var allFinishedBookings = _carMainteanceService.GetArchivedBookings();
            if (User.IsInRole(SystemRoles.Admin))
            {
                var model = Mapper.Map<IEnumerable<ServiceBookingSummaryAdminViewModel>>(allFinishedBookings);
                return View("Index", model);
            }
            var userId = User.Identity.GetUserId();
            var modelForMechanic = new ServiceBookingSeparatedAdminViewModel
            {
                IsArchived = true,
                ServicesAlreadyAssigned = Mapper.Map<IEnumerable<ServiceBookingSummaryAdminViewModel>>(allFinishedBookings.Where(x => x.MechanicId == userId))
            };
            return View("IndexMechanic", modelForMechanic);
        }
        
        public ViewResult Show(int bookingServiceId)
        {
            var bookingService = _carMainteanceService.GetBooking(bookingServiceId);
            var car = _carService.GetCarDetails(bookingService.Car.Id);
            var user = _userManager.FindById(car.UserId);
            var model = new ServiceBookingDetailAdminViewModel
            {
                ServiceDetails = Mapper.Map<ServiceBookingSummaryViewModel>(bookingService),
                CarDetails = car,
                User = Mapper.Map<UserBasicViewModel>(user)
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
        public async Task<ActionResult> EditDate(ServiceBookingDateAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _carMainteanceService.UpdateDateServiceBooking(model.Id, model.DateCreated.Value, model.Comment);
            try
            {
                var user = _carMainteanceService.GetUser(model.Id);
                await _userManager.SendEmailAsync(user.Email, "Zmieniono datę usługi", string.Format(Resource.EmailToClientOfChangedDate, user.Name, model.DateCreated.Value.ToShortDateString()));
            }
            catch (System.Exception)
            {
                //Logger.Error();
            }
            
            return RedirectToAction("Index");
        }

        [Authorize(Roles = SystemRoles.Admin)]
        public ActionResult EditMechanic(int bookingServiceId)
        {
            var mechanics = _userManager.Users.ToList().Where(x => x.Roles.Select(c => c.Name).Contains(SystemRoles.Mechanic)).ToList();
            var booking = _carMainteanceService.GetBooking(bookingServiceId);
            var model = new ServiceBookingMechanicAdminViewModel
            {
                Mechanics = Mapper.Map<IEnumerable<UserBasicViewModel>>(mechanics),
                MechanicId = booking.MechanicId,
                ServiceBookingId = bookingServiceId
            };
            return View(model);
        }

        [Authorize(Roles = SystemRoles.Admin)]
        [HttpPost]
        public ActionResult EditMechanic(ServiceBookingMechanicAdminViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var mechanics = _userManager.Users.ToList().Where(x => x.Roles.Select(c => c.Name).Contains(SystemRoles.Mechanic)).ToList();
                model.Mechanics = Mapper.Map<IEnumerable<UserBasicViewModel>>(mechanics);
                return View(model);
            }

            _bookingService.AssignUser(model.ServiceBookingId, model.MechanicId);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = SystemRoles.Mechanic)]
        [HttpPost]
        public ActionResult AssignToMechanic(int bookingServiceId)
        {
            var userId = User.Identity.GetUserId();
            _bookingService.AssignUser(bookingServiceId, userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult SetAsVerified(int bookingServiceId)
        {
            try
            {
                _bookingService.SetStatusAsVerified(bookingServiceId);
                return Json(new JsonObjectResponse());
            }
            catch (System.Exception)
            {
                return Json(new JsonObjectResponse("Not saved"));
            }
        }

        [HttpPost]
        [BookingServiceMechanicAssignedFilter]
        [BookingServiceStatusAfterVerifyFilter]
        public JsonResult SetAsAccepted(int bookingServiceId)
        {
            try
            {
                var service = _carMainteanceService.GetBooking(bookingServiceId);
                if (service.Status == Resource.BookingStatusWaitingClient)
                    return Json(new JsonObjectResponse("Oczekiwanie na odpowiedź klienta"));

                _bookingService.SetStatusAsAccepted(bookingServiceId);
                return Json(new JsonObjectResponse());
            }
            catch (System.Exception)
            {
                return Json(new JsonObjectResponse("Not saved"));
            }
        }

        [BookingServiceMechanicAssignedFilter]
        [HttpPost]
        public JsonResult SetAsDecline(int bookingServiceId)
        {
            try
            {
                _bookingService.SetStatusAsDeclined(bookingServiceId);
                return Json(new JsonObjectResponse());
            }
            catch (System.Exception)
            {
                return Json(new JsonObjectResponse("Not saved"));
            }
        }

        [BookingServiceMechanicAssignedFilter]
        [HttpPost]
        public JsonResult SetAsInProgress(int bookingServiceId)
        {
            try
            {
                _bookingService.SetStatusInProgress(bookingServiceId);
                return Json(new JsonObjectResponse());
            }
            catch (System.Exception)
            {
                return Json(new JsonObjectResponse("Not saved"));
            }
        }

        [BookingServiceMechanicAssignedFilter]
        [HttpPost]
        public JsonResult SetAsFinished(int bookingServiceId)
        {
            try
            {
                _bookingService.SetStatusAsFinished(bookingServiceId);
                return Json(new JsonObjectResponse());
            }
            catch (System.Exception)
            {
                return Json(new JsonObjectResponse("Not saved"));
            }
        }
        
        [HttpPost]
        public JsonResult AssignUser(int bookingServiceId, string userId)
        {
            try
            {
                _bookingService.AssignUser(bookingServiceId, userId);
                return Json(new JsonObjectResponse());
            }
            catch (System.Exception)
            {
                return Json(new JsonObjectResponse("Not saved"));
            }
        }
    }
}