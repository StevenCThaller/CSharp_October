using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityIntro.Models
{
    public class GhostHasEvidence
    {
        [Key]
        public int GhostHasEvidenceId { get; set; }

        public int GhostId { get; set; }
        // Navigation Property for the Ghost
        public Ghost Ghost { get; set; }

        public int EvidenceId { get; set; }
        // Navigation Property for the Evidence
        public Evidence Evidence { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}