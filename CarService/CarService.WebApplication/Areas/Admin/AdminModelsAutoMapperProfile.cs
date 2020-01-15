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
               ).ForMember(
                    dest => dest.Mechanic,
                    opt => opt.MapFrom(src => src.MechanicFullName)
               );

            CreateMap<DTO.BookingServiceDTO, ServiceBookingDateAdminViewModel>()
                .ForMember(
                    dest => dest.DateCreated,
                    opt => opt.MapFrom(src => src.DateStarted)
               );

            CreateMap<DTO.CarModelDTO, CarManagementSummaryViewModel>()
                .ForMember(
                    dest => dest.CarBrandId,
                    opt => opt.MapFrom(src => src.Brand.Id)
                ).ForMember(
                    dest => dest.CarBrandName,
                    opt => opt.MapFrom(src => src.Brand.Name)
                ).ForMember(
                    dest => dest.CarModelId,
                    opt => opt.MapFrom(src => src.Id)
                ).ForMember(
                    dest => dest.CarModelName,
                    opt => opt.MapFrom(src => src.Name)
                ).ForMember(
                    dest => dest.Active,
                    opt => opt.MapFrom(src => src.Active ? 1 : 0)
                );
        }
    }
}