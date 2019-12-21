using AutoMapper;
using CarService.Identity;
using CarService.Repository.Entities;
using CarService.WebApplication.Models;
using CarService.WebApplication.Models.Car;
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