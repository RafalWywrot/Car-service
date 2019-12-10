using CarService.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarService.WebApplication.Controllers
{
    public class TestController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            bool isInjected = unitOfWork != null;
            return View();
        }
    }
}