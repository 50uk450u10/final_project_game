using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameAudioManager : MonoBehaviour
{
    AudioSource music;
    private void OnEnable()
    {
        music = GetComponent<AudioSource>();
        music.volume = AudioVolume.mainVolume * AudioVolume.musicVolume;
        VFX[] VFXsounds = FindObjectsOfType<VFX>();
        foreach (VFX sound in VFXsounds)
        {
            sound.GetComponent<AudioSource>().volume = AudioVolume.mainVolume * AudioVolume.effectsVolume;
        }
    }

    private void Update()
    {
        if (SceneManager.GetSceneByName("Settings Overlay").isLoaded)
        {
            music.volume = AudioVolume.mainVolume * AudioVolume.musicVolume;
            VFX[] VFXsounds = FindObjectsOfType<VFX>();
            foreach (VFX sound in VFXsounds)
            {
                sound.GetComponent<AudioSource>().volume = AudioVolume.mainVolume * AudioVolume.effectsVolume;
            }
        }
    }

}
