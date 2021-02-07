using Data;
using UnityEngine;

namespace SpaceLander.Model
{
    internal class ForceModel : IForceModel
    {
        public ConstantForce ShipConstantForce { get; set; }
        public ParticleSystem Thruster { get; }
        public AudioClip ThrusterSound { get; }
        public float ForceRate { get; }
        public float TorqueRate { get; }

        public ForceModel(GameObject ship, ShipData data)
        {
            if (ship.TryGetComponent(typeof(ConstantForce), out var constForce))
            {
                ShipConstantForce = constForce as ConstantForce;
            }

            Thruster = ship.GetComponentInChildren<ParticleSystem>();

            ThrusterSound = data.ThrusterSound;
            ForceRate = data.ForceRate;
            TorqueRate = data.TorqueRate;
        }
    }
}
