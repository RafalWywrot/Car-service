using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Logic.Services.Abstract
{
    public interface IBookingService
    {
        /// <param name="id">Booking service id</param>
        void SetStatusAsVerified(int id);
    }
}