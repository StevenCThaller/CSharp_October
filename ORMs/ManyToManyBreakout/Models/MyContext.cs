using Microsoft.EntityFrameworkCore;
namespace ManyToManyBreakout.Models
{ 
    // the MyContext class representing a session with our MySQL 
    // database allowing us to query for or save data
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<UserLikesColor> UsersLikeColors { get; set; }
    }
}