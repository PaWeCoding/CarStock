using Car.Core.Abstractions.Services;
using Car.Infrastructure.Abstractions.Entities;
using Car.Infrastructure.Abstractions.Repositories;

namespace Car.Core.Services
{
    public sealed class CarStockService(ICarRepository carRepository) : ICarStockService
    {
        private readonly ICarRepository _carRepository = carRepository;

        public void BookInMany(IEnumerable<CarBase> cars) =>
            _carRepository.InsertMany(cars);

        public void PrintStock()
        {
            // Assumption: Since the print order is not specified, I have decided to print the stock in descending order based on the year
            var cars = 
                _carRepository.GetAll()
                    .OrderByDescending(c => c.Year)
                    .Select(c => $"{c.Brand},\t{c.Year},\t{c.MaxSpeedKmh}km/h")
                    .ToList();
            Console.WriteLine("Brand\tYear\tMax Speed");
            cars.ForEach(Console.WriteLine);
        }
    }
}