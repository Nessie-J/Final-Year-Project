using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockables : MonoBehaviour
{
    public int winCounter;
    public int destoryedObjectsCounter;
    public int dodgeObjectCounter;

    [SerializeField] private int winsUnlockAmount;
    [SerializeField] private int destoryObjectUnlockAmount;
    [SerializeField] private int dodgeObjectUnlockAmount;

    [SerializeField] private GameObject winLockBox;
    [SerializeField] private GameObject destoryObjectLockBox;
    [SerializeField] private GameObject dodgeObjectLockBox;

    // Start is called before the first frame update
    void Start()
    {
        UnlockWin();
        UnlockDestory();
        UnlockDodge();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockWin()
    {
        if (winCounter >= winsUnlockAmount)
        {
            Destroy(winLockBox);
        }
    }

    public void UnlockDestory()
    {
        if (destoryedObjectsCounter >= destoryObjectUnlockAmount)
        {
            Destroy(destoryObjectLockBox);
        }
    }

    public void UnlockDodge()
    {
        if (dodgeObjectCounter >= dodgeObjectUnlockAmount )
        {
            Destroy(dodgeObjectLockBox);
        }
    }
}
