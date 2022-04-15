using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;

public class Destructables : Obstacles
{

    protected override void OnTriggerEnter(Collider other)
    {
        if ((wallLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            
            pointCounter.Score += currentPointValue;
            Debug.Log(currentPointValue + " hitting wall");

        }

        //If minus point wall is hit - current pointvalie MINUS.

        //If Miss wall is hit - Missed();

        else
        {
            return;
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if ((playerLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            Debug.Log("Player Punch");
            currentPointValue += pointIncreaseValue;
            //Smash - Add Points - Add to Combo - After x Amount of time - Destory
            // pointCounter.Score = +pointCounter.PointAmount;
        }

        else
        {
            return;
        }
    }

    protected override void Missed()
    {
        //current points = 0. Destory Object.
    }

}
