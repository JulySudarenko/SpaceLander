using System;
using System.Collections.Generic;
using Assistants;
using UnityEngine;

namespace SpaceLander
{
    internal class HitListener :  IHitListener
    {
        private List<HitLandingComponentSystem> _landingComponents;
        public ILandingAssessmentViewModel LandingAssessment { get; }
        public ICrashAssessmentViewModel CrashAssessment { get; }
        private Transform _ship;
        private HitShipSystem _hitShipSystem;
        private bool _isOnPlatform;

        public HitListener(Transform ship, IWinModel winModel, ICrashModel crashModel)
        {
            LandingAssessment = new LandingAssessmentViewModel(winModel);
            CrashAssessment = new CrashAssessmentViewModel(crashModel);
            _ship = ship;
            _isOnPlatform = false;
        }

        public void Initialize()
        {
            _hitShipSystem = _ship.GetComponent<HitShipSystem>();
            _hitShipSystem.OnHit += HitSignalProcessing;

            _landingComponents = new List<HitLandingComponentSystem>();

            foreach (Transform child in _ship.transform)
            {
                if (child.TryGetComponent<HitLandingComponentSystem>(out var component))
                {
                    _landingComponents.Add(component);
                    component.OnHit += LandingComponentsHitProcessing;
                }
            }
        }

        private void HitSignalProcessing(HitState state, GameObject collisionObject)
        {
            if (collisionObject.name == NameManager.NAME_PLATFORM)
            {
                switch (state)
                {
                    case HitState.Enter:
                        _isOnPlatform = true;
                        break;
                    case HitState.Exit:
                        LandingAssessment.ResetPlatformTime();
                        _isOnPlatform = false;
                        break;
                    case HitState.Stay:
                        LandingAssessment.CheckWinningConditions(_hitShipSystem.transform);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(state), state,
                            "New state? Do I need to know about this?");
                }
            }
            else
            {
                if (!_isOnPlatform && collisionObject.name == NameManager.NAME_STAGE)
                {
                    CrashAssessment.Crash();
                }
            }
        }

        private void LandingComponentsHitProcessing(GameObject gameObject, GameObject collisionObject, float speed)
        {
            if (collisionObject.name == NameManager.NAME_STAGE)
            {
                CrashAssessment.AnalysisOfDamage(gameObject, speed);
            }
        }

        public void Cleanup()
        {
            _hitShipSystem.OnHit -= HitSignalProcessing;
            foreach (var component in _landingComponents)
            {
                component.OnHit -= LandingComponentsHitProcessing;
            }
        }
    }
}
