using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FullScreenPref 
{
    public static bool fullScreenPref { get; private set; }

    public static bool CheckFullScreen()
    {
        if (PlayerPrefs.GetInt("fullScreen") == 1)
        {
            fullScreenPref = true;
            return fullScreenPref;
        }
        else if (PlayerPrefs.GetInt("fullScreen") == 0)
        {
            fullScreenPref = false;
            return fullScreenPref;
        }
        else
        {
            fullScreenPref = false;
            return fullScreenPref;
        }
    }

}
