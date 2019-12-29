﻿using AutoMapper;
using CarService.Logic.Services.Abstract;
using CarService.WebApplication.Areas.Admin.Models;
using CarService.WebApplication.Helpers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarService.WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = SystemRoles.Admin)]
    public class BookController : Controller
    {
        private readonly ICarMainteanceService _carMainteanceService;
        private readonly IBookingService _bookingService;

        public BookController(ICarMainteanceService carMainteanceService, IBookingService bookingService)
        {
            _carMainteanceService = carMainteanceService;
            _bookingService = bookingService;
        }

        public ActionResult Index()
        {
            var allBookings = _carMainteanceService.GetAllBookings();
            var model = Mapper.Map<IEnumerable<ServiceBookingSummaryAdminViewModel>>(allBookings);
            return View(model);
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