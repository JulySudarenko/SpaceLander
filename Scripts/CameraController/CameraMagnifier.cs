using Data;
using UnityEngine;

namespace SpaceLander
{
    internal class CameraMagnifier
    {
        private Camera _camera;
        private Vector3 _defaultPosition;
        private float _defaultSize;
        private float _moveSpeed;
        private float _zoomSpeed;
        private float _zoomLimit;
        
        public CameraMagnifier(CameraData data, Camera camera)
        {
            _camera = camera;
            _moveSpeed = data.CameraMoveSpeed;
            _zoomSpeed = data.CameraZoomSpeed;
            _zoomLimit = data.CameraZoomLimit;
        }

        public void GetCameraStartSettings()
        {
            _defaultPosition = _camera.transform.position;
            _defaultSize = _camera.orthographicSize;
        }
        
        public void ExecuteFocus(float deltaTime, Transform ship)
        {
            float size = _camera.orthographicSize;
            float sizeDiff = size - _zoomLimit;

            Vector3 landerOffset = ship.transform.position - _camera.transform.position;
            landerOffset.Set(landerOffset.x, landerOffset.y, 0f);

            float time = sizeDiff / _zoomSpeed;
            if (time > 0)
            {
                _moveSpeed = landerOffset.magnitude / time;
            }


            if (size > _zoomLimit)
            {
                _camera.orthographicSize -= _zoomSpeed * deltaTime;
            }


            if (landerOffset.magnitude < _moveSpeed * deltaTime)
            {
                _camera.transform.position += landerOffset;
            }
            else
            {
                landerOffset.Normalize();
                _camera.transform.position += landerOffset * _moveSpeed * deltaTime;
            }
        }

        public void ResetFocus()
        {
            _camera.transform.position = _defaultPosition;
            _camera.orthographicSize = _defaultSize;
        }
    }
}
