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

        // Assumption: Since the order is not specified, I have decided to return the car stock in descending order based on the year
        public IList<CarBase> GetStockOrderedByYearDesc()
        {
            var carStock =
                _carRepository.GetAll()
                    .OrderByDescending(car => car.Year)
                    .ToList();
            return carStock;
        }
    }
}