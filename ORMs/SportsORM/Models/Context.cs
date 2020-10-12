using Microsoft.EntityFrameworkCore;


namespace SportsORM.Models
{
    /// <summary>Context class representing a session with our sqlite
    /// database allowing us to query or save data</summary>
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite("Data Source=SportsORM.db");

        public DbSet<League> Leagues {get;set;}
        public DbSet<Team> Teams {get;set;}
        public DbSet<Player> Players {get;set;}
        public DbSet<PlayerTeam> PlayerTeams {get;set;}

    }
}
