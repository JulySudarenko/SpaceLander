using System;
using UnityEngine;

namespace SpaceLander
{
    public interface IPlatformViewModel
    {
        event Action<Vector3> OnPlatformPositionReboot;
        event Action<Vector3, float> OnPlatformSizeReboot;
        void RebootPlatform();
    }
}
