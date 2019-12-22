using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CarService.WebApplication.Models.Car
{
    public class CarFormViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Marka")]
        public int CarBrandId { get; set; }
        public IEnumerable<SelectListItem> CarBrands{ get; set; }

        [Required]
        [Display(Name = "Model")]
        [Range(1, int.MaxValue, ErrorMessage = "Pole wymagane")]
        public int CarModelId { get; set; }
        public IEnumerable<SelectListItem> CarModels { get; set; }

        [Required]
        [Display(Name = "Rok")]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Pojemność")]
        public double EngineCapacity { get; set; }

        [Required]
        [Display(Name = "Skrzynia")]
        public int TransmissionId { get; set; }
        public IEnumerable<SelectListItem> TransmissionOptions { get; set; }

        [Required]
        [Display(Name = "Przebieg")]
        public int Odometer { get; set; }

        [Required]
        [Display(Name = "Paliwo")]
        public int FuelTypeId { get; set; }
        public IEnumerable<SelectListItem> FuelOptions { get; set; }

        [Required]
        [Display(Name = "Moc")]
        public int EnginePower { get; set; }
    }
}