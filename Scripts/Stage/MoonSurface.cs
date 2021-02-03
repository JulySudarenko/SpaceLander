using Data;
using UnityEngine;

namespace SpaceLander
{
    internal class MoonSurface
    {
        private Material _sky;
        private GameObject _land;
        private float _gravity;

        public MoonSurface(StageData data)
        {
            _sky = data.MoonBackground;
            _gravity = data.MoonGravity;
            _land = data.LandScape;
        }

        public void CreateSurface()
        {
            RenderSettings.skybox = _sky;
            Physics.gravity = new Vector3(0, _gravity, 0);
        }
    }
}
