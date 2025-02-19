using Microsoft.EntityFrameworkCore;
namespace Mission06_Smith.Models;

public class MoviesFormContext : DbContext 
{
    // this will go into the contrller.cs file for the options...
    public MoviesFormContext(DbContextOptions<MoviesFormContext> options) : base(options) // constructor
    {
    }
    // this is where you name your table in the database
    public DbSet<Movies> Movies { get; set; }
    
}