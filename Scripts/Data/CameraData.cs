using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Camera", menuName = "Data/Camera", order = 0)]
    public class CameraData : ScriptableObject
    {
        public Transform CameraDefaultPosition;

        public float CameraDefaultSize { get; }
        public float CameraMoveSpeed { get; }
        public float CameraZoomSpeed { get; }
        public float CameraZoomLimit { get; }
    }
}
