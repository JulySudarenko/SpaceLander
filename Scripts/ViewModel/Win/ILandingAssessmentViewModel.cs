using System;
using UnityEngine;

namespace SpaceLander
{
    internal interface ILandingAssessmentViewModel
    {
        event Action IsWin;
        AudioClip WinSound { get; }
        string WinMessage  { get; }
        void ResetPlatformTime();
        void CheckWinningConditions(Transform ship);
    }
}
