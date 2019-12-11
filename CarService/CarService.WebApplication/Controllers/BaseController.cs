using CarService.Repository.Abstract;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarService.WebApplication.Controllers
{
    public class BaseController : Controller
    {
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }
        
    }
}