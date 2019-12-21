﻿using AutoMapper;
using CarService.Logic.ModelsDTO;
using CarService.Logic.Services.Abstract;
using CarService.Repository.Repositories.Abstract;
using System.Collections.Generic;

namespace CarService.Logic.Services.Concrete
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IEnumerable<CarBrandDTO> GetAll()
        {
            var carBrands = _carRepository.GetAll();
            return Mapper.Map<IEnumerable<CarBrandDTO>>(carBrands);
        }

        public IEnumerable<CarModelDTO> GetModels(int carBrandId)
        {
            var carModels = _carRepository.GetAll(carBrandId);
            return Mapper.Map<IEnumerable<CarModelDTO>>(carModels);
        }

        public IEnumerable<CarSummaryDTO> GetUserCars(string userId)
        {
            var cars = _carRepository.GetUserCars(userId);
            return Mapper.Map<IEnumerable<CarSummaryDTO>>(cars);
        }
    }
}