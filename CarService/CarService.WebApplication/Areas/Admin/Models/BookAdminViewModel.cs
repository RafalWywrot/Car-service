using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Areas.Admin.Models
{
    public class BookAdminViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        public string Name { get; set; }

        [Display(Name = "ServiceCommentRequired", ResourceType = typeof(Resource))]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        public bool RequiredComment { get; set; }

        [Display(Name = "Message", ResourceType = typeof(Resource))]
        public string MessageUser { get; set; }
    }
}