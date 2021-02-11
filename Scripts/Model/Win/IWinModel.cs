using UnityEngine;

namespace SpaceLander
{
    internal interface IWinModel
    {
        AudioClip WinSound { get; }
        float WinTimeOnPlatform { get; }
        float ValidTimeOnPlatform { get; set; }
        float MinAngle { get; }
        float MaxAngle { get; }
    }
}
