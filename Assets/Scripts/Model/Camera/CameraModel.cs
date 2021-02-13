using UnityEngine;

namespace SpaceLander
{
    public class CameraModel : ICameraModel
    {
        public Transform CameraDefaultPosition { get; }
        public float CameraMoveSpeed { get; set; }
        public float CameraZoomLimit { get; }
        public float CameraZoomSpeed { get; }
        public float CameraDefaultSize { get; set; }

        public CameraModel(CameraData data)
        {
            CameraDefaultPosition = data.CameraDefaultPosition;
            CameraDefaultSize = data.CameraDefaultSize;
            CameraMoveSpeed = data.CameraMoveSpeed;
            CameraZoomLimit = data.CameraZoomLimit;
            CameraZoomSpeed = data.CameraDefaultSize;
        }
    }
}
