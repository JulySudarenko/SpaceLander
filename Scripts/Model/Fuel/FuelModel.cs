using Data;

namespace SpaceLander.Model
{
    internal class FuelModel : IFuelModel
    {
        public float MaxFuel { get; }
        public float CurrentFuel { get; set; }
        public float FuelRate { get; }

        public FuelModel(ShipData data)
        {
            MaxFuel = data.InitialFuelSupply;
            CurrentFuel = MaxFuel;
            FuelRate = data.FuelRate;
        }
    }
}
