using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class OptionsScript : MonoBehaviour {

    public AudioMixer mixer;
    public Slider volumeSlider;
    public Dropdown graphics;
    public float volume;

    private void Update()
    {
        volume = volumeSlider.value;

        
    }

    public void MasterVolume()
    {
        mixer.SetFloat("MasterVol", volume);
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
