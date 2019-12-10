using CarService.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarService.WebApplication.Controllers
{
    public class TestNinjectController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public TestNinjectController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: TestNinject
        [AllowAnonymous]
        public ActionResult Index()
        {
            bool aaadsfa = unitOfWork != null;
            return View();
        }
    }
}