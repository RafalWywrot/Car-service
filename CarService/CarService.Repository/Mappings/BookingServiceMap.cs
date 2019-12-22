using CarService.Repository.CustomTypes;
using CarService.Repository.Entities;
using FluentNHibernate.Mapping;

namespace CarService.Repository.Mappings
{
    public class BookingServiceMap : ClassMap<BookingService>
    {
        public BookingServiceMap()
        {
            Table("SERVICE_BOOKING");

            Id(x => x.Id);

            Map(x => x.Status, "Status").CustomType<ServiceBookingStatus>(); ;
            Map(x => x.DateStarted, "DateStarted");
            Map(x => x.DateEnded, "DateEnded");
            Map(x => x.UserComment, "ClientComment");

            References(x => x.Service, "ServiceId");
            References(x => x.Car, "CarId");
        }
    }
}