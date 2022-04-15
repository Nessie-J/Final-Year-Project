using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timers {
    public class GameTimer : MonoBehaviour
    {
        public int songLength = 10;
        public float amountOfSongLeft;
        public float AttackPhaseEndTime;
        public float DefensePhaseEndTime;

        public bool isAttackPhase;
        public bool isDefensePhase;
        public bool isComboPhase;

        private void Awake()
        {
            amountOfSongLeft = songLength;
            isAttackPhase = true;
        }

  

        // Update is called once per frame
        void Update()
        {
            amountOfSongLeft -= Time.deltaTime;

            if (amountOfSongLeft <= AttackPhaseEndTime && amountOfSongLeft >= DefensePhaseEndTime)
            {
                AttackPhaseEnd();
            }

            else if(amountOfSongLeft <= DefensePhaseEndTime && amountOfSongLeft >= 0)
            {
                DefensePhaseEnd();
            }

           else if(amountOfSongLeft <= 0)
            {
                GameEnd();
            }

            else
            {
                isAttackPhase = true;
            } 
        }

        private void AttackPhaseEnd()
        {
            isAttackPhase = false;
            isDefensePhase = true;
            Debug.Log("ATTACK END");
        }

        private void DefensePhaseEnd()
        {
            isDefensePhase = false;
            isComboPhase = true;
            Debug.Log("DEFENSE END");
        }

        private void GameEnd()
        {
           
            
                //END THE GAME
                Debug.Log("END");
                Time.timeScale = 0;

                amountOfSongLeft = 0;
                isComboPhase = false;
                isAttackPhase = false;
                isDefensePhase = false;

            
        }
    }
}
