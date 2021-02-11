using System;
using UnityEngine;

namespace SpaceLander
{
    internal class LandingAssessmentViewModel : ILandingAssessmentViewModel
    {
        public event Action IsWin;
        private IWinModel _model;

        public LandingAssessmentViewModel(IWinModel winModel)
        {
            _model = winModel;
        }

        public void ResetPlatformTime()
        {
            _model.ValidTimeOnPlatform = 0.0f;
        }

        public void CheckWinningConditions(Transform ship)
        {
            float angle = ship.rotation.eulerAngles.z;
            if (angle > _model.MaxAngle || angle < _model.MaxAngle)
            {
                _model.ValidTimeOnPlatform += Time.deltaTime;
            }
            else
            {
                ResetPlatformTime();
            }

            if (_model.ValidTimeOnPlatform > _model.WinTimeOnPlatform)
            {
                Debug.Log("Winner");
                IsWin?.Invoke();
            }
        }
    }
}
