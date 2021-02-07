using Data;
using UnityEngine;

namespace SpaceLander.Model
{
    internal class CrashEffectModel
    {
        public ParticleSystem CrashSmoke { get; }
        public AudioClip CrashSound { get; }

        public CrashEffectModel(ShipData data)
        {
            CrashSmoke = data.CrashSmoke;
            CrashSound = data.CrashSound;
        }
    }
}
