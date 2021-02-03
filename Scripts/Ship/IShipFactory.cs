using UnityEngine;

namespace Ship
{
    internal interface IShipFactory
    {
        GameObject CreateShip();
    }
}
