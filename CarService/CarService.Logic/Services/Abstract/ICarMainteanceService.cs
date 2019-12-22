using CarService.Logic.ModelsDTO;
using System.Collections.Generic;

namespace CarService.Logic.Services.Abstract
{
    public interface ICarMainteanceService
    {
        IEnumerable<IdNamePair> GetServices();
        IdNamePair GetService(int id);
        void AddService(string name);
        void UpdateService(int id, string name);
        void AddServiceBooking(BookingServiceDTO bookingService);
        IEnumerable<BookingServiceDTO> GetBookings(string userId);
        BookingServiceDTO GetBooking(int id);
        void UpdateServiceBooking(BookingServiceDTO bookingService);
    }
}