
namespace SpaceLander
{
    internal class PlatformInitialize
    {
        private IPlatformFactory _factory;
        private PlatformView _platformView;
        private IPlatformViewModel _platformViewModel;

        public PlatformInitialize(IPlatformFactory factory, IPlatformModel model)
        {
            _factory = factory;
            var platform = _factory.CreatePlatform();
            _platformView = platform.GetComponent<PlatformView>();
            _platformViewModel = new PlatformViewModel(model);
        }

        public void Initialize()
        {
            _platformView.InitializeView(_platformViewModel);
            _platformViewModel.RebootPlatform();
        }
    }
}
