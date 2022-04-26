using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using controller;

namespace customise
{
    public class Customise : MonoBehaviour
    {
        [Header("Material")]
        [SerializeField] private Material newMaterial;

        [Header("Layer Mask")]
        public LayerMask handsLayer;

        [Header("Hands")]
        public SkinManager[] hands;

        void Awake()
        {
            hands = null;
        }

        private void Start()
        {
            
        }

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if ((handsLayer.value & (1 << collision.gameObject.layer)) > 0)
            {
                hands = FindObjectsOfType<SkinManager>();

                for (int i = 0; i < hands.Length; i++)
                {
                    hands[i].GetComponent<MeshRenderer>().material = newMaterial;
                }
            }

            else
            {
                return;
            }
               

        }
    }
}
