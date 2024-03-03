using Car.Infrastructure.Abstractions.Enums;

namespace Car.Infrastructure.Abstractions.Entities
{
    public abstract record CarBase(
        CarBrands Brand, 
        ushort MaxSpeedKmh, 
        ushort Year)
    {
        public Tyre FrontLeftTyre { get; set; } = null!;
        public Tyre FrontRightTyre { get; set; } = null!;
        public Tyre RearLeftTyre { get; set; } = null!;
        public Tyre RearRightTyre { get; set; } = null!;
    }
}