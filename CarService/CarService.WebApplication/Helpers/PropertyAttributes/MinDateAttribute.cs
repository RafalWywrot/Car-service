using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.WebApplication.Helpers.PropertyAttributes
{
    public class MinDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult(string.Format("Wybierz datę"));
            
            var date = (DateTime)value;
            var dateTimeMin = DateTime.Now;

            if (date < dateTimeMin.Date)
                return new ValidationResult(string.Format("Nie można dodać usługi z historyczną datą"));

            return ValidationResult.Success;
        }
    }
}
