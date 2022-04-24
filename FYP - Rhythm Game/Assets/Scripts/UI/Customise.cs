using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using controller;

namespace customise
{
    public class Customise : MonoBehaviour
    {
        [SerializeField] private Material newMaterial;
        public LayerMask handsLayer;

        public SkinManager[] hands;

        void Awake()
        {
            hands = FindObjectsOfType<SkinManager>();
        }

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            if ((handsLayer.value & (1 << collision.gameObject.layer)) > 0)
            {
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

        private void SetItem()
        {

        }
    }
}
