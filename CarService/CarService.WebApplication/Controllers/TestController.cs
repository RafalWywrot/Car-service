using AutoMapper;
using CarService.Repository.Repositories;
using CarService.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarService.WebApplication.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestRepository testRepository;

        public TestController(ITestRepository testRepository)
        {
            this.testRepository = testRepository;
        }

        // GET: Test
        public ActionResult Index()
        {
            var testData = testRepository.Get();
            var testAutoMapper = AutoMapper.Mapper.Map<TestAutoMapperViewModel>(testData);
            return View();
        }
    }
}