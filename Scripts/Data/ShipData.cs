using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Ship", menuName = "Data/Ship", order = 0)]
    public class ShipData : ScriptableObject
    {
        public GameObject ShipPrefab;
        public ConstantForce ConstForce;
 
        [Space, Header("Force")] 
        [SerializeField] private float _forceRate;
        [SerializeField] private float torqueRate;

        [Space, Header("Thruster")] 
        public ParticleSystem Thruster;
        public AudioClip ThrusterSound;

        [Space, Header("Crash")] public ParticleSystem CrashSmoke;
        public AudioClip CrashSound;

        [Space, Header("Fuel")] 
        [SerializeField] private float _initialFuelSupply;
        [SerializeField] private float _fuelRate;

        [Space, Header("Win")]
        public AudioClip LandSuccessSound;

        [SerializeField] private float _validTimeOnPlatform;

        public float InitialFuelSupply => _initialFuelSupply;

        public float FuelRate => _fuelRate;

        public float ForceRate => _forceRate;
        public float TorqueRate => torqueRate;

        public float ValidTimeOnPlatform => _validTimeOnPlatform;
    }
}
