using UnityEngine;

namespace Platform
{
    internal class PlatformInitialize
    {
        private IPlatformFactory _factory;

        //TODO Move to StageData
        private const float PLATFORM_SIZE = 2.0f;
        private const float MIN_X = 0.0f;
        private const float MAX_X = 70.0f;

        public PlatformInitialize(IPlatformFactory factory)
        {
            _factory = factory;
        }

        public Transform CreatePlatform(float landPosition)
        {
            return _factory.CreatePlatform(PlatformPlaceGenerator(landPosition), PLATFORM_SIZE);
        }
        
        private Vector3 PlatformPlaceGenerator(float landPosition)
        {
            var positionX = Random.Range(MIN_X, MAX_X);
            var place = new Vector3(positionX, landPosition, 0.0f);
            return place;
        }
    }
}
