using UnityEngine;

namespace SpaceLander
{
    internal interface ICrashModel
    {
        AudioClip CrashSound { get; }
        float RandomForceMINX { get; }
        float RandomForceMAXX { get; }
        float RandomForceMINY { get; }
        float RandomForceMAXY { get; }
        float RandomTorqueForceMIN { get; }
        float RandomTorqueForceMAX { get; }
    }
}
