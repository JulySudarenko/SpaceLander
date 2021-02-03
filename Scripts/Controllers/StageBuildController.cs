using Data;
using Factories;
using UnityEngine;

namespace SpaceLander
{
    internal class StageBuildController : IInitialize
    {
        private MoonSurface _moon;
        private PlatformFactory _platformFactory;
        private StageData _data;
        private GameObject _ground;
        private float _platformSize = 2.0f;

        public StageBuildController(StageData data)
        {
            _moon = new MoonSurface(data);
            _platformFactory = new PlatformFactory(data.PlatformParticles);
            _data = data;
        }

        public void Initialize()
        {
            _moon.CreateSurface();
            CreateGround();
            _platformFactory.CreatePlatform(new Vector3(10f, 3f, 0f), 2f);
        }

        public GameObject CreateGround()
        {
            var ground = Object.Instantiate(_data.LandScape);
            return ground;
        }

        public Vector3 PlatformPlaceGenerator()
        {
            float positionY = _ground.transform.localScale.y / 2;
            float positionX = Random.Range(0, 70);
            var place = new Vector3(positionX, positionY, 0.0f);
            return place;
        }
    }
}
