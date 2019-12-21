using CarService.Repository.Entities;
using FluentNHibernate.Mapping;
namespace CarService.Repository.Mappings
{
    public class CarBrandMap : ClassMap<CarBrand>
    {
        public CarBrandMap()
        {
            Table("CAR_BRAND");

            Id(x => x.Id);
            Map(x => x.Name, "Name").Not.Nullable();
        }
    }
}