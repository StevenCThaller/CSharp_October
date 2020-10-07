using System;
using System.ComponentModel.DataAnnotations;

namespace EntityIntro.Models
{
    public class Vampire
    {
        [Key]
        public int VampireId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Victims { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}