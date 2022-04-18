using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Score;

namespace UI
{
    public class PointsUI : MonoBehaviour
    {
        public Text scoreText;
        public Text comboMultiText;
        public Text missText;

        public PointsCounter pointCounter;

        private void Start()
        {
            pointCounter = FindObjectOfType<PointsCounter>();
        }

        private void Update()
        {
            scoreText.text = pointCounter.Score.ToString();
            comboMultiText.text = pointCounter.ComboMultiplyer.ToString();
            missText.text = pointCounter.MissCounter.ToString();
        }
    }
}
