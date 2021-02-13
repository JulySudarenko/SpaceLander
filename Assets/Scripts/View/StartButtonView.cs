using UnityEngine;
using UnityEngine.UI;

namespace SpaceLander
{
    internal class StartButtonView : MonoBehaviour
    {
        [SerializeField] private Button _startBtn;
        private ICrashAssessmentViewModel _crashViewModel;
        private ILandingAssessmentViewModel _landingViewModel;

        public void InitializeView(ICrashAssessmentViewModel crash, ILandingAssessmentViewModel win, IGameManager gameManager)
        {
            _crashViewModel = crash;
            _landingViewModel = win;
            _crashViewModel.OnCrash += ShowButton;
            _landingViewModel.IsWin += ShowButton;
            _startBtn.onClick.AddListener(gameManager.RebootGame);
        }

        private void ShowButton()
        {
            _startBtn.gameObject.SetActive(true);
        }

        ~StartButtonView()
        {
            _crashViewModel.OnCrash -= ShowButton;
            _landingViewModel.IsWin -= ShowButton;
        }
    }
}
