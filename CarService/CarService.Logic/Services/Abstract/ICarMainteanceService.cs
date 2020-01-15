using CarService.Logic.ModelsDTO;
using System;
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
        IEnumerable<CarModelDTO> GetAllCarModels();
        CarBrandDTO GetCarBrand(int id);
        void AddCarBrand(string name);
        void UpdateCarBrand(int id, string name);
        CarModelDTO GetCarModel(int id);
        void AddCarModel(int carBrandId, string name);
        void UpdateCarModel(int carModelId, string name);
        IEnumerable<BookingServiceDTO> GetBookings(string userId);
        IEnumerable<BookingServiceDTO> GetBookingsByCar(int carId);
        IEnumerable<BookingServiceDTO> GetAllBookings();
        IEnumerable<BookingServiceDTO> GetUnfinishedBookings();
        IEnumerable<BookingServiceDTO> GetArchivedBookings();
        BookingServiceDTO GetBooking(int id);
        void UpdateServiceBooking(BookingServiceDTO bookingService);
        void UpdateDateServiceBooking(int id, DateTime date, string reason);
    }
}