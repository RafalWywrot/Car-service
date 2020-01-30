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

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(?:(?:(?:\+|00)?48)|(?:\(\+?48\)))?(?:1[2-8]|2[2-69]|3[2-49]|4[1-68]|5[0-9]|6[0-35-9]|[7-8][1-9]|9[145])\d{7}", ErrorMessage = "Niepoprawny numer telefonu")]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resource))]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Roles", ResourceType = typeof(Resource))]
        public string Roles { get; set; }

        [Display(Name = "Status", ResourceType = typeof(Resource))]
        public bool Active { get; set; }


        public string FullName
        {
            get {
                return $"{Name} {Surname}";
            }
        }
    }
}