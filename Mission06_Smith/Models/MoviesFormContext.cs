using Microsoft.EntityFrameworkCore;
using Mission06_Smith.Models;

namespace Mission06_Smith.Models
{
    // Database context for managing movie records and categories
    public class MoviesFormContext : DbContext
    {
        // Constructor to initialize with dependency-injected options
        public MoviesFormContext(DbContextOptions<MoviesFormContext> options) : base(options)
        {
        }

        // Table for movies
        public DbSet<Movies> Movies { get; set; }
        // Table for categories
        public DbSet<Category> Categories { get; set; }

        // Configure entity relationships and keys
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>()
                .HasKey(m => m.MovieId);

            modelBuilder.Entity<Movies>()
                .Property(m => m.MovieId)
                .ValueGeneratedOnAdd(); // Auto-increment MovieId

            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            modelBuilder.Entity<Movies>()
                .HasOne(m => m.Category)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent category deletion if movies exist
        }
    }
}