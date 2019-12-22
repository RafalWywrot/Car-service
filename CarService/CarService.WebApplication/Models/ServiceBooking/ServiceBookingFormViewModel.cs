using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CarService.WebApplication.Models.ServiceBooking
{
    public class ServiceBookingFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Usługa")]
        public int CarId { get; set; }

        public IEnumerable<SelectListItem> Cars { get; set; }

        [Required]
        [Display(Name = "Samochód")]
        public int ServiceId { get; set; }

        public IEnumerable<SelectListItem> Services { get; set; }

        [Required]
        [Display(Name = "Data")]
        public DateTime? DateCreated { get; set; }

        [Required]
        [Display(Name = "Jak najszybciej")]
        public bool AsSoonAsPossible { get; set; }
        public string Comment { get; set; }
    }
}