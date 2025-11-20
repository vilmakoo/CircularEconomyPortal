using Microsoft.EntityFrameworkCore;
using CircularPortal.API.Models;

namespace CircularPortal.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<WasteBin> WasteBins { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }

    // Seed data so the app isn't empty when you start it
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "John Doe", Email = "john@circular.com", Phone = "123-456-7890" }
        );

        modelBuilder.Entity<WasteBin>().HasData(
            new WasteBin { Id = 1, UserId = 1, Address = "123 Green St", EmptyingSchedule = "Weekly", LastEmptiedAt = DateTime.Now.AddDays(-2) },
            new WasteBin { Id = 2, UserId = 1, Address = "456 Eco Ave", EmptyingSchedule = "Bi-Weekly", LastEmptiedAt = DateTime.Now.AddDays(-10) }
        );
    }
}