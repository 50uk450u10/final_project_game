using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDisplay : MonoBehaviour
{
    private void OnEnable()
    {
        if (Screen.height != 1920 || Screen.width != 10800)
        {
            Screen.SetResolution(1920, 1080, FullScreenPref.fullScreenPref);
        }
    }
}
