using UnityEngine;

namespace SpaceLander
{
    internal class PlatformModel : IPlatformModel
    {
        public Vector3 VectorScale { get; }
        public float LandPosition { get; }
        public float Size { get; }
        public float MinX { get; }
        public float MaxX { get; }

        public PlatformModel(StageData data, Vector3 vector, float landPosition)
        {
            VectorScale = vector;
            LandPosition = landPosition;
            Size = data.PlatformSize;
            MinX = data.PlatformPlaceMinX;
            MaxX = data.PlatformPlaceMaxX;
        }
    }
}
