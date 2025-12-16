using CarInventory.Data;
using CarInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace CarInventory.Services
{
    // This service handles simple authentication state for the demo application.
    public class AuthService
    {
        private readonly AppDbContext _db;

        // Stores the currently logged-in user in memory.
        public User? CurrentUser { get; private set; }

        // Convenience flag for authentication checks.
        public bool IsLoggedIn => CurrentUser != null;

        // Notifies the UI when login/logout occurs.
        public event Action? OnAuthChanged;

        // Injects the database context.
        public AuthService(AppDbContext db)
        {
            _db = db;
        }

        // Validates credentials and sets the current user.
        public bool Login(string username, string password)
        {
            var user = _db.Users
                .AsNoTracking()
                .FirstOrDefault(u =>
                    u.Username == username &&
                    u.PasswordHash == password);

            if (user == null)
                return false;

            CurrentUser = user;
            OnAuthChanged?.Invoke();
            return true;
        }

        // Clears authentication state and notifies listeners.
        public void Logout()
        {
            CurrentUser = null;
            OnAuthChanged?.Invoke();
        }
    }
}