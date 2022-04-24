using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace unlock {
    public class UnlocksUI : MonoBehaviour
    {
        [Header("Classes")]
        [SerializeField] private Unlockables unlockables;

        [Header("Counting Text")]
        public Text winUnlockText;
        public Text destructablesText;
        public Text obsticlesText;

        [Header("Locked Text")]
        public GameObject lockedText1;
        public GameObject lockedText2;
        public GameObject lockedText3;

        [Header("Lock Boxes")]
        [SerializeField] private GameObject winLockBox;
        [SerializeField] private GameObject destoryObjectLockBox;
        [SerializeField] private GameObject dodgeObjectLockBox;


        private void Start()
        {
            unlockables = FindObjectOfType<Unlockables>();

            

        }

        private void Update()
        {
            UnlockWin();
            UnlockDestory();
            UnlockDodge();
        }


        public void UnlockWin()
        {
            winUnlockText.text = PlayerPrefs.GetInt("winUnlock", unlockables.amountWinsLeft).ToString();

            if (unlockables.amountWinsLeft <= 0)
            {
                Destroy(winLockBox);
                Destroy(lockedText1);
            }
        }

        public void UnlockDestory()
        {
            destructablesText.text = PlayerPrefs.GetInt("destoryUnlock", unlockables.destoryedObjectsLeft).ToString();

            if (unlockables.destoryedObjectsLeft <= 0)
            {
                Destroy(destoryObjectLockBox);
                Destroy(lockedText2);
            }
        }

        public void UnlockDodge()
        {
            obsticlesText.text = PlayerPrefs.GetInt("dodgeUnlock", unlockables.dodgedObjectsLeft).ToString();

            if (unlockables.dodgedObjectsLeft <= 0)
            {
                Destroy(dodgeObjectLockBox);
                Destroy(lockedText3);
            }
        }
    }
}
