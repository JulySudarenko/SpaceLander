using System;
using UnityEngine;

namespace SpaceLander
{
    internal class LandingAssessmentViewModel : ILandingAssessmentViewModel
    {
        public event Action IsWin;
        private IWinModel _model;
        private bool _endGame;

        public LandingAssessmentViewModel(IWinModel winModel)
        {
            _model = winModel;
            _endGame = false;
        }

        public AudioClip WinSound => _model.WinSound;
        public string WinMessage => _model.WinMessage;

        public void ResetPlatformTime()
        {
            _model.ValidTimeOnPlatform = 0.0f;
        }

        public void CheckWinningConditions(Transform ship)
        {
            float angle = ship.rotation.eulerAngles.z;
            if (angle > _model.LandingWinAngleMax || angle < _model.LandingWinAngleMin)
            {
                _model.ValidTimeOnPlatform += Time.deltaTime;
            }
            else
            {
                ResetPlatformTime();
            }

            if ((_model.ValidTimeOnPlatform > _model.WinTimeOnPlatform) && _endGame == false)
            {
                IsWin?.Invoke();
                _endGame = true;
            }
        }
    }
}
