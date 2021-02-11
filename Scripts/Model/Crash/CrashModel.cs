using UnityEngine;

namespace SpaceLander
{
    internal class CrashModel : ICrashModel
    {
        public AudioClip CrashSound { get; }

        public float RandomForceMINX { get; }
        public float RandomForceMAXX { get; }
        public float RandomForceMINY { get; }
        public float RandomForceMAXY { get; }
        public float RandomTorqueForceMIN { get; }
        public float RandomTorqueForceMAX { get; }

        public CrashModel(ShipData data)
        {
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
