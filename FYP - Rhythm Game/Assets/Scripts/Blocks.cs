using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpawnedObjects {
    public class Blocks : MonoBehaviour
    {

        public float moveSpeed = 2;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position += Time.deltaTime * transform.forward * moveSpeed;
        }
    }
}
