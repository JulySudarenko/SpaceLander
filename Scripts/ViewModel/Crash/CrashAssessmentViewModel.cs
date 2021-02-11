using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace SpaceLander
{
    internal class CrashAssessmentViewModel : ICrashAssessmentViewModel
    {
        public event Action<Vector3, Vector3> OnCrash;
        public event Action IsLose;
        private ICrashModel _model;


        public CrashAssessmentViewModel(ICrashModel model)
        {
            _model = model;
        }

        public void Crash()
        {
            float randomForceX = Random.Range(_model.RandomForceMINX, _model.RandomForceMAXX);
            float randomForceY = Random.Range(_model.RandomForceMINY, _model.RandomForceMAXY);
            float randomTorqueForce = Random.Range(_model.RandomTorqueForceMIN, _model.RandomTorqueForceMAX);

            Vector3 collisionForce = new Vector3(randomForceX, randomForceY, 0.0f);
            Vector3 torqueForce = new Vector3(0.0f, 0.0f, randomTorqueForce);

            IsLose?.Invoke();
            OnCrash?.Invoke(collisionForce, torqueForce);
        }
    }
}
