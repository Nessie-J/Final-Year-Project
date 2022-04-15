using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;

public class Collision : MonoBehaviour
{
    public string debugStatementTrigger;
    public string debugStatementCol;

    public PointsCounter pointCounter;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(debugStatementTrigger);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        //If collision with hands:

        //Smash - Add Points - Add to Combo - After x Amount of time - Destory

        // pointCounter.Score = +pointCounter.PointAmount;
        //  pointCounter.ComboMultiplyer++;

        Debug.Log(debugStatementCol);
    }
}

