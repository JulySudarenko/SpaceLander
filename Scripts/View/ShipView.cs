using UnityEngine;

namespace SpaceLander
{
    public sealed class ShipView : MonoBehaviour
    {
        [SerializeField] private ConstantForce _shipConstantForce;
        [SerializeField] private ParticleSystem _thruster;
        private IMoveViewModel _moveViewModel;

        public void InitializeView(IMoveViewModel moveViewModel)
        {
            _moveViewModel = moveViewModel;
            _moveViewModel.OnMovementChange += MoveUp;
            _moveViewModel.OnRotateChange += Rotate;
            _moveViewModel.OnStopMove += OnStop;
        }

        private void MoveUp(Vector3 vector)
        {
            _shipConstantForce.force = vector;
            _thruster.Play();
        }

        private void OnStop(Vector3 vector)
        {
            _shipConstantForce.force = vector;
            _thruster.Stop();
        }

        private void Rotate(Vector3 vector)
        {
            _shipConstantForce.torque = vector;
        }
  
        ~ShipView()
        {
            _moveViewModel.OnMovementChange -= MoveUp;
            _moveViewModel.OnRotateChange -= Rotate;
            _moveViewModel.OnStopMove -= OnStop;
        }
    }
}
