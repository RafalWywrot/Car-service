using CarService.Repository.Abstract;
using CarService.Repository.Entities;
using CarService.Repository.Repositories.Abstract;
using System.Collections.Generic;

namespace CarService.Repository.Repositories.Concrete
{
    public class CarRepository : ICarRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public CarRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<CarBrand> GetAll()
        {
            return unitOfWork.Session.QueryOver<CarBrand>().List();
        }

        public IEnumerable<CarModel> GetAll(int carBrandId)
        {
            return unitOfWork.Session.QueryOver<CarModel>().Where(x => x.Brand.Id == carBrandId).List();
        }
    }
}