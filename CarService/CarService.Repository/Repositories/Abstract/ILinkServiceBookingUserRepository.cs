using CarService.Repository.Entities;
using System.Collections.Generic;

namespace CarService.Repository.Repositories.Abstract
{
    public interface ILinkServiceBookingUserRepository
    {
        LinkBookingServiceUser Get(int bookingServiceId);
        IEnumerable<BookingServiceEntity> Get(string userId);
        void Add(LinkBookingServiceUser entity);
        void Update(LinkBookingServiceUser entity);
        void Delete(LinkBookingServiceUser entity);
    }
}