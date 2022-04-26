using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;

namespace Timers {

    public class PhaseTimer : MonoBehaviour
    {
        [Header("Song Information")]
        public string songName;
        public float BMP;
        public AudioClip songClip;
        public int songLengthInSeconds;

        [Header("Timers")]
        public float amountOfSongLeft;
        public float beatTimer;

        public enum Phase { attackPhase, defensePhase, comboPhase, endPhase }
        [Header("Phases")]
        public Phase currentPhase;

        [Header("Phase Times")]
        public float defensePhaseStartTime;
        public float comboPhaseStartTime;
        public float endPhaseStartTime;

        [Header("Phase Bools")]
        public bool isAttackPhase;
        public bool isDefensePhase;
        public bool isComboPhase;

        [Header("Pause Bools")]
        public bool stop;

        [Header("Classes")]
        public PreGame preGameTimer;
      

        private void Awake()
        {
            preGameTimer = GetComponent<PreGame>();
        }



        private void Start()
        {

            currentPhase = Phase.attackPhase;
            amountOfSongLeft = songLengthInSeconds;

        }

        private void Update()
        {

            if(preGameTimer.isGameStart)
            {
                if (!stop)
                {
                    updateTimer();

                    CheckPhase();
                }

                else
                {
                    return;
                }
            }

            else
            {
                return;
            }
           
        }


        public void CheckPhase()
        {

            if (amountOfSongLeft <= defensePhaseStartTime && amountOfSongLeft >= comboPhaseStartTime)
            {
                currentPhase = Phase.defensePhase;
                SwitchPhase();
            }

            else if (amountOfSongLeft <= comboPhaseStartTime && amountOfSongLeft >= endPhaseStartTime)
            {
                currentPhase = Phase.comboPhase;
                SwitchPhase();
            }

            else if (amountOfSongLeft <= endPhaseStartTime)
            {
                currentPhase = Phase.endPhase;
                SwitchPhase();
            }

            else
            {
                currentPhase = Phase.attackPhase;
                SwitchPhase();
            }

            return;
        }

        public void SwitchPhase()
        {
            switch (currentPhase)
            {
                case Phase.attackPhase:
                    isAttackPhase = true;
                    isDefensePhase = false;
                    isComboPhase = false;
                    break;

                case Phase.defensePhase:
                    isAttackPhase = false;
                    isDefensePhase = true;
                    isComboPhase = false;
                    break;

                case Phase.comboPhase:
                    isAttackPhase = false;
                    isDefensePhase = false;
                    isComboPhase = true;
                    break;

                case Phase.endPhase:
                    isAttackPhase = false;
                    isDefensePhase = false;
                    isComboPhase = false;
                    break;

            }
        }

        void updateTimer()
        {
            if (amountOfSongLeft >= 0)
            {
                amountOfSongLeft -= Time.deltaTime;
            }

            else
            {
                return;
            }
        }
    }
}
