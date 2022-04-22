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

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(mainMenu);
            Debug.Log("Main Menu");
        }

       public void LoadGame()
        {
            SceneManager.LoadScene(Game);
            Debug.Log("Game");
        }

       public void Quit()
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
