namespace SpaceLander.Model
{
    public interface IFuelModel
    {
        float MaxFuel { get; }
        float CurrentFuel { get; set; }
        float FuelRate { get; }
    }
}
