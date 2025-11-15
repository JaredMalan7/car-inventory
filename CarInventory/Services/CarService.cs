using CarInventory.Models;

namespace CarInventory.Services
{
    public class CarService
    {
        private readonly List<Car> _cars = new()
        {
            new Car { Id = 1, Make = "Toyota", Model = "Camry", Year = 2020, Price = 22000, ImageUrl = "" },
            new Car { Id = 2, Make = "Ford", Model = "Mustang", Year = 2019, Price = 28000, ImageUrl = "" }
        };

        public List<Car> GetCars() => _cars;

        public Car? GetCarById(int id) =>
            _cars.FirstOrDefault(x => x.Id == id);

        public void AddCar(Car car)
        {
            car.Id = _cars.Max(c => c.Id) + 1;
            _cars.Add(car);
        }

        public void UpdateCar(Car car)
        {
            var existing = GetCarById(car.Id);
            if (existing == null) return;

            existing.Make = car.Make;
            existing.Model = car.Model;
            existing.Year = car.Year;
            existing.Price = car.Price;
            existing.ImageUrl = car.ImageUrl;
        }

        public void DeleteCar(int id)
        {
            var car = GetCarById(id);
            if (car != null)
                _cars.Remove(car);
        }
    }
}
