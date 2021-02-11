using System;

namespace SpaceLander
{
    public interface IFuelViewModel

    {
        bool HasFuel { get; }
        event Action<float> OnFuelChange;

        IFuelModel FuelModel { get; }

        void ConsumeFuelToRise(float deltaTime);

        void ConsumeFuelOnTorque(float deltaTime);
    }
}
