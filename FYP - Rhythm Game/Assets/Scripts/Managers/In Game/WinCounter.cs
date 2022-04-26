using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unlock {
    public class WinCounter : MonoBehaviour
    {
        [Header("Classes")]
        [SerializeField] private Unlockables unlockables;

        private void Awake()
        {
            unlockables = FindObjectOfType<Unlockables>();

        }
        void Start()
        {
            if (PlayerPrefs.GetInt("winUnlock", unlockables.amountWinsLeft) > 0)
            {
                unlockables.amountWinsLeft--;
                PlayerPrefs.SetInt("winUnlock", unlockables.amountWinsLeft);
            }
               
        }
    }
}
