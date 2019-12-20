using CarService.Repository.Entities;
using System.Collections.Generic;

namespace CarService.Repository.Repositories.Abstract
{
    public interface ICarRepository
    {
        IEnumerable<CarBrand> GetAll();
        IEnumerable<CarModel> GetAll(int carBrandId);
    }
}