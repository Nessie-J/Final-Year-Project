using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


namespace controller {
    // Focues on Haptic Reasponses
    public class ControllersCollision : MonoBehaviour
    {
        [Header("Hand")]
        public Hands hands;
        
        [Header("Layer Mask")]
        public LayerMask hand;
        public LayerMask head;
        
        [Header("Haptics")]
        [SerializeField] private float strength = 0.1f;
        [SerializeField] private float duration = 0.1f;
        [SerializeField] private bool isHapticsOn = false;
        

       // Layer Masks - Hands + Heads + Destructables + Obstacles

        // Start is called before the first frame update
        void Start()
        {
            hands = GetComponent<Hands>();
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
            if (!isHapticsOn)
            {
                hands.devices.ForEach(c => c.SendHapticImpulse(0, strength, duration));
                isHapticsOn = true;
            }

            else
            {
                isHapticsOn = false;
            }

           
        }
    }
}
