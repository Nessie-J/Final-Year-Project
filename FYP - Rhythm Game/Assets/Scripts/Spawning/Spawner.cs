using Timers;
using UnityEngine;

namespace spawner
{
    public class Spawner : MonoBehaviour
    {
        public enum spawnItems { block, obstacles, combo, none }
        [Header("Spawn Phase")]
        public spawnItems currentItemSpawning;


        [Header("Objects")]
        public GameObject[] destructables;
        public GameObject[] obsticals;
     

        [Header("Spawn Points")]
        public Transform[] destructableSpawnPoints;
        public Transform[] obsticalSpawnPoint;
     

        [Header("Timers")]
        public PhaseTimer phaseTimer;
        public BeatTimer beatTimer;

        //[Header("Destroy")]
       // public float objectDestoryTimer = 200;

        

        private void Start()
        {
            currentItemSpawning = spawnItems.block;

            phaseTimer = FindObjectOfType<PhaseTimer>();

            beatTimer = FindObjectOfType<BeatTimer>();

         
           
        }

        private void Update()
        {
            if (!phaseTimer.stop)
            {
                CheckPhase();
            }

            else
            {
                return;
            }
        }



        public void CheckPhase()
        {
            if (phaseTimer.isAttackPhase)
            {
                currentItemSpawning = spawnItems.block;
                switchItem();
              

            }

            else if (phaseTimer.isDefensePhase)
            {
                currentItemSpawning = spawnItems.obstacles;
                switchItem();
                
            }

            else if (phaseTimer.isComboPhase)
            {
                currentItemSpawning = spawnItems.combo;
                switchItem();
              
            }

            else if (!phaseTimer.isAttackPhase && !phaseTimer.isDefensePhase && !phaseTimer.isComboPhase)
            {
                currentItemSpawning = spawnItems.none;
                switchItem();
                return;
            }
        }

       

        public void switchItem()
        {
            switch (currentItemSpawning)
            {
                case spawnItems.block:
                    AttackDestructables();
                    break;

                case spawnItems.obstacles:
                        DefenseObstacles();
                    break;

                case spawnItems.combo:
                    AttackDestructables();
                    DefenseObstacles();
                   break;

                case spawnItems.none:
                    break;

                


            }
        }

        void AttackDestructables()
        {
            if (beatTimer.attackBeatTimer > beatTimer.attackBeat)
            {
                GameObject destructableObj = Instantiate(destructables[Random.Range(0, destructables.Length)], destructableSpawnPoints[Random.Range(0, destructableSpawnPoints.Length)]);
                destructableObj.transform.localPosition = Vector3.zero;
              //  Destroy(destructableObj, objectDestoryTimer);
                beatTimer.attackBeatTimer -= beatTimer.attackBeat;
            }
        }

        void DefenseObstacles()
        {
            if (beatTimer.defenseBeatTimer > beatTimer.defenseBeat)
            {
                GameObject obsitical = Instantiate(obsticals[Random.Range(0, obsticals.Length)], obsticalSpawnPoint[Random.Range(0, obsticalSpawnPoint.Length)]);
                obsitical.transform.localPosition = Vector3.zero;
             //   Destroy(obsitical, objectDestoryTimer);
                beatTimer.defenseBeatTimer -= beatTimer.defenseBeat;
            }
        }


    


     

  
    }

}


