using UnityEngine;

namespace SpaceLander
{
    internal class CameraMagnifier
    {
        private Camera _camera;
        private ICameraModel _model;
        private Transform _ship;
        
        public CameraMagnifier(ICameraModel model, Camera camera, Transform ship)
        {
            _model = model;
            _camera = camera;
            _ship = ship;
        }
        
        public void GetCameraStartSettings()
        {
            _model.CameraDefaultPosition.position = _camera.transform.position;
            _model.CameraDefaultSize = _camera.orthographicSize;
        }
        
        public void ExecuteFocus(float deltaTime)
        {
            Debug.Log("Camera change focus");
            float size = _camera.orthographicSize;
            float sizeDiff = size - _model.CameraZoomLimit;
            
            Vector3 landerOffset = _ship.transform.position - _camera.transform.position;
            landerOffset.Set(landerOffset.x, landerOffset.y, 0f);
            
            float time = sizeDiff / _model.CameraZoomSpeed;
            if (time > 0)
            {
                _model.CameraMoveSpeed = landerOffset.magnitude / time;
            }
            
            
            if (size > _model.CameraZoomLimit)
            {
                _camera.orthographicSize -= _model.CameraZoomSpeed * deltaTime;
            }
            
            
            if (landerOffset.magnitude < _model.CameraMoveSpeed * deltaTime)
            {
                _camera.transform.position += landerOffset;
            }
            else
            {
                landerOffset.Normalize();
                _camera.transform.position += landerOffset * _model.CameraMoveSpeed * deltaTime;
            }
        }

        public void ResetFocus()
        {
            _camera.transform.position = _model.CameraDefaultPosition.position;
            _camera.orthographicSize = _model.CameraDefaultSize;
        }
    }
}
