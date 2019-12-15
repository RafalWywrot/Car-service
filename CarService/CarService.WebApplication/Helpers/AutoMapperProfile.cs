using AutoMapper;
using CarService.Repository.Entities;
using CarService.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarService.WebApplication.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FirstMappedClass, TestAutoMapperViewModel>();
        }
    }
}