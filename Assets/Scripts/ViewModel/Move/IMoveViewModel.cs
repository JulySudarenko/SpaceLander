using System;
using UnityEngine;

namespace SpaceLander
{
    public interface IMoveViewModel
    {
        event Action<Vector3> OnMovementChange;
        event Action<Vector3> OnRotateChange;
        event Action<Vector3> OnStopMove;
        AudioClip ThrusterSound { get; }
    }
}
