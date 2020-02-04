using System;

namespace CarService.Logic.ModelsDTO
{
    public class BookingServiceDTO
    {
        public int Id { get; set; }

        public IdNamePair Service { get; set; }
        public CarDTO Car { get; set; }
        public string Status { get; set; }
        public DateTime? DateStarted { get; set; }
        public string UserComment { get; set; }
        public string MechanicComment { get; set; }
        public bool AsSoonAsPossible { get; set; }
        public string MechanicId { get; set; }
        public string MechanicFullName { get; set; }

        public string UserFullName { get { return Car?.CarOwnerFullName; }}
    }
}