using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Areas.Admin.Models
{
    public class ServiceBookingSummaryAdminViewModel
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

        [Display(Name = "Cautions", ResourceType = typeof(Resource))]
        public string Comment { get; set; }


        [Display(Name = "Status", ResourceType = typeof(Resource))]
        public string Status { get; set; }

        [Display(Name = "Date", ResourceType = typeof(Resource))]
        public string DateThatClientSelect { get; set; }

        [Display(Name = "Mechanic", ResourceType = typeof(Resource))]
        public string Mechanic { get; set; }

        [Display(Name = "Klient")]
        public string UserCarOwner { get; set; }
    }
}