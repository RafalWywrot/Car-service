using AutoMapper;
using CarService.Logic.ModelsDTO;
using CarService.Logic.Services.Abstract;
using CarService.WebApplication.Areas.Admin.Models;
using CarService.WebApplication.Controllers;
using CarService.WebApplication.Helpers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CarService.WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = SystemRoles.Admin)]
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
            return View(new BookAdminViewModel());
        }

        [HttpPost]
        public ActionResult Add(BookAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!CheckServiceRequiredComment(model))
                return View(model);
            
            _carMainteanceService.AddService(Mapper.Map<ServiceDTO>(model));
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = _carMainteanceService.GetService(id);
            var model = Mapper.Map<BookAdminViewModel>(service);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(BookAdminViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!CheckServiceRequiredComment(model))
                return View(model);

            _carMainteanceService.UpdateService(Mapper.Map<ServiceDTO>(model));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int serviceId)
        {
            _carMainteanceService.SetActiveStatusOfService(serviceId, false);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Activate(int serviceId)
        {
            _carMainteanceService.SetActiveStatusOfService(serviceId, true);
            return RedirectToAction("Index");
        }

        private bool CheckServiceRequiredComment(BookAdminViewModel model)
        {
            if (model.RequiredComment == false)
                return true;

            if (!string.IsNullOrEmpty(model.MessageUser))
                return true;

            ModelState.AddModelError("MessageUser", "Pole wymagane w przypadku zaznaczenia wymagany komentarz");
            return false;
        }
    }
}