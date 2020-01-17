using CarService.WebApplication.Helpers.PropertyAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Areas.Admin.Models
{
    public class ServiceBookingDateAdminViewModel
    {
        public int Id { get; set; }

        [MinDateAttribute]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date", ResourceType = typeof(Resource))]
        public DateTime? DateCreated { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "EditDateCause", ResourceType = typeof(Resource))]
        public string Comment { get; set; }
    }
}