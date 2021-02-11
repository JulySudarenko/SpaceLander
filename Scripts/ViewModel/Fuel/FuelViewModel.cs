using System;
using UnityEngine;

namespace SpaceLander
{
    public sealed class FuelViewModel : IFuelViewModel
    {
        private bool _hasFuel;
        public event Action<float> OnFuelChange;
        public IFuelModel FuelModel { get; }

        public bool HasFuel => _hasFuel;

        public FuelViewModel(IFuelModel fuelModel)
        {
            FuelModel = fuelModel;
            _hasFuel = true;
        }

        public void ConsumeFuelToRise(float deltaTime)
        {
            FuelModel.CurrentFuel += FuelModel.FuelRate * deltaTime;
            CheckFuelValue();
        }

        public void ConsumeFuelOnTorque(float deltaTime)
        {
            FuelModel.CurrentFuel += FuelModel.FuelRate / FuelModel.TorqueFuelRate * deltaTime;
            CheckFuelValue();
        }

        private void CheckFuelValue()
        {
            if (FuelModel.CurrentFuel <= 0)
            {
                _hasFuel = false;
                FuelModel.CurrentFuel = 0f;
            }
            OnFuelChange?.Invoke(Mathf.Round(FuelModel.CurrentFuel));
        }
    }
}
