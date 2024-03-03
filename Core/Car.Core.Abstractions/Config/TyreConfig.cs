using Car.Infrastructure.Abstractions.Enums;

namespace Car.Core.Abstractions.Config
{
    // Assumption: Default tyre config if not otherwise specified
    public sealed class TyreConfig
    {
        public TyreBrands Brand { get; set; } = TyreBrands.Pirelli;
        public ushort SizeInch { get; set; } = 17;
        public ushort FrontPressurePsi { get; set; } = 55;
        public ushort RearPressurePsi { get; set; } = 55;
    }
}