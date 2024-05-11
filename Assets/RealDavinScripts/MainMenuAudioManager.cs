using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuAudioManager : MonoBehaviour
{
    AudioSource music;
    private void OnEnable()
    {
        music = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            AudioVolume.mainVolume = PlayerPrefs.GetFloat("MasterVolume");
        }
        else
        {
            AudioVolume.mainVolume = 1;
        }
        if (PlayerPrefs.HasKey("EffectsVolume"))
        {
            AudioVolume.effectsVolume = PlayerPrefs.GetFloat("EffectsVolume");
        }
        else
        {
            AudioVolume.effectsVolume = 1;
        }
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            AudioVolume.musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            AudioVolume.musicVolume = 1;
        }
        music.volume = AudioVolume.mainVolume * AudioVolume.musicVolume;
    }

    private void Update()
    {
        if (SceneManager.GetSceneByName("Settings Overlay").isLoaded)
        {
            music.volume = AudioVolume.mainVolume * AudioVolume.musicVolume;
        }
    }
}
