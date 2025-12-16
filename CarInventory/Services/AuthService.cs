using CarInventory.Data;
using CarInventory.Models;
using Microsoft.EntityFrameworkCore;

namespace CarInventory.Services
{
    public class AuthService
    {
        private readonly AppDbContext _db;

        public User? CurrentUser { get; private set; }
        public bool IsLoggedIn => CurrentUser != null;
        public event Action? OnAuthChanged;

        public AuthService(AppDbContext db)
        {
            _db = db;
        }

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

        public void Logout()
        {
            CurrentUser = null;
            OnAuthChanged?.Invoke();
        }
    }
}