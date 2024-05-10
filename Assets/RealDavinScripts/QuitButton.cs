using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
   public void Quit()
   {
        Application.Quit();
        //Remove before launch
        UnityEditor.EditorApplication.isPlaying = false;
   }
}
