using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using spawner;
using permObjects;

public class SetPositions : MonoBehaviour
{
    public DontDestory playerCam;
    public GameObject spawner;

    private void Awake()
    {
        playerCam = FindObjectOfType<DontDestory>();
    }

    private void Start()
    {
        spawner.transform.position = new Vector3(spawner.transform.position.x, playerCam.transform.position.y + 1, spawner.transform.position.z);

        
    }
}
