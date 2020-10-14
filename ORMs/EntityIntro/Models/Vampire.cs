using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EntityIntro.Extensions.Validations;

namespace EntityIntro.Models
{
    public class Vampire
    {
        [Key]
        public int VampireId { get; set; }
        [Required]
        [MinLength(3)]
        [NoDracula]
        public string Name { get; set; }

        [PastDate]
        public DateTime Birthday { get; set; }
        // Navigation Property
        public List<Victim> Victims { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}