using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using spawner;
using permObjects;

namespace settings {
    public class SetPositions : MonoBehaviour
    {
        [Header("Objects")]
        public DontDestory playerCam;
        public GameObject spawner;

        private void Awake()
        {
            playerCam = FindObjectOfType<DontDestory>();
        }

        

        private void Start()
        {

           if (playerCam != null)
            {
                spawner.transform.position = new Vector3(spawner.transform.position.x, playerCam.transform.position.y + 1, spawner.transform.position.z);
            }

           if (playerCam == null)
            {
                spawner.transform.position = new Vector3(spawner.transform.position.x, spawner.transform.position.y, spawner.transform.position.z);
            }
           


        }


    }
}
