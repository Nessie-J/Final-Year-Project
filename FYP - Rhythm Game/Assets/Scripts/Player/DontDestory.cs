using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace permObjects {
    public class DontDestory : MonoBehaviour
    {
        public static DontDestory player;

        private void Start()
        {
            if (player != null)
            {
                Destroy(this.gameObject);
                return;
            }

            player = this;
            DontDestroyOnLoad(this.gameObject);

            

        }
    }
}
