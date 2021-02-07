using UnityEngine;

namespace Platform
{
    internal interface IPlatformFactory
    {
        Transform CreatePlatform(Vector3 position, float size);
    }
}
