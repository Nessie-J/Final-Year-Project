using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unlock;

public class WINTEST : MonoBehaviour
{
    [SerializeField] private Unlockables unlockables;

    private void Awake()
    {
        unlockables = FindObjectOfType<Unlockables>();

    }
    void Start()
    {
        unlockables.amountWinsLeft--;
        PlayerPrefs.SetInt("winUnlock", unlockables.amountWinsLeft);
    }

    
}
