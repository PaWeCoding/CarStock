using Car.Infrastructure.Abstractions.Enums;

namespace Car.Infrastructure.Abstractions.Entities
{
    public sealed record FordCar : Car
    {
        public FordCar(
            ushort year,
            Tyre frontLeftTyre,
            Tyre frontRightTyre,
            Tyre rearLeftTyre,
            Tyre rearRightTyre) :
            base(
                CarBrands.Ford,
                MaxSpeedKmh: 250,
                year)
        {
            FrontLeftTyre = frontLeftTyre;
            FrontRightTyre = frontRightTyre;
            RearLeftTyre = rearLeftTyre;
            RearRightTyre = rearRightTyre;
        }
    }
}
