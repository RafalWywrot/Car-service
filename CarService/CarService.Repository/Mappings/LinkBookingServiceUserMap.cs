using CarService.Repository.Entities;
using FluentNHibernate.Mapping;

namespace CarService.Repository.Mappings
{
    public class LinkBookingServiceUserMap : ClassMap<LinkBookingServiceUser>
    {
        public LinkBookingServiceUserMap()
        {
            Table("LINK_SERVICE_BOOKING_USER");
            CompositeId()
                .KeyProperty(x => x.BookingServiceId, "ServiceBookingId")
                .KeyProperty(x => x.UserId, "ApplicationUserId");

            References(x => x.BookingService, "ServiceBookingId").ReadOnly().Cascade.None();
            References(x => x.AssignedUser, "ApplicationUserId").ReadOnly().Cascade.None();
        }
    }
}