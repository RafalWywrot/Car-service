using AutoMapper;
using CarService.Logic.ModelsDTO;
using CarService.Logic.Services.Abstract;
using CarService.WebApplication.Helpers.Extensions;
using CarService.WebApplication.Models.Car;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace CarService.WebApplication.Controllers
{
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
    }
}