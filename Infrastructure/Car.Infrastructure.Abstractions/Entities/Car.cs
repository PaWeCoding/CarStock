using Car.Infrastructure.Abstractions.Enums;

namespace Car.Infrastructure.Abstractions.Entities
{
    public abstract record Car(
        CarBrands Brand, 
        ushort MaxSpeedKmh, 
        ushort Year, 
        Tyre FrontLeftTyre, 
        Tyre FrontRightTyre, 
        Tyre RearLeftTyre, 
        Tyre RearRightTyre);
}
