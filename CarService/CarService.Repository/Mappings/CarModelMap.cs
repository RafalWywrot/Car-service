using CarService.Repository.Entities;
using FluentNHibernate.Mapping;

namespace CarService.Repository.Mappings
{
    public class CarModelMap : ClassMap<CarModel>
    {
        public CarModelMap()
        {
            Table("CAR_MODEL");

            Id(x => x.Id);
            Map(x => x.Name, "Name").Not.Nullable();
            Map(x => x.Active, "Active").Not.Nullable();

            References(x => x.Brand, "CarBrandId").Cascade.None();
        }
    }
}