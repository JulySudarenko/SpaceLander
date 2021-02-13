using UnityEngine;

namespace SpaceLander
{
    [CreateAssetMenu(fileName = "Ship", menuName = "Data/Ship", order = 0)]
    public class ShipData : ScriptableObject
    {
        public GameObject ShipPrefab;

        [Space, Header("Force")] 
        [SerializeField] private float _forceRate;
        [SerializeField] private float torqueRate;

        [Space, Header("Sounds")] 
        public AudioClip ThrusterSound;
        public AudioClip LandSuccessSound;
        public AudioClip CrashSound;

        [Space, Header("Fuel")] 
        [SerializeField] private float _initialFuelSupply;
        [SerializeField] private float _fuelRate;
        [SerializeField] private float _torqueFuelRate;

        [Space, Header("Win")] 
        [SerializeField] private string _winMessage;
        [SerializeField] private float _winTimeOnPlatform;
        [SerializeField] private float _landingWinAngleMin;
        [SerializeField] private float _landingWinAngleMax;

        [Space, Header("Crash")]
        [SerializeField] private string _crashMessage;
        [SerializeField] private float _landingCrashSpeed;
        [SerializeField] private float _crashAngleMin;
        [SerializeField] private float _crashAngleMax;
        [SerializeField] private float _randomForceMINX;
        [SerializeField] private float _randomForceMAXX;
        [SerializeField] private float _randomForceMINY;
        [SerializeField] private float _randomForceMAXY;
        [SerializeField] private float _randomTorqueForceMIN;
        [SerializeField] private float _randomTorqueForceMAX;

        public string WinMessage => _winMessage;
        public string CrashMessage => _crashMessage;
        public float InitialFuelSupply => _initialFuelSupply;
        public float FuelRate => _fuelRate;
        public float ForceRate => _forceRate;
        public float TorqueFuelRate => _torqueFuelRate;
        public float TorqueRate => torqueRate;
        public float WinTimeOnPlatform => _winTimeOnPlatform;

        public float LandingWinAngleMin => _landingWinAngleMin;

        public float LandingWinAngleMax => _landingWinAngleMax;

        public float LandingCrashSpeed => _landingCrashSpeed;
        public float CrashAngleMin => _crashAngleMin;
        public float CrashAngleMax => _crashAngleMax;
        public float RandomForceMaxX => _randomForceMAXX;
        public float RandomForceMinX => _randomForceMINX;
        public float RandomForceMinY => _randomForceMINY;
        public float RandomForceMaxY => _randomForceMAXY;
        public float RandomTorqueForceMIN => _randomTorqueForceMIN;
        public float RandomTorqueForceMAX => _randomTorqueForceMAX;
    }
}
