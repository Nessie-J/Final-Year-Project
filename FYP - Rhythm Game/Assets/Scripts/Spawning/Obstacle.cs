using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                
            }

            base.OnTriggerEnter(other);

            if ((scoreWallLayer.value & (1 << other.gameObject.layer)) > 0)
            {
                return;
            }
        }

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if ((headLayer.value & (1 << collision.gameObject.layer)) > 0 || (handsLayer.value & (1 << collision.gameObject.layer)) > 0)
            {
                currentPointValue = 0;

                pointCounter.resetComboMulti();
            }
        }
    }
}
