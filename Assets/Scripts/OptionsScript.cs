using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class OptionsScript : MonoBehaviour {

    public AudioMixer masterMixer;
    public AudioMixerGroup effectsMixer;
    public AudioMixerGroup musicMixer;

    public Dropdown graphics;

    public Slider volumeSlider;
    [Range(-50, 0)]
    public float masterVolume;
    public Slider effectsVolumeSlider;
    [Range(-50, 0)]
    public float effectsVolume;
    public Slider musicVolumeSlider;
    [Range(-50, 0)]
    public float musicVolume;


    private void Start()
    {
        volumeSlider.maxValue = 0;
        volumeSlider.minValue = -50;

        effectsVolumeSlider.maxValue = 0;
        effectsVolumeSlider.minValue = -50;

        musicVolumeSlider.maxValue = 0;
        musicVolumeSlider.minValue = -50;
    }

    private void Update()
    {
        masterVolume = volumeSlider.value;
        effectsVolume = effectsVolumeSlider.value;
        musicVolume = musicVolumeSlider.value;
    }

    public void MasterVolume()
    {
        masterMixer.SetFloat("MasterVol", masterVolume);
    }

    public void EffectsVolume()
    {
        effectsMixer.audioMixer.SetFloat("EffectsVol", effectsVolume);
    }

    public void MusicVolume()
    {
        musicMixer.audioMixer.SetFloat("MusicVol", musicVolume);
    }

    public void ChangeValue()
    {
        switch (graphics.value)
        {
            case 0:
                QualitySettings.SetQualityLevel(0);
                break;
            case 1:
                QualitySettings.SetQualityLevel(2);
                break;
            case 2:
                QualitySettings.SetQualityLevel(4);
                break;

            default:
                break;
        }

        Debug.Log(QualitySettings.GetQualityLevel());
    }


}
