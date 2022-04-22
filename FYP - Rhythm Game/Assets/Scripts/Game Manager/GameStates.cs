using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;
using Timers;

namespace GameManager { 

    public class GameStates : MonoBehaviour
    {
        [Header("Classes")]
        public PointsCounter pointCounter;
        public PhaseTimer phaseTimer;

        [Header("Counter Information")]
        public int maxMissAmount;

        [Header("State Bools")]
        public bool isPaused;
        public bool gameOver;
        public bool gameWin;

        [Header("Game Objects")]
        public GameObject spawner;

        private void Start()
        {
            phaseTimer = FindObjectOfType<PhaseTimer>();
            pointCounter = FindObjectOfType<PointsCounter>();

            isPaused = false;
        }

        private void Update()
        {

            if (pointCounter.MissCounter >= maxMissAmount)
            {
                //GAME OVER - give options to return to main menu or quit
                isPaused = true;
                Destroy(spawner);
            }

            if (phaseTimer.amountOfSongLeft <= 0)
            {
                //Game Win - display high score board
                isPaused = true;
                Destroy(spawner);
            }
        }


        public void pauseGame()
        {
            isPaused = true;
            Time.timeScale = 0;
            
        }

        public void resumeGame()
        {
            isPaused = false;
            Time.timeScale = 1;
          
        }
    }
}