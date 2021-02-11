using UnityEngine;
using static Assistants.Extentions;

namespace SpaceLander
{
    [CreateAssetMenu(fileName = "UIData", menuName = "Data/UIData", order = 0)]
    public class UIData : ScriptableObject
    {
        [SerializeField] private string _mainMenuDataPath;
        [SerializeField] private string _gameMenuDataPath;
        private MainMenuData _mainMenuData;
        private GameMenuData _gameMenuData;

        public MainMenuData MainMenuData
        {
            get
            {
                if (_mainMenuData == null)
                {
                    _mainMenuData = Load<MainMenuData>("Data/" + _mainMenuDataPath);
                }

                return _mainMenuData;
            }
        }

        public GameMenuData GameMenuData
        {
            get
            {
                if (_gameMenuData == null)
                {
                    _gameMenuData = Load<GameMenuData>("Data/" + _gameMenuDataPath);
                }

                return _gameMenuData;
            }
        }
    }
}
