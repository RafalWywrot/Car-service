using CarService.Repository.Entities;
using System.Collections.Generic;

namespace CarService.Repository.Repositories.Abstract
{
    public interface ICarMainteanceRepository
    {
        IEnumerable<Service> GetServices();
        Service GetService(int id);
        void AddService(string name);
        void UpdateServie(int id, string name);
        void AddServiceBooking(BookingServiceEntity bookingService);
        IEnumerable<BookingServiceEntity> GetBookings(string userId);
        IEnumerable<BookingServiceEntity> GetAllBookings();
        BookingServiceEntity GetBooking(int id);
        void UpdateServiceBooking(BookingServiceEntity bookingService);
    }
}