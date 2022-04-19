using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [Header("Sliders to Manager AudioMixer")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private AudioMixer sfxMixer;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("mVol"))
        {
            PlayerPrefs.SetInt("mVol", 1);
            sfxSlider.value = 1;
        }

        if (!PlayerPrefs.HasKey("sfxVol"))
        {
            PlayerPrefs.SetFloat("sfxVol", 1);
            sfxSlider.value = 1;
        }

        float currentSFX = PlayerPrefs.GetFloat("sfxVol");
        float currentMusic = PlayerPrefs.GetFloat("mVol");

        musicSlider.value = currentMusic;
        sfxSlider.value = currentSFX;
    }

    private void Update()
    {
        //This version of Unity has a possible bug on slider single value so as work around sliders are checked on update
        SetSFXLevel(sfxSlider.value);
        SetMusicLevel(musicSlider.value);
    }


    public void SetSFXLevel(float sfxLvl)
    {

        sfxMixer.SetFloat("Volume", sfxLvl); // change to correct names from  audio mixer 
        PlayerPrefs.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMusicLevel(float musicLvl)
    {

        musicMixer.SetFloat("Volume", musicLvl);  // change to correct names from  audio mixer 
        PlayerPrefs.SetFloat("mVol", musicLvl);
    }
}
