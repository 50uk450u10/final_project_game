using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResumeButton : MonoBehaviour
{
    Button resume;
    private void OnEnable()
    {
        resume = GetComponent<Button>();
        resume.onClick.AddListener(ResumeGame);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        resume.onClick.RemoveAllListeners();
        Time.timeScale = 1;
    }

    void ResumeGame()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
    }

}
