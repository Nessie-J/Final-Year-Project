using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unlock;
using Score;
using Timers;

namespace spawnedObject {
    public class Obstacle : SpawnObjectBase
    { 

        protected override void OnTriggerEnter(Collider other)
        {
            if ((missWallLayer.value & (1 << other.gameObject.layer)) > 0)
            {
                pointCounter.PointAmount = currentPointValue;

                pointCounter.addComboMutli();
                pointCounter.addPoints();
                pointCounter.removeMissCounter();

                if (PlayerPrefs.GetInt("dodgeUnlock", unlockables.dodgedObjectsLeft) > 0)
                {
                    unlockables.dodgedObjectsLeft--;
                    PlayerPrefs.SetInt("dodgeUnlock", unlockables.dodgedObjectsLeft);
                }
                   


            }

            base.OnTriggerEnter(other);

            if ((scoreWallLayer.value & (1 << other.gameObject.layer)) > 0)
            {
                return;
            }

            if ((headLayer.value & (1 << other.gameObject.layer)) > 0 || (handsLayer.value & (1 << other.gameObject.layer)) > 0)
            {
                currentPointValue = 0;

                pointCounter.resetComboMulti();
            }
        }

      
    }
}
