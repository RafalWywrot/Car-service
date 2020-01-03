using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Models.ServiceBooking
{
    public class ServiceBookingSummaryViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Car", ResourceType = typeof(Resource))]
        public string CarName { get; set; }

        [Display(Name = "Service", ResourceType = typeof(Resource))]
        public string ServiceName { get; set; }

        [Display(Name = "Date", ResourceType = typeof(Resource))]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "AsSoonAsPossible", ResourceType = typeof(Resource))]
        public bool AsSoonAsPossible { get; set; }

        [Display(Name = "Comment", ResourceType = typeof(Resource))]
        public string Comment { get; set; }

        [Display(Name = "Status", ResourceType = typeof(Resource))]
        public string Status { get; set; }

        [Display(Name = "Mechanic", ResourceType = typeof(Resource))]
        public string Mechanic { get; set; }
    }
}