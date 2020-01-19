using AutoMapper;
using CarService.Logic.Exceptions;
using CarService.Logic.Services.Abstract;
using CarService.WebApplication.Areas.Admin.Models;
using CarService.WebApplication.Controllers;
using CarService.WebApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
namespace CarService.WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = SystemRoles.Admin)]
    public class CarController : BaseController
    {
        private readonly ICarMainteanceService _carMainteanceService;

        public CarController(ICarMainteanceService carMainteanceService)
        {
            _carMainteanceService = carMainteanceService;
        }

        public ViewResult Index()
        {
            var carModels = _carMainteanceService.GetAllCarModels();
            var model = Mapper.Map<IEnumerable<CarManagementSummaryViewModel>>(carModels);
            return View(model);
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CarBrandAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _carMainteanceService.AddCarBrand(model.Name);
                return RedirectToAction("Index");
            }
            catch (CarException)
            {
                ModelState.AddModelError("Name", "Nazwa już istnieje");
                return View(model);
            }
        }


        public ActionResult Update(int carBrandId)
        {
            var car = _carMainteanceService.GetCarBrand(carBrandId);
            if (car == null)
                return RedirectToAction("Index");
                
            return View(new CarBrandAdminViewModel
            {
                Id = car.Id,
                Name = car.Name
            });
        }

        [HttpPost]
        public ActionResult Update(CarBrandAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _carMainteanceService.UpdateCarBrand(model.Id, model.Name);
                return RedirectToAction("Index");
            }
            catch (CarException)
            {
                ModelState.AddModelError("Name", "Nazwa już istnieje");
                return View(model);
            }
        }


        public ActionResult AddNewModel(int carBrandId)
        {
            var car = _carMainteanceService.GetCarBrand(carBrandId);
            if (car == null)
                return RedirectToAction("Index");

            var model = new CarModelAdminViewModel
            {
                CarBrandId = car.Id,
                CarBrand = car.Name
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddNewModel(CarModelAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _carMainteanceService.AddCarModel(model.CarBrandId, model.Name);
                return RedirectToAction("Index");
            }
            catch (CarException)
            {
                ModelState.AddModelError("Name", "Nazwa już istnieje");
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Wystąpił bład");
                return View(model);
            }
        }
        
        public ActionResult UpdateModel(int carModelId)
        {
            var car = _carMainteanceService.GetCarModel(carModelId);
            if (car == null)
                return RedirectToAction("Index");

            var model = new CarModelAdminViewModel
            {
                Id = car.Id,
                Name = car.Name,
                CarBrandId = car.Brand.Id,
                CarBrand = car.Brand.Name
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateModel(CarModelAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _carMainteanceService.UpdateCarModel(model.Id, model.Name);
                return RedirectToAction("Index");
            }
            catch (CarException)
            {
                ModelState.AddModelError("Name", "Nazwa już istnieje");
                return View(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Wystąpił bład");
                return View(model);
            }
        }

        public ActionResult DeleteModel(int carModelId)
        {
            _carMainteanceService.DisActiveCarModel(carModelId);
            return RedirectToAction("Index");
        }

        public ActionResult ReactivateModel(int carModelId)
        {
            _carMainteanceService.ActivateCarModel(carModelId);
            return RedirectToAction("Index");
        }

        public ViewResult History(int carId)
        {
            var allBookings = _carMainteanceService.GetBookingsByCar(carId);
            var model = Mapper.Map<IEnumerable<ServiceBookingSummaryAdminViewModel>>(allBookings);
            return View(model);
        }
    }
}