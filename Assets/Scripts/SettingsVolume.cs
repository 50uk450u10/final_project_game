using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsVolume : MonoBehaviour
{
    [SerializeField] Slider mainVolumeSlider;
    [SerializeField] Slider effectsVolumeSlider;
    [SerializeField] Slider musicVolumeSlider;
    private void OnEnable()
    {
        effectsVolumeSlider.value = AudioVolume.effectsVolume;
        musicVolumeSlider.value = AudioVolume.musicVolume;
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            mainVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        }
        else
        {
            mainVolumeSlider.value = 1;
        }
        if (PlayerPrefs.HasKey("EffectsVolume"))
        {
            effectsVolumeSlider.value = PlayerPrefs.GetFloat("EffectsVolume");
        }
        else
        {
            effectsVolumeSlider.value = 1;
        }
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            musicVolumeSlider.value = 1;
        }
    }

    private void OnDisable()
    {
        AudioVolume.mainVolume = mainVolumeSlider.value;
        AudioVolume.effectsVolume = effectsVolumeSlider.value;
        AudioVolume.musicVolume = musicVolumeSlider.value;
        PlayerPrefs.SetFloat("MasterVolume", mainVolumeSlider.value);
        PlayerPrefs.SetFloat("EffectsVolume", effectsVolumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
    }
    private void Update()
    {
        AudioVolume.mainVolume = mainVolumeSlider.value;
        AudioVolume.effectsVolume = effectsVolumeSlider.value;
        AudioVolume.musicVolume = musicVolumeSlider.value;
    }
}
