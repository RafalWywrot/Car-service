using CarService.Logic.ModelsDTO;
using System.Collections.Generic;

namespace CarService.Logic.Services.Abstract
{
    public interface ICarService
    {
        IEnumerable<CarBrandDTO> GetAll();
        IEnumerable<CarModelDTO> GetModels(int carBrandId);
    }
}
