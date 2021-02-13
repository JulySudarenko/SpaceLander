using UnityEngine;
using UnityEngine.UI;

namespace SpaceLander
{
    internal class ExitButtonView : MonoBehaviour
    {
        [SerializeField] private Button _exitBtn;
        private ICrashAssessmentViewModel _crashViewModel;
        private ILandingAssessmentViewModel _landingViewModel;

        public void InitializeView(ICrashAssessmentViewModel crash, ILandingAssessmentViewModel win,
            IGameManager gameManager)
        {
            _crashViewModel = crash;
            _landingViewModel = win;
            _crashViewModel.OnCrash += ShowButton;
            _landingViewModel.IsWin += ShowButton;
            _exitBtn.onClick.AddListener(gameManager.ExitGame);
        }

        private void ShowButton()
        {
            _exitBtn.gameObject.SetActive(true);
        }

        ~ExitButtonView()
        {
            _crashViewModel.OnCrash -= ShowButton;
            _landingViewModel.IsWin -= ShowButton;
        }
    }
}
