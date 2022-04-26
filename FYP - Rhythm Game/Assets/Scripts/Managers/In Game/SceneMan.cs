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


        public void LoadMainMenu()
        {
            SceneManager.LoadScene(mainMenu);
            Debug.Log("Main Menu");
        }

       public void LoadGame()
        {
            StartCoroutine(load());
        }

       public void Quit()
        {
            StartCoroutine(quit());
       
        }

        IEnumerator load()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(Game);
        }

        IEnumerator quit()
        {
            yield return new WaitForSeconds(1f);
            PlayerPrefs.DeleteAll();
            Application.Quit();
        }
    }
}
