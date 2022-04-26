using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;


namespace spawnedObject {
    public class Destructable : SpawnObjectBase
    {
        [Header("Shatter")]
        public GameObject shatterObject;
        public float explosionnMinForce = 5;
        public float explosionMaxForce = 100;
        public float explosionRadius = 10;
        public float explosionProjection = 2f;

        [Header("Current Position")]
        public Vector3 currentPos;

        private void Awake()
        {
            shatterObject = Resources.Load("Prefabs/shatter_001") as GameObject;
        }
        protected override void Start()
        {
            base.Start();

           
        }

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

                if (PlayerPrefs.GetInt("destoryUnlock", unlockables.destoryedObjectsLeft) > 0)
                {
                    unlockables.destoryedObjectsLeft--;
                    PlayerPrefs.SetInt("destoryUnlock", unlockables.destoryedObjectsLeft);
                }
                    

                Shattering();


            }
            
            if ((headLayer.value & ( 1 << collision.gameObject.layer)) > 0)
            {
                currentPointValue = 0;
            }

        }

        protected override void Update()
        {
            base.Update();

            currentPos = transform.position;

           
        }
        
           
        

        void Shattering()
        {
            if (shatterObject != null)
            {
                var shatterObj = Instantiate(shatterObject, currentPos, Quaternion.identity) as GameObject;
              

                foreach (Transform t in shatterObj.transform)
                {
                    var rb = t.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        rb.AddExplosionForce(Random.Range(explosionnMinForce, explosionMaxForce), currentPos, explosionRadius, explosionProjection);
                        Debug.Log("shatter");
                    }
                }

                Destroy(shatterObj, 5);
                Destroy(gameObject);

            }
        }
    }
}
