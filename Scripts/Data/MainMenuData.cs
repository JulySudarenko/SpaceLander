using UnityEngine;
using UnityEngine.UI;

namespace SpaceLander
{
    [CreateAssetMenu(fileName = "MainMenu", menuName = "Data/MainMenu", order = 0)]
    public class MainMenuData : ScriptableObject
    {
        public Button StartGameBtn { get; }
        public Button ExitGameBtn { get; }
    }
}
