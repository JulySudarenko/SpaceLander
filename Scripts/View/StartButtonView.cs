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
            _crashViewModel.IsLose += ShowTitle;
            _landingViewModel.IsWin += ShowTitle;
            _startBtn.onClick.AddListener(gameManager.RebootGame);
        }

        private void ShowTitle()
        {
            _startBtn.gameObject.SetActive(true);
        }

        private void HideTitle()
        {
            _startBtn.gameObject.SetActive(false);
        }

        ~StartButtonView()
        {
            _crashViewModel.IsLose -= ShowTitle;
            _landingViewModel.IsWin -= ShowTitle;
        }
    }
}
