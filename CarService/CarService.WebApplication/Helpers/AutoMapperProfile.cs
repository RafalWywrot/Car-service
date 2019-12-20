using AutoMapper;
using CarService.Identity;
using CarService.Logic.ModelsDTO;
using CarService.Repository.Entities;
using CarService.WebApplication.Models;
using CarService.WebApplication.Models.User;
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
            CreateMap<CarBrand, CarBrandDTO>();
            CreateMap<CarModel, CarModelDTO>();
            CreateMap<FirstMappedClass, TestAutoMapperViewModel>();

            #region Users userManager
            CreateMap<ApplicationUser, UserBasicViewModel>()
                .ForMember
                (
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                ).ForMember
                (
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                ).ForMember
                (
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => src.Surname)
                ).ForMember
                (
                    dest => dest.Email,
                    opt => opt.MapFrom(src => src.Email)
                ).ForMember
                (
                    dest => dest.Roles,
                    opt => opt.MapFrom(src => string.Join(", ", src.Roles.Select(x => x.Name)))
                );
            #endregion
        }
    }
}