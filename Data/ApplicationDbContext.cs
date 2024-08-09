using GraphQl.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQl.Data
{
  
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
                
            }
            public DbSet<Project> Projects { get; set; }
            public DbSet<Activity> Tasks { get; set; }
            public DbSet<User> Users { get; set; }
        }
}
