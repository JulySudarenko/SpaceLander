using UnityEngine;

namespace Ship
{
    internal class ShipFactory : IShipFactory
    {
        private GameObject _prefab;
  
        public ShipFactory(GameObject ship)
        {
            _prefab = ship;
        }

        public GameObject CreateShip()
        {
            var ship = Object.Instantiate(_prefab);
            return ship;
        }
    }
}
