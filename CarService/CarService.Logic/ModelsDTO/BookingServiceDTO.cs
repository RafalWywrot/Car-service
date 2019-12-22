using System;

namespace CarService.Logic.ModelsDTO
{
    public class BookingServiceDTO
    {
        public int Id { get; set; }

        public IdNamePair Service { get; set; }
        public CarDTO Car { get; set; }
        public string Status { get; set; }
        public DateTime DateStarted { get; set; }
        public string UserComment { get; set; }
    }
}