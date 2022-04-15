using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;

public class Obstacles : MonoBehaviour
{
    [Header("Layer Masks")]
    public LayerMask playerLayer;
    public LayerMask wallLayer;

    [Header("Variables")]
    public float movementSpeed = 5;
    public float destoryTimer = 200;

    [Header("Score")]
    public PointsCounter pointCounter;
    public int baseScoreValue;
    public int pointIncreaseValue = 50;
    public int currentPointValue;

    [Header("Componets")]
    public Rigidbody rigiBod;




    protected virtual void Start()
    {
        currentPointValue = baseScoreValue;
        pointCounter = FindObjectOfType<PointsCounter>();
        rigiBod = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigiBod.AddForce(Time.deltaTime * transform.forward * movementSpeed);
    }

   protected virtual void OnTriggerEnter(Collider other)
    {

        if ((wallLayer.value & (1 << other.gameObject.layer)) > 0)
        {
           
            Debug.Log(currentPointValue + "hitting wall");
            

        }
        // If miss wall is hit 

        if ((playerLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            Debug.Log("Hitting Player");
        }

        else
        {
            currentPointValue = baseScoreValue;
            return;
        }

    }

    protected virtual void Missed()
    {
      //  currentpoint value add to score
    }


    protected virtual IEnumerator Destory()
    {
        yield return new WaitForSeconds(destoryTimer);
        Destory();
    }

 


}
