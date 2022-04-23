using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public static test instance;
    private void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        
       
    }
}
