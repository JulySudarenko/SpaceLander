using UnityEngine;

namespace SpaceLander.Model
{
    internal interface IForceModel
    {
        ConstantForce ShipConstantForce { get; set; }
        ParticleSystem Thruster { get; }
        AudioClip ThrusterSound { get; }
        float ForceRate { get; }
        float TorqueRate { get; }
    }
}
