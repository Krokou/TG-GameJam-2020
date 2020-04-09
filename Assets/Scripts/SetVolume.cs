using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public Slider slider;
    public AudioMixer catMixer;

    public void SetLevel (float sliderValue)
    {
        catMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void Start ()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }
}
