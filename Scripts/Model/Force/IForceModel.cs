
using UnityEngine;

namespace SpaceLander
{
    internal interface IForceModel
    {
        AudioClip ThrusterSound { get; }
        float ForceRate { get; }
        float TorqueRate { get; }
    }
}
