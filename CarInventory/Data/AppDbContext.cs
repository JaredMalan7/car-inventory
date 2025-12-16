using CarInventory.Models;
using Microsoft.EntityFrameworkCore;

// THIS IS WHERE I SEEDED THE USER AND THE CARS TO HAVE SOMETHING TO WORK WITH WHEN THE REPO IS CLONED AND FOR DEMO PURPOSES

namespace CarInventory.Data
{
    // Represents the Entity Framework Core database context for the application
    public class AppDbContext : DbContext
    {
        // Represents the Cars table in the database
        public DbSet<Car> Cars => Set<Car>();
        // Represents the Users table in the database
        public DbSet<User> Users => Set<User>();

        // Constructor that receives configuration options via dependency injection
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call the base method to ensure proper model creation behavior
            base.OnModelCreating(modelBuilder);

            // === Car Defaults ===
            // Configure default value for ImageUrl property of Car entities
            modelBuilder.Entity<Car>()
                .Property(c => c.ImageUrl)
                .HasDefaultValue("no-image");

            // === Seed Super Admin ===
            // Seed a default admin user for demo purposes
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "superadmin",
                    PasswordHash = "admin123", //TODO: optional to hash later
                    Role = "Admin"
                }


            );

            // === Seed Cars ===
            // Seed sample cars for initial application data
            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    Id = 1,
                    Make = "Toyota",
                    Model = "Camry",
                    Year = 2020,
                    Price = 22000,
                    ImageUrl = "no-image"
                },
                new Car
                {
                    Id = 2,
                    Make = "Ford",
                    Model = "Mustang",
                    Year = 2019,
                    Price = 28000,
                    ImageUrl = "no-image"
                },
                new Car
                {
                    Id = 3,
                    Make = "Honda",
                    Model = "Civic",
                    Year = 2021,
                    Price = 21500,
                    ImageUrl = "no-image"
                },
                new Car
                {
                    Id = 4,
                    Make = "Tesla",
                    Model = "Model 3",
                    Year = 2022,
                    Price = 39000,
                    ImageUrl = "no-image"
                },
                new Car
                {
                    Id = 5,
                    Make = "Chevrolet",
                    Model = "Silverado",
                    Year = 2018,
                    Price = 31000,
                    ImageUrl = "no-image"
                },
                new Car
                {
                    Id = 6,
                    Make = "Subaru",
                    Model = "Outback",
                    Year = 2020,
                    Price = 27800,
                    ImageUrl = "no-image"
                },
                new Car
                {
                    Id = 7,
                    Make = "BMW",
                    Model = "330i",
                    Year = 2019,
                    Price = 33500,
                    ImageUrl = "no-image"
                }
            );
        }
    }
}