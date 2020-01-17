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
            Map(x => x.RequiredComment, "RequiredComment");
            Map(x => x.MessageUser, "MessageUser").Nullable();
            Map(x => x.Active, "Active");

            HasMany(x => x.BookingServices)
                  .KeyColumn("ServiceId")
                  .Inverse()
                  .Cascade.AllDeleteOrphan();
        }
    }
}