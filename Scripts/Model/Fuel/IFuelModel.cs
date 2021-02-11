namespace SpaceLander
{
    public interface IFuelModel
    {
        float MaxFuel { get; }
        float CurrentFuel { get; set; }
        float TorqueFuelRate { get; }
        float FuelRate { get; }
    }
}
