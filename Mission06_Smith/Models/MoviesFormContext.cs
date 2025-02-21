using Microsoft.EntityFrameworkCore;

namespace Mission06_Smith.Models
{
    // MoviesFormContext is the database context for managing movie records.
    public class MoviesFormContext : DbContext 
    {
        // Constructor to initialize the context with options passed by dependency injection.
        public MoviesFormContext(DbContextOptions<MoviesFormContext> options) : base(options) 
        {
        }
        
        // DbSet representing the Movies table in the database.
        public DbSet<Movies> Movies { get; set; }
    }
}