using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDisplay : MonoBehaviour
{
    private void OnEnable()
    {
        if (Screen.height != 1280 || Screen.width != 720)
        {
            Screen.SetResolution(1280, 720, FullScreenPref.fullScreenPref);
        }
    }
}
