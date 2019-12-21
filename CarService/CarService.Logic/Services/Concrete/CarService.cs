using AutoMapper;
using CarService.Logic.ModelsDTO;
using CarService.Logic.Services.Abstract;
using CarService.Repository.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Logic.Services.Concrete
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void AddCar(CarDTO car, string userId)
        {
            var newCar = new Repository.Entities.Car
            {
                Active = true,
                EngineCapacity = car.EngineCapacity,
                EnginePower = car.EnginePower,
                Fuel = new Repository.Entities.FuelType { Id = car.FuelTypeId },
                Transmission = new Repository.Entities.Transmission { Id = car.TransmissionId },
                Model = new Repository.Entities.CarModel { Id = car.Model.Id },
                Odometer = car.Odometer,
                Year = car.Year
            };
            _carRepository.AddCar(newCar, userId);
        }

        public IEnumerable<CarBrandDTO> GetAll()
        {
            var carBrands = _carRepository.GetAll();
            return Mapper.Map<IEnumerable<CarBrandDTO>>(carBrands);
        }

        public CarDTO GetCar(int carId)
        {
            return Mapper.Map<CarDTO>(_carRepository.GetCar(carId));
        }

        public IEnumerable<IdNamePair> GetFuelTypes()
        {
            return _carRepository.GetFuelTypes().Select(x => new IdNamePair
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public IEnumerable<CarModelDTO> GetModels(int carBrandId)
        {
            var carModels = _carRepository.GetAll(carBrandId);
            return Mapper.Map<IEnumerable<CarModelDTO>>(carModels);
        }

        public IEnumerable<IdNamePair> GetTransmissionOptions()
        {
            return _carRepository.GetTransmissions().Select(x => new IdNamePair
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public IEnumerable<CarSummaryDTO> GetUserCars(string userId)
        {
            var cars = _carRepository.GetUserCars(userId);
            return Mapper.Map<IEnumerable<CarSummaryDTO>>(cars);
        }

        public void UpdateCar(CarDTO car)
        {
            var currentCar = _carRepository.GetCar(car.Id);
            if (currentCar.Model.Id != car.Model.Id)
                currentCar.Model = new Repository.Entities.CarModel {Id = car.Model.Id };

            currentCar.EngineCapacity = car.EngineCapacity;
            currentCar.EnginePower = car.EnginePower;

            if (currentCar.Fuel.Id != car.FuelTypeId)
                currentCar.Fuel = new Repository.Entities.FuelType { Id = car.FuelTypeId };

            if (currentCar.Transmission.Id != car.TransmissionId)
                currentCar.Transmission = new Repository.Entities.Transmission { Id = car.TransmissionId};

            currentCar.Odometer = car.Odometer;
            currentCar.Year = car.Year;

            _carRepository.UpdateCar(currentCar);
        }
    }
}