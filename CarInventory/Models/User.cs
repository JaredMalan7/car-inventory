namespace CarInventory.Models
{
    // Represents an application user (admin access only in this project)
    public class User
    {
        // Primary key
        public int Id { get; set; }

        // Username used to log into the application
        public string Username { get; set; } = "";

        // Password value (stored as plain text for demo purposes only)
        public string PasswordHash { get; set; } = "";

        // User role (currently not enforced beyond admin access)
        public string Role { get; set; } = "User"; // Admin / User
    }
}