using UnityEngine;

namespace SpaceLander
{
    internal interface ICameraModel
    {
        Transform CameraDefaultPosition { get; }
        float CameraMoveSpeed { get; set; }
        float CameraZoomLimit { get; }
        float CameraZoomSpeed { get; }
        float CameraDefaultSize { get; set; }
    }
}
