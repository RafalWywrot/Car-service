using CarService.Repository.Repositories;
using CarService.WebApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarService.WebApplication.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        private ApplicationUserManager _userManager;
        private readonly ITestRepository testRepository;

        public UsersController(ApplicationUserManager userManager, ITestRepository testRepository)
        {
            _userManager = userManager;
            this.testRepository = testRepository;
        }
        // GET: Admin/Users
        public ActionResult Index()
        {
            var model = testRepository.Get();
            return View(model);
        }
    }
}