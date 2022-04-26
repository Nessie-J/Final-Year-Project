using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;
using Timers;
using unlock;

namespace GameManager { 

    public class GameStates : MonoBehaviour
    {
        [Header("Classes")]
        public PointsCounter pointCounter;
        public PhaseTimer phaseTimer;
        public Unlockables unlockables;

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
            unlockables = FindObjectOfType<Unlockables>();

            isPaused = false;

            Time.timeScale = 1;
        }

        private void Update()
        {

            if (pointCounter.MissCounter >= maxMissAmount)
            {
                //GAME OVER - give options to return to main menu or quit
                gameEnd();
                Destroy(spawner);
            }

            if (phaseTimer.amountOfSongLeft <= 0)
            {
                //Game Win - display high score board
                gameEnd();
                Destroy(spawner);

              
            }
        }


        public void pauseGame()
        {
            isPaused = true;
            phaseTimer.stop = true;
            
        }

        public void resumeGame()
        {
            isPaused = false;
            phaseTimer.stop = false;
          
        }

        public void gameEnd()
        {
            phaseTimer.stop = true;
        }
    }
}
