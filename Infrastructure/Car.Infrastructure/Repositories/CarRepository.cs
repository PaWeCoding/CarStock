using Car.Infrastructure.Abstractions.Entities;
using Car.Infrastructure.Abstractions.Repositories;
using System.Collections.Immutable;

namespace Car.Infrastructure.Repositories
{
    public sealed class CarRepository : ICarRepository
    {
        private readonly IImmutableList<CarBase> _cars = [];

        public void InsertMany(IEnumerable<CarBase> cars) =>
            _cars.AddRange(cars);

        public IQueryable<CarBase> GetAll() => _cars.AsQueryable();
    }
}
