using AutoMapper;
using CarService.Identity;
using CarService.WebApplication.Areas.Admin.Models;
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
                    opt => opt.MapFrom(src => $"{src.Car.Model.Brand.Name} / {src.Car.Model.Name} / {src.Car.Year}r.")
               ).ForMember(
                    dest => dest.Comment,
                    opt => opt.MapFrom(src => src.UserComment)
               ).ForMember(
                    dest => dest.ServiceName,
                    opt => opt.MapFrom(src => src.Service.Name)
               ).ForMember(
                    dest => dest.DateCreated,
                    opt => opt.MapFrom(src => src.DateStarted)
               ).ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status)
               ).ForMember(
                    dest => dest.DateThatClientSelect,
                    opt => opt.MapFrom(src => src.AsSoonAsPossible ? "Jak najszybciej" : src.DateStarted.Value.ToShortDateString())
               );

            CreateMap<DTO.BookingServiceDTO, ServiceBookingDateAdminViewModel>()
                .ForMember(
                    dest => dest.DateCreated,
                    opt => opt.MapFrom(src => src.DateStarted)
               );
        }
    }
}