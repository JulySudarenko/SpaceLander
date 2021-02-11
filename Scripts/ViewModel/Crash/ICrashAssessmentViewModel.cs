using System;
using UnityEngine;

namespace SpaceLander
{
    internal interface ICrashAssessmentViewModel
    {
        event Action<Vector3, Vector3> OnCrash;
        event Action IsLose;
        void Crash();
    }
}
