using CarService.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Repository.Repositories
{
    public interface ITestRepository
    {
        FirstMappedClass Get();
    }
}
