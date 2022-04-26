using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;
using UnityEngine.UI;
namespace UI {

    public class HighScore_Main_Menu : MonoBehaviour
    {
        [Header("UI")]
        public Text highScore;

        [Header("Counter")]
        public PointsCounter pointCounter;

        private void Awake()
        {
            pointCounter = GetComponent<PointsCounter>();
        }

        private void Start()
        {
            highScore.text = PlayerPrefs.GetInt("HighScore", pointCounter.highScore).ToString();
        }
    }
}
