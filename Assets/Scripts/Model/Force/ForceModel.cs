using UnityEngine;

namespace SpaceLander
{
    internal class ForceModel : IForceModel
    {
        public AudioClip ThrusterSound { get; }
        public float ForceRate { get; }
        public float TorqueRate { get; }

        public ForceModel(ShipData data)
        {
            ThrusterSound = data.ThrusterSound;
            ForceRate = data.ForceRate;
            TorqueRate = data.TorqueRate;
        }
    }
}
