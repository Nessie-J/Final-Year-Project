using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Score;

public class MainMenu : MonoBehaviour
{
    public Text highScore;

    public PointsCounter pointCounter;

    private void Awake()
    {
        pointCounter = FindObjectOfType<PointsCounter>();
    }

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", pointCounter.highScore).ToString();
    }
}
