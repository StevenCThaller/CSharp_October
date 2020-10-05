using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SessionIntro.Models
{
    public class User
    {
        [Required]
        [MinLength(2)]
        [Display(Name="First Name: ")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name="Last Name: ")]
        public string LastName { get; set; }

        [Required(ErrorMessage="You must enter a number")]
        [Display(Name="Age: ")]
        public int? Age { get; set; }

    }
}