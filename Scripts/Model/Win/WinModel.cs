using UnityEngine;

namespace SpaceLander
{
    internal class WinModel : IWinModel
    {
        public AudioClip WinSound { get; }
        public float WinTimeOnPlatform { get; }
        public float ValidTimeOnPlatform { get; set; }
        public float MinAngle { get; }
        public float MaxAngle { get; }


        public WinModel(ShipData data)
        {
            WinSound = data.LandSuccessSound;
            WinTimeOnPlatform = data.WinTimeOnPlatform;
            ValidTimeOnPlatform = 0.0f;
        }
    }
}
