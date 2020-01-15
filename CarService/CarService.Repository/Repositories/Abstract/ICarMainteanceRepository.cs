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
        CarBrand GetCarBrand(int id);
        IEnumerable<CarBrand> GetCarBrands();
        void AddCarBrand(CarBrand brand);
        void UpdateCarBrand(CarBrand brand);
        CarModel GetCarModel(int id);
        void AddCarModel(CarModel model);
        void UpdateCarModel(CarModel model);
        void AddServiceBooking(BookingServiceEntity bookingService);
        IEnumerable<BookingServiceEntity> GetBookings(string userId);
        IEnumerable<BookingServiceEntity> GetBookingsByCar(int carId);
        IEnumerable<BookingServiceEntity> GetAllBookings();
        BookingServiceEntity GetBooking(int id);
        void UpdateServiceBooking(BookingServiceEntity bookingService);
    }
}