using UnityEngine;

namespace SpaceLander
{
    internal interface IWinModel
    {
        AudioClip WinSound { get; }
        string WinMessage { get; }
        float WinTimeOnPlatform { get; }
        float ValidTimeOnPlatform { get; set; }
        float LandingWinAngleMin { get; }
        float LandingWinAngleMax { get; }
    }
}
