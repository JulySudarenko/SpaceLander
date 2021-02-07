using Data;
using Platform;
using Stage;
using UnityEngine;

namespace SpaceLander
{
    internal class StageBuildController : IInitialize
    {
        private MoonSurface _moon;
        private PlatformInitialize _platformInitialize;
        private AudioMainThemePlayer _audioMainThemePlayer;
        private Transform _platform;
 

        public StageBuildController(StageData data)
        {
            _moon = new MoonSurface(data);
            _platformInitialize = new PlatformInitialize(new PlatformFactory(data.PlatformParticles));
            _audioMainThemePlayer = new AudioMainThemePlayer(data.MainMelody);
        }

        public void Initialize()
        {
            _moon.CreateSurface();
            _platform = _platformInitialize.CreatePlatform(_moon.HeightOfThePlatformLocation);
            _audioMainThemePlayer.PlayMainThemeClip();
        }
    }
}
