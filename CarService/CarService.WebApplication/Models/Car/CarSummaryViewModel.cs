using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Models.Car
{
    public class CarSummaryViewModel
    {
        public int Id { get; set; }
        [Display(Name = "CarModel", ResourceType = typeof(Resource))]
        public string Model { get; set; }

        [Display(Name = "CarYear", ResourceType = typeof(Resource))]
        public int Year { get; set; }

        [Display(Name = "CarCapacity", ResourceType = typeof(Resource))]
        public double EngineCapacity { get; set; }

        [Display(Name = "CarTransmission", ResourceType = typeof(Resource))]
        public string Transmission { get; set; }

        [Display(Name = "CarOdometer", ResourceType = typeof(Resource))]
        public int Odometer { get; set; }

        [Display(Name = "CarFuel", ResourceType = typeof(Resource))]
        public string Fuel { get; set; }

        [Display(Name = "CarPower", ResourceType = typeof(Resource))]
        public int EnginePower { get; set; }
        
        public bool Active { get; set; }
    }
}