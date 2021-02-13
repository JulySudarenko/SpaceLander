using UnityEngine;

namespace SpaceLander
{
    internal class ShipAudioPlayer : IInitialize
    {
        private AudioSource _audioSource;
        private ICrashAssessmentViewModel _crashViewModel;
        private ILandingAssessmentViewModel _landingViewModel;
        private IMoveViewModel _moveViewModel;

        public ShipAudioPlayer(AudioSource audioSource, IHitListener hitListener, IMoveViewModel moveViewModel)
        {
            _audioSource = audioSource;
            _crashViewModel = hitListener.CrashAssessment;
            _landingViewModel = hitListener.LandingAssessment;
            _moveViewModel = moveViewModel;
        }

        public void Initialize()
        {
            _crashViewModel.OnCrash += PlayCrashSound;
            _landingViewModel.IsWin += PlayWinSound;
            _moveViewModel.OnMovementChange += PlayThrusterSound;
            _moveViewModel.OnStopMove += StopThrusterSound;
        }

        private void PlayThrusterSound(Vector3 vector)
        {
            _audioSource.clip = _moveViewModel.ThrusterSound;
            _audioSource.Play();
        }

        private void PlayWinSound()
        {
            _audioSource.clip = _landingViewModel.WinSound;
            _audioSource.Play();
        }

        private void PlayCrashSound()
        {
            _audioSource.clip = _crashViewModel.CrashSound;
            _audioSource.Play();
        }

        private void StopThrusterSound(Vector3 vector)
        {
            if (_audioSource.clip == _moveViewModel.ThrusterSound)
            {
                _audioSource.Stop();
            }
        }
    }
}
