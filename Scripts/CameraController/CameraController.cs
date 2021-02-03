using Data;
using UnityEngine;

namespace SpaceLander
{
    internal class CameraController : IInitialize, IExecute
    {
        private Transform _ship;
        private Camera _camera;
        private CameraMagnifier _cameraMagnifier;
        private CameraFocusLock _focusLock;
 
        public CameraController(Transform ship, CameraData data)
        {
            _camera = Camera.main;
            _ship = ship;
            _focusLock = new CameraFocusLock(false);
            _cameraMagnifier = new CameraMagnifier(data, _camera);
        }


        public void Initialize()
        {
             _cameraMagnifier.GetCameraStartSettings();
        }

        public void Execute(float deltaTime)
        {
            if (_focusLock.IsUnlock)
            {
                _cameraMagnifier.ExecuteFocus(deltaTime, _ship);
            }
        }

        public void StartNewLevel()
        {
            _focusLock.IsUnlock = false;
            _cameraMagnifier.ResetFocus();
        }
    }
}
