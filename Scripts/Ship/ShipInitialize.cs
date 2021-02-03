using UnityEngine;

namespace Ship
{
    internal class ShipInitialize
    {
        private IShipFactory _shipFactory;

        public ShipInitialize(IShipFactory shipFactory)
        {
            _shipFactory = shipFactory;
        }

        public Transform ShipTransform()
        {
            return _shipFactory.CreateShip().transform;
        }
    }
}
