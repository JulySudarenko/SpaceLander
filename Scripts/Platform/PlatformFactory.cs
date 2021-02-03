using UnityEngine;

namespace Factories
{
    public class PlatformFactory : IPlatformFactory
    {
        private GameObject _prefab;
        private Vector3 _scale;
  
        public PlatformFactory(GameObject platform)
        {
            _prefab = platform;
        }

        public Transform CreatePlatform(Vector3 position, float size)
        {
            var platform = Object.Instantiate(_prefab, position, Quaternion.identity);

            _scale = _prefab.transform.localScale;
            platform.transform.localScale = new Vector3(size, _scale.y, _scale.z);

            var platformShape = platform.GetComponentInChildren<ParticleSystem>().shape;
            platformShape.radius = size;

            return platform.transform;
        }
    }
}
