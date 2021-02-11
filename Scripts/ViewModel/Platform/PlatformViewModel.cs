using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceLander
{
    internal class PlatformViewModel : IPlatformViewModel
    {
        public event Action<Vector3> OnPlatformPositionReboot;
        public event Action<Vector3, float> OnPlatformSizeReboot;

        private IPlatformModel _platformModel;

        public PlatformViewModel(IPlatformModel model)
        {
            _platformModel = model;
        }

        public void RebootPlatform()
        {
            PlatformPlaceGenerator();
        }
            
        private void PlatformPlaceGenerator()
        {
            var positionX = Random.Range(_platformModel.MinX, _platformModel.MaxX);
            var place = new Vector3(positionX, _platformModel.LandPosition, 0.0f);
            OnPlatformPositionReboot?.Invoke(place);
        }

        private void ChangePlatformSize()
        {
            var scale = _platformModel.VectorScale;
            var vectorScale = new Vector3(_platformModel.Size, scale.y, scale.z);
            OnPlatformSizeReboot?.Invoke(vectorScale, _platformModel.Size);
        }
    }
}
