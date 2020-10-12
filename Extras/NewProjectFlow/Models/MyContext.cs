using Microsoft.EntityFrameworkCore;
namespace NewProjectFlow.Models
{ 
    // the MyContext class representing a session with our MySQL 
    // database allowing us to query for or save data
    public class MyContext : DbContext 
    { 
        public MyContext(DbContextOptions options) : base(options) { }

        // DON'T FORGET TO COME BACK AND ADD YOUR DBSETS
        public DbSet<TestModel> TestModels { get; set; }
    }
}