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

            if (PlayerPrefs.GetInt("winUnlock", unlockables.amountWinsLeft) >= 0)
            {
                winUnlockText.text = PlayerPrefs.GetInt("winUnlock", unlockables.amountWinsLeft).ToString();
            }

            else if (PlayerPrefs.GetInt("winUnlock", unlockables.amountWinsLeft) < 0)
            {
                winUnlockText.text = 0.ToString();
            }
           

            if (PlayerPrefs.GetInt("winUnlock", unlockables.amountWinsLeft) <= 0)
            {
                Destroy(winLockBox);
                Destroy(lockedText1);
            }
        }

        public void UnlockDestory()
        {

            if (PlayerPrefs.GetInt("destoryUnlock", unlockables.destoryedObjectsLeft) >= 0)
            {
                destructablesText.text = PlayerPrefs.GetInt("destoryUnlock", unlockables.destoryedObjectsLeft).ToString();
            }

           else if (PlayerPrefs.GetInt("destoryUnlock", unlockables.destoryedObjectsLeft) < 0)
            {
                destructablesText.text = 0.ToString();
            }


            if (PlayerPrefs.GetInt("destoryUnlock", unlockables.destoryedObjectsLeft) <= 0)
            {
                Destroy(destoryObjectLockBox);
                Destroy(lockedText2);
            }
        }

        public void UnlockDodge()
        {

            if (PlayerPrefs.GetInt("dodgeUnlock", unlockables.dodgedObjectsLeft) >= 0)
            {
                obsticlesText.text = PlayerPrefs.GetInt("dodgeUnlock", unlockables.dodgedObjectsLeft).ToString();
            }

            else if (PlayerPrefs.GetInt("dodgeUnlock", unlockables.dodgedObjectsLeft) < 0)
            {
                obsticlesText.text = 0.ToString();
            }
           

            if (PlayerPrefs.GetInt("dodgeUnlock", unlockables.dodgedObjectsLeft) <= 0)
            {
                Destroy(dodgeObjectLockBox);
                Destroy(lockedText3);
            }
        }
    }
}
