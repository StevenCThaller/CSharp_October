using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityIntro.Models
{
    public class Ghost
    {
        [Key]
        public int GhostId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        // Navigation property for the many to many relationship
        public List<GhostHasEvidence> GhostHasEvidence{ get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}