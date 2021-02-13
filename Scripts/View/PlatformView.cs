using UnityEngine;

namespace SpaceLander
{
    public sealed class PlatformView : MonoBehaviour
    {
        private IPlatformViewModel _platformViewModel;

        public void InitializeView(IPlatformViewModel platformViewModel)
        {
            _platformViewModel = platformViewModel;
            _platformViewModel.OnPlatformPositionReboot += SetPlace;
        }

        private void SetPlace(Vector3 vector)
        {
            transform.position = vector;
        }

        ~PlatformView()
        {
            _platformViewModel.OnPlatformPositionReboot -= SetPlace;
        }
    }
}
