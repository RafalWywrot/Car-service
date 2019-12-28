using CarService.Repository.CustomTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Repository.Repositories.Abstract
{
    public interface IBookingRepository
    {
        void SetBookingStatus(int id, ServiceBookingStatus status);
    }
}