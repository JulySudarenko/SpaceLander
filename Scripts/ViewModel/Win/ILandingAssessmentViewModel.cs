using System;
using UnityEngine;

namespace SpaceLander
{
    internal interface ILandingAssessmentViewModel
    {
        event Action IsWin;
        void ResetPlatformTime();
        void CheckWinningConditions(Transform ship);
    }
}
