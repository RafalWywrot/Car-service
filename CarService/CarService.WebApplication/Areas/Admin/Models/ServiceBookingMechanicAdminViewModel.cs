using CarService.WebApplication.Models.User;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Areas.Admin.Models
{
    public class ServiceBookingMechanicAdminViewModel
    {
        public IEnumerable<UserBasicViewModel> Mechanics { get; set; }

        [Required]
        [Display(Name = "Mechanik")]
        public string MechanicId { get; set; }

        public int ServiceBookingId { get; set; }
    }
}