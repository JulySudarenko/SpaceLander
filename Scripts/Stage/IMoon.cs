using UnityEngine;

namespace Stage
{
    internal interface IMoon
    {
        GameObject LandScape { get; }
        Material MoonBackground { get; }
        float MoonGravity { get; }
    }
}
