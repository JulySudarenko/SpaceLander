using Data;
using UnityEngine;

namespace SpaceLander.Model
{
    internal class WinCharacteristicsModel
    {
        public float ValidTimeOnPlatform { get; }
        public AudioClip WinSound { get; }

        public WinCharacteristicsModel(ShipData data)
        {
            ValidTimeOnPlatform = data.ValidTimeOnPlatform;
            WinSound = data.LandSuccessSound;
        }
    }
}
