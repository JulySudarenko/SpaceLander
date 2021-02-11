using System.Collections.Generic;
using UnityEngine;

namespace SpaceLander
{
    class CrashingShipComponents : IInitialize
    {
        private List<CrashComponentEffectView> _crashComponents;
        private ICrashAssessmentViewModel _crashViewModel;
        private Transform _ship;

        public CrashingShipComponents(Transform ship, ICrashAssessmentViewModel crashViewModel)
        {
            _crashComponents = new List<CrashComponentEffectView>();
            _crashViewModel = crashViewModel;
            _ship = ship;
        }

        public void Initialize()
        {
            foreach (Transform component in _ship)
            {
                if (component.TryGetComponent<CrashComponentEffectView>(out var crashComponent))
                {
                    _crashComponents.Add(crashComponent);
                    crashComponent.InitializeView(_crashViewModel);
                }
            }
        }
    }
}
