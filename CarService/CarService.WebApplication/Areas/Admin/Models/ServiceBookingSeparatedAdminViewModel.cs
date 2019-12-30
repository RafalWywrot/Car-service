using System.Collections.Generic;

namespace CarService.WebApplication.Areas.Admin.Models
{
    public class ServiceBookingSeparatedAdminViewModel
    {
        public IEnumerable<ServiceBookingSummaryAdminViewModel> ServicesUnassignedToAnyMechanic { get; set; }
        public IEnumerable<ServiceBookingSummaryAdminViewModel> ServicesAlreadyAssigned { get; set; }
    }
}