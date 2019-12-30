using CarService.WebApplication.Models.User;
using System.Collections.Generic;

namespace CarService.WebApplication.Areas.Admin.Models
{
    public class ServiceBookingMechanicAdminViewModel
    {
        public IEnumerable<UserBasicViewModel> Mechanics { get; set; }
        public string MechanicId { get; set; }
        public int ServiceBookingId { get; set; }
    }
}