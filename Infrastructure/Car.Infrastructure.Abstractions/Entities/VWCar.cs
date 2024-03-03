using Car.Infrastructure.Abstractions.Enums;

namespace Car.Infrastructure.Abstractions.Entities
{
    public sealed record VWCar : CarBase
    {
        public VWCar(
            ushort year,
            Tyre frontLeftTyre,
            Tyre frontRightTyre,
            Tyre rearLeftTyre,
            Tyre rearRightTyre) :
            base(
                CarBrands.VW,
                MaxSpeedKmh: 180,
                year)
        {
            FrontLeftTyre = frontLeftTyre;
            FrontRightTyre = frontRightTyre;
            RearLeftTyre = rearLeftTyre;
            RearRightTyre = rearRightTyre;
        }
    }
}