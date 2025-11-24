using CarInventory.Models;
using CarInventory.Data;
using Microsoft.EntityFrameworkCore;

namespace CarInventory.Services
{
    public class CarService
    {
        private readonly AppDbContext _db;

        public CarService(AppDbContext db)
        {
            _db = db;
        }

        public List<Car> GetCars() =>
            _db.Cars.AsNoTracking().ToList();

        public Car? GetCarById(int id) =>
            _db.Cars.AsNoTracking().FirstOrDefault(c => c.Id == id);

        public void AddCar(Car car)
        {
            _db.Cars.Add(car);
            _db.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            _db.Cars.Update(car);
            _db.SaveChanges();
        }

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
