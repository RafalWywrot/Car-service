using CarService.Repository.Entities;
using FluentNHibernate.Mapping;

namespace CarService.Repository.Mappings
{
    public class CarMap : ClassMap<Car>
    {
        public CarMap()
        {
            Table("CAR");

            Id(x => x.Id);

            Map(x => x.EngineCapacity, "EngineCapacity");
            Map(x => x.EnginePower, "EnginePower");
            Map(x => x.Odometer, "Odometer");
            Map(x => x.Year, "ProductionYear");
            Map(x => x.Active, "Active");

            References(x => x.Model, "CarModelId").Cascade.None();
            References(x => x.AssignedUser, "ApplicationUserId").Cascade.None();
            References(x => x.Fuel, "FuelTypeId").Cascade.None();
            References(x => x.Transmission, "TransmissionId").Cascade.None();
        }
    }
}