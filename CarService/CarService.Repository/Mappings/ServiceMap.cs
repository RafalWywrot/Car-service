using CarService.Repository.Entities;
using FluentNHibernate.Mapping;

namespace CarService.Repository.Mappings
{
    public class ServiceMap : ClassMap<Service>
    {
        public ServiceMap()
        {
            Table("SERVICE");

            Id(x => x.Id);
            Map(x => x.Name, "Name");
        }
    }
}