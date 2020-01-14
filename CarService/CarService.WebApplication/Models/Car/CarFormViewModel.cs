using CarService.WebApplication.Helpers.PropertyAttributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CarService.WebApplication.Models.Car
{
    public class CarFormViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        
        [Display(Name = "CarBrand", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        public int CarBrandId { get; set; }
        public IEnumerable<SelectListItem> CarBrands{ get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "CarModel", ResourceType = typeof(Resource))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        public int CarModelId { get; set; }
        public IEnumerable<SelectListItem> CarModels { get; set; }

        [CarYearAttribute]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "CarYear", ResourceType = typeof(Resource))]
        public int Year { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Niepoprawna pojemność")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "CarCapacity", ResourceType = typeof(Resource))]
        public double EngineCapacity { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "CarTransmission", ResourceType = typeof(Resource))]
        public int TransmissionId { get; set; }
        public IEnumerable<SelectListItem> TransmissionOptions { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Niepoprawny przebieg")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "CarOdometer", ResourceType = typeof(Resource))]
        public int Odometer { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "CarFuel", ResourceType = typeof(Resource))]
        public int FuelTypeId { get; set; }
        public IEnumerable<SelectListItem> FuelOptions { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Niepoprawna moc")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "CarPower", ResourceType = typeof(Resource))]
        public int EnginePower { get; set; }
    }
}