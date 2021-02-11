using UnityEngine;

namespace SpaceLander
{
    internal class CameraController : IInitialize, IExecute, IReboot, ICleanup
    {
        private Camera _camera;
        private CameraMagnifier _cameraMagnifier;
        private CameraFocusLock _focusLock;
        private ICrashAssessmentViewModel _crash;
        private ILandingAssessmentViewModel _win;

        public CameraController(Transform ship, CameraData data, ICrashAssessmentViewModel crash, ILandingAssessmentViewModel win)
        {
            _camera = Camera.main;
            _focusLock = new CameraFocusLock(false);
            _cameraMagnifier = new CameraMagnifier(new CameraModel(data), _camera, ship);
            _win = win;
            _crash = crash;
        }

        public void Initialize()
        {
            _cameraMagnifier.GetCameraStartSettings();
            _win.IsWin += UnlockCameraMagnifier;
            _crash.IsLose += UnlockCameraMagnifier;
        }

        public void Execute(float deltaTime)
        {
            if (_focusLock.IsUnlock)
            {
                _cameraMagnifier.ExecuteFocus(deltaTime);
            }
        }

        public void RebootLevel()
        {
            _focusLock.IsUnlock = false;
            _cameraMagnifier.ResetFocus();
        }

        public void UnlockCameraMagnifier()
        {
            _focusLock.IsUnlock = true;
        }

        public void Cleanup()
        {
            _win.IsWin -= UnlockCameraMagnifier;
            _crash.IsLose -= UnlockCameraMagnifier;
        }
    }
}
