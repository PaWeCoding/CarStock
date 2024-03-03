using Car.Infrastructure.Abstractions.Entities;

namespace Car.Infrastructure.Abstractions.Repositories
{
    public interface ICarRepository
    {
        void InsertMany(IEnumerable<CarBase> cars);
        IQueryable<CarBase> GetAll();
    }
}