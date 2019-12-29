using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Areas.Admin.Models
{
    public class ServiceBookingDateAdminViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public DateTime? DateCreated { get; set; }

        [Required]
        [Display(Name = "Powód zmiany daty")]
        public string Comment { get; set; }
    }
}