using AutoMapper;
using CarService.Identity;
using CarService.Repository.Entities;
using CarService.WebApplication.Models;
using CarService.WebApplication.Models.Car;
using CarService.WebApplication.Models.ServiceBooking;
using CarService.WebApplication.Models.User;
using System.Linq;
using DTO = CarService.Logic.ModelsDTO;
using Entity = CarService.Repository.Entities;
namespace CarService.WebApplication.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entity.CarBrand, DTO.CarBrandDTO>();
            CreateMap<Entity.CarModel, DTO.CarModelDTO>();
            CreateMap<Entity.Service, DTO.IdNamePair>()
                 .ForMember
                (
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                );
            CreateMap<Entity.Car, DTO.CarSummaryDTO>()
                .ForMember
                (
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                ).ForMember
                (
                    dest => dest.Model,
                    opt => opt.MapFrom(src => $"{src.Model.Brand.Name} / {src.Model.Name}")
                ).ForMember
                (
                    dest => dest.Fuel,
                    opt => opt.MapFrom(src => src.Fuel.Name)
                ).ForMember
                (
                    dest => dest.Transmission,
                    opt => opt.MapFrom(src => src.Transmission.Name)
                );

            CreateMap<Entity.Car, DTO.CarDTO>()
                .ForMember(
                    dest => dest.TransmissionId,
                    opt => opt.MapFrom(src => src.Transmission.Id)
                ).ForMember(
                    dest => dest.FuelTypeId,
                    opt => opt.MapFrom(src => src.Fuel.Id)
                );

            CreateMap<CarFormViewModel, DTO.CarDTO>()
               .ForMember
               (
                   dest => dest.Id,
                   opt => opt.MapFrom(src => src.Id)
               ).ForMember
               (
                   dest => dest.Model,
                   opt => opt.MapFrom(src => new DTO.CarModelDTO
                   {
                       Id = src.CarModelId,
                       Brand = new DTO.CarBrandDTO
                       {
                           Id = src.CarBrandId
                       }
                   })
               ).ForMember
               (
                   dest => dest.TransmissionId,
                   opt => opt.MapFrom(src => src.TransmissionId)
               ).ForMember
               (
                   dest => dest.FuelTypeId,
                   opt => opt.MapFrom(src => src.FuelTypeId)
               )
               .ReverseMap()
                .ForMember(
                    dest => dest.CarBrandId,
                    opt => opt.MapFrom(src => src.Model.Brand.Id)
               ).ForMember(
                    dest => dest.CarModelId,
                    opt => opt.MapFrom(src => src.Model.Id)
               ).ForMember(
                    dest => dest.FuelTypeId,
                    opt => opt.MapFrom(src => src.FuelTypeId)
               ).ForMember(
                    dest => dest.TransmissionId,
                    opt => opt.MapFrom(src => src.TransmissionId)
               );

            CreateMap<Entity.BookingServiceEntity, DTO.BookingServiceDTO>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.ResolveUsing(src => Mapper.Map<string>(src.Status))
                )
                .ReverseMap();

            CreateMap<Repository.CustomTypes.ServiceBookingStatus, string>().ConvertUsing(value =>
            {
                switch (value)
                {
                    case Repository.CustomTypes.ServiceBookingStatus.Created:
                        return Resource.BookingStatusCreated;
                    case Repository.CustomTypes.ServiceBookingStatus.Accepted:
                        return Resource.BookingStatusAccepted;
                    case Repository.CustomTypes.ServiceBookingStatus.Declined:
                        return Resource.BookingStatusDeclined;
                    case Repository.CustomTypes.ServiceBookingStatus.Finished:
                        return Resource.BookingStatusFinished;
                    case Repository.CustomTypes.ServiceBookingStatus.InProgress:
                        return Resource.BookingStatusInProgress;
                    case Repository.CustomTypes.ServiceBookingStatus.Verify:
                        return Resource.BookingStatusVerify;
                    default:
                        return string.Empty;
                }
            });


            CreateMap<DTO.BookingServiceDTO, ServiceBookingSummaryViewModel>()
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
               );
               

            CreateMap<DTO.BookingServiceDTO, ServiceBookingFormViewModel>()
                .ForMember(
                    dest => dest.CarId,
                    opt => opt.MapFrom(src => src.Car.Id )
               ).ForMember(
                    dest => dest.ServiceId,
                    opt => opt.MapFrom(src => src.Service.Id)
               ).ForMember(
                    dest => dest.Comment,
                    opt => opt.MapFrom(src => src.UserComment)
               ).ForMember(
                    dest => dest.DateCreated,
                    opt => opt.MapFrom(src => src.DateStarted)
               )
               .ReverseMap()
               .ForMember(
                    dest => dest.Car,
                    opt => opt.MapFrom(src => new DTO.CarDTO { Id = src.CarId })
               ).ForMember(
                    dest => dest.UserComment,
                    opt => opt.MapFrom(src => src.Comment)
               ).ForMember(
                    dest => dest.Service,
                    opt => opt.MapFrom(src => new DTO.IdNamePair { Id = src.ServiceId })
               )
               .ForMember(
                    dest => dest.DateStarted,
                    opt => opt.MapFrom(src => src.DateCreated)
               );

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