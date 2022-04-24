using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Classes")]
        public GameStates gameState;

        [Header("Menus")]
        public GameObject pauseMenu;
        public GameObject gameOverMenu;
        public GameObject highScoreMenu;



        private void Start()
        {
            pauseMenu.SetActive(false);
            gameOverMenu.SetActive(false);
            highScoreMenu.SetActive(false);
        }

        private void Update()
        {
            if (gameState.isPaused)
            {
                pauseMenu.SetActive(true);

            }
        }
    }
}
