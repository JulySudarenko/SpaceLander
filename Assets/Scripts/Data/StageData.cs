using UnityEngine;

namespace SpaceLander
{
    [CreateAssetMenu(fileName = "Stage", menuName = "Data/Stage", order = 0)]
    public class StageData : ScriptableObject, IMoon
    {
        public AudioClip MainMelody;
        
        [Space, Header("Platform")]
        public Transform PlatformParticles;
        [SerializeField] private float _platformSize;
        [SerializeField] private float _platformPlaceMinX;
        [SerializeField] private float _platformPlaceMaxX;

        [Space, Header("Moon")] 
        [SerializeField] private GameObject _landScape;
        [SerializeField] private Material _moonBackground;
        [SerializeField] private float _moonGravity;

        public GameObject LandScape => _landScape;
        public Material MoonBackground => _moonBackground;
        public float MoonGravity => _moonGravity;

        public float PlatformSize => _platformSize;

        public float PlatformPlaceMinX => _platformPlaceMinX;

        public float PlatformPlaceMaxX => _platformPlaceMaxX;
    }
}
