using System.ComponentModel.DataAnnotations;

namespace CarInventory.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Range(1900, 2030)]
        public int Year { get; set; }
        [Range(1, 200000)]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string? ImageFileName { get; set; }
        public bool IsSold { get; set; } = false;
    }
}
