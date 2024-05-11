using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoSettingsManager : MonoBehaviour
{
    //[SerializeField] TMP_Dropdown resolutionChoice;
    [SerializeField] Toggle fullscreenToggle;
    bool fullscreen;
    public void ConfirmChanges()
    {
        fullscreen = fullscreenToggle.enabled;
        Screen.fullScreen = fullscreen;
    }

    // Code for resolution if we ever do it 
    //void ChangeResolution(int value, bool screen)
    //{
    //    switch (value)
    //    {
    //        case 0:
    //            Screen.SetResolution(1920, 1080, screen);
    //            break;
    //        case 1:
    //            Screen.SetResolution(1280, 720, screen);
    //            break;
    //        case 2:
    //            Screen.SetResolution(1024, 576, screen);
    //            break;
    //    }
    //}

    /*void ChangeVScync(bool vsync)
    {
        if (vsync)
        {
            QualitySettings.vSyncCount = 1;
        }
        else if (!vsync)
        {
            QualitySettings.vSyncCount = 0;
        }
    }*/
}
