using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FullScreenPref 
{
    public static bool fullScreenPref { get; private set; }

    public static void CheckFullScreen()
    {
        if (PlayerPrefs.GetInt("fullScreen") == 1)
        {
            fullScreenPref = true;
        }
        else if (PlayerPrefs.GetInt("fullScreen") == 0)
        {
            fullScreenPref = false;
        }
        else
        {
            fullScreenPref = false;
        }
    }

}
