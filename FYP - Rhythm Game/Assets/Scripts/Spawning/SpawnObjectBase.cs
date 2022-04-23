using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;

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

        [Header("Classes")]
        public PointWall pointWall;
        public PointsCounter pointCounter;
        public Unlockables unlockables;

        void Start()
        {
            rigiBod = GetComponent<Rigidbody>();

            currentPointValue = baseScoreValue;

            pointCounter = FindObjectOfType<PointsCounter>();
            unlockables = FindObjectOfType<Unlockables>();
        }

        // Update is called once per frame
        void Update()
        {
            rigiBod.AddForce(Time.deltaTime * transform.forward * movementSpeed);
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
