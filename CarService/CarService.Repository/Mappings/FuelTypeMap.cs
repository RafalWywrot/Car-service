using CarService.Repository.Entities;
using FluentNHibernate.Mapping;

namespace CarService.Repository.Mappings
{
    public class FuelTypeMap : ClassMap<FuelType>
    {
        public FuelTypeMap()
        {
            Table("FUEL_TYPE");

            Id(x => x.Id);
            Map(x => x.Name, "Name");
        }
    }
}