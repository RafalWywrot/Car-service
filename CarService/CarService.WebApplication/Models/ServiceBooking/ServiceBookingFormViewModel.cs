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
        [Display(Name = "Samochód")]
        public int CarId { get; set; }

        public IEnumerable<SelectListItem> Cars { get; set; }

        [Required]
        [Display(Name = "Usługa")]
        public int ServiceId { get; set; }

        public IEnumerable<SelectListItem> Services { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime? DateCreated { get; set; }

        [Required]
        [Display(Name = "Termin")]
        public bool AsSoonAsPossible { get; set; }

        [Display(Name = "Uwagi")]
        public string Comment { get; set; }
    }
}