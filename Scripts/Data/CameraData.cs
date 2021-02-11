using UnityEngine;

namespace SpaceLander
{
    [CreateAssetMenu(fileName = "Camera", menuName = "Data/Camera", order = 0)]
    public class CameraData : ScriptableObject
    {
        public Transform CameraDefaultPosition;

        [SerializeField] private float _cameraDefaultSize;
        [SerializeField] private float _cameraMoveSpeed;
        [SerializeField] private float _cameraZoomSpeed;
        [SerializeField] private float _cameraZoomLimit;

        public float CameraMoveSpeed => _cameraMoveSpeed;

        public float CameraZoomLimit => _cameraZoomLimit;

        public float CameraZoomSpeed => _cameraZoomSpeed;

        public float CameraDefaultSize => _cameraDefaultSize;
    }
}
