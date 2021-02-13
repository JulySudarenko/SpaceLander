
namespace SpaceLander
{
    internal class PlatformModel : IPlatformModel
    {
        public float LandPosition { get; }
        public float Size { get; }
        public float MinX { get; }
        public float MaxX { get; }

        public PlatformModel(StageData data, float landPosition)
        {
            LandPosition = landPosition;
            Size = data.PlatformSize;
            MinX = data.PlatformPlaceMinX;
            MaxX = data.PlatformPlaceMaxX;
        }
    }
}
