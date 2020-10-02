using System;
using System.ComponentModel.DataAnnotations;

namespace ModelsModelsModels.Models
{
    public class User
    {
        [Display(Name="First Name: ", Prompt="enter first name here")]
        [Required(ErrorMessage="First name is required.")]
        [MinLength(2, ErrorMessage="That's too short.")]
        public string FirstName { get; set; }
    
        [Display(Name="Last Name: ")]
        [Required(ErrorMessage="Last name is required.")]
        [MaxLength(20, ErrorMessage="That's too long.")]
        public string LastName { get; set; }

        [Display(Name="Email: ")]
        [Required(ErrorMessage="Email address is required.")]
        // [EmailAddress]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage="Invalid email address.")]
        public string Email { get; set; }

        // public string Password { get; set; }
        // [Compare("Password")]
        // public string ConfirmPassword { get; set; }
    }
}