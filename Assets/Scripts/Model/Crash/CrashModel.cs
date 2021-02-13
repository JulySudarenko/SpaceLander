using UnityEngine;

namespace SpaceLander
{
    internal class CrashModel : ICrashModel
    {
        public AudioClip CrashSound { get; }
        public string CrashMessage { get; }
        public float LandingCrashSpeed { get; }
        public float CrashAngleMin { get; }
        public float CrashAngleMax { get; }
        public float RandomForceMINX { get; }
        public float RandomForceMAXX { get; }
        public float RandomForceMINY { get; }
        public float RandomForceMAXY { get; }
        public float RandomTorqueForceMIN { get; }
        public float RandomTorqueForceMAX { get; }

        public CrashModel(ShipData data)
        {
            CrashMessage = data.CrashMessage;
            LandingCrashSpeed = data.LandingCrashSpeed;
            CrashAngleMin = data.CrashAngleMin;
            CrashAngleMax = data.CrashAngleMax;
            RandomForceMINX = data.RandomForceMinX;
            RandomForceMAXX = data.RandomForceMaxX;
            RandomForceMINY = data.RandomForceMinY;
            RandomForceMAXY = data.RandomForceMaxY;
            RandomTorqueForceMIN = data.RandomTorqueForceMIN;
            RandomTorqueForceMAX = data.RandomTorqueForceMAX;
            CrashSound = data.CrashSound;
        }
    }
}
