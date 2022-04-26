using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Classes")]
        public GameStates gameState;

        [Header("Menus")]
        public GameObject[] pauseMenu;
        public GameObject[] gameOverMenu;
        public GameObject[] gameWinMenu;
        public GameObject scoreDisplay;
        public GameObject highScoreDisplay;

        [Header("Wall")]
        public GameObject wall;



        private void Start()
        {
            BaseSetting();
        }

        private void Update()
        {

          if (!gameState.isPaused)
           {
                foreach (GameObject PauseMen in pauseMenu)
                {
                    PauseMen.SetActive(false);
                }
            }

            else if (gameState.isPaused)
            {
                foreach (GameObject PauseMen in pauseMenu)
                {
                    PauseMen.SetActive(true);
                }

            }

         
            else if (gameState.gameOver)
            {

                foreach (GameObject gameOverMen in gameOverMenu)
                {
                    gameOverMen.SetActive(true);
                    turnOffScoreDisplay();
                }
               
                
            }

            else if (gameState.gameWin)
            {
                foreach (GameObject gameWinMen in gameWinMenu)
                {
                    gameWinMen.SetActive(true);
                    turnOffScoreDisplay();
                }
                
            }
               
        }


        void turnOffScoreDisplay()
        {
            scoreDisplay.SetActive(false);
        }

        void BaseSetting()
        {
            foreach (GameObject PauseMen in pauseMenu)
            {
                PauseMen.SetActive(false);
            }


            foreach (GameObject gameOverMen in gameOverMenu)
            {
                gameOverMen.SetActive(false);
            }

            foreach (GameObject gameWinMen in gameWinMenu)
            {
                gameWinMen.SetActive(false);
            }

            scoreDisplay.SetActive(true);

            highScoreDisplay.SetActive(true);
        }
    }
}
