using UnityEngine;

namespace Score
{
    public class PointsCounter : MonoBehaviour
    {
        [Header("Final Score")]
        public float Score;

        [Header("Point Variables")]
        public int PointAmount;
        public int ComboMultiplyer;

        [Header("Miss Counter")]
        public int MissCounter;


        private void Start()
        {
            Score = 0;
            ComboMultiplyer = 0;
            MissCounter = 0;
        }

        public void addPoints()
        {
            if (ComboMultiplyer >= 1)
            {
                PointAmount *= ComboMultiplyer;
            }
            Score += PointAmount;

          
            Debug.Log("Adding" + Score);
        }

        public void addComboMutli()
        {
            ComboMultiplyer++;
        }

        public void resetComboMulti()
        {
            if (ComboMultiplyer >= 1)
            {
                ComboMultiplyer = 0;
            }
         
        }

        public void addMissCounter()
        {
            MissCounter++;
        }

        public void removeMissCounter()
        {
            if (MissCounter >= 1)
            {
                MissCounter--;
            }
            
        }
    }
}