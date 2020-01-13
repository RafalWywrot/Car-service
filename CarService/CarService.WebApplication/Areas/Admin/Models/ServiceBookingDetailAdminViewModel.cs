using CarService.Logic.ModelsDTO;
using CarService.WebApplication.Models.ServiceBooking;
using CarService.WebApplication.Models.User;

namespace CarService.WebApplication.Areas.Admin.Models
{
    public class ServiceBookingDetailAdminViewModel
    {
        public ServiceBookingSummaryViewModel ServiceDetails { get; set; }
        public CarSummaryDTO CarDetails { get; set; }
        public UserBasicViewModel User { get; set; }
    }
}