using UnityEngine;
using UnityEngine.UI;

namespace SpaceLander
{
    internal class EndGameMessageView : MonoBehaviour
    {
        [SerializeField] private GameObject _messageBox;
        [SerializeField] private Text _messageText;
        private ICrashAssessmentViewModel _crashViewModel;
        private ILandingAssessmentViewModel _landingViewModel;

        public void InitializeView(ICrashAssessmentViewModel crash, ILandingAssessmentViewModel win)
        {
            _crashViewModel = crash;
            _landingViewModel = win;
            _crashViewModel.OnCrash += ShowCrashTitle;
            _landingViewModel.IsWin += ShowWinTitle;
        }

        private void ShowWinTitle()
        {
            _messageBox.SetActive(true);
            _messageText.text = _landingViewModel.WinMessage;
        }

        private void ShowCrashTitle()
        {
            _messageBox.SetActive(true);
            _messageText.text = _crashViewModel.CrashMessage;
        }

        ~EndGameMessageView()
        {
            _crashViewModel.OnCrash -= ShowCrashTitle;
            _landingViewModel.IsWin -= ShowWinTitle;
        }
    }
}
