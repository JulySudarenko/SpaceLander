using UnityEngine;

namespace SpaceLander
{
    internal class CrashComponentEffectView : MonoBehaviour
    {
        [SerializeField] private FixedJoint[] _joint;
        [SerializeField] private Rigidbody _rigidbody;
        private ICrashAssessmentViewModel _viewModel;

        public void InitializeView(ICrashAssessmentViewModel crashViewModel)
        {
            _viewModel = crashViewModel;
            _viewModel.OnCrash += OnCrash;
        }

        private void OnCrash()
        {
            for (int j = 0; j < _joint.Length; j++)
            {
                Destroy(_joint[j]);
            }

            _rigidbody.AddForce(_viewModel.CollisionForce);
            _rigidbody.AddTorque(_viewModel.TorqueForce);
        }

        ~CrashComponentEffectView()
        {
            _viewModel.OnCrash -= OnCrash;
        }
    }
}
