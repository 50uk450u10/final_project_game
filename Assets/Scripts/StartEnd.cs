using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEnd : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;//allow game to run
    }

    public void OnLose()
    {
        SceneManager.LoadScene(1);//reload the game
    }
}
