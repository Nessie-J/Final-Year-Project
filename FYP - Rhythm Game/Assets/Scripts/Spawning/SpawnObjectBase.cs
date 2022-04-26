using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;
using Timers;
using unlock;

namespace spawnedObject {
    public class SpawnObjectBase : MonoBehaviour
    {
        [Header("Layer Masks")]
        public LayerMask handsLayer;
        public LayerMask headLayer;
        public LayerMask scoreWallLayer;
        public LayerMask missWallLayer;

        [Header("Object Variables")]
        public float movementSpeed = 5;

        [Header("Points Variables")]
        public int baseScoreValue;
        public int currentPointValue;

        [Header("Componets")]
        public Rigidbody rigiBod;
        public MeshRenderer[] myRenders;
        public Collider[] myCollider;

        [Header("Classes")]
        public PointWall pointWall;
        public PointsCounter pointCounter;
        public Unlockables unlockables;
        public PhaseTimer phaseTimer;


        protected virtual void Start()
        {
            rigiBod = GetComponent<Rigidbody>();
            
            myRenders = GetComponentsInChildren<MeshRenderer>();
            myCollider = GetComponentsInChildren<Collider>();

            currentPointValue = baseScoreValue;

            phaseTimer = FindObjectOfType<PhaseTimer>();
            pointCounter = FindObjectOfType<PointsCounter>();
            unlockables = FindObjectOfType<Unlockables>();
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if (!phaseTimer.stop)
            {
               
                rigiBod.AddForce(Time.deltaTime * transform.forward * movementSpeed);

                foreach (Collider thiscollide in myCollider)
                {
                    thiscollide.enabled = true;
                }

                foreach (MeshRenderer meshRender in myRenders)
                {
                    meshRender.enabled = true;
                }
            

            }

            else
            {
                rigiBod.velocity = Vector3.zero;
                rigiBod.angularVelocity = Vector3.zero;
                rigiBod.useGravity = false;

                foreach (Collider thiscollide in myCollider)
                {
                    thiscollide.enabled = false;
                }

                foreach (MeshRenderer meshRender in myRenders)
                {
                    meshRender.enabled = false;
                }
             

            }

            

            
        }


       protected virtual void OnTriggerEnter(Collider other)
        {

            //If triggered by miss wall -  Destory game object.
            if ((missWallLayer.value & (1 << other.gameObject.layer)) > 0)
            {
                StartCoroutine(destoryTimer());
            }
        }

        
        //Coroutine add to ensure - Points added function will happen before the destruction of the object
        public IEnumerator destoryTimer()
        {
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }


    }
}
