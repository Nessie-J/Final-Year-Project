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

        [Header("Audio")]
        public AudioSource musicAudio;

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
                gameOver = true;
                phaseTimer.stop = true;
               
                Destroy(spawner);
            }

            if (phaseTimer.amountOfSongLeft <= 0)
            {
                //Game Win - display high score board
                
                gameEnd();
                gameWin = true;
                phaseTimer.stop = true;
               
                Destroy(spawner);

              
            }

            if (isPaused)
            {
                musicAudio.Pause();
                phaseTimer.stop = true;
            }

            if(!isPaused)
            {
                musicAudio.UnPause();
                phaseTimer.stop = false;
            }
        }


        public void pauseGame()
        {
            musicAudio.Pause();
            isPaused = true;
            phaseTimer.stop = true;
            
        }

        public void resumeGame()
        {
            musicAudio.UnPause();
            isPaused = false;
            phaseTimer.stop = false;
          
        }

        public void gameEnd()
        {
            musicAudio.Stop();
            phaseTimer.stop = true;
        }
    }
}
