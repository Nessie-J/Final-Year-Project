using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;
using Timers;

namespace gameState {

    public class GameStates : MonoBehaviour
    {
        public PointsCounter pointCounter;
        public PhaseTimer phaseTimer;

        public int maxMissAmount;

        private void Start()
        {
            phaseTimer = FindObjectOfType<PhaseTimer>();
            pointCounter = FindObjectOfType<PointsCounter>();
        }

        private void Update()
        {
            if (pointCounter.MissCounter >= maxMissAmount)
            {
                //GAME OVER - give options to return to main menu or quit
            }

            if (phaseTimer.amountOfSongLeft <= 0)
            {
                //Game Win - display high score board
            }
        }
    }
}
