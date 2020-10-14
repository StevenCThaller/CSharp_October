using System;
using System.ComponentModel.DataAnnotations;

namespace EntityIntro.Extensions.Validations
{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Write logic to determine whether a date is in the past
            if((DateTime)value >= DateTime.Now)
            {
                return new ValidationResult("Date cannot be in the future.");
            }
            else 
            {
                return ValidationResult.Success;
            }
        }
    }

    public class NoDraculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(((string)value).ToLower() == "dracula")
            {
                return new ValidationResult("NO DRACULA!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}