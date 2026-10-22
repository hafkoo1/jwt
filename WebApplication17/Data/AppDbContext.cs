using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApplication17.Models;

namespace WebApplication17.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Username = "admin", Password = "password123" }
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Inception", Genre = "Sci-Fi", ReleaseYear = 2010, Rating = 8.8 },
            new Movie { Id = 2, Title = "Interstellar", Genre = "Sci-Fi", ReleaseYear = 2014, Rating = 8.6 },
            new Movie { Id = 3, Title = "The Dark Knight", Genre = "Action", ReleaseYear = 2008, Rating = 9.0 }
        );
    }
}