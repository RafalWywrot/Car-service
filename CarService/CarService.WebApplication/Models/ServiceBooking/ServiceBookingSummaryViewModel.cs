using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Models.ServiceBooking
{
    public class ServiceBookingSummaryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Samochód")]
        public string CarName { get; set; }

        [Display(Name = "Usługa")]
        public string ServiceName { get; set; }

        [Display(Name = "Data")]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Jak najszybciej")]
        public bool AsSoonAsPossible { get; set; }

        [Display(Name = "Uwagi")]
        public string Comment { get; set; }
    }
}