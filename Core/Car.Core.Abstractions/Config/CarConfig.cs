namespace Car.Core.Abstractions.Config
{
    public class CarConfig
    {
        // Assumption: Default year is, when not otherwise specified, the current one
        public ushort Year { get; set; } = (ushort)DateTime.Now.Year;
        public TyreConfig TyreConfig { get; } = new();
    }
}