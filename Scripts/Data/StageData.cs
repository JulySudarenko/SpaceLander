using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Stage", menuName = "Data/Stage", order = 0)]
    public class StageData : ScriptableObject
    {

        public GameObject PlatformParticles;
        public AudioClip MainMelody;
        [Header("Moon")]
        public GameObject LandScape;
        public Material MoonBackground;
        [SerializeField] private float _moonGravity;
        public float MoonGravity =>  _moonGravity;
    }
}
