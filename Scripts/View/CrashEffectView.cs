using UnityEngine;

namespace SpaceLander
{
    internal class CrashEffectView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem CrashSmoke;
        private ICrashAssessmentViewModel _viewModel;

        public void InitializeView(ICrashAssessmentViewModel crashViewModel)
        {
            _viewModel = crashViewModel;
            _viewModel.OnCrash += OnCrash;

        }

        private void OnCrash(Vector3 collisionForce, Vector3 torqueForce)
        {
            CrashSmoke.Play();
            

            // for (int i = 0; i < _rigidbody.Length; i++)
            // {
            //     _rigidbody[i].AddForce(collisionForce);
            //     _rigidbody[i].AddTorque(torqueForce);
            // }
        }

        ~CrashEffectView()
        {
            _viewModel.OnCrash -= OnCrash;
        }
    }
}
