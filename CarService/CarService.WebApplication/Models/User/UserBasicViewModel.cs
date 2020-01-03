using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Models.User
{
    public class UserBasicViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "UserName", ResourceType = typeof(Resource))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Surname", ResourceType = typeof(Resource))]
        public string Surname { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Roles", ResourceType = typeof(Resource))]
        public string Roles { get; set; }
    }
}