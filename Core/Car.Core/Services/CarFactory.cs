using Car.Core.Abstractions.Config;
using Car.Core.Abstractions.Services;
using Car.Infrastructure.Abstractions.Entities;

namespace Car.Core.Services
{
    public sealed class CarFactory : ICarFactory
    {
        public FordCar CreateFord(Action<CarConfig>? config = default)
        {
            var carConfig = new CarConfig();
            config?.Invoke(carConfig);

            var (FrontLeftTyre, FrontRightTyre, RearLeftTyre, RearRightTyre) = CreateTyres(carConfig.TyreConfig);

            var fordCar = 
                new FordCar(
                    carConfig.Year, 
                    FrontLeftTyre, 
                    FrontRightTyre, 
                    RearLeftTyre, 
                    RearRightTyre);
            return fordCar;
        }

        public VWCar CreateVW(Action<CarConfig>? config = default)
        {
            var carConfig = new CarConfig();
            config?.Invoke(carConfig);

            var (FrontLeftTyre, FrontRightTyre, RearLeftTyre, RearRightTyre) = CreateTyres(carConfig.TyreConfig);

            var vwCar =
                new VWCar(
                    carConfig.Year,
                    FrontLeftTyre,
                    FrontRightTyre,
                    RearLeftTyre,
                    RearRightTyre);
            return vwCar;
        }

        private static (Tyre FrontLeftTyre, Tyre FrontRightTyre, Tyre RearLeftTyre, Tyre RearRightTyre) CreateTyres(TyreConfig tyreConfig)
        {
            var frontLeftTyre = new Tyre(tyreConfig.Brand, tyreConfig.SizeInch);
            var frontRightTyre = new Tyre(tyreConfig.Brand, tyreConfig.SizeInch);
            frontLeftTyre.PressurePsi = frontRightTyre.PressurePsi = tyreConfig.FrontPressurePsi;

            var rearLeftTyre = new Tyre(tyreConfig.Brand, tyreConfig.SizeInch);
            var rearRightTyre = new Tyre(tyreConfig.Brand, tyreConfig.SizeInch);
            rearLeftTyre.PressurePsi = rearRightTyre.PressurePsi = tyreConfig.RearPressurePsi;

            return (frontLeftTyre, frontRightTyre, rearLeftTyre, rearRightTyre);
        }
    }
}