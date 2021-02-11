using Assistants;
using UnityEngine;

namespace SpaceLander
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
            ship.GetOrAddComponent<HitShipSystem>();
            return ship;
        }
    }
}
