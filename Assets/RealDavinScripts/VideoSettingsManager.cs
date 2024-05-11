using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoSettingsManager : MonoBehaviour
{
    //[SerializeField] TMP_Dropdown resolutionChoice;
    [SerializeField] Toggle fullscreenToggle;
    public void Switch()
    {
        if (fullscreenToggle.isOn)
        {
            PlayerPrefs.SetInt("fullScreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("fullScreen", 0);
        }
        Screen.SetResolution(1920, 1080, FullScreenPref.CheckFullScreen());
    }
}
