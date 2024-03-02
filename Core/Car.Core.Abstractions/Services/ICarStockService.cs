using Car.Infrastructure.Abstractions.Entities;

namespace Car.Core.Abstractions.Services
{
    public interface ICarStockService
    {
        void BookInMany(IEnumerable<CarBase> cars);
        void PrintStock();
    }
}