using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour
{
    public GameObject shatterObject;

    public bool isShattered;

    public float explosionnMinForce = 5;
    public float explosionMaxForce = 100;
    public float explosionRadius = 10;
    public float fragScaleFactor = 1;


    void Start()
    {
        isShattered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shattering();

        }
    }

    void Shattering()
    {
       if (shatterObject != null)
        {
           var shatterObj = Instantiate(shatterObject) as GameObject;
            Vector3 oldPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

            foreach( Transform t in shatterObj.transform)
            {
                var rb = t.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(Random.Range(explosionnMinForce, explosionMaxForce), oldPos, explosionRadius);
                    
                }
            }

            Destroy(shatterObj, 5);
            Destroy(gameObject);

        }
    }
}
