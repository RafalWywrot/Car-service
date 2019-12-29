using CarService.Repository.CustomTypes;
using CarService.Repository.Entities;
using FluentNHibernate.Mapping;

namespace CarService.Repository.Mappings
{
    public class BookingServiceMap : ClassMap<BookingServiceEntity>
    {
        public BookingServiceMap()
        {
            Table("SERVICE_BOOKING");

            Id(x => x.Id);

            Map(x => x.Status, "Status").CustomType<ServiceBookingStatus>(); ;
            Map(x => x.DateStarted, "DateStarted").Nullable();
            Map(x => x.DateEnded, "DateEnded");
            Map(x => x.UserComment, "ClientComment");
            Map(x => x.AsSoonAsPossible, "AsSoonAsPossible");

            References(x => x.Service, "ServiceId");
            References(x => x.Car, "CarId");
        }
    }
}