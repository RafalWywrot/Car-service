using AutoMapper;
using CarService.Logic.Services.Abstract;
using CarService.WebApplication.Areas.Admin.Models;
using CarService.WebApplication.Controllers;
using CarService.WebApplication.Helpers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarService.WebApplication.Areas.Admin.Controllers
{
    public class ServiceController : BaseController
    {
        private readonly ICarMainteanceService _carMainteanceService;

        public ServiceController(ICarMainteanceService carMainteanceService)
        {
            _carMainteanceService = carMainteanceService;
        }

        public ActionResult Index()
        {
            var model = _carMainteanceService.GetServices();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BookAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _carMainteanceService.AddService(model.Name);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = _carMainteanceService.GetService(id);
            var model = new BookAdminViewModel
            {
                Id = service.Id,
                Name = service.Name
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _carMainteanceService.UpdateService(model.Id, model.Name);
            return RedirectToAction("Index");
        }
    }
}