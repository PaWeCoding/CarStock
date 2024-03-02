using Car.Infrastructure.Abstractions.Enums;

namespace Car.Infrastructure.Abstractions.Entities
{
    public sealed record FordCar : Car
    {
        public FordCar(
            ushort Year,
            Tyre FrontLeftTyre,
            Tyre FrontRightTyre,
            Tyre RearLeftTyre,
            Tyre RearRightTyre) :
            base(
                CarBrands.Ford,
                MaxSpeedKmh: 250,
                Year,
                FrontLeftTyre,
                FrontRightTyre,
                RearLeftTyre,
                RearRightTyre)
        { }
    }
}
