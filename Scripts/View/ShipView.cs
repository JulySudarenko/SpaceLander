using UnityEngine;

namespace SpaceLander
{
    public sealed class ShipView : MonoBehaviour
    {
        [SerializeField] private ConstantForce _shipConstantForce;
        [SerializeField] private ParticleSystem _thruster;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _thrusterSound;
        private IMoveViewModel _moveViewModel;

        public void InitializeView(IMoveViewModel moveViewModel)
        {
            _moveViewModel = moveViewModel;
            _moveViewModel.OnMovementChange += MoveUp;
            _moveViewModel.OnRotateChange += Rotate;
            _moveViewModel.OnStopMove += OnStop;
            _audioSource.clip = _thrusterSound;
            _audioSource.Play();
        }

        private void MoveUp(Vector3 vector)
        {
            _shipConstantForce.force = transform.rotation * vector;
            PlayThrusterView();
        }

        private void OnStop(Vector3 vector)
        {
            _shipConstantForce.force = vector;
            StopThrusterView();
        }

        private void Rotate(Vector3 vector)
        {
            _shipConstantForce.torque = vector;
        }

        private void PlayThrusterView()
        {
            _thruster.Play();
            _audioSource.clip = _thrusterSound;
            _audioSource.Play();
        }

        private void StopThrusterView()
        {
            _thruster.Stop();
            if (_audioSource.clip == _thrusterSound)
            {
                _audioSource.Stop();
            }
        }
        
        ~ShipView()
        {
            _moveViewModel.OnMovementChange -= MoveUp;
            _moveViewModel.OnRotateChange -= Rotate;
            _moveViewModel.OnStopMove -= OnStop;
        }
    }
}
