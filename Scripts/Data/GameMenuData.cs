using UnityEngine;
using UnityEngine.UI;

namespace SpaceLander
{
    [CreateAssetMenu(fileName = "GameMenu", menuName = "Data/GameMenu", order = 0)]
    public class GameMenuData : ScriptableObject
    {
        public Button ReturnToGameBtn { get; }
        public Button RestartGameBtn { get; }
        public Button MainMenuBtn { get; }
        public Text ScoreText { get; }
        public Text FuelText { get; }
        public GameObject MessagePanel { get; }
    }
}
