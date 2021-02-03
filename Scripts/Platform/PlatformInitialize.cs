using UnityEngine;

namespace Factories
{
    internal class PlatformInitialize
    {
        private IPlatformFactory _factory;

        public PlatformInitialize(IPlatformFactory factory)
        {
            _factory = factory;
        }

        public Transform CreatePlatform(Vector3 position, float size)
        {
            return _factory.CreatePlatform(position, size);
        }
    }

    internal class PlatformPool
    {
        
    }
}
