using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceLander
{
    internal class CrashAssessmentViewModel : ICrashAssessmentViewModel
    {
        public event Action OnCrash;
        public Vector3 CollisionForce { get; private set; }
        public Vector3 TorqueForce { get; private set; }
        private ICrashModel _model;
        private bool _endGame;

        public CrashAssessmentViewModel(ICrashModel model)
        {
            _model = model;
            CollisionForce = Vector3.zero;
            TorqueForce = Vector3.zero;
            _endGame = false;
        }

        public AudioClip CrashSound => _model.CrashSound;
        public string CrashMessage => _model.CrashMessage;

        public void AnalysisOfDamage(GameObject gameObject, float speed)
        {
            float angle = gameObject.transform.parent.transform.rotation.eulerAngles.z;

            if (angle < _model.CrashAngleMax && angle > _model.CrashAngleMin || speed > _model.LandingCrashSpeed)
            {
                Crash();
            }
        }

        public void Crash()
        {
            float randomForceX = Random.Range(_model.RandomForceMINX, _model.RandomForceMAXX);
            float randomForceY = Random.Range(_model.RandomForceMINY, _model.RandomForceMAXY);
            float randomTorqueForce = Random.Range(_model.RandomTorqueForceMIN, _model.RandomTorqueForceMAX);

            CollisionForce = new Vector3(randomForceX, randomForceY, 0.0f);
            TorqueForce = new Vector3(0.0f, 0.0f, randomTorqueForce);

            if (_endGame == false)
            {
                OnCrash?.Invoke();
                _endGame = true;
            }
        }
    }
}
