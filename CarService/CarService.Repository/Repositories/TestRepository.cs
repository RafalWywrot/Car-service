using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarService.Repository.Abstract;
using CarService.Repository.Entities;

namespace CarService.Repository.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public TestRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<FirstMappedClass> Get()
        {
            return unitOfWork.Session.QueryOver<FirstMappedClass>().List();
        }
    }
}
