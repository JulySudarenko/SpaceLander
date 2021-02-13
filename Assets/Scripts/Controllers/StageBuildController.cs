
namespace SpaceLander
{
    internal class StageBuildController : IInitialize
    {
        private MoonSurface _moon;
        private PlatformInitialize _platformInitialize;
        private AudioMainThemePlayer _audioMainThemePlayer;

        public StageBuildController(StageData data)
        {
            _moon = new MoonSurface(data);
            IPlatformModel model = new PlatformModel(data, _moon.HeightOfThePlatformLocation);
            _platformInitialize = new PlatformInitialize(new PlatformFactory(data.PlatformParticles, model.Size), model);
            _audioMainThemePlayer = new AudioMainThemePlayer(data.MainMelody);
        }

        public void Initialize()
        {
            _moon.CreateSurface();
            _audioMainThemePlayer.PlayMainThemeClip();
            _platformInitialize.Initialize();
        }
    }
}
