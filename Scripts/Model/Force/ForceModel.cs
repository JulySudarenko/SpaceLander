using UnityEngine;

namespace SpaceLander
{
    internal class ForceModel : IForceModel
    {
        public float ForceRate { get; }
        public float TorqueRate { get; }

        public ForceModel(ShipData data)
        {
            ForceRate = data.ForceRate;
            TorqueRate = data.TorqueRate;
        }
    }
}
