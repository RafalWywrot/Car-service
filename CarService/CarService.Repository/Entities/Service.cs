using System.Collections.Generic;

namespace CarService.Repository.Entities
{
    public class Service
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool RequiredComment { get; set; }
        public virtual string MessageUser { get; set; }
        public virtual bool Active { get; set; }

        public virtual IEnumerable<BookingServiceEntity> BookingServices { get; set; }
    }
}