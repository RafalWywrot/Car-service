using AutoMapper;
using CarService.Logic.ModelsDTO;
using CarService.Logic.Services.Abstract;
using CarService.Repository.Entities;
using CarService.Repository.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Logic.Services.Concrete
{
    public class CarMainteanceService : ICarMainteanceService
    {
        private readonly ICarMainteanceRepository _carMainteanceRepository;

        public CarMainteanceService(ICarMainteanceRepository carMainteanceRepository)
        {
            _carMainteanceRepository = carMainteanceRepository;
        }

        public void AddService(string name)
        {
            _carMainteanceRepository.AddService(name);
        }

        public void AddServiceBooking(BookingServiceDTO bookingService)
        {
            var newServiceBooking = new BookingService {
                Car = new Car { Id = bookingService.Car.Id },
                Service = new Service { Id = bookingService.Service.Id },
                DateStarted = DateTime.Now,
                Status = Repository.CustomTypes.ServiceBookingStatus.Created,
                UserComment = bookingService.UserComment
            };
            _carMainteanceRepository.AddServiceBooking(newServiceBooking);
        }

        public IEnumerable<BookingServiceDTO> GetAllBookings()
        {
            return Mapper.Map<IEnumerable<BookingServiceDTO>>(_carMainteanceRepository.GetAllBookings());
        }

        public BookingServiceDTO GetBooking(int id)
        {
            return Mapper.Map<BookingServiceDTO>(_carMainteanceRepository.GetBooking(id));
        }

        public IEnumerable<BookingServiceDTO> GetBookings(string userId)
        {
            return Mapper.Map<IEnumerable<BookingServiceDTO>>(_carMainteanceRepository.GetBookings(userId));
        }

        public IdNamePair GetService(int id)
        {
            var entity = _carMainteanceRepository.GetService(id);
            return new IdNamePair
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public IEnumerable<IdNamePair> GetServices()
        {
            return _carMainteanceRepository.GetServices().Select(x => new IdNamePair
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public void UpdateService(int id, string name)
        {
            _carMainteanceRepository.UpdateServie(id, name);
        }

        public void UpdateServiceBooking(BookingServiceDTO bookingService)
        {
            var currentBooking = _carMainteanceRepository.GetBooking(bookingService.Id);
            if (currentBooking.Car.Id != bookingService.Car.Id)
                currentBooking.Car = new Car { Id = bookingService.Car.Id };

            if (currentBooking.Service.Id != bookingService.Service.Id)
                currentBooking.Service = new Service { Id = bookingService.Service.Id };

            currentBooking.UserComment = bookingService.UserComment;

            _carMainteanceRepository.UpdateServiceBooking(currentBooking);
        }
    }
}