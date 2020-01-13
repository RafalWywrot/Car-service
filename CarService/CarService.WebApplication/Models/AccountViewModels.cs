using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resource))]
        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        [EmailAddress]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resource))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [EmailAddress]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }

        [MinLength(6, ErrorMessageResourceName = "PasswordLengthError", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [MinLength(6, ErrorMessageResourceName = "PasswordLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Compare("Password", ErrorMessageResourceName = "ComparePasswordError", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resource))]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [EmailAddress]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }

        [MinLength(6, ErrorMessageResourceName = "PasswordLengthError", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [MinLength(6, ErrorMessageResourceName = "PasswordLengthError", ErrorMessageResourceType = typeof(Resource))]
        [Compare("Password", ErrorMessageResourceName = "CompareError", ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resource))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [EmailAddress]
        [Required(ErrorMessageResourceType = typeof(Resource), ErrorMessageResourceName = "FieldRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resource))]
        public string Email { get; set; }
    }
}