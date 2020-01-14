using CarService.Logic.ModelsDTO;
using System.Collections.Generic;

namespace CarService.Logic.Services.Abstract
{
    public interface ICarService
    {
        IEnumerable<CarBrandDTO> GetAll();
        IEnumerable<CarModelDTO> GetModels(int carBrandId);
        IEnumerable<CarSummaryDTO> GetUserCars(string userId);
        CarSummaryDTO GetCarDetails(int carId);
        CarDTO GetCar(int carId);
        void UpdateCar(CarDTO car);
        IEnumerable<IdNamePair> GetTransmissionOptions();
        IEnumerable<IdNamePair> GetFuelTypes();
        void AddCar(CarDTO car, string userId);
        void DeleteCar(int carId);
    }
}