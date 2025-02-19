using Microsoft.EntityFrameworkCore;

namespace Mission06_Smith.Models;

public class MoviesFormContext : DbContext 
{
    
    public MoviesFormContext(DbContextOptions<MoviesFormContext> options) : base(options) 
    {
    }
    
    public DbSet<Movies> Movies { get; set; }
    
}