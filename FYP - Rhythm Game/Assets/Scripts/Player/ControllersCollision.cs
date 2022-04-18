using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;

namespace controller {
    // Focues on Haptic Reasponses
    public class ControllersCollision : MonoBehaviour
    {

       // Layer Masks - Hands + Heads + Destructables + Obstacles

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
           // If hit obstial: Haptics
             
            
        }

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
           

            //If hit other hand or head - Haptics
        }
    }
}
