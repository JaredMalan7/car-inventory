using System.ComponentModel.DataAnnotations;

namespace CarInventory.Models
{
    // Represents a car entity stored in the database
    public class Car
    {
        // Primary key
        public int Id { get; set; }

        // Manufacturer of the vehicle (required)
        [Required]
        public string Make { get; set; }

        // Model name of the vehicle (required)
        [Required]
        public string Model { get; set; }

        // Year the vehicle was manufactured
        [Range(1900, 2030)]
        public int Year { get; set; }

        // Price of the vehicle
        [Range(1, 200000)]
        public decimal Price { get; set; }

        // Optional external image URL (not required for uploads)
        public string ImageUrl { get; set; }

        // Name of the uploaded image file stored in wwwroot/images
        public string? ImageFileName { get; set; }

        // Indicates whether the car has been sold
        public bool IsSold { get; set; } = false;
    }
}