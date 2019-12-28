using CarService.Logic.Services.Abstract;
using CarService.Repository.CustomTypes;
using CarService.Repository.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Logic.Services.Concrete
{
    public class BookingService : IBookingService
    {
        private readonly ICarMainteanceRepository _carMainteanceRepository;

        public BookingService(ICarMainteanceRepository carMainteanceRepository)
        {
            _carMainteanceRepository = carMainteanceRepository;
        }

        public void SetStatusAsVerified(int id)
        {
            var booking = _carMainteanceRepository.GetBooking(id);
            if (booking.Status == ServiceBookingStatus.Verify)
                return;

            booking.Status = ServiceBookingStatus.Verify;
            _carMainteanceRepository.UpdateServiceBooking(booking);
        }
    }
}