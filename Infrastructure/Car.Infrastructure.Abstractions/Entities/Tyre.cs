using Car.Infrastructure.Abstractions.Enums;

namespace Car.Infrastructure.Abstractions.Entities
{
    public sealed record Tyre(TyreBrands Brand, ushort SizeInch)
    {
        public ushort PressurePsi { get; set; }
    }
}
