using CarService.Logic.ModelsDTO;
using CarService.WebApplication.Models.User;

namespace CarService.WebApplication.Models.ServiceBooking
{
    public class ServiceBookingDetailViewModel
    {
        public ServiceBookingSummaryViewModel ServiceDetails { get; set; }
        public CarSummaryDTO CarDetails { get; set; }
        public string MechanicPhoneNumber { get; set; }
    }
}