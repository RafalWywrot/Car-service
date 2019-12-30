using CarService.Identity;
using CarService.Logic.Services.Abstract;
using CarService.Repository.CustomTypes;
using CarService.Repository.Entities;
using CarService.Repository.Repositories.Abstract;
using System;

namespace CarService.Logic.Services.Concrete
{
    public class BookingService : IBookingService
    {
        private readonly ICarMainteanceRepository _carMainteanceRepository;

        public BookingService(ICarMainteanceRepository carMainteanceRepository)
        {
            _carMainteanceRepository = carMainteanceRepository;
        }

        public void AssignUser(int serviceBookingId, string user)
        {
            var service = _carMainteanceRepository.GetBooking(serviceBookingId);
            if (service == null)
                throw new NullReferenceException();

            var newUser = new ApplicationUser();
            newUser.SetId(user);
            service.AssignedUser = newUser;
            _carMainteanceRepository.UpdateServiceBooking(service);
        }

        public void SetStatusAsAccepted(int id)
        {
            var booking = _carMainteanceRepository.GetBooking(id);
            if (booking.Status == ServiceBookingStatus.Accepted)
                return;

            booking.Status = ServiceBookingStatus.Accepted;
            _carMainteanceRepository.UpdateServiceBooking(booking);
        }

        public void SetStatusAsDeclined(int id)
        {
            var booking = _carMainteanceRepository.GetBooking(id);
            if (booking.Status == ServiceBookingStatus.Declined)
                return;

            booking.Status = ServiceBookingStatus.Declined;
            _carMainteanceRepository.UpdateServiceBooking(booking);
        }

        public void SetStatusAsFinished(int id)
        {
            var booking = _carMainteanceRepository.GetBooking(id);
            if (booking.Status == ServiceBookingStatus.Finished)
                return;

            booking.Status = ServiceBookingStatus.Finished;
            _carMainteanceRepository.UpdateServiceBooking(booking);
        }

        public void SetStatusAsVerified(int id)
        {
            var booking = _carMainteanceRepository.GetBooking(id);
            if (booking.Status == ServiceBookingStatus.Verify)
                return;

            booking.Status = ServiceBookingStatus.Verify;
            _carMainteanceRepository.UpdateServiceBooking(booking);
        }

        public void SetStatusInProgress(int id)
        {
            var booking = _carMainteanceRepository.GetBooking(id);
            if (booking.Status == ServiceBookingStatus.InProgress)
                return;

            booking.Status = ServiceBookingStatus.InProgress;
            _carMainteanceRepository.UpdateServiceBooking(booking);
        }
    }
}