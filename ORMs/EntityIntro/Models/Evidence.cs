using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityIntro.Models
{
    public class Evidence
    {
        [Key]
        public int EvidenceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<GhostHasEvidence> GhostHasEvidence { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}