using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Timers
{
    public class BeatTimer : MonoBehaviour
    {
        [Header("Beat")]
        public float attackBeat;
        public float defenseBeat;
        public float comboPhaseAttackBeat;
        public float comboPhaseDefenseBeat;
        public bool checkBeat;

        [Header("Timers")]
        public float attackBeatTimer;
        public float defenseBeatTimer;

        [Header("Called Classes")]
        public PhaseTimer phaseTimer;

        private void Start()
        {
            checkBeat = true;

            phaseTimer = GetComponent<PhaseTimer>();
        }

        private void Update()
        {
            checkPhase();
        }

        void checkPhase()
        {
            if (phaseTimer.isAttackPhase)
            {
                checkBeat = true;
                attackBeatTimer += Time.deltaTime;
                defenseBeatTimer = 0;
            }

            else if (phaseTimer.isDefensePhase)
            {
                attackBeatTimer = 0;
                defenseBeatTimer += Time.deltaTime;
            }

            else if (phaseTimer.isComboPhase)
            {
                attackBeat = comboPhaseAttackBeat;
                defenseBeat = comboPhaseDefenseBeat;

                attackBeatTimer += Time.deltaTime;
                defenseBeatTimer += Time.deltaTime;
            }

            else
            {
                checkBeat = false;
                return;
            }

        }
    }
}
