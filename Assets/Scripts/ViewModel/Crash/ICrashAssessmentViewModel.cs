using System;
using UnityEngine;

namespace SpaceLander
{
    internal interface ICrashAssessmentViewModel
    {
        event Action OnCrash;
        Vector3 CollisionForce { get; }
        Vector3 TorqueForce { get; }
        AudioClip CrashSound { get; }
        string CrashMessage { get; }
        void Crash();
        void AnalysisOfDamage(GameObject gameObject, float speed);
    }
}
