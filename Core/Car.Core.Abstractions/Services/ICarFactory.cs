using Car.Core.Abstractions.Config;
using Car.Infrastructure.Abstractions.Entities;

namespace Car.Core.Abstractions.Services
{
    public interface ICarFactory
    {
        FordCar CreateFord(Action<CarConfig> config);
        VWCar CreateVW(Action<CarConfig> config);
    }
}