using CarService.Repository.Entities;
using System.Collections.Generic;

namespace CarService.Repository.Repositories
{
    public interface ITestRepository
    {
        IEnumerable<FirstMappedClass> Get();
    }
}