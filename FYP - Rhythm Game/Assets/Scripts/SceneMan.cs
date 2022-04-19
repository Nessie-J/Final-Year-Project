using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager {
    public class SceneMan : MonoBehaviour
    {
        [Header("Scene Names")]
        public string mainMenu;
        public string Game;
        // Start is called before the first frame update

        void LoadMainMenu()
        {
            SceneManager.LoadScene(mainMenu);
        }

        void LoadGame()
        {
            SceneManager.LoadScene(Game);
        }

        void Quit()
        {
            Application.Quit();
        }
    }
}
