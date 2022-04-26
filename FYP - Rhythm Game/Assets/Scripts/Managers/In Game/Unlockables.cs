using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace unlock {
    public class Unlockables : MonoBehaviour
    {
        [Header("Classes")]
        public static Unlockables instance;

        [Header("Counters")]
        [SerializeField] public int amountWinsLeft = 2;
        [SerializeField] public int destoryedObjectsLeft = 50;
        [SerializeField] public int dodgedObjectsLeft = 50;

       

        // Start is called before the first frame update
        void Start()
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }


        void Update()
        {
            PlayerPrefs.GetInt("winUnlock", amountWinsLeft);
            PlayerPrefs.GetInt("destoryUnlock", destoryedObjectsLeft);
            PlayerPrefs.GetInt("dodgeUnlock", dodgedObjectsLeft);
          
        }

        
    }
}
