using UnityEngine;

namespace SpaceLander
{
    internal class EndGameMessageView : MonoBehaviour
    {
        [SerializeField] private GameObject _messageBox;
        private ICrashAssessmentViewModel _crashViewModel;
        private ILandingAssessmentViewModel _landingViewModel;

        public void InitializeView(ICrashAssessmentViewModel crash, ILandingAssessmentViewModel win)
        {
            _crashViewModel = crash;
            _landingViewModel = win;
            _crashViewModel.IsLose += ShowTitle;
            _landingViewModel.IsWin += ShowTitle;
        }

        private void ShowTitle()
        {
            _messageBox.SetActive(true);
        }

        private void HideTitle()
        {
            _messageBox.SetActive(true);
        }

        ~EndGameMessageView()
        {
            _crashViewModel.IsLose -= ShowTitle;
            _landingViewModel.IsWin -= ShowTitle;
        }
    }
}
