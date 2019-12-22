using CarService.Identity;
using System.Collections.Generic;

namespace CarService.Repository.Entities
{
    public class Car
    {
        public virtual int Id { get; set; }
        public virtual CarModel Model { get; set; }
        public virtual ApplicationUser AssignedUser { get; set; }
        public virtual int Year { get; set; }
        public virtual double EngineCapacity { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual int Odometer { get; set; }
        public virtual FuelType Fuel { get; set; }
        public virtual int EnginePower { get; set; }
        public virtual bool Active { get; set; }

        public virtual IEnumerable<BookingService> BookingServices { get; set; }
    }
}