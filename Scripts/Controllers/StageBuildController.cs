
namespace SpaceLander
{
    internal class StageBuildController : IInitialize, IReboot
    {
        private MoonSurface _moon;
        private PlatformInitialize _platformInitialize;
        private AudioMainThemePlayer _audioMainThemePlayer;

        public StageBuildController(StageData data)
        {
            _moon = new MoonSurface(data);
            _platformInitialize = new PlatformInitialize(new PlatformFactory(data.PlatformParticles, data.PlatformSize), data, _moon.HeightOfThePlatformLocation);
            _audioMainThemePlayer = new AudioMainThemePlayer(data.MainMelody);
        }

        public void Initialize()
        {
            _moon.CreateSurface();
            _audioMainThemePlayer.PlayMainThemeClip();
            _platformInitialize.Initialize();
        }

        public void RebootLevel()
        {
             _platformInitialize.RebootPlatform();
        }
    }
}
