using CarService.Repository.Entities;
using System.Collections.Generic;

namespace CarService.Repository.Repositories.Abstract
{
    public interface ICarRepository
    {
        IEnumerable<CarBrand> GetAll();
        IEnumerable<CarModel> GetAllModels();
        IEnumerable<CarModel> GetAll(int carBrandId);
        IEnumerable<Car> GetUserCars(string userId);
        Car GetCar(int carId);
        void UpdateCar(Car car);
        IEnumerable<Transmission> GetTransmissions();
        IEnumerable<FuelType> GetFuelTypes();
        void AddCar(Car car, string userId);
    }
}