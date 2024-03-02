using Car.Infrastructure.Abstractions.Enums;

namespace Car.Infrastructure.Abstractions.Entities
{
    public sealed record VWCar : Car
    {
        public VWCar(
            ushort Year,
            Tyre FrontLeftTyre,
            Tyre FrontRightTyre,
            Tyre RearLeftTyre,
            Tyre RearRightTyre) :
            base(
                CarBrands.VW,
                MaxSpeedKmh: 180,
                Year,
                FrontLeftTyre,
                FrontRightTyre,
                RearLeftTyre,
                RearRightTyre)
        { }
    }
}
