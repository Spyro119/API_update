using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<interventions> interventions { get; set; }
        public DbSet<batteries> batteries { get; set; }
        public DbSet<buildings> buildings { get; set; }
        public DbSet<elevators> elevators { get; set; }
        public DbSet<columns> columns { get; set; }
        public DbSet<leads> leads { get; set; }
        public DbSet<customers> customers { get; set; }
        public DbSet<quotes> quotes { get; set; }

        
    }
}
