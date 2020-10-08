using System;
using System.ComponentModel.DataAnnotations;

namespace EntityIntro.Models
{
    public class Victim
    {
        [Key]
        public int VictimId { get; set; }
        public string Name { get; set; }

        // Foreign Key for the O2M relationship
        public int VampireId { get; set; }
        // Navigation Property - it allows us to populate the data regarding the foreign key
        public Vampire Vampire { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}