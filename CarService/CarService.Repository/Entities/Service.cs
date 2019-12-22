using System.Collections.Generic;

namespace CarService.Repository.Entities
{
    public class Service
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IEnumerable<BookingService> BookingServices { get; set; }
    }
}