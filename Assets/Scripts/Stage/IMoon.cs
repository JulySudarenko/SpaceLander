using UnityEngine;

namespace SpaceLander
{
    internal interface IMoon
    {
        GameObject LandScape { get; }
        Material MoonBackground { get; }
        float MoonGravity { get; }
    }
}
