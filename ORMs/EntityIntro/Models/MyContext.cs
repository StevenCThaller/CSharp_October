using Microsoft.EntityFrameworkCore;

namespace EntityIntro.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        // our dbsets
        public DbSet<Vampire> Vampires { get; set; }
        public DbSet<Victim> Victims { get; set; }

        public DbSet<Ghost> Ghosts { get; set; }
        public DbSet<Evidence> Evidence { get; set; }
        public DbSet<GhostHasEvidence> GhostsHaveEvidence { get; set; }
    }
}