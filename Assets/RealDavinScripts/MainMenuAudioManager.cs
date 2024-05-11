using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAudioManager : MonoBehaviour
{
    AudioSource music;
    private void OnEnable()
    {
        music = GetComponent<AudioSource>();
        music.volume = AudioVolume.mainVolume * AudioVolume.musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = AudioVolume.mainVolume * AudioVolume.musicVolume;
    }
}
