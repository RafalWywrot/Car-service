using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Areas.Admin.Models
{
    public class CarBrandAdminViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        public string Name { get; set; }
    }
}