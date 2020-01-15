using System.Collections.Generic;

namespace CarService.Repository.Entities
{
    public class CarBrand
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IEnumerable<CarModel> Models{ get; set; }
    }
}