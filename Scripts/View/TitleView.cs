using UnityEngine;
using UnityEngine.UI;

namespace SpaceLander
{
    internal class TitleView : MonoBehaviour
    {
        [SerializeField] private Text _titleText;
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
            _titleText.gameObject.SetActive(true);
        }

        private void HideTitle()
        {
            _titleText.gameObject.SetActive(false);
        }

        ~TitleView()
        {
            _crashViewModel.IsLose -= ShowTitle;
            _landingViewModel.IsWin -= ShowTitle;
        }
    }
}
