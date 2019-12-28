﻿using CarService.Repository.Abstract;
using CarService.Repository.Entities;
using CarService.Repository.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace CarService.Repository.Repositories.Concrete
{
    public class CarMainteanceRepository : ICarMainteanceRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public CarMainteanceRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void AddService(string name)
        {
            var entity = new Service
            {
                Name = name
            };
            using (var transaction = unitOfWork.Session.BeginTransaction())
            {
                unitOfWork.Session.Save(entity);
                transaction.Commit();
            }
        }

        public Service GetService(int id)
        {
            return unitOfWork.Session.Get<Service>(id);
        }

        public IEnumerable<Service> GetServices()
        {
            return unitOfWork.Session.QueryOver<Service>().List();
        }

        public void UpdateServie(int id, string name)
        {
            var entity = GetService(id);
            entity.Name = name;
            using (var transaction = unitOfWork.Session.BeginTransaction())
            {
                unitOfWork.Session.Update(entity);
                transaction.Commit();
            }
        }

        public void AddServiceBooking(BookingServiceEntity bookingService)
        {
            using (var transaction = unitOfWork.Session.BeginTransaction())
            {
                unitOfWork.Session.Save(bookingService);
                transaction.Commit();
            }
        }

        public IEnumerable<BookingServiceEntity> GetBookings(string userId)
        {
            var cars = unitOfWork.Session.QueryOver<Car>().Where(x => x.AssignedUser.Id == userId).List();
            var bookedServices = unitOfWork.Session.QueryOver<BookingServiceEntity>().AndRestrictionOn(x => x.Car.Id).IsIn(cars.Select(c => c.Id).ToList()).List();
            return bookedServices;
        }

        public BookingServiceEntity GetBooking(int id)
        {
            return unitOfWork.Session.Get<BookingServiceEntity>(id);
        }

        public void UpdateServiceBooking(BookingServiceEntity bookingService)
        {
            using (var transaction = unitOfWork.Session.BeginTransaction())
            {
                unitOfWork.Session.Update(bookingService);
                transaction.Commit();
            }
        }

        public IEnumerable<BookingServiceEntity> GetAllBookings()
        {
            return unitOfWork.Session.QueryOver<BookingServiceEntity>().List();
        }
    }
}