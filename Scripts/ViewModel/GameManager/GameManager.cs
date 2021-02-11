using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceLander
{
    internal class GameManager : IGameManager
    {
        public void RebootGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
