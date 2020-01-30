using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CarService.WebApplication.Models.ServiceBooking
{
    public class ServiceBookingFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Car", ResourceType = typeof(Resource))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        public int CarId { get; set; }

        public IEnumerable<SelectListItem> Cars { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Service", ResourceType = typeof(Resource))]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        public int ServiceId { get; set; }

        public IEnumerable<SelectListItem> Services { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date", ResourceType = typeof(Resource))]
        public DateTime? DateCreated { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "DateService", ResourceType = typeof(Resource))]
        public bool AsSoonAsPossible { get; set; }

        [Display(Name = "Cautions", ResourceType = typeof(Resource))]
        public string Comment { get; set; }
    }
}