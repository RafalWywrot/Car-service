using AutoMapper;
using CarService.Identity;
using CarService.Repository.Entities;
using CarService.WebApplication.Areas.Admin.Models;
using CarService.WebApplication.Models;
using CarService.WebApplication.Models.Car;
using CarService.WebApplication.Models.ServiceBooking;
using CarService.WebApplication.Models.User;
using System.Linq;
using DTO = CarService.Logic.ModelsDTO;
using Entity = CarService.Repository.Entities;

namespace CarService.WebApplication.Areas.Admin
{
    public class AdminModelsAutoMapperProfile : Profile
    {
        public AdminModelsAutoMapperProfile()
        {
            CreateMap<DTO.BookingServiceDTO, ServiceBookingSummaryAdminViewModel>()
                .ForMember(
                    dest => dest.CarName,
                    opt => opt.MapFrom(src => $"{src.Car.Model.Brand.Name} / {src.Car.Model.Name}")
               ).ForMember(
                    dest => dest.Comment,
                    opt => opt.MapFrom(src => src.UserComment)
               ).ForMember(
                    dest => dest.ServiceName,
                    opt => opt.MapFrom(src => src.Service.Name)
               ).ForMember(
                    dest => dest.DateCreated,
                    opt => opt.Ignore()
               ).ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status)
               );
        }
    }
}