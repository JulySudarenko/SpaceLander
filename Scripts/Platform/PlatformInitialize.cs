using UnityEngine;

namespace SpaceLander
{
    internal class PlatformInitialize
    {
        private IPlatformFactory _factory;
        private PlatformView _platformView;
        private ParticleSystem _particle;
        private IPlatformViewModel _platformViewModel;

        public PlatformInitialize(IPlatformFactory factory, StageData data, float landPosition)
        {
            _factory = factory;
            var platform = _factory.CreatePlatform();
            _particle = platform.GetComponentInChildren<ParticleSystem>();
            var model = new PlatformModel(data, platform.localScale, landPosition);
            _platformView = platform.GetComponent<PlatformView>();
            _platformViewModel = new PlatformViewModel(model);
        }

        public void Initialize()
        {
            // var particleShape = _particle.shape;
            // particleShape.radius = 2f;
            _platformView.InitializeView(_platformViewModel, _particle);
            _platformViewModel.RebootPlatform();
        }
        
        public void RebootPlatform()
        {
            _platformViewModel.RebootPlatform();
        }
    }
}
