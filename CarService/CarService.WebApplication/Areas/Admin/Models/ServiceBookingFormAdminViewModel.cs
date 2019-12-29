using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Areas.Admin.Models
{
    public class ServiceBookingFormAdminViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Samochód")]
        public string CarName { get; set; }

        [Display(Name = "Usługa")]
        public string ServiceName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data")]
        public string DateCreated { get; set; }

        [Display(Name = "Dodatkowe informacje")]
        public string Comment { get; set; }
    }
}