using UnityEngine;

namespace SpaceLander
{
    public sealed class PlatformView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _platformParticle;
        [SerializeField] private Transform _platform;
        private ParticleSystem _particle;
        private IPlatformViewModel _platformViewModel;

        public void InitializeView(IPlatformViewModel platformViewModel, ParticleSystem particleSystem)
        {
            _platformViewModel = platformViewModel;
            _particle = particleSystem;
            _platformViewModel.OnPlatformPositionReboot += SetPlace;
            _platformViewModel.OnPlatformSizeReboot += SetSize;
        }

        private void SetPlace(Vector3 vector)
        {
            transform.position = vector;
        }

        private void SetSize(Vector3 vectorScale, float size)
        {
            // var particleShape = _particle.shape;
            // particleShape.radius = size;
            // _particle.transform.localScale = vectorScale;
            var platformParticleShape = _platformParticle.shape;
            platformParticleShape.radius = size;
            _platform.localScale = vectorScale;

        }

        ~PlatformView()
        {
            _platformViewModel.OnPlatformPositionReboot -= SetPlace;
            _platformViewModel.OnPlatformSizeReboot -= SetSize;
        }
    }
}
