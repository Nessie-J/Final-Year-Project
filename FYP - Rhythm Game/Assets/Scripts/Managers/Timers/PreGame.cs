using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Timers {
    public class PreGame : MonoBehaviour
    {
        [Header("Timer")]
        public float countDownTime;

        [Header("Game Start")]
        public bool isGameStart = false;

        [Header("Audio")]
        public AudioSource musicAudioSource;
        public AudioSource countDownAudioSource;

        [Header("UI")]
        public Text countDownText;



        public void Awake()
        {

            countDownText.text = countDownTime.ToString();
            countDownText.gameObject.SetActive(true);

            isGameStart = false;


        }
        void Start()
        {
            StartCoroutine(countDown());
            countDownAudioSource.Play();
        }


        IEnumerator countDown()
        {
            while (countDownTime > -1)
            {
                countDownText.text = countDownTime.ToString();

                yield return new WaitForSeconds(1);

                countDownTime--;
                countDownAudioSource.Play();
                
            }

            yield return new WaitForSeconds(countDownTime + 0.5f);
            musicAudioSource.Play();
            countDownText.gameObject.SetActive(false);
            isGameStart = true;


        }
    }
}
