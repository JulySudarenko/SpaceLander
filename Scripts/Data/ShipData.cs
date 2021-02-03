using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Ship", menuName = "Data/Ship", order = 0)]
    public class ShipData : ScriptableObject
    {
        public GameObject ShipPrefab;
        public ParticleSystem Thruster;
        public ParticleSystem CrashSmoke;
        public AudioClip ThrusterSound;
        public AudioClip CrashSound;
        public AudioClip LandSuccessSound;

        [SerializeField] private float _initialFuelSupply;
        [SerializeField] private float _fuelRate;

        public float InitialFuelSupply1 => _initialFuelSupply;

        public float FuelRate => _fuelRate;
    }
}
