using AutoMapper;
using CarService.Logic.ModelsDTO;
using CarService.Logic.Services.Abstract;
using CarService.Repository.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Logic.Services.Concrete
{
    public class CarMainteanceService : ICarMainteanceService
    {
        private readonly ICarMainteanceRepository _carMainteanceRepository;

        public CarMainteanceService(ICarMainteanceRepository carMainteanceRepository)
        {
            _carMainteanceRepository = carMainteanceRepository;
        }

        public void AddService(string name)
        {
            _carMainteanceRepository.AddService(name);
        }

        public IdNamePair GetService(int id)
        {
            var entity = _carMainteanceRepository.GetService(id);
            return new IdNamePair
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public IEnumerable<IdNamePair> GetServices()
        {
            return _carMainteanceRepository.GetServices().Select(x => new IdNamePair
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public void UpdateService(int id, string name)
        {
            _carMainteanceRepository.UpdateServie(id, name);
        }
    }
}