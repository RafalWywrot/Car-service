using CarService.Repository.Abstract;
using CarService.Repository.CustomTypes;
using CarService.Repository.Entities;
using CarService.Repository.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Repository.Repositories.Concrete
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void SetBookingStatus(int id, ServiceBookingStatus status)
        {
            var booking = _unitOfWork.Session.Get<BookingService>(id);
            booking.Status = status;
            using (var transaction = _unitOfWork.Session.BeginTransaction())
            {
                _unitOfWork.Session.Save(booking);
                transaction.Commit();
            }
        }
    }
}