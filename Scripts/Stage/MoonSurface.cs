using UnityEngine;

namespace Stage
{
    internal class MoonSurface
    {
        private IMoon _data;

        public MoonSurface(IMoon data)
        {
            _data = data;
        }

        public float HeightOfThePlatformLocation => _data.LandScape.transform.localScale.y / 2;

        public void CreateSurface()
        {
               CreatePlanet();
               CreateGround();
        }


        private void CreatePlanet()
        {
            RenderSettings.skybox = _data.MoonBackground;
            Physics.gravity = new Vector3(0.0f, _data.MoonGravity, 0.0f);
        }
        
        private void CreateGround()
        {
            var ground = Object.Instantiate(_data.LandScape);
        }
    }
}
