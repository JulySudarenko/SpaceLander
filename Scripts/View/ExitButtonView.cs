using UnityEngine;
using UnityEngine.UI;

namespace SpaceLander
{
    internal class ExitButtonView : MonoBehaviour
    {
        [SerializeField] private Button _exitBtn;
        private ICrashAssessmentViewModel _crashViewModel;
        private ILandingAssessmentViewModel _landingViewModel;

        public void InitializeView(ICrashAssessmentViewModel crash, ILandingAssessmentViewModel win, IGameManager gameManager)
        {
            _crashViewModel = crash;
            _landingViewModel = win;
            _crashViewModel.IsLose += ShowTitle;
            _landingViewModel.IsWin += ShowTitle;
            _exitBtn.onClick.AddListener(gameManager.ExitGame);
        }

        private void ShowTitle()
        {
            _exitBtn.gameObject.SetActive(true);
        }

        private void HideTitle()
        {
            _exitBtn.gameObject.SetActive(false);
        }

        ~ExitButtonView()
        {
            _crashViewModel.IsLose -= ShowTitle;
            _landingViewModel.IsWin -= ShowTitle;
        }
    }

}
