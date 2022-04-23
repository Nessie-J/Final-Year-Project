using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsCustom : MonoBehaviour
{
    
    [SerializeField] private Material currentMat;

    void Start()
    {
        int currentID = PlayerPrefs.GetInt("newMaterial");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
