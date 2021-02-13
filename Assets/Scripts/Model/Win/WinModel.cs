using UnityEngine;

namespace SpaceLander
{
    internal class WinModel : IWinModel
    {
        public AudioClip WinSound { get; }
        public  string WinMessage { get; }
        public float WinTimeOnPlatform { get; }
        public float ValidTimeOnPlatform { get; set; }
        public float LandingWinAngleMin { get; }
        public float LandingWinAngleMax { get; }

        public WinModel(ShipData data)
        {
            WinSound = data.LandSuccessSound;
            WinMessage = data.WinMessage;
            WinTimeOnPlatform = data.WinTimeOnPlatform;
            ValidTimeOnPlatform = 0.0f;
            LandingWinAngleMin = data.LandingWinAngleMin;
            LandingWinAngleMax = data.LandingWinAngleMax;
        }
    }
}
