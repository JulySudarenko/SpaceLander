using UnityEngine;

namespace SpaceLander
{
    internal sealed class AudioMainThemePlayer
    {
        private const string AUDIO = "AudioPlayer";
        private readonly AudioClip _mainClip;
        
        public AudioMainThemePlayer(AudioClip clip)
        {
            _mainClip = clip;
        }
        
        public void PlayMainThemeClip()
        {
            var mainAudioThemePlayer = new GameObject(AUDIO);
            var audio = mainAudioThemePlayer.AddComponent<AudioSource>();
            audio.clip = _mainClip;
            audio.Play();
        }
    }
}
