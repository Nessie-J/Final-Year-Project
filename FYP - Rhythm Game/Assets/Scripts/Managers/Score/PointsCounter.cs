using UnityEngine;
using unlock;

namespace Score
{
    public class PointsCounter : MonoBehaviour
    {
        [Header("Final Score")]
        public int Score;

        [Header("Point Variables")]
        public int PointAmount;
        public int ComboMultiplyer;
        [SerializeField] public int highScore;

        [Header("Miss Counter")]
        public int MissCounter;

        [Header("Classes")]
        public PointsUI pointsUI;
        public Unlockables unlockables;


        private void Start()
        {
            Score = 0;
            ComboMultiplyer = 0;
            MissCounter = 0;

            PlayerPrefs.GetInt("HighScore", highScore);

            unlockables = FindObjectOfType<Unlockables>();

            
        }

        private void Update()
        {
            
            updateHighScore();
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

        public void updateHighScore()
        {
            if (Score > PlayerPrefs.GetInt("HighScore", highScore))
            {
                PlayerPrefs.SetInt("HighScore", Score);
                pointsUI.highScoreText.text = Score.ToString();
                highScore = Score;
            }
        }

        public void buttonTest()
        {
            Score += Random.Range(1, 9);
        }
    }
}