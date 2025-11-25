using Microsoft.EntityFrameworkCore;
using CircularPortal.API.Models;

namespace CircularPortal.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<WasteBin> WasteBins { get; set; }

    public DbSet<Feedback> Feedback { get; set; }

    // Seed data
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "John Doe", Email = "john@email.com", Phone = "040-1234567" }
        );

        modelBuilder.Entity<WasteBin>().HasData(
            new WasteBin { Id = 1, UserId = 1, Address = "Mannerheimintie 1", EmptyingSchedule = "Weekly", LastEmptiedAt = DateTime.Now.AddDays(-2) },
            new WasteBin { Id = 2, UserId = 1, Address = "Hämeentie 2", EmptyingSchedule = "Monthly", LastEmptiedAt = DateTime.Now.AddDays(-10) }
        );
    }
}