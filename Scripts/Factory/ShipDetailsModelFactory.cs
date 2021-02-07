using Data;
using SpaceLander.Model;
using UnityEngine;

namespace SpaceLander
{
    internal class ShipDetailsModelFactory
    {
        private IFuelModel _fuelModel;
        private IForceModel _forceModel;

        public ShipDetailsModelFactory(GameObject ship, ShipData data)
        {
            _fuelModel = new FuelModel(data);
            _forceModel = new ForceModel(ship, data);
        }

        public IFuelModel FuelModel => _fuelModel;

        public IForceModel ForceModel => _forceModel;
    }
}
