using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Score;


namespace Score
{
    public class PointsUI : MonoBehaviour
    {
        [Header("Texts")]
        public Text scoreText;
        public Text comboMultiText;
        public Text missText;
        public Text highScoreText;

        [Header("Classes")]
        public PointsCounter pointCounter;

        private void Start()
        {
            pointCounter = FindObjectOfType<PointsCounter>();

            highScoreText.text = PlayerPrefs.GetInt("HighScore", pointCounter.highScore).ToString();
        }

        private void Update()
        {
            scoreText.text = pointCounter.Score.ToString();
            comboMultiText.text = pointCounter.ComboMultiplyer.ToString();
            missText.text = pointCounter.MissCounter.ToString();
           
        }
    }
}
