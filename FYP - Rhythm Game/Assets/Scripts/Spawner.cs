using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Objects")]
    public GameObject[] blocks;
    public GameObject[] obsticals;

    [Header("Spawn Points")]
    public Transform[] blockSpawnPoint;
    public Transform obsticalSpawnPoint;

    [Header("Beat")]
    public float beat;
    

    [Header("Timers")]
    public float beatTimer;
    public float objectDestoryTimer = 200;

    private void Start()
    {

    }

    private void Update()
    {
        SpawnBlock();

        //SpawnObstical();

        beatTimer += Time.deltaTime;
        
    }

    public void SpawnBlock()
    {
        if (beatTimer > beat)
        {
            //Spawn
            GameObject block = Instantiate(blocks[Random.Range(0, 2)], blockSpawnPoint[Random.Range(0, 2)]);

            //Movement & Rotation
            block.transform.localPosition = Vector3.zero;

            block.transform.Rotate(transform.forward * -1, 90 * Random.Range(0, 4));

            //Destory after lenth of time
            Destroy(block, objectDestoryTimer);

            beatTimer -= beat;

        }
    }

    public void SpawnObstical()
    {
        if (beatTimer > beat)
        {
            //Spawm
            GameObject obsitical = Instantiate(obsticals[Random.Range(0, 2)], obsticalSpawnPoint);

            //Movement
            obsitical.transform.localPosition = Vector3.zero;
            

            //Timer Reset
            beatTimer -= beat;
        }
    }

   

}


