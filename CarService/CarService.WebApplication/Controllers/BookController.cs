﻿using AutoMapper;
using CarService.Logic.ModelsDTO;
using CarService.Logic.Services.Abstract;
using CarService.WebApplication.Helpers;
using CarService.WebApplication.Helpers.ActionFilters;
using CarService.WebApplication.Helpers.Extensions;
using CarService.WebApplication.Models.Car;
using CarService.WebApplication.Models.ServiceBooking;
using CarService.WebApplication.Models.User;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CarService.WebApplication.Controllers
{
    [Authorize(Roles = SystemRoles.User)]
    public class BookController : Controller
    {
        private readonly ICarMainteanceService _carMainteanceService;
        private readonly ICarService _carService;
        private readonly ApplicationUserManager _userManager;

        public BookController(
            ICarMainteanceService carMainteanceService,
            ICarService carService,
            ApplicationUserManager userManager)
        {
            _carMainteanceService = carMainteanceService;
            _carService = carService;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var bookingsOfAllCars = _carMainteanceService.GetBookings(userId);
            var model = Mapper.Map<IEnumerable<ServiceBookingSummaryViewModel>>(bookingsOfAllCars);
            return View(model);
        }

        public ViewResult Show(int bookingServiceId)
        {
            var bookingService = _carMainteanceService.GetBooking(bookingServiceId);
            var car = _carService.GetCarDetails(bookingService.Car.Id);
            var mechanic = _userManager.FindById(bookingService.MechanicId);
            var model = new ServiceBookingDetailViewModel
            {
                ServiceDetails = Mapper.Map<ServiceBookingSummaryViewModel>(bookingService),
                CarDetails = car,
                MechanicPhoneNumber = mechanic?.PhoneNumber ?? string.Empty
            };
            return View(model);
        }

        public ViewResult AddServiceBooking()
        {
            var model = new ServiceBookingFormViewModel
            {
                AsSoonAsPossible = true
            };
            InitializeDropdown(model);
            return View(model);
        }
        
        [ServiceBookingDateTimeFilter]
        [HttpPost]
        public ActionResult AddServiceBooking(ServiceBookingFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InitializeDropdown(model);
                return View(model);
            }

            _carMainteanceService.AddServiceBooking(Mapper.Map<BookingServiceDTO>(model));
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int bookingServiceId)
        {
            var bookingService = _carMainteanceService.GetBooking(bookingServiceId);
            var model = Mapper.Map<ServiceBookingFormViewModel>(bookingService);
            InitializeDropdown(model);
            return View(model);
        }

        [ServiceBookingDateTimeFilter]
        [HttpPost]
        public ActionResult Edit(ServiceBookingFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InitializeDropdown(model);
                return View(model);
            }

            _carMainteanceService.UpdateServiceBooking(Mapper.Map<BookingServiceDTO>(model));
            return RedirectToAction("Index");
        }

        private void InitializeDropdown(ServiceBookingFormViewModel model)
        {
            var userId = User.Identity.GetUserId();
            model.Cars = _carService.GetUserCars(userId).Where(x => x.Active).ToSelectListItems(x => x.Id, x => x.Model);
            model.Services = _carMainteanceService.GetServices().ToSelectListItems(x => x.Id, x => x.Name);
        }
    }
}