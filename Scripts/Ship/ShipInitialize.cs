using Assistants;
using UnityEngine;

namespace SpaceLander
{
    internal class ShipInitialize
    {
        public GameObject Ship { get; }
        public Transform ShipTransform { get; }
        public ShipView ShipView { get; }
        public HitShipSystem HitShipSystem { get; }

        public CrashEffectView CrashEffectView { get; }

        public ShipInitialize(IShipFactory shipFactory)
        {
            Ship = shipFactory.CreateShip();
            ShipTransform = Ship.transform;
            ShipView = Ship.GetOrAddComponent<ShipView>();
            HitShipSystem = Ship.GetOrAddComponent<HitShipSystem>();
            CrashEffectView = Ship.GetOrAddComponent<CrashEffectView>();
        }
    }
}
