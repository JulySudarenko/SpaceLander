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

        private void OnCrash()
        {
            CrashSmoke.Play();
        }

        ~CrashEffectView()
        {
            _viewModel.OnCrash -= OnCrash;
        }
    }
}
