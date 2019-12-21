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

        public void AddCar(Car car, string userId)
        {
            var user = new Identity.ApplicationUser();
            user.SetId(userId);
            car.AssignedUser = user;
            using (var transaction = unitOfWork.Session.BeginTransaction())
            {
                unitOfWork.Session.Save(car);
                transaction.Commit();
            }
        }

        public IEnumerable<CarBrand> GetAll()
        {
            return unitOfWork.Session.QueryOver<CarBrand>().List();
        }

        public IEnumerable<CarModel> GetAll(int carBrandId)
        {
            return unitOfWork.Session.QueryOver<CarModel>().Where(x => x.Brand.Id == carBrandId).List();
        }

        public Car GetCar(int carId)
        {
            return unitOfWork.Session.Get<Car>(carId);
        }

        public IEnumerable<FuelType> GetFuelTypes()
        {
            return unitOfWork.Session.QueryOver<FuelType>().List();
        }

        public IEnumerable<Transmission> GetTransmissions()
        {
            return unitOfWork.Session.QueryOver<Transmission>().List();
        }

        public IEnumerable<Car> GetUserCars(string userId)
        {
            return unitOfWork.Session.QueryOver<Car>().Where(x => x.AssignedUser.Id == userId).List();
        }

        public void UpdateCar(Car car)
        {
            using (var transaction = unitOfWork.Session.BeginTransaction())
            {
                unitOfWork.Session.Update(car);
                transaction.Commit();
            };
        }
    }
}