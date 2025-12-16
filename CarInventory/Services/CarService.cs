using CarInventory.Models;
using CarInventory.Data;
using Microsoft.EntityFrameworkCore;

namespace CarInventory.Services
{
    // Service responsible for all car-related database operations
    public class CarService
    {
        private readonly AppDbContext _db;

        // Inject the database context
        public CarService(AppDbContext db)
        {
            _db = db;
        }

        // Retrieve all cars from the database (read-only)
        public List<Car> GetCars() =>
            _db.Cars.AsNoTracking().ToList();

        // Retrieve a single car by its ID (read-only)
        public Car? GetCarById(int id) =>
            _db.Cars.AsNoTracking().FirstOrDefault(c => c.Id == id);

        // Add a new car to the database
        public void AddCar(Car car)
        {
            _db.Cars.Add(car);
            _db.SaveChanges();
        }

        // Update an existing car safely without re-attaching entities
        public void UpdateCar(Car updatedCar)
        {
            // Find the existing tracked entity
            var existingCar = _db.Cars.FirstOrDefault(c => c.Id == updatedCar.Id);
            if (existingCar == null)
                return;

            // Update individual fields
            existingCar.Make = updatedCar.Make;
            existingCar.Model = updatedCar.Model;
            existingCar.Year = updatedCar.Year;
            existingCar.Price = updatedCar.Price;
            existingCar.ImageFileName = updatedCar.ImageFileName;

            _db.SaveChanges();
        }

        // Delete a car by ID
        public void DeleteCar(int id)
        {
            var car = _db.Cars.Find(id);
            if (car != null)
            {
                _db.Cars.Remove(car);
                _db.SaveChanges();
            }
        }
    }
}