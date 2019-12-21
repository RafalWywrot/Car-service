using CarService.Repository.Entities;
using FluentNHibernate.Mapping;

namespace CarService.Repository.Mappings
{
    public class TransmissionMap : ClassMap<Transmission>
    {
        public TransmissionMap()
        {
            Table("TRANSMISSION");

            Id(x => x.Id);
            Map(x => x.Name, "Name");
        }
    }
}