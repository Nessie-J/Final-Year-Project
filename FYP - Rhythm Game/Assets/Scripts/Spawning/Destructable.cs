using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;


namespace spawnedObject {
    public class Destructable : SpawnObjectBase
    {
        protected override void OnTriggerEnter(Collider other)
        {

            if ((missWallLayer.value & (1 << other.gameObject.layer)) > 0)
            {
                currentPointValue = 0;
                pointCounter.resetComboMulti();
                pointCounter.addMissCounter();

            }

            base.OnTriggerEnter(other);

            if ((scoreWallLayer.value & (1 << other.gameObject.layer)) > 0)
            {
                pointWall = other.gameObject.GetComponent<PointWall>();

                currentPointValue += pointWall.PointValue;
            }

        }

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {

            if ((handsLayer.value & (1 << collision.gameObject.layer)) > 0)
            {
                pointCounter.PointAmount = currentPointValue;

                pointCounter.addPoints();
                pointCounter.addComboMutli();
                pointCounter.removeMissCounter();

                unlockables.destoryedObjectsLeft--;
                PlayerPrefs.SetInt("destoryUnlock", unlockables.destoryedObjectsLeft);
            }
            
            if ((headLayer.value & ( 1 << collision.gameObject.layer)) > 0)
            {
                currentPointValue = 0;
            }

        }
    }
}
