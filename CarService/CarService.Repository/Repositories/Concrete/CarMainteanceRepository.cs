using CarService.Repository.Abstract;
using CarService.Repository.Entities;
using CarService.Repository.Repositories.Abstract;
using System.Collections.Generic;

namespace CarService.Repository.Repositories.Concrete
{
    public class CarMainteanceRepository : ICarMainteanceRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public CarMainteanceRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddService(string name)
        {
            var entity = new Service
            {
                Name = name
            };
            using (var transaction = unitOfWork.Session.BeginTransaction())
            {
                unitOfWork.Session.Save(entity);
                transaction.Commit();
            }
        }

        public Service GetService(int id)
        {
            return unitOfWork.Session.Get<Service>(id);
        }

        public IEnumerable<Service> GetServices()
        {
            return unitOfWork.Session.QueryOver<Service>().List();
        }

        public void UpdateServie(int id, string name)
        {
            var entity = GetService(id);
            entity.Name = name;
            using (var transaction = unitOfWork.Session.BeginTransaction())
            {
                unitOfWork.Session.Update(entity);
                transaction.Commit();
            }
        }
    }
}
