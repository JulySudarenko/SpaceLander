using Assistants;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SpaceLander
{
    public class PlatformFactory : IPlatformFactory
    {
        private Transform _prefab;
        private float _size;

        public PlatformFactory(Transform platform, float size)
        {
            _prefab = platform;
            _size = size;
        }

        public Transform CreatePlatform()
        {
            var platform = Object.Instantiate(_prefab);
            var shapeModule = platform.GetComponentInChildren<ParticleSystem>().shape;
            shapeModule.radius = _size;
            platform.name = NameManager.NAME_PLATFORM;
            return platform.transform;
        }
    }
}
