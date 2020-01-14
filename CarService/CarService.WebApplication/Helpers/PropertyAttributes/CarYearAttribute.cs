using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Helpers.PropertyAttributes
{
    public class CarYearAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int year = 0;
            if (value == null || !Int32.TryParse(value.ToString(), out year))
            {
                return new ValidationResult(string.Format("Niepoprawny rok"));
            };

            var minYear = 1900;
            var currentYear = DateTime.Now.Year;
            if (year < minYear || year > currentYear)
                return new ValidationResult(string.Format("Niepoprawny rok"));
            
            return ValidationResult.Success;
        }
    }
}