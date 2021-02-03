using UnityEngine;

namespace Factories
{
    internal interface IPlatformFactory
    {
        Transform CreatePlatform(Vector3 position, float size);
    }
}
