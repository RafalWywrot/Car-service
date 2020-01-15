using AutoMapper;
using CarService.Logic.Exceptions;
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
        private readonly ICarRepository _carRepository;

        public CarMainteanceService(
            ICarMainteanceRepository carMainteanceRepository,
            ICarRepository carRepository)
        {
            _carMainteanceRepository = carMainteanceRepository;
            _carRepository = carRepository;
        }

        public void AddService(string name)
        {
            _carMainteanceRepository.AddService(name);
        }

        public void AddServiceBooking(BookingServiceDTO bookingService)
        {
            var newServiceBooking = new Repository.Entities.BookingServiceEntity {
                Car = new Car { Id = bookingService.Car.Id },
                Service = new Service { Id = bookingService.Service.Id },
                DateStarted = bookingService.AsSoonAsPossible ? (DateTime?)null : bookingService.DateStarted,
                Status = Repository.CustomTypes.ServiceBookingStatus.Created,
                UserComment = bookingService.UserComment,
                AsSoonAsPossible = bookingService.AsSoonAsPossible
            };
            _carMainteanceRepository.AddServiceBooking(newServiceBooking);
        }

        public IEnumerable<CarModelDTO> GetAllCarModels()
        {
            return Mapper.Map<IEnumerable<CarModelDTO>>(_carRepository.GetAllModels());
        }

        public CarBrandDTO GetCarBrand(int id)
        {
            return Mapper.Map<CarBrandDTO>(_carMainteanceRepository.GetCarBrand(id));
        }

        public void AddCarBrand(string name)
        {
            var carBrands = _carMainteanceRepository.GetCarBrands();
            if (carBrands.Any(x => x.Name.ToUpper() == name.ToUpper()))
                throw new CarException();

            _carMainteanceRepository.AddCarBrand(new CarBrand { Name = name });
        }

        public void UpdateCarBrand(int id, string name)
        {
            var carBrands = _carMainteanceRepository.GetCarBrands();
            if (carBrands.Any(x => x.Name.ToUpper() == name.ToUpper()))
                throw new CarException();

            var car = carBrands.Single(x => x.Id == id);
            car.Name = name;
            _carMainteanceRepository.UpdateCarBrand(car);
        }

        public CarModelDTO GetCarModel(int id)
        {
            return Mapper.Map<CarModelDTO>(_carMainteanceRepository.GetCarModel(id));
        }

        public void AddCarModel(int carBrandId, string name)
        {
            var carBrands = _carMainteanceRepository.GetCarBrands();
            var brand = carBrands.SingleOrDefault(x => x.Id == carBrandId);
            if (brand == null)
                throw new Exception();
            
            if (brand.Models.Any(x => x.Name.ToUpper() == name.ToUpper()))
                throw new CarException();

            _carMainteanceRepository.AddCarModel(
                new CarModel {
                    Brand = new CarBrand { Id = carBrandId },
                    Name = name }
                );
        }

        public void UpdateCarModel(int carModelId, string name)
        {
            var carModel = _carMainteanceRepository.GetCarModel(carModelId);
            if (carModel == null)
                throw new Exception();

            var brand = _carMainteanceRepository.GetCarBrand(carModel.Brand.Id);
            if (brand == null)
                throw new Exception();

            if (brand.Models.Any(x => x.Name.ToUpper() == name.ToUpper()))
                throw new CarException();

            carModel.Name = name;
            _carMainteanceRepository.UpdateCarModel(carModel);
        }

        public IEnumerable<BookingServiceDTO> GetAllBookings()
        {
            return Mapper.Map<IEnumerable<BookingServiceDTO>>(_carMainteanceRepository.GetAllBookings());
        }
        
        public IEnumerable<BookingServiceDTO> GetUnfinishedBookings()
        {
            var bookings = _carMainteanceRepository.GetAllBookings();
            return Mapper.Map<IEnumerable<BookingServiceDTO>>(bookings.Where(x => x.Status != Repository.CustomTypes.ServiceBookingStatus.Finished && x.Status != Repository.CustomTypes.ServiceBookingStatus.Declined));
        }

        public IEnumerable<BookingServiceDTO> GetArchivedBookings()
        {
            var bookings = _carMainteanceRepository.GetAllBookings();
            return Mapper.Map<IEnumerable<BookingServiceDTO>>(bookings.Where(x => x.Status == Repository.CustomTypes.ServiceBookingStatus.Finished || x.Status == Repository.CustomTypes.ServiceBookingStatus.Declined));
        }

        public BookingServiceDTO GetBooking(int id)
        {
            return Mapper.Map<BookingServiceDTO>(_carMainteanceRepository.GetBooking(id));
        }

        public IEnumerable<BookingServiceDTO> GetBookings(string userId)
        {
            return Mapper.Map<IEnumerable<BookingServiceDTO>>(_carMainteanceRepository.GetBookings(userId));
        }

        public IEnumerable<BookingServiceDTO> GetBookingsByCar(int carId)
        {
            return Mapper.Map<IEnumerable<BookingServiceDTO>>(_carMainteanceRepository.GetBookingsByCar(carId));
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

        public void UpdateDateServiceBooking(int id, DateTime date, string reason)
        {
            var currentBooking = _carMainteanceRepository.GetBooking(id);
            currentBooking.DateStarted = date;
            currentBooking.UserComment +=  $" powód zmiany daty: {reason}";
            currentBooking.AsSoonAsPossible = false;

            _carMainteanceRepository.UpdateServiceBooking(currentBooking);
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

            if (bookingService.AsSoonAsPossible)
                currentBooking.DateStarted = null;
            else
                currentBooking.DateStarted = bookingService.DateStarted;

            currentBooking.AsSoonAsPossible = bookingService.AsSoonAsPossible;

            _carMainteanceRepository.UpdateServiceBooking(currentBooking);
        }
    }
}