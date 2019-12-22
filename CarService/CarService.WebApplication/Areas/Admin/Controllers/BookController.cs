using AutoMapper;
using CarService.Logic.ModelsDTO;
using CarService.Logic.Services.Abstract;
using CarService.WebApplication.Areas.Admin.Models;
using CarService.WebApplication.Helpers;
using CarService.WebApplication.Helpers.Extensions;
using CarService.WebApplication.Models.Car;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace CarService.WebApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = SystemRoles.Admin)]
    public class BookController : Controller
    {
        private readonly ICarMainteanceService _carMainteanceService;

        public BookController(ICarMainteanceService carMainteanceService)
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