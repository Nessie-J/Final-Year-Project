using Score;
using UnityEngine;

namespace SpawnedObjects
{
    public class Blocks : MonoBehaviour
    {
        [Header("Layer Masks")]
        public LayerMask PlayerLayer;
        public LayerMask wallLayer;

        public PointsCounter PointsCounter;
        public Rigidbody rb;

        [Header("Movement")]
        public float moveSpeed = 2;

        [Header("Point Information")]
        public int basePointValue = 10;
        public int pointIncreaseValue = 50;
        public int currentPointValue;
        // Start is called before the first frame update
        void Start()
        {
            currentPointValue = basePointValue;
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            // transform.position += Time.deltaTime * transform.forward * moveSpeed;


            rb.AddForce(Time.deltaTime * transform.forward * moveSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {

            if ((wallLayer.value & (1 << other.gameObject.layer)) > 0)
            {
                // currentPointValue += pointIncreaseValue;
                Debug.Log(currentPointValue + "hitting wall");

            }

            else
            {
                Debug.Log("MEH");
            }

        }

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if ((PlayerLayer.value & (1 << collision.gameObject.layer)) > 0)
            {
                Debug.Log("Player Punch");
            }

            else
            {

            }


        }

        protected virtual void Missed()
        {
            //If reach x point - Destory - +1 To miss counter

            PointsCounter.MissCounter++;
            PointsCounter.ComboMultiplyer = 0;
        }

        protected virtual void Destory()
        {

        }
    }
}
