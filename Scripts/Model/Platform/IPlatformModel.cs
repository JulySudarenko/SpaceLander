using UnityEngine;

namespace SpaceLander
{
    public interface IPlatformModel
    {
        Vector3 VectorScale { get; }
        float LandPosition { get; }
        float Size { get; }
        float MinX { get; }
        float MaxX { get; }
    }
}
