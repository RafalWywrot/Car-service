namespace CarService.WebApplication.Areas.Admin.Models
{
    public class CarManagementSummaryViewModel
    {
        public int CarBrandId { get; set; }
        public int CarModelId{ get; set; }
        public string CarBrandName{ get; set; }
        public string CarModelName { get; set; }
        public int Active { get; set; }
    }
}