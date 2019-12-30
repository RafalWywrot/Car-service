using CarService.Repository.Abstract;
using CarService.Repository.Entities;
using CarService.Repository.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;


namespace CarService.Repository.Repositories.Concrete
{
    public class LinkServiceBookingUserRepository : ILinkServiceBookingUserRepository
    {
        private readonly IUnitOfWork unitOfWork;

        public LinkServiceBookingUserRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(LinkBookingServiceUser entity)
        {
            using (var transaction = unitOfWork.Session.BeginTransaction())
            {
                unitOfWork.Session.Save(entity);
                transaction.Commit();
            }
        }

        public void Delete(LinkBookingServiceUser entity)
        {
            using (var transaction = unitOfWork.Session.BeginTransaction())
            {
                unitOfWork.Session.Delete(entity);
                transaction.Commit();
            }
        }

        public IEnumerable<BookingServiceEntity> Get(string userId)
        {
            //var cars = unitOfWork.Session.QueryOver<Car>().Where(x => x.AssignedUser.Id == userId).List();
            //var bookedServices = unitOfWork.Session.QueryOver<BookingServiceEntity>().AndRestrictionOn(x => x.Car.Id).IsIn(cars.Select(c => c.Id).ToList()).List();
            var allServices = unitOfWork.Session.QueryOver<LinkBookingServiceUser>().Where(x => x.AssignedUser.Id == userId).List();
            return allServices.Select(x => x.BookingService);
        }

        public LinkBookingServiceUser Get(int bookingServiceId)
        {
            return unitOfWork.Session.QueryOver<LinkBookingServiceUser>().Where(x => x.BookingService.Id == bookingServiceId).SingleOrDefault();
        }

        public void Update(LinkBookingServiceUser entity)
        {
            using (var transaction = unitOfWork.Session.BeginTransaction())
            {
                unitOfWork.Session.Update(entity);
                transaction.Commit();
            }
        }
    }
}
