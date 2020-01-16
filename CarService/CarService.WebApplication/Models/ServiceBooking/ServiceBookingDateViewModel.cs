using CarService.WebApplication.Helpers.PropertyAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Models.ServiceBooking
{
    public class ServiceBookingDateViewModel
    {
        public int Id { get; set; }

        [MinDateAttribute]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date", ResourceType = typeof(Resource))]
        public DateTime? DateStarted { get; set; }
    }
}