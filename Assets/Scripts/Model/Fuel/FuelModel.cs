
namespace SpaceLander
{
    internal class FuelModel : IFuelModel
    {
        public float MaxFuel { get; }
        public float CurrentFuel { get; set; }
        public float TorqueFuelRate { get; }
        public float FuelRate { get; }

        public FuelModel(ShipData data)
        {
            MaxFuel = data.InitialFuelSupply;
            CurrentFuel = MaxFuel;
            TorqueFuelRate = data.TorqueRate;
            FuelRate = data.FuelRate;
        }
    }
}
